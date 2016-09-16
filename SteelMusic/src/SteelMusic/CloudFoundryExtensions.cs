using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteelMusic
{
    public static class CloudFoundryExtensions
    {
        public static IWebHostBuilder UsePortEnvVariable(this IWebHostBuilder builder)
        {
            List<string> urls = new List<string>();

            string portStr = Environment.GetEnvironmentVariable("PORT");
            if (!string.IsNullOrWhiteSpace(portStr))
            {
                int port;
                if (int.TryParse(portStr, out port))
                {
                    urls.Add($"http://*:{port}");
                }
            }

            if (urls.Count > 0) {
                builder.UseUrls(urls.ToArray());
            }

            return builder;
        }

    }
}
