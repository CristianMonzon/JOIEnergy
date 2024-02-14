using JOIEnergy.Business.Config;
using JOIEnergy.Generator;
using JOIEnergy.Services;
using JOIEnergy.Services.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.IO;

namespace JOIEnergy
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<AppSettings>(new AppSettings(GenerateConfiguration()));
            services.AddSwaggerGen(SetUpSwaggerDoc);

            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IMeterReadingService, MeterReadingService>();
            services.AddTransient<IPricePlanService, PricePlanService>();
            services.AddSingleton((IServiceProvider arg) => ElectricityReadingGenerator.ElectricityReading());
            services.AddSingleton((IServiceProvider arg) => PricePlanGenerator.PricePlans());
            services.AddSingleton((IServiceProvider arg) => SuppliersGenerator.Suppliers);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(SetUpSwaggerDoc);
            }
            app.UseMvc();
        }

        #region Generation

        private static IConfigurationRoot GenerateConfiguration()
        {
            return new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json").Build();
        }

        private static void SetUpSwaggerDoc(SwaggerGenOptions c)
        {
            c.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = "JOIEnergy",
                Version = "v1",
                Description = "JOI Energy"
            });
        }

        private void SetUpSwaggerDoc(SwaggerUIOptions c)
        {            
            c.SwaggerEndpoint("v1/swagger.json", "Swagger JOI Energy");
        }
               
        #endregion
    }
}