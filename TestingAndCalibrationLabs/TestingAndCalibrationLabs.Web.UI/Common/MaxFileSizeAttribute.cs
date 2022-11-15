using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestingAndCalibrationLabs.Web.UI.Common
{
    /// <summary>
    /// To check the file (Image) size 
    /// </summary>
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;
        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }
        /// <summary>
        /// File Size check (image) is of 100Kb or more.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                if (file.Length > _maxFileSize)
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }
            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return $"Maximum allowed file size is { _maxFileSize/1000} KB.";
        }
    }
}
