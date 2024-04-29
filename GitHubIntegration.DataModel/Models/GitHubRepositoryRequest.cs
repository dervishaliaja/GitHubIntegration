namespace GitHubIntegration.DataModel.Models
{
    public class GitHubRepositoryRequest
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public string Query { get; set; }
    }
}
