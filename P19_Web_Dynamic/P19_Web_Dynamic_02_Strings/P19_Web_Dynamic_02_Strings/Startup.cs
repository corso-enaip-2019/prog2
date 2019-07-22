using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace P19_Web_Dynamic_02_Strings
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            app.Run(async (context) =>
            {
                var html =
                    "<!DOCTYPE html>" +
                    "<html>" +
                    "<head>" +
                        "<meta charset=\"utf-8\" />" +
                        "<title></title>" +
                    "</head>" +
                    "<body>" +
                        "<h1>Request analysis</h1>" +

                        "<h2>Path:</h2>" +
                        "<ul>";

                var steps = context.Request.Path.Value.Split('/');
                foreach (var s in steps.Where(x => !string.IsNullOrWhiteSpace(x))) {
                    html += "<li>" + s + "</li>\n";
                }
                html +=
                        "</ul>" +
                        "<h2>Query:</h2>" +
                    "<pre>{\n";
                foreach (var kvp in context.Request.Query) {
                    html += $"    {kvp.Key}: {kvp.Value},\n";
                }
                html += 
                    "}</pre>" +
                    "</body>" +
                    "</html>";

                await context.Response.WriteAsync(html);
            });
        }
    }
}
