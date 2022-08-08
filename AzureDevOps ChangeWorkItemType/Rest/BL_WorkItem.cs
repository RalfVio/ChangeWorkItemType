using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;


namespace AzureDevOps_ChangeWorkItemType.Rest
{
    public class BL_WorkItem : BLBase, IDisposable
    {
        public BL_WorkItem(BusinessObjects.ConnectionData connectionData)
            : base(connectionData)
        {
        }

        public void Dispose()
        {
            if (_httpClient != null)
                _httpClient.Dispose();
        }

        public class WorkItem : BusinessObjects.WorkItem
        {
            public string Description { get; set; }
        }



        /// <summary>
        /// Read a Work Item
        /// </summary>
        /// <param name="id">Id of the work item</param>
        /// <param name="withLinks"></param>
        /// <returns></returns>
        public async Task<WorkItem> GetWorkItem(int id)
        {
            //https://docs.microsoft.com/en-us/rest/api/azure/devops/wit/work-items/get-work-item?view=azure-devops-rest-7.1&tabs=HTTP
            //GET https://dev.azure.com/{organization}/{project}/_apis/wit/workitems/{id}?api-version=7.1-preview.3
            string restUri = $"{_collectionUrl}/_apis/wit/workitems/{id}?api-version=7.1-preview.3";

            WorkItem result = null;

            try
            {
                if (_httpClient == null)
                    _httpClient = GetClient();

                using HttpResponseMessage response = await _httpClient.GetAsync(
                            restUri);
                response.EnsureSuccessStatusCode();

                string responseString = await response.Content.ReadAsStringAsync();

                dynamic resultJObject = JObject.Parse(responseString);
                dynamic fieldsJObject = resultJObject.fields;
                dynamic relationsJObject = resultJObject.relations;

                result = new WorkItem()
                {
                    Id = resultJObject.id,
                    Rev = resultJObject.rev,
                    Title = fieldsJObject["System.Title"],
                    State = fieldsJObject["System.State"],
                    Reason = fieldsJObject["System.Reason"],
                    WorkItemType = fieldsJObject["System.WorkItemType"],
                    Description = fieldsJObject["System.Description"] ?? "",
                };
            }
            catch { throw; }

            return result;
        }

        public async Task<List<WorkItem>> GetWorkItems(List<int> workItemIds)
        {
            //https://docs.microsoft.com/en-us/rest/api/vsts/wit/wiql/query%20by%20wiql
            //https://www.visualstudio.com/en-us/docs/integrate/api/wit/wiql

            string restUri = $"{_collectionUrl}/_apis/wit/WorkItems?ids={SqlIds(workItemIds)}&fields=System.Id,System.Title,System.State,System.Reason,System.WorkItemType&api-version=1.0";

            List<WorkItem> result = null;
            try
            {
                if (_httpClient == null)
                    _httpClient = GetClient();

                using (HttpResponseMessage response = await _httpClient.GetAsync(
                            restUri))
                {
                    response.EnsureSuccessStatusCode();

                    string responseString = await response.Content.ReadAsStringAsync();

                    dynamic resultJObject = JObject.Parse(responseString);
                    dynamic dataItemsJObject = resultJObject.value;
                    int dataItemsCount = resultJObject.count;
                    result = new List<WorkItem>();

                    for (int i = 0; i < dataItemsCount; i++)
                    {
                        result.Add(new WorkItem()
                        {
                            Id = dataItemsJObject[i].id,
                            Rev = dataItemsJObject[i].rev,
                            State = dataItemsJObject[i].fields["System.State"],
                            Reason = dataItemsJObject[i].fields["System.Reason"],
                            Title = dataItemsJObject[i].fields["System.Title"],
                            WorkItemType = dataItemsJObject[i].fields["System.WorkItemType"],
                        });

                    }
                }
            }
            catch
            {
                //MessageBox.Show(ex.ToString());
                throw;
            }

            return result;
        }



        /// Updates Fields or Links of a Work Item
        /// </summary>
        /// <param name="workItem">Work Item</param>
        /// <param name="updateJson">Json Update String</param>
        /// <returns></returns>
        public async Task<bool> UpdateWorkItem(WorkItem workItem, string updateJson)
        {
            //https://docs.microsoft.com/en-us/rest/api/azure/devops/wit/work-items/update?view=azure-devops-rest-7.1&tabs=HTTP
            //PATCH https://dev.azure.com/{organization}/{project}/_apis/wit/workitems/{id}?validateOnly={validateOnly}&bypassRules={bypassRules}&suppressNotifications={suppressNotifications}&$expand={$expand}&api-version=7.1-preview.3

            string restUri = $"{_collectionUrl}/{_teamProject}/_apis/wit/workitems/{workItem.Id}?bypassRules=true&api-version=7.1-preview.3";  //
            string restContent = $"[{{\r\n\"op\": \"test\",\r\n\"path\": \"/rev\",\r\n\"value\": {workItem.Rev}\r\n}}\r\n,{updateJson}\r\n]";
            bool result = false;
            try
            {
                if (_httpClient == null)
                    _httpClient = GetClient();

                using HttpResponseMessage response = await _httpClient.PatchAsync(
                            restUri, new StringContent(restContent, System.Text.Encoding.UTF8, "application/json-patch+json"));
                response.EnsureSuccessStatusCode();
                result = true;
            }
            catch { throw; }

            return result;
        }
        /// Add Comment to a Work Item
        /// </summary>
        /// <param name="workItem">Work Item</param>
        /// <param name="newComment">Comment</param>
        /// <returns></returns>
        public async Task<bool> WorkItemAddComment(WorkItem workItem, string newComment)
        {
            //https://docs.microsoft.com/en-us/rest/api/azure/devops/wit/comments/add?view=azure-devops-rest-7.1&tabs=HTTP
            //POST https://dev.azure.com/fabrikam/Fabrikam-Fiber-Git/_apis/wit/workItems/299/comments?api-version=7.1-preview.3

            string restUri = $"{_collectionUrl}/{_teamProject}/_apis/wit/workitems/{workItem.Id}/comments?api-version=7.1-preview.3";
            string newCommentJson = newComment.Replace("\\", "\\\\").Replace("\"", "\\\"");

            string restContent = $"{{\r\n  \"text\": \"{newCommentJson}\"\r\n}}";
            bool result = false;
            try
            {
                if (_httpClient == null)
                    _httpClient = GetClient();

                using HttpResponseMessage response = await _httpClient.PostAsync(
                            restUri, new StringContent(restContent, System.Text.Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                result = true;
            }
            catch { throw; }

            return result;
        }

        public async Task<List<int>> GetFlatQueryResult(string wiqlWhere)
        {
            if (_httpClient == null)
                _httpClient = GetClient();

            string wiql = $"SELECT [System.Id] FROM workitems WHERE [System.TeamProject] = '{_teamProject}' AND {wiqlWhere}";
            return await GetFlatQueryResult(wiql, _httpClient);
        }
    }
}
