using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class TemplateDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter The TemplateName")]
        public string  TemplateName{get;set;}

        /// <summary>
        /// To Store HtmlFile
        /// </summary>
        [Required(ErrorMessage = "Please select data to upload")]        
        public IFormFile DataUrl { get; set; }

       /// <summary>
       /// It will store the Name of the File
       /// </summary>
        public int FileId { get; set; }
        
        
    }
}
