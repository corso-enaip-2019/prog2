using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace P17_Web_static_03_Bootstrap
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async(context, next) =>
            {
                if (context.Request.Method == "POST")
                {
                    using(var r = new StreamReader(context.Request.Body))
                    {
                        var body = await r.ReadToEndAsync();
                        // ...
                    }
                    context.Request.Method = "GET";
                    context.Request.Path = "/message-sent.html";
                }
                await next();
            });
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}
