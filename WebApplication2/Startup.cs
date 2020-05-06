using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApplication2.Models;

namespace WebApplication2
{
    public class Startup
    {
        public IConfiguration _config;
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddXmlSerializerFormatters();
            services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
               
                app.UseDeveloperExceptionPage();
            }

           

            //app.UseFileServer();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();




            /*app.UseMvc(routes =>{
                routes.MapRoute( "default", "{controller = home }/{action = index }/{id?}");
            });*/

            //app.UseMvc();

            /*app.Run(async (context) =>
            {
               
                await context.Response.WriteAsync("Hello from middleware");
               // logger.LogInformation("handled & produced");
            });*/
        }
    }
}
