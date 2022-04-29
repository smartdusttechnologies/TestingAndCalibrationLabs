using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    /// <summary>
    /// Controllers Loads the Home Page Application
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Default Action of the Home Cotroller
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        
        
    }
}
