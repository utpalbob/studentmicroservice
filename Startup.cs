using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Steeltoe.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Steeltoe.Discovery.Client;

namespace studentms
{
    public class Startup
    {
		public IConfigurationRoot Configuration { get; set; }

		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(System.IO.Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddEnvironmentVariables()
				.AddConfigServer(env);

			Configuration = builder.Build();
		}
        
        public void ConfigureServices(IServiceCollection services)
        {

			services.AddConfigServer(Configuration);
			services.AddDiscoveryClient(Configuration);
			services.AddMvc();
			services.AddScoped<IStudentmsRepository, StudentmsRepository>();
			services.AddScoped<IClient, Client>();
        }

       
        public void Configure(IApplicationBuilder app)
		{
			app.UseDiscoveryClient();
            app.UseMvc();

		}

    }
}
