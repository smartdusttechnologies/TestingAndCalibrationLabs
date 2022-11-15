using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TestingAndCalibrationLabs.Web.UI.Common
{
        /// <summary>
        ///Check the File type upload i.e. it should be '.jpeg', '.jpg','.png' only 
        /// </summary>
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;
        public AllowedExtensionsAttribute(string[] extensions)
        {
            _extensions = extensions;
        }
        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                if (!_extensions.Contains(extension.ToLower()))
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }
            return ValidationResult.Success;
        }
        public string GetErrorMessage()
        {
            return $"Only jpg, jpeg, png, pdf, doc, docs, xls, xlxs - type of files allowed.";
        }
    }
}
