using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Core.Model.Common
{
    public  class TemplateModel
    {
        public int Id { get; set; }
        /// <summary>
        /// To Get the Name Of Template
        /// </summary>
        public string TemplateName { get; set; }

        /// <summary>
        /// To Store HtmlFile
        /// </summary>
        
        public IFormFile DataUrl { get; set; }

        /// <summary>
        /// To Store the Name of File
        /// </summary>
        public int FileId { get; set; }
       
    }
}
