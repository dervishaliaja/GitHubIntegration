using System.Collections.Generic;

namespace GitHubIntegration.DataModel.Models
{
    public class GitHubRepositoryResponse : List<GitHubRepositoryItem>
    {
    }

    public class GitHubRepositoryItem
    {
        public string RepositoryName { get; set; }
        public string OwnerLogin { get; set; }
        public string RepositoryUrl { get; set; }
    }
}
