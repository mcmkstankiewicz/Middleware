using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middleware
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
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            /*
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("<p>Yo 1 </p>");
                await next();
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("<p>Yo 2 </p>");
                await next();
            });
            app.Map("/angular", action => 
            {
                action.Use(async (context, next )=> 
                {
                    await context.Response.WriteAsync("<p>Angular 6</p>");
                    await next();
                });

                action.Use(async (context, next) =>
                {
                    await context.Response.WriteAsync("<p>zostal wydany</p>");
                    await next();
                });
                action.Run(async context =>
                {
                    await context.Response.WriteAsync("<p>w maju 2018</p>");
                });
            });

            app.MapWhen(context => context.Request.Query.ContainsKey("name"), action => //"localhost:xxxxx/?name=Jan
            {
                action.Run(async context =>
                {
                    var name = context.Request.Query["name"];
                    await context.Response.WriteAsync($"<p>Witaj {name} </p>");
                });
               
            });
            app.Run(async context =>
            {
                await context.Response.WriteAsync("<p>yo z  nie-run middleware</p>");
            });
            */

            app.UseHttpsRedirection();
           
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseUrlTransformMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });


        }
    }
}
