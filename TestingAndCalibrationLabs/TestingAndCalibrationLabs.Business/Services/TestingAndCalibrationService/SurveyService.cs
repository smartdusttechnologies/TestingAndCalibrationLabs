using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// using the SurverInterface
    /// </summary>
    public class SurveyService : ISurveyService
    {
        private readonly ISurveyRepository _surveyRepository;
        private readonly IEmailService _emailService;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _hostingEnvironment;
        
        #region public methods

        public SurveyService(ISurveyRepository surveyRepository, IWebHostEnvironment hostingEnvironment, IEmailService emailservice, IUserRepository userRepository, IConfiguration configuration)
        {
            _surveyRepository = surveyRepository;
            _emailService = emailservice;
            _userRepository = userRepository;
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        public RequestResult<int> Add(SurveyModel surveymodel)
        {
            var emailsendTo = _userRepository.Get();

            //Read other values from Appsetting .Json 
            surveymodel.EmailTemplate = _configuration["TestingAndCalibrationSurvey:UserTemplate"];
            surveymodel.EmailTemplate = _configuration["TestingAndCalibrationSurvey:AdminMailTemplate"];
            surveymodel.LogoImage = _configuration["TestingAndCalibrationSurvey:LogoImage"];
            surveymodel.BodyImage = _configuration["TestingAndCalibrationSurvey:BodyImage"];
            surveymodel.EmailContact = _configuration["TestingAndCalibrationSurvey:emailID"];
            surveymodel.MobileNumber = _configuration["TestingAndCalibrationSurvey:Mobile"];
            surveymodel.Subject = _configuration["TestingAndCalibrationSurvey:Subject"];

            //Create User Mail
            surveymodel.HtmlMsg = CreateBody(surveymodel.EmailTemplate);
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*name*", surveymodel.Name);
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*contactmail*", surveymodel.EmailContact);
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*mob*", surveymodel.MobileNumber);
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*LogoLink*", surveymodel.LogoImage);
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*BodyImageLink*", surveymodel.BodyImage);
            surveymodel.Subject = surveymodel.Subject;

            var isemailsendsuccessfully = _emailService.Sendemail(surveymodel);
            
            //Saving the data to data base
            _surveyRepository.Insert(surveymodel);

            //create msg for admins
            surveymodel.HtmlMsg = CreateBodyAdmin(surveymodel.EmailTemplate);
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*name*", surveymodel.Name);
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*mobilenumber*", surveymodel.Mobile);
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*Emailid*", surveymodel.Email.FirstOrDefault());
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*TestingType*", surveymodel.TestingType);
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*Address*", surveymodel.Address);
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*City*", surveymodel.City);
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*State*", surveymodel.State);
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*Pin*", surveymodel.PinCode);
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*Comment*", surveymodel.Comments);
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*contactmail*", surveymodel.EmailContact);
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*Mob*", surveymodel.MobileNumber);
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*LogoLink*", surveymodel.LogoImage);
            surveymodel.HtmlMsg = surveymodel.HtmlMsg.Replace("*BodyImageLink*", surveymodel.BodyImage);
            surveymodel.Subject = surveymodel.Subject;

            //Remove users mail id and add the List of mail addresss of users[Admin] in Database. 
            surveymodel.Email.RemoveAt(0);
            foreach (var item in emailsendTo)
            {
                surveymodel.Email.Add(item);
            }

            var isemailsendsuccessfully1 = _emailService.Sendemail(surveymodel);
            if ((bool)isemailsendsuccessfully1)
            {
                return new RequestResult<int>(1);
            }
            return new RequestResult<int>(0);
        }

        /// <summary>
        /// To use the email Template to send mail to the User participated.
        /// </summary>
        /// <param name="emailTemplate"></param>
        ///returns></returns>
        private string CreateBody(string emailTemplate)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Path.Combine(_hostingEnvironment.WebRootPath, _configuration["TestingAndCalibrationSurvey:UserTemplate"])))
            {
                body = reader.ReadToEnd();
            }
            return body;
        }

        /// <summary>
        /// To use the email Template to send mail to the Users in database.
        /// </summary>
        /// <param name="emailTemplate"></param>
        /// <returns></returns>
        private string CreateBodyAdmin(string emailTemplate)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Path.Combine(_hostingEnvironment.WebRootPath, _configuration["TestingAndCalibrationSurvey:AdminMailTemplate"])))
            {
                body = reader.ReadToEnd();
            }
            return body;
        }
    }
}
#endregion