using System.Threading.Tasks;
using GitHubIntegration.DataModel.Models;

namespace GitHubIntegration.BusinessLogic.Services
{
    public interface IGitHubClient
    {
        Task<Result<GitHubRepositoryResponse>> SearchAllRepositoriesAsync(GitHubRepositoryRequest request);
        Task<Result<GitHubRepositoryResponse>> SearchUserRepositories(GitHubRepositoryRequest request);
    }
}
