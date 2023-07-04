using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Threading.Tasks;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Services

{
    /// <summary>
    /// This service is exclusively to send the email.
    /// </summary>
    public class EmailService : IEmailService
    {
        /// <summary>
        /// It is to access the Appsetting.json file.
        /// </summary>
        private readonly IConfiguration _configuration;
        private readonly string _smtpUsername;
        private readonly SecureString _smtpPassword;
        private readonly string _senderEmail;
        private readonly int _smtpPort;
        private readonly string _smtpHost;

        /// <summary>
        /// Constructor call.
        /// </summary>
        /// <param name="configuration"></param>
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        /// <summary>
        /// Sends mail using the Email model.
        /// </summary>
        /// <param name="surveyModel"></param>
        /// <returns></returns>
        public bool Sendemail(EmailModel emailModel)
        {
            try
            {
                //Read SMTP settings from AppSettings.json.
                string host = _configuration["Smtp:Server"];
                int port = int.Parse(_configuration["Smtp:Port"]);
                string fromAddress = _configuration["Smtp:FromAddress"];
                string userName = _configuration["Smtp:UserName"];
                string linkpre = _configuration["GoogleCloudStorage:PrefixLink"];
                string password = _configuration["Smtp:Password"];
                string emailTo = string.Join(",", emailModel.Email);

                using (MailMessage mm = new MailMessage(fromAddress, emailTo))
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
                        return true;
                    }
                }
            }
            catch(Exception)
            {
                return false;
            }                           
        }

        Task IEmailService.FindByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}    