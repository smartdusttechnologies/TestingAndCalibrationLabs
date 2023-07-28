
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using Microsoft.Win32;
using CloudinaryDotNet.Actions;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhatsappController : Controller
    {     
        public readonly IWhatsappService _whatsappService;


        public WhatsappController(IWhatsappService whatsappService)
        {           
            _whatsappService = whatsappService;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(WhatsappModel whatsappModel)
        {
            try
            {          
                {
                    //handle incoming message                           
                    string senderId = whatsappModel.phoneNumberId.ToString();
                    //when user request something via text or select something
                   // string incomingMessageText = whatsappModel.entry.ToString();
              
      
                    WhatsappModel message = new WhatsappModel();
                    message.messagingproduct = "whatsapp";
                    message.to = whatsappModel.from.ToString();

                 //fetching data what to send
                    message.text = whatsappModel.body.ToString();

              
                    await _whatsappService.SendMessageAsync(message, senderId);
                    return Ok("not found");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
                return BadRequest();
            }

        }

    }
}