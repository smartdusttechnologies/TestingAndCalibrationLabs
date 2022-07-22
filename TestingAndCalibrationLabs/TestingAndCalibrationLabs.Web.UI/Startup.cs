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
using TestingAndCalibrationLabs.Business.Data.Repository.TestingAndCalibration;
using TestingAndCalibrationLabs.Business.Data.TestingAndCalibration;
using TestingAndCalibrationLabs.Business.Services.TestingAndCalibrationService;
using Microsoft.Extensions.Hosting.Internal;


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
            services.AddScoped<ISurveyService, SurveyService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ISampleService, SampleService>();
            services.AddScoped<ITestReportService, TestReportService>();
            services.AddScoped<DriveDownloadFile, GoogleUploadService>();
            services.AddScoped<IEmailService, EmailService >();
            
 
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ISecurityParameterService, SecurityParameterService>();
            services.AddScoped<ILogger, Logger>();
            services.AddScoped<IOrganizationService, OrganizationService>();

            
            //Repository
            services.AddScoped<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<ISampleRepository, SampleRepository>();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped<ILoggerRepository, LoggerRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ISecurityParameterRepository, SecurityParameterRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped< ITestReportRepository, TestReportRepository >();
            services.AddScoped< IUserRepository, UserRepository>();
            services.AddScoped<ISurveyRepository, SurveyRepository>();
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