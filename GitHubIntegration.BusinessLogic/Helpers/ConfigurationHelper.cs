using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubIntegration.BusinessLogic.Helpers
{
    public static class ConfigurationHelper
    {
        public  class GitHubSettings
        {
            
            public static string ApiUrl
            {
                get
                {
                    return Environment.GetEnvironmentVariable("ApiBaseUrl");
                }
            }
            public static string AuthenticateUrl
            {
                get
                {
                    return Environment.GetEnvironmentVariable("AuthenticateUrl");
                }
            }
            public static string ClientId
            {
                get
                {
                    return Environment.GetEnvironmentVariable("ClientId");
                }
            }
            public static string ClientSecret
            {
                get
                {
                    return Environment.GetEnvironmentVariable("ClientSecret");
                }
            }
           
        }
    }
}
