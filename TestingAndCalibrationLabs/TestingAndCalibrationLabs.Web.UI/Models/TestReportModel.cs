using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using TestingAndCalibrationLabs.Web.UI.Common;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class TestReportModel 
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter the name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter JobId")]
        [DataType(DataType.PhoneNumber)]
        public string JobId { get; set; }

        [Required(ErrorMessage = "Please enter client name")]
        public string Client { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        //[MaxLength(50)]
        [RegularExpression("[a-z0-9._%+-]+@[a-z0-9.-]+.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please select data to upload")]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png",".pdf" })]
        [MaxFileSize(100000)]
        public IFormFile DataUrl { get; set; }
        
        public string   FilePath { get; set; }

        public DateTime DateTime { get; set; }
    }
}
