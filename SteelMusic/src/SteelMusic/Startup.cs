using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Net;
using SteelMusic.Services;
using System.Collections;
using SteelToe.Extensions.Configuration;

namespace SteelMusic
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, ILoggerFactory logFactory)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .AddConfigServer(env, logFactory);
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddConfigServer(Configuration);
            services.AddMvc();

            services.AddSingleton<IAlbumService, AlbumService>(provider => {
                AlbumService service = new AlbumService();

                service.Load("Data/albums.json");

                return service;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");
            });

            loggerFactory.CreateLogger("Main").LogInformation("Starting Steel Music");
            Console.WriteLine("[Console] Starting Steel Music");

            foreach(DictionaryEntry pair in Environment.GetEnvironmentVariables())
            {
                Console.WriteLine("Env: {0} = \"{1}\"", pair.Key, pair.Value);
            }

        }
    }
}
