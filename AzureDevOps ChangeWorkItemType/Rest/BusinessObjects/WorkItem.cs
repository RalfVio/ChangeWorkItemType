using System;
using System.Collections.Generic;
using System.Text;

namespace AzureDevOps_ChangeWorkItemType.Rest.BusinessObjects
{
    public class WorkItem
    {
        public int Id { get; set; }
        public int Rev { get; set; }
        public string WorkItemType { get; set; }
        public string Title { get; set; }
        public string State { get; set; }
        public string Reason { get; set; }
        public List<Link> Links { get; set; }
        public string GetFullName() { return string.Format("{1} {0}: {2}", Id, WorkItemType, Title); }
    }

    public class Link
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rel { get; set; }
        public string Comment { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? CreatedDateLocal { get { return CreatedDate.HasValue ? CreatedDate.Value.ToLocalTime() : (DateTime?)null; } }
        public bool IsCommitLink() { return Rel == "ArtifactLink" && Name.Contains("Commit"); }
    }
}
