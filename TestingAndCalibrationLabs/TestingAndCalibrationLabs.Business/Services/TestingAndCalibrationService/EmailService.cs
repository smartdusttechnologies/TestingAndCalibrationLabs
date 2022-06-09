using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

    
        public EmailService(IConfiguration configuration, IEmailService emailService)
        {
            _configuration = configuration;
            _emailService = emailService;
        }
        
        /// <summary>
        /// Sends mail using the Survey model.
        /// </summary>
        /// <param name="surveyModel"></param>
        /// <returns></returns>
        public bool Sendemail(EmailModel emailModel)
        {
            //Read SMTP settings from AppSettings.json.
            string host = _configuration["Smtp:Server"];
            int port = int.Parse(_configuration["Smtp:Port"]);
            string fromAddress = _configuration["Smtp:FromAddress"];
            string userName = _configuration["Smtp:UserName"];
            string password = _configuration["Smtp:Password"];
            string emailto = string.Join(",", emailModel.EmailTo);

            using (MailMessage mm = new MailMessage(fromAddress, emailto))
            {
                mm.Subject = emailModel.Subject;
                mm.Body = emailModel.HtmlMsg;
                mm.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = host;
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential(userName, password);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = port;
                    smtp.Send(mm);
                }
            }
            return true;
        }

        public object Sendemail(SurveyModel surveymodel)
        {
            return _emailService.Sendemail(surveymodel);
        }
    }
}    