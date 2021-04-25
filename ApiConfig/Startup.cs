using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ApiConfig
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //ConfigureServices, .netcore dan hangi servise ihtiya� var ise onlar�n eklendi�i yer �rne�in;
            //services.AddMvc();
            //services.AddCors();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Configure, requestlerin ve response'lar�n y�netildi�i yer

            if (env.IsDevelopment()) //geli�tirme ortam� ise error page d�ner
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting(); //requestteki url'in projedeki hangi route ile e�le�ti�ini belirler

            //app.UseEndpoints(endpoints => //gelen route'� �al��t�r�r
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
            //app.UseEndpoints(endpoints => //gelen route'� �al��t�r�r
            //{
            //    endpoints.MapGet("/test", async context =>
            //    {
            //        await context.Response.WriteAsync("testss!");
            //    });
            //});
            app.UseEndpoints(endpoints => //gelen route'� �al��t�r�r
            {
                endpoints.MapControllers();
            });
        }
    }
}
