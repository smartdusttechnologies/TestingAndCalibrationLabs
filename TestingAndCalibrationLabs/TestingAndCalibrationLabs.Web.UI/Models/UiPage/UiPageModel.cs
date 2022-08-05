using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models.UiPage
{
    public class UiPageModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        
    }
}
