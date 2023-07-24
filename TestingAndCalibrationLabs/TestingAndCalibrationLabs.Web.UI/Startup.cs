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
using TestingAndCalibrationLabs.Business.Data.Repository.TestingAndCalibration;
using TestingAndCalibrationLabs.Business.Data.TestingAndCalibration;
using TestingAndCalibrationLabs.Business.Services.TestingAndCalibrationService;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.common;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using TestingAndCalibrationLabs.Business.Data.Repository.BackOffice;
using Newtonsoft.Json.Serialization;
using TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice;

namespace TestingAndCalibrationLabs.Web.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static TokenValidationParameters tokenValidationParameters;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();
            services.AddControllersWithViews();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers().AddNewtonsoftJson();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
          .AddJwtBearer(options =>
          {
              options.TokenValidationParameters = tokenValidationParameters;
          });

            //PolicyBases Authorization
            services.AddAuthorization(options =>
            {
                options.AddPolicy(PolicyTypes.Users.Manage, policy => { policy.RequireClaim(CustomClaimTypes.Permission, Permissions.UsersPermissions.Add); });
                options.AddPolicy(PolicyTypes.Users.Manage, policy => { policy.RequireClaim(CustomClaimTypes.Permission, Permissions.UsersPermissions.Edit); });
                options.AddPolicy(PolicyTypes.Users.Manage, policy => { policy.RequireClaim(CustomClaimTypes.Permission, Permissions.UsersPermissions.Read); });
                //options.AddPolicy(PolicyTypes.Users.Manage, policy => { policy.RequireClaim(CustomClaimTypes.Permission, Permissions.UsersPermissions.Delete); });
                options.AddPolicy(PolicyTypes.Users.EditRole, policy => { policy.RequireClaim(CustomClaimTypes.Permission, Permissions.UsersPermissions.EditRole); });
            });
            //Services
            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<ISampleService, SampleService>();
            services.AddScoped<ISurveyService, SurveyService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ISampleService, SampleService>();
            services.AddScoped<ITestReportService, TestReportService>();
            services.AddScoped<IGoogleDriveService, GoogleDriveService>();
            services.AddScoped<IEmailService, EmailService >();

            services.AddScoped<IModuleService, ModuleService>();
            services.AddScoped<IWorkflowActivityService, WorkflowActivityService>();
            services.AddScoped<IActivityMetadataService, ActivityMetadataService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ISecurityParameterService, SecurityParameterService>();
            services.AddScoped<ILogger, Logger>();
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<IUiControlTypeService, UiControlTypeService>();
            services.AddScoped<IUiPageTypeService, UiPageTypeService>();
            services.AddScoped<IUiPageValidationService, UiPageValidationService>();
            services.AddScoped<IUiPageMetadataService, UiPageMetadataService>();
            services.AddScoped<IDataTypeService, DataTypeService>();
            services.AddScoped<IFileCompressionService, FileCompressionService>();
            services.AddScoped<IUiPageValidationTypeService, UiPageValidationTypeService>();
            services.AddScoped<IUiControlCategoryTypeService, UiControlCategoryTypeService>();

            services.AddScoped<ILookupService, LookupService>();
            services.AddScoped<IActivityMetadataService, ActivityMetadataService>();
            services.AddScoped<ILookupCategoryService, LookupCategoryService>();
            services.AddScoped<IListSorterService, ListSorterService>();
            services.AddScoped<IModuleService, ModuleService>();
            services.AddScoped<IWorkflowService, WorkflowService>();
            services.AddScoped<IWorkflowStageService, WorkflowStageService>();
            services.AddScoped<IUiPageMetadataCharacteristicsService, UiPageMetadataCharacteristicsService>();
            services.AddScoped<IUiPageNavigationService, UiPageNavigationService>();
            services.AddScoped<IActivityMetadataService, ActivityMetadataService>();


            //Repository
            services.AddScoped<IModuleRepository, ModuleRepository>();
            services.AddScoped<ILookupRepository, LookupRepository>();
            services.AddScoped<IActivityMetadataRepository, ActivityMetadataRepository>();
            services.AddScoped<IWorkflowActivityRepository, WorkflowActivityRepository>();
            services.AddScoped<IWorkflowRepository, WorkflowRepository>();
            services.AddScoped<IWorkflowStageRepository, WorkflowStageRepository>();
            services.AddScoped<IUiPageValidationRepository, UiPageValidationRepository>();
            services.AddScoped<IUiPageMetadataRepository, UiPageMetadataRepository>();
            services.AddScoped<IUiPageMetadataCharacteristicsRepository, UiPageMetadataCharacteristicsRepository>();
            services.AddScoped<IUiPageNavigationRepository, UiPageNavigationRepository>();
            services.AddScoped<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<IGenericRepository<UiControlCategoryTypeModel>, GenericRepository<UiControlCategoryTypeModel>>();
            services.AddScoped<IGenericRepository<UiPageTypeModel>, GenericRepository<UiPageTypeModel>>();
            services.AddScoped<IGenericRepository<ActivityMetadataModel>, GenericRepository<ActivityMetadataModel>>();
            services.AddScoped<IGenericRepository<ModuleModel>, GenericRepository<ModuleModel>>();
            services.AddScoped<IGenericRepository<LookupCategoryModel>, GenericRepository<LookupCategoryModel>>();
            services.AddScoped<IGenericRepository<LookupModel>, GenericRepository<LookupModel>>();
            services.AddScoped<IGenericRepository<UiPageDataModel>, GenericRepository<UiPageDataModel>>();
            services.AddScoped<IGenericRepository<UiNavigationCategoryModel>, GenericRepository<UiNavigationCategoryModel>>();
            services.AddScoped<IGenericRepository<RecordModel>, GenericRepository<RecordModel>>();
            services.AddScoped<IGenericRepository<DataTypeModel>, GenericRepository < DataTypeModel >> ();
            services.AddScoped<IGenericRepository<UiPageValidationTypeModel>, GenericRepository < UiPageValidationTypeModel >> ();
            services.AddScoped<IGenericRepository<UiPageValidationModel>, GenericRepository < UiPageValidationModel >> ();
            services.AddScoped<IGenericRepository<UiControlTypeModel>, GenericRepository<UiControlTypeModel>>();
            services.AddScoped<IGenericRepository<UiPageMetadataModel>, GenericRepository<UiPageMetadataModel>>();
            services.AddScoped<ISampleRepository, SampleRepository>();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped<ILoggerRepository, LoggerRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ISecurityParameterRepository, SecurityParameterRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped< ITestReportRepository, TestReportRepository >();
            services.AddScoped< IUserRepository, UserRepository>();
            services.AddScoped<ICommonRepository, CommonRepository>();
            services.AddScoped<ISurveyRepository, SurveyRepository>();
            services.AddScoped<IUiControlCategoryTypeRepository, UiControlCategoryTypeRepository>();
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

            tokenValidationParameters = new TokenValidationParameters
            {
                // The signing key must match!
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"])),

                // Validate the JWT Issuer (iss) claim
                ValidateIssuer = true,
                ValidIssuer = Configuration["JWT:ValidIssuer"],

                // Validate the JWT Audience (aud) claim
                ValidateAudience = true,
                ValidAudience = Configuration["JWT:ValidAudience"],

                // Validate the token expiry
                ValidateLifetime = true,

                // If you want to allow a certain amount of clock drift, set that here:
                ClockSkew = TimeSpan.Zero
            };
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
                    pattern: "{controller=TestReport}/{action=Index}/{id?}");
            });
           
        }
    }
}