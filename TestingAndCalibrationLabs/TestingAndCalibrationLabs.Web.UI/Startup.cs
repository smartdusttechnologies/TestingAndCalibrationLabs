using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Data.Repository;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Infrastructure;
using TestingAndCalibrationLabs.Business.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.common;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.common;
using TestingAndCalibrationLabs.Business.Core.Model.Common;

namespace TestingAndCalibrationLabs.Web.UI
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
            services.AddControllersWithViews();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            //Services
            services.AddScoped<ICommonService, SampleService>();

            //Repository
            services.AddScoped<IConnectionFactory, ConnectionFactory>();
            //services.AddScoped<IGenericRepository<SampleModel>, GenericRepository<SampleModel>>();
            services.AddScoped<IGenericRepository<UiPageTypeModel>, GenericRepository<UiPageTypeModel>>();
            services.AddScoped<IGenericRepository<UiPageDataModel>, GenericRepository<UiPageDataModel>>();
            services.AddScoped<IGenericRepository<RecordModel>, GenericRepository<RecordModel>>();
            services.AddScoped<IGenericRepository<UiPageValidationTypes>, GenericRepository<UiPageValidationTypes>>();
            services.AddScoped<IGenericRepository<UiPageMetadataModel>, GenericRepository<UiPageMetadataModel>>();
            // services.AddScoped<ISampleRepository, SampleRepository>();
            services.AddScoped<ICommonCrudRepository, CommonCrudRepository>();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Sample}/{action=Index}/{id?}");
            });
        }
    }
}
