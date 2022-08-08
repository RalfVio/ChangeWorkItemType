using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace AzureDevOps_ChangeWorkItemType.Rest
{
    public abstract class BLBase
    {
        protected string _collectionUrl = null;
        protected string _teamProject = null;
        protected string _personalAccessToken = null;

        protected HttpClient _httpClient = null;


        public BLBase(string collectionUrl, string teamProject, string personalAccessToken)
        {
            _collectionUrl = collectionUrl; _teamProject = teamProject; _personalAccessToken = personalAccessToken;
        }
        public BLBase(BusinessObjects.ConnectionData connectionData)
        {
            _collectionUrl = connectionData.CollectionUrl; _teamProject = connectionData.TeamProject; _personalAccessToken = connectionData.PersonalAccessToken;
        }


        protected string Credentials() { return Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "", _personalAccessToken))); }

        protected HttpClient GetClient()
        {
            HttpClient result = new HttpClient
            {
                Timeout = new TimeSpan(0, 1, 0)
            };

            result.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            result.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Credentials());
            return result;
        }
        #region Helper functions
        public static string GetUpdateJson(string newValue, string currentValue, string fieldName, string updateJson)
        {
            string newValueJson = string.IsNullOrEmpty(newValue) ? "" : newValue.Replace("\\", "\\\\").Replace("\"", "\\\"");

            if (!string.IsNullOrEmpty(newValue) && string.IsNullOrEmpty(currentValue))
                return (string.IsNullOrEmpty(updateJson) ? "" : updateJson + ",")
                  + "{\"op\":\"add\",\"path\":\"/fields/" + fieldName + "\",\"value\":\"" + newValueJson + "\"}";

            if (!string.IsNullOrEmpty(newValue) && !string.IsNullOrEmpty(currentValue) && newValue != currentValue)
                return (string.IsNullOrEmpty(updateJson) ? "" : updateJson + ",")
                  + "{\"op\":\"replace\",\"path\":\"/fields/" + fieldName + "\",\"value\":\"" + newValueJson + "\"}";

            if (string.IsNullOrEmpty(newValue) && !string.IsNullOrEmpty(currentValue))
                return (string.IsNullOrEmpty(updateJson) ? "" : updateJson + ",")
                  + "{\"op\":\"remove\",\"path\":\"/fields/" + fieldName + "\"}";

            return updateJson;
        }
        protected async Task<List<int>> GetFlatQueryResult(string wiql, HttpClient httpClient)
        {
            //https://www.visualstudio.com/en-us/docs/integrate/api/wit/wiql
            //https://stackoverflow.com/questions/11145053/cant-find-how-to-use-httpcontent

            const string restUriFormat = "{0}/{1}/_apis/wit/wiql?api-version=1.0";

            string restUri = string.Format(restUriFormat, _collectionUrl, _teamProject);
            string restContent = string.Format("{{\r\n\"query\":\"{0}\"\r\n}}", wiql);

            List<int> result = null;
            try
            {
                using (HttpResponseMessage response = await httpClient.PostAsync(
                            restUri, new StringContent(restContent, System.Text.Encoding.UTF8, "application/json")))  //(JsonConvert.SerializeObject(model)
                {
                    response.EnsureSuccessStatusCode();

                    string responseString = await response.Content.ReadAsStringAsync();
                    dynamic resultJObject = JObject.Parse(responseString);
                    dynamic dataItemsJObject = resultJObject.workItems;
                    int count = dataItemsJObject.Count;
                    result = new List<int>();
                    for (int i = 0; i < count; i++)
                    {
                        int wiId = dataItemsJObject[i].id;
                        result.Add(wiId);
                    }
                    //result.Add(dataItemsJObject[0].id);
                    //result = JsonConvert.DeserializeObject<WorkItemsRootobject>(responseString);
                }
            }

            catch
            {
                //MessageBox.Show(ex.ToString());
                throw;
            }

            return result;
        }

        public static List<List<int>> SplitIdsIntoBatches(List<int> ids)
        {
            List<List<int>> result = new List<List<int>>();

            List<int> idsBatch = new List<int>();
            foreach (int id in ids)
            {
                idsBatch.Add(id);
                if (idsBatch.Count >= 25)
                {
                    result.Add(idsBatch);
                    idsBatch = new List<int>();
                }
            }
            if (idsBatch.Count > 0)
                result.Add(idsBatch);

            return result;
        }
        protected static string SqlIds(List<int> ids)
        {
            string result = null;
            foreach (int id in ids)
                result = (result == null ? "" : result + ",") + id.ToString();
            return result;
        }
        #endregion
    }
}