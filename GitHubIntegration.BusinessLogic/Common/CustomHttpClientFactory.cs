using System.Net.Http;
using GitHubIntegration.BusinessLogic.Services;

namespace GitHubIntegration.BusinessLogic.Common;

public static class CustomHttpClientFactory
{
    public static HttpClient CreateClient()
    {
#if DEBUG
        return new HttpClient(new CustomHttpLogger());
#else
        return new HttpClient();
#endif
    }
}