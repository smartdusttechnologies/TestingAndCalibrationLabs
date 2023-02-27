using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
 
    public class ActivityDTO
    {
     
        public int Id { get; set; }
       
        [Required(ErrorMessage = "Please Enter  Name")]
        public string Name { get; set; }


    }
}
