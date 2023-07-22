using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Services

{
    /// <summary>
    /// This service is exclusively to send the email.
    /// </summary>
    public class WhatsappService : IWhatsappService
    {
        /// <summary>
        /// It is to access the Appsetting.json file.
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor call.
        /// </summary>
        /// <param name="configuration"></param>
        public WhatsappService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendMessageAsync(JObject message, string senderId)
        {
            string apiUrl = $"https://graph.facebook.com/v17.0/{senderId}/messages";
            string apiToken = _configuration["MetaDeveloper:APIToken"];

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);

                var content = new StringContent(message.ToString(), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("message sent successfully");
                }
                else
                {
                    Console.WriteLine($"Error sending message :{response.StatusCode}");
                }
            }
        }
    }
}    