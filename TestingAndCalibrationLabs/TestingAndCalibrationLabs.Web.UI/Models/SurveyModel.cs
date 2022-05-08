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
        internal string Testing;

        //public int Id { get; set; }
        /// <summary>
        /// Name of the Person
        /// </summary>
        [Required(ErrorMessage ="Name required")]
        public string Name { get; set; }

        /// <summary>
        /// Mobile Number
        /// </summary>
        [Required,MaxLength(10, ErrorMessage = "Mobile no. is required")]
        [RegularExpression(@"^([6-9]{1}[0-9]{9})$", ErrorMessage = "Mobile no. required")]
        public string Mobile { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        [Required, EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Communication address
        /// </summary>    
        [Required(ErrorMessage = "Address required")]
        public string Address { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [Required(ErrorMessage = "City required")]
        public string City { get; set; }
        
        /// <summary>
        /// State to which Person belongs
        /// </summary>
        [Required(ErrorMessage = "State required")]
        public string State { get; set; }
        
        /// <summary>
        /// Pin code
        /// </summary>
        [Required,MaxLength(6, ErrorMessage = "Pin code is required")]
        [RegularExpression(@"^([1-9]{1}[0-9]{5})$", ErrorMessage = "Fill 6 digit pin code ")]
        public string PinCode { get; set; }
        
        /// <summary>
        /// Comment concernced to Survey
        /// </summary>
        [Required(ErrorMessage = "Comment is required")]
        public string Comments { get; set; }

        /// <summary>
        /// Test type selected
        /// </summary>
        [Required(ErrorMessage = "Testing Type required")]
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