
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
        public async Task<IActionResult> PostAsync([FromForm]WhatsappModel whatsappModel)
        {
            try
            {          
                {
                    //handle incoming message                           
                    string senderId = whatsappModel.phoneNumberId.ToString();
                    //when user request something via text or select something
                    // string incomingMessageText = whatsappModel.entry.ToString();

                    var Image = whatsappModel.Image;


                  //  var ImageName = Path.GetFileName(imagelenth.FileName);
                    //Getting file Extension
                 //   var ImageExtension = Path.GetExtension(Image);
                    // concatenating  FileName + FileExtension
                    var NewImageName = String.Concat(Convert.ToString(Guid.NewGuid()), Image);

                    WhatsappModel message = new WhatsappModel();
                    message.messagingproduct = "whatsapp";
                    message.to = whatsappModel.from.ToString();

                 //fetching data what to send
                 //   message.text = whatsappModel.Image.ToString();
                    message.text = NewImageName;

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
//List<string> imageId = new List<string>();

//foreach (var imagelenth in Request.Form.Files)
//{
//    if (imagelenth != null)
//    {
//        if (imagelenth.Length > 0)
//        {
//            //Getting FileName
//            var ImageName = Path.GetFileName(imagelenth.FileName);
//            //Getting file Extension
//            var ImageExtension = Path.GetExtension(ImageName);
//            // concatenating  FileName + FileExtension
//            var NewImageName = String.Concat(Convert.ToString(Guid.NewGuid()), ImageExtension);
//            var ObjImage = new FileUploadModel()
//            {
//                Name = NewImageName,
//                FileType = ImageExtension,
//                CreatedOn = DateTime.Now
//            };
//            using (var target = new MemoryStream())
//            {
//                imagelenth.CopyTo(target);
//                ObjImage.DataFiles = target.ToArray();
//            }
//            var Imagecollection = _commonService.ImageUpload(ObjImage);
//            imageId.Add(NewImageName.ToString());
//        }
//    }
//}
//retu