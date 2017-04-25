﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace studentms
{
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {

			services.AddScoped<IStudentmsRepository, StudentmsRepository>();
			services.AddMvc();
        }

       
        public void Configure(IApplicationBuilder app)
		{
			app.UseMvc();

		}

    }
}
