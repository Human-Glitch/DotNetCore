using System.Threading.Tasks;
using DotNetCore.DependencyInjection.Interfaces;
using DotNetCore.DependencyInjection.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DotNetCore.DependencyInjection
{
    public class Startup
    {
        IConfigurationRoot Configuration { get; }

        public Startup()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }

        // This method gets called by the runtime. Use this method to configure 
        // the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory) 
        {
            if (env.IsDevelopment()) { 
                app.UseDeveloperExceptionPage(); 
            }
            
            app.Run(async (context) => { 
                MyService service = new MyService();
                string response = await new Task<string>(() => service.GetResponse("https://www.google.com"));
            });  
        } 

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddSingleton<IConfigurationRoot>(Configuration);
            services.AddSingleton<IMyService, MyService>();
        }
    }
}