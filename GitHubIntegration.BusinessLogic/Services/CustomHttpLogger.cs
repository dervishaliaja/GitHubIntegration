using System;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace GitHubIntegration.BusinessLogic.Services;

public class CustomHttpLogger : HttpClientHandler
{
    public CustomHttpLogger()
    {
        ServerCertificateCustomValidationCallback = ValidateServerCertificate;
    }

    private static bool ValidateServerCertificate(HttpRequestMessage request, X509Certificate2 certificate,
        X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        // Ignore SSL certificate errors
        return true;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        // Log the raw HTTP request
        Console.WriteLine("----- Headers -----");
        Console.WriteLine($"{request.Headers}");
        Console.WriteLine("----- Request -----");
        Console.WriteLine($"{request.Method} {request.RequestUri} HTTP/{request.Version}");

        if (request.Content != null)
        {
            var content = await request.Content.ReadAsStringAsync();
            Console.WriteLine(content);
        }

        Console.WriteLine();

        // Call the inner handler to process the request
        var response = await base.SendAsync(request, cancellationToken);

        // Log the raw HTTP response
        Console.WriteLine("----- Response -----");
        Console.WriteLine($"HTTP/{response.Version} {response.StatusCode} {response.ReasonPhrase}");

        if (response.Content != null)
        {
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);
        }

        Console.WriteLine();

        return response;
    }
}