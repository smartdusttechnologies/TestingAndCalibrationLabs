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
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.common;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.common;
using TestingAndCalibrationLabs.Business.Core.Model.Common;
using TestingAndCalibrationLabs.Business.Data.Repository.Cui;
using TestingAndCalibrationLabs.Business.Core.Interfaces.Cui;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.Cui;
using TestingAndCalibrationLabs.Business.Services.Cui;

using AutoMapper;
using Microsoft.AspNetCore.Http;

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
            services.AddSession();
            services.AddControllersWithViews();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();

            //Services
            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<ISampleService, SampleService>();
            services.AddScoped<ISurveyService, SurveyService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ISampleService, SampleService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ISecurityParameterService, SecurityParameterService>();
            services.AddScoped<ILogger, Logger>();
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<IUiControlService, UiControlService>();
            services.AddScoped<IUiPageService, UiPageService>();
            services.AddScoped<IUiPageValidationService, UiPageValidationService>();
            services.AddScoped<IUiPageControlService, UiPageControlService>();

            
            //Repository
            services.AddScoped<IUiControlRepo, UiControlRepo>();
            services.AddScoped<IUiPageRepo, UiPageRepo>();
            services.AddScoped<IUiPageValidationRepo, UiPageValidationRepo>();
            services.AddScoped<IUiPageControlRepo, UiPageControlRepo>();
            services.AddScoped<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<IGenericRepository<UiPageTypeModel>, GenericRepository<UiPageTypeModel>>();
            services.AddScoped<IGenericRepository<UiPageDataModel>, GenericRepository<UiPageDataModel>>();
            services.AddScoped<IGenericRepository<RecordModel>, GenericRepository<RecordModel>>();
            services.AddScoped<IGenericRepository<UiPageValidationTypes>, GenericRepository<UiPageValidationTypes>>();
            services.AddScoped<IGenericRepository<UiPageMetadataModel>, GenericRepository<UiPageMetadataModel>>();
            services.AddScoped<ISampleRepository, SampleRepository>();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped<ILoggerRepository, LoggerRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ISecurityParameterRepository, SecurityParameterRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<ICommonRepository, CommonRepository>();
            services.AddScoped<ISurveyRepository, SurveyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
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
            app.UseSession();

            app.Use(async (context, next) =>
            {
                var token = context.Session.GetString("Token");
                if (!string.IsNullOrEmpty(token))
                {
                    context.Request.Headers.Add("Authorization", "Bearer " + token);
                }
                await next();
            });
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Login}/{id?}");
            });
           
        }
    }
}


