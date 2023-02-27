using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{

    public class ApplicationDTO
    {
        
        public int Id { get; set; }
      
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Please Enter Description")]
        public string Description { get; set; }
    }
}
