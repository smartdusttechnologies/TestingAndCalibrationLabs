using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class SurveyModel
    {
        //public int Id { get; set; }

        [Required(ErrorMessage ="Name required")]
        public string Name { get; set; }

        [Required,MaxLength(10, ErrorMessage = "Mobile no. required")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Mobile no. required")]
        public string Mobile { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Testing Type required")]
        public string TestingType { get; set; }
        
        [Required(ErrorMessage = "Address required")]
        public string Address { get; set; }
        
        [Required(ErrorMessage = "City required")]
        public string City { get; set; }
        
        [Required(ErrorMessage = "State required")]
        //public string State { get; set; }
        public string State { get; set; }
        
        [Required,MaxLength(6, ErrorMessage = "Pin code required")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Fill 6 digit pin code ")]
        public string PinCode { get; set; }
        
        [Required(ErrorMessage = "Comment required")]
        public string Comments { get; set; }
    }
}