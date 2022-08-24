using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using TestingAndCalibrationLabs.Web.UI.Common;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class TestReportModel 
    {
        /// <summary>
        /// Unique Id of the data
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the Party/ Customer
        /// </summary>
        [Required(ErrorMessage ="Please enter the name")]
        public string Name { get; set; }

        /// <summary>
        /// JobId 
        /// </summary>
        [Required(ErrorMessage = "Please enter JobId")]
        [DataType(DataType.PhoneNumber)]
        public string JobId { get; set; }

        /// <summary>
        /// Cleint Name
        /// </summary>
        [Required(ErrorMessage = "Please enter client name")]
        public string Client { get; set; }

        /// <summary>
        /// Email address of the User
        /// </summary>
        [Required(ErrorMessage = "Please enter your email address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        //[MaxLength(50)]
        [RegularExpression("[a-z0-9._%+-]+@[a-z0-9.-]+.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string Email { get; set; }

        /// <summary>
        /// url from where the file is uploaded
        /// </summary>
        [Required(ErrorMessage = "Please select data to upload")]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png",".pdf" })]
        [MaxFileSize(30000000)]
        
        public IFormFile DataUrl { get; set; }
        
        /// <summary>
        /// Location of the file where it is saved locally or on the cloud
        /// </summary>
        public string   FilePath { get; set; }

        /// <summary>
        /// Time when the UI is used
        /// </summary>
        public DateTime DateTime { get; set; }
    }
}