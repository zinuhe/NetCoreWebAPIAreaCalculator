using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using AreaCalculatorRestApi.Models;


namespace AreaCalculatorRestApi
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
            services.AddControllers();

            //Added a policy AngularFrontend - JSB
            services.AddCors(options => options.AddPolicy("AngularFrontend", builder => builder.AllowAnyHeader()
                                                                                                .AllowAnyMethod()
                                                                                                .AllowAnyOrigin()
                                                                                                // .WithOrigins("http://localhost:4200")
                                                                                            ));
            services.AddApplicationInsightsTelemetry();

            //Added - JSB
            //services.AddDbContext<AreaContext>(opt => opt.UseInMemoryDatabase("AreaList"));
            //services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseCors(options => options.AllowAnyOrigin());  //Added JSB
            // app.UseCors("AngularFrontend"); //Refers to the Policy "AngularFrontend" define on ConfigureServices
        }
    }
}
