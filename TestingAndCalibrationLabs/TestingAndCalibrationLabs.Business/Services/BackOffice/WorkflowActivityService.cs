﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    public class WorkflowActivityService : IWorkflowActivityService
    {

        private readonly IWorkflowActivityRepository _workflowActivityRepository;
        private readonly IActivityMetadataService _activityMetadataService;
        private readonly IGenericRepository<UiPageDataModel> _pageDataGenericRepository;
        private readonly IEmailService _emailService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;

        public WorkflowActivityService(IConfiguration configuration,IWebHostEnvironment webHostEnvironment, IEmailService emailService, IActivityMetadataService activityMetadataService, IWorkflowActivityRepository workflowActivityRepository, IGenericRepository<UiPageDataModel> pageDataGenericRepository)
        {
            _workflowActivityRepository = workflowActivityRepository;
            _pageDataGenericRepository = pageDataGenericRepository;
            _activityMetadataService = activityMetadataService;
            _emailService = emailService;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }
        #region Public Methods
        /// <summary>
        /// To Run All Activity here Which Are Given To A Stage
        /// </summary>
        /// <param name="recordModel"></param>
        /// <returns></returns>
        public bool WorkflowActivity(RecordModel recordModel)
        {
            var activityList = _workflowActivityRepository.GetByWorkflowStageId(recordModel.WorkflowStageId);
            var pageDataList = _pageDataGenericRepository.Get("RecordId", recordModel.Id);
            foreach (var activity in activityList)
            {
                if (activity.ActivityId == (int)ActivityType.EmailServices)
                {
                   SendEmail(pageDataList,activity.ActivityId);
                }
            }
            return true;
        }
        #endregion
        #region private Methods

        #region Email Send Service
        /// <summary>
        /// Sending Email With Dynamic And Static Parameters 
        /// </summary>
        /// <param name="pageDataList"></param>
        /// <param name="activityId"></param>
        private void SendEmail(List<UiPageDataModel> pageDataList,int activityId)
        {
            EmailModel emailModel = new EmailModel();
            var activityList = _activityMetadataService.GetAll(activityId);
            var templatePath = activityList.Where(x => x.Name == "HtmlMsg").Select(x => x.Value).First();
            var staticList = activityList.Where(x => x.ActivityMetadataTypeId == (int)ActivityMetadataType.Static);
            var dynamicList = activityList.Where(x => x.ActivityMetadataTypeId == (int)ActivityMetadataType.Dynamic);
            var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, templatePath);
            var template = File.ReadAllText(fullPath);
            var logoImage = _configuration["TestingAndCalibrationSurvey:LogoImage"];
            var bodyImage = _configuration["TestingAndCalibrationSurvey:BodyImage"];
            var email = _configuration["TestingAndCalibrationSurvey:emailID"];
            var mobile = _configuration["TestingAndCalibrationSurvey:Mobile"];
            //Replacing Info
            template = template.Replace("*contactmail*", email);
            template = template.Replace("*mob*", mobile);
            template = template.Replace("*LogoLink*", logoImage);
            template = template.Replace("*BodyImageLink*", bodyImage);
            //loop For Static Parameters
            foreach(var activity in staticList)
            {
                if(activity.Name == "Subject")
                {
                    emailModel.Subject = activity.Value;
                }
            }
            //loop for Dynamic Parameters
            foreach (var param in dynamicList)
            {
                if (param.Name == "Email")
                {
                    emailModel.Email = new List<string> { pageDataList.Where(x => x.UiPageMetadataId == param.UiPageMetadataId).Select(x => x.Value).First() };
                }
                else if(param.Name== "Name")
                {
                    var value = pageDataList.Where(x => x.UiPageMetadataId == param.UiPageMetadataId).Select(x => x.Value).First();
                    template = template.Replace("*name*", value);
                }
            }
            emailModel.HtmlMsg = template;
           _emailService.Sendemail(emailModel);
        } 
        
        #endregion

        #endregion
    }

}
