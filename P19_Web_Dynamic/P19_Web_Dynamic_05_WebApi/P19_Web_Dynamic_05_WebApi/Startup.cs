using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using P19_Web_Dynamic_05_WebApi.Infrastructure.DomainExceptions;

namespace P19_Web_Dynamic_05_WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .AddJsonOptions(options => {
                    options.SerializerSettings.ReferenceLoopHandling =
                        ReferenceLoopHandling.Ignore;
                });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                try
                {
                    await next();
                }
                catch (InvalidInputException ex)
                {
                    var result = JsonConvert.SerializeObject(new { message = ex.Message });
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                    await context.Response.WriteAsync(result);
                }
                catch(NotFoundException ex)
                {
                    var result = JsonConvert.SerializeObject(new { message = ex.Message });
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    await context.Response.WriteAsync(result);
                }
            });

            app.UseMvc();
        }
    }
}
