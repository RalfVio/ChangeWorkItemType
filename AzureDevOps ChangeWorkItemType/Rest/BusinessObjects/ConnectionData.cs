using System;
using System.Collections.Generic;
using System.Text;

namespace AzureDevOps_ChangeWorkItemType.Rest.BusinessObjects
{
    public class ConnectionData
    {
        public string CollectionUrl { get; set; } 
        public string TeamProject { get; set; } 
        public string PersonalAccessToken { get; set; }

        public bool IsValid()
        {
            return !(string.IsNullOrEmpty(CollectionUrl)
                || string.IsNullOrEmpty(TeamProject)
                || string.IsNullOrEmpty(PersonalAccessToken));
        }

    }
}
