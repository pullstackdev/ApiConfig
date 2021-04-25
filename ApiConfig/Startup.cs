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
            //ConfigureServices, .netcore dan hangi servise ihtiyaç var ise onlarýn eklendiði yer örneðin;
            //services.AddMvc();
            //services.AddCors();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Configure, requestlerin ve response'larýn yönetildiði yer

            if (env.IsDevelopment()) //geliþtirme ortamý ise error page döner
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting(); //requestteki url'in projedeki hangi route ile eþleþtiðini belirler

            //app.UseEndpoints(endpoints => //gelen route'ý çalýþtýrýr
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
            //app.UseEndpoints(endpoints => //gelen route'ý çalýþtýrýr
            //{
            //    endpoints.MapGet("/test", async context =>
            //    {
            //        await context.Response.WriteAsync("testss!");
            //    });
            //});
            app.UseEndpoints(endpoints => //gelen route'ý çalýþtýrýr
            {
                endpoints.MapControllers();
            });
        }
    }
}
