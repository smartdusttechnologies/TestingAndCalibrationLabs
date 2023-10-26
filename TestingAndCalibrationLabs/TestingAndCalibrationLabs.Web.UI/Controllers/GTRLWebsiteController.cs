using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class GTRLWebsiteController : Controller
    {
        public IActionResult GtrlWeb()
        {
            GTRLWebsiteDTO gtrlWeb = new GTRLWebsiteDTO();
            HeaderStripDTO headerStrip = new HeaderStripDTO
            {
                CompanyLogo = "/Image/Logo.gif",
                Contact = "9854263510",
                Email = "gtrlweb@gmail.com",
                linkedlnURL = "https://www.linkedin.com/login",
                FacebookURL = "https://www.facebook.com/login",
                XUrl = "https://twitter.com/"
            };
            gtrlWeb.HeaderStrips = new List<HeaderStripDTO> { headerStrip };
            var imageSlider = new List<ImageSliderDTO>
            {
             new ImageSliderDTO { Image = "http://www.gtrl.org.in/images/header1.jpg", Header = "Nilesh", Paragraph = "Kumar" },
             new ImageSliderDTO { Image = "http://www.gtrl.org.in/images/header2.jpg", Header="Rahul",Paragraph ="Singh" },
             new ImageSliderDTO { Image = "http://www.gtrl.org.in/images/header3.jpg", Header="Ranveer",Paragraph ="Singh" },
             new ImageSliderDTO { Image = "http://www.gtrl.org.in/images/header4.jpg", Header ="Shohan",Paragraph = "Singh" }
            };
            gtrlWeb.imageSlider = imageSlider;
            return View(gtrlWeb);
        }
        public IActionResult gtrlWebService()
        {
            return View(new GTRLWebsiteDTO { });
        }
    }
}
