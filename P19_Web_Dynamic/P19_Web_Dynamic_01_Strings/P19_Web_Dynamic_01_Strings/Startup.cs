using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace P19_Web_Dynamic_01_Strings
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hi, I'm middleware 1!\n");

                await next();

                await context.Response.WriteAsync("Farewell from middleware 1!\n");
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hi, I'm middleware 2!\n");

                await next();

                await context.Response.WriteAsync("Farewell from middleware 2!\n");
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hi, I'm middleware 3!\n");

                await context.Response.WriteAsync("Farewell from middleware 3!\n");
            });
        }
    }
}
