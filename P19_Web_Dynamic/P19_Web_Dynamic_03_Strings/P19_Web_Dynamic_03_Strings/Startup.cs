using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace P19_Web_Dynamic_03_Strings
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var filePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot",
                "index.html");

            var text = File.ReadAllText(filePath);

            app.Run(async (context) =>
            {
                var steps = context.Request.Path.Value
                    .Split('/')
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .Select(s => "<li>" + s + "</li>");

                var htmlSteps = string.Join("\n", steps);

                var textWithSteps = text.Replace("<li>@pathStep</li>", htmlSteps);

                var queryValues = context.Request.Query
                    .Select(kvp => $"    {kvp.Key}: {kvp.Value}");

                var queryValuesHtml = string.Join("\n", queryValues);

                var finalText = textWithSteps.Replace("    @key: @value", queryValuesHtml);

                await context.Response.WriteAsync(finalText);
            });
        }
    }
}
