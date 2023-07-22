using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.Threading;
using MailKit;
using CloudinaryDotNet.Actions;
using System.Net.Http;
using System.IO;
using AutoMapper;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using Org.BouncyCastle.Asn1.Ocsp;
using TestingAndCalibrationLabs.Business.Services;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    [Route("api/[controller]")]
     [ApiController]
    public class WhatsappController : Controller
    {
        private readonly IConfiguration _configuration;
        public readonly IMapper _mapper;
        public readonly IWhatsappService _whatsappService;
       public WhatsappController(IConfiguration configuration, IMapper mapper, IWhatsappService whatsappService)
        {
            _configuration = configuration;
            _mapper = mapper;
            _whatsappService = whatsappService;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync()
        {
            Console.WriteLine(Request);

            var req = Request;
            try
            {
                //validate the webhook
                string mode = req.Query["hub.mode"];
                string challenge = req.Query["hub.challenge"];
                string verifyToken = req.Query["hub.verify_token"];

                if (!string.IsNullOrEmpty(mode) && !string.IsNullOrEmpty(verifyToken))
                {
                    if (mode == "subscribe" && verifyToken == "hello from jd")
                    {
                        System.Console.WriteLine("Token Verified");
                        string responseMessage = challenge;
                        return new OkObjectResult(responseMessage);
                    }
                    else
                    {
                        System.Console.WriteLine("Error Validation");
                        return new BadRequestObjectResult("your error message");
                    }
                }
                else
                {
                    //handle incoming message
                    string requestBody = await new StreamReader(Request.Body).ReadToEndAsync();                
                    var receivedMessage = JObject.Parse(requestBody);                
                    string senderPhoneNumber = receivedMessage["from"].ToString();
                    string senderId = receivedMessage["phoneNumberId"].ToString();
                    string incomingMessageText = receivedMessage["entry"].ToString();

                

                    JObject response = new JObject();
                    response["messaging_product"] = "whatsapp";
                    response["to"] = senderPhoneNumber;


                    JObject message = new JObject();            
                    message["body"] = "aman123";
                    response["text"] = message;
                    //    await SendMessageAsync(response, senderId);
                  await  _whatsappService.SendMessageAsync(response, senderId);
                    return Ok("not found");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
                return BadRequest();

            }
            return null;
        }


     //private async Task SendMessageAsync(JObject message, string senderId)
     //   {
     //       string apiUrl = $"https://graph.facebook.com/v17.0/{senderId}/messages";
     //       string apiToken = _configuration["MetaDeveloper:APIToken"];

     //       using (var httpClient = new HttpClient())
     //       {
     //           httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);

     //           var content = new StringContent(message.ToString(), Encoding.UTF8, "application/json");
     //           var response = await httpClient.PostAsync(apiUrl, content);

     //           if (response.IsSuccessStatusCode)
     //           {
     //               Console.WriteLine("message sent successfully");
     //           }
     //           else
     //           {
     //               Console.WriteLine($"Error sending message :{response.StatusCode}");
     //           }
     //       }
     //   }
       
    }
}