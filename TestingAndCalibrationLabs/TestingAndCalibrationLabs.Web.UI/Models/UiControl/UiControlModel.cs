using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models.UiControl
{
    public class UiControlModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your displayname")]
        public string DisplayName { get; set; }

        
    }
}

