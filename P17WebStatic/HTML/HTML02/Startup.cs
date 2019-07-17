using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

using System.IO;

namespace HTML02
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.UseDefaultFiles(new DefaultFilesOptions { DefaultFileNames = new List<string> { "index.html" } });
            app.UseDefaultFiles();
            app.UseStaticFiles();


        app.Use(async(ContextBoundObject,next) =>
            {
                if(ContextBoundObject.Request.Method == "POST") 
                {
                    using(var r = new StreamReader(ContextBoundObject.Request.Body))
                    {
                        var body = await r.ReadToEndAsync();
                    }
                }
            });
        }
        
        // public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        // {
            // app.UseDefaultFiles();
            // app.UseStaticFiles();
        // }

        public void ConfigureServices(IServiceCollection services)
        {
        }

    }
}