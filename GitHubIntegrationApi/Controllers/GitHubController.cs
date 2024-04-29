using System;
using System.Threading.Tasks;
using GitHubIntegration.BusinessLogic.Services;
using GitHubIntegration.DataModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GitHubIntegration.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GitHubController : ControllerBase
{
    private readonly IGitHubClient _githubClient;
    private readonly ILogger<GitHubController> _logger;

    public GitHubController(IGitHubClient githubClient, ILogger<GitHubController> logger)
    {
        _githubClient = githubClient;
        _logger = logger;
    }

    [HttpGet("search/all/{query}")]
    public async Task<Result<GitHubRepositoryResponse>> SearchAllRepositories(string query)
    {
        var request = new GitHubRepositoryRequest { Query = query };
        var repositories = await _githubClient.SearchAllRepositoriesAsync(request);
        return repositories;
    }
    
    [HttpGet("search/{username}/{token}/{query}")]
    public async Task<Result<GitHubRepositoryResponse>> SearchAllRepositories(string username, string token, string query)
    {
        var request = new GitHubRepositoryRequest { Token = token, Username = username, Query = query };
        var repositories = await _githubClient.SearchUserRepositories(request);
        return repositories;
    }
}