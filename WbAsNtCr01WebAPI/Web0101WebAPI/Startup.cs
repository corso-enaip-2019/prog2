using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Web0101WebAPI.Infrastructure;

namespace Web0101WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //PER SDK >= 2.2    ->  services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //PER SDK < 2.2     ->  services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                /* HTTP Strict Transport Security (HSTS) is a web server directive that informs user agents and web browsers how to handle its connection through a response header sent at the very beginning and back to the browser.
                   This sets the Strict-Transport-Security policy field parameter. It forces those connections over HTTPS encryption, disregarding any script's call to load any resource in that domain over HTTP. HSTS is but one arrow in a bundled sheaf of security settings for your web server or your web hosting service. */
                //app.UseHsts();

                app.Use(async (context, next) =>
                    {
                        try
                        {
                            await next();
                        }
                        catch (InvalidInputException ex) // ex definita in Infrastructure
                        {
                            var result = JsonConvert.SerializeObject(new { message = ex.Message });
                            context.Response.ContentType = "application/json";
                            context.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                            await context.Response.WriteAsync(result);
                        }
                        catch (NotFoundException ex) // ex definita in Infrastructure
                        {
                            var result = JsonConvert.SerializeObject(new { message = ex.Message });
                            context.Response.ContentType = "application/json";
                            context.Response.StatusCode = StatusCodes.Status404NotFound;
                            await context.Response.WriteAsync(result);
                        }

                    }

                );
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}