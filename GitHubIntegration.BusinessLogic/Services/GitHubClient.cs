using System;
using System.Net.Http;
using System.Threading.Tasks;
using GitHubIntegration.BusinessLogic.Common;
using GitHubIntegration.DataModel.Models;
using Newtonsoft.Json;

namespace GitHubIntegration.BusinessLogic.Services;

public class GitHubClient : IGitHubClient
{
    public async Task<Result<GitHubRepositoryResponse>> SearchAllRepositoriesAsync(GitHubRepositoryRequest request)
    {
        try
        {
            if (string.IsNullOrEmpty(request.Query)) throw new Exception("Parameter query is required");

            var uri = new UriBuilder("https://api.github.com/search/repositories")
            {
                Query = $"q={Uri.EscapeDataString(request.Query)}"
            };

            using var httpClient = CustomHttpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Custom-Github-Integration");

            var response = await httpClient.GetAsync(uri.Uri);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"GitHub API returned status code {response.StatusCode}");

            var responseBody = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<dynamic>(responseBody);

            var result = new Result<GitHubRepositoryResponse>
            {
                IsSuccessful = true,
                Data = MapData(data["items"])
            };

            return result;
        }
        catch (Exception ex)
        {
            return new Result<GitHubRepositoryResponse>
            {
                IsSuccessful = false,
                Exception = ex
            };
        }
    }

    public async Task<Result<GitHubRepositoryResponse>> SearchUserRepositories(GitHubRepositoryRequest request)
    {
        try
        {
            var uri = new Uri($"https://api.github.com/users/{Uri.EscapeDataString(request.Username)}/repos");
            using var httpClient = CustomHttpClientFactory.CreateClient();

            httpClient.DefaultRequestHeaders.Add("User-Agent", "Custom-Github-Integration");
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {request.Token}");

            var response = await httpClient.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"GitHub API returned status code {response.StatusCode}");

            var responseBody = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<dynamic>(responseBody);

            var result = new Result<GitHubRepositoryResponse>
            {
                IsSuccessful = true,
                Data = MapData(data)
            };

            return result;
        }
        catch (Exception ex)
        {
            return new Result<GitHubRepositoryResponse>
            {
                IsSuccessful = false,
                Exception = ex
            };
        }
    }

    private GitHubRepositoryResponse MapData(dynamic data)
    {
        try
        {
            var list = new GitHubRepositoryResponse();
            foreach (var item in data)
                list.Add(new GitHubRepositoryItem
                {
                    OwnerLogin = item["owner"]["login"],
                    RepositoryUrl = item["html_url"],
                    RepositoryName = item["name"]
                });

            return list;
        }
        catch (Exception ex)
        {
            throw new Exception("Unable to parse data from GitHub API", ex);
        }
    }
}