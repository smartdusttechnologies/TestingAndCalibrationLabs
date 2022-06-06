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
        /// <summary>
        /// Name of the Person
        /// </summary>
        [Required(ErrorMessage ="Please enter your name")]
        public string Name { get; set; }

        /// <summary>
        /// Mobile Number
        /// </summary>
        [Required(ErrorMessage = "Please enter 10 digit Mobile number")]
        [MaxLength(10, ErrorMessage = "Please enter 10 digit Mobile number")]
        [RegularExpression(@"^([6-9]{1}[0-9]{9})$", ErrorMessage = "Please enter valid Mobile number")]
        public string Mobile { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        [Required(ErrorMessage = "Please enter your email address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        [MaxLength(50)]
        [RegularExpression("[a-z0-9._%+-]+@[a-z0-9.-]+.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]

        //[Required, EmailAddress(ErrorMessage ="Please enter correct email id"]
        public string Email { get; set; }

        /// <summary>
        /// Communication address
        /// </summary>    
        [Required(ErrorMessage = "Please enter your address")]
        public string Address { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [Required(ErrorMessage = "City name is required")]
        public string City { get; set; }
        
        /// <summary>
        /// State to which Person belongs
        /// </summary>
        [Required(ErrorMessage = "State name is required")]
        public string State { get; set; }
        
        /// <summary>
        /// Pin code
        /// </summary>
        [Required(ErrorMessage = "Please fill 6 digit pin code")]
        [MaxLength(6, ErrorMessage ="Please enter 6 digit Pin code")] 
        [RegularExpression(@"^([1-9]{1}[0-9]{5})$", ErrorMessage = "Please fill valid pin code")]
        public string PinCode { get; set; }
        
        /// <summary>
        /// Comment concernced to Survey
        /// </summary>
        [Required(ErrorMessage = "Comment is required")]
        public string Comments { get; set; }

        /// <summary>
        /// Test type selected
        /// </summary>
        [Required(ErrorMessage = "Testing Type is required")]
        public Testing? TestingType { get; set; }
    }
    
    /// <summary>
    /// Types of Test
    /// </summary>
    public enum Testing
    {
        Testing, 
        Calibration, 
        Other
    }
}