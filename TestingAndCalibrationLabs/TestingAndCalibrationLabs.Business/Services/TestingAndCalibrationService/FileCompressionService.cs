using ImageProcessor.Plugins.WebP.Imaging.Formats;
using System.IO;
using ImageProcessor;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Class For Image Compress
    /// </summary>
    public class FileCompressionService : IFileCompressionService
    {
        private readonly Dictionary<string, string> AllowedFileTypesForCompression = new Dictionary<string, string>()
        {
            {".png", "image/png"},
            {".jpg", "image/jpeg"},
            {".jpeg", "image/jpeg"},
            {".gif", "image/gif"}
        };
        private readonly IWebHostEnvironment _WebHostingEnviroment;
        public readonly IConfiguration _configuration;

        /// <summary>
        /// Cunstructor
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        /// <param name="configuration"></param>
        public FileCompressionService(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _WebHostingEnviroment = webHostEnvironment;
            _configuration = configuration;
        }
        /// <summary>
        /// Method To Compress Image And If File Is not Compressable Type Then Saving To DownloadedTemp And Then Returning FilePath
        /// </summary>
        /// <param name="file"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public void ImageCompression(IFormFile file, string filePath)
        {
            try
            {
                using (var imgData = new FileStream(filePath, FileMode.Create))
                {
                    using (var fileStream = file.OpenReadStream())
                    {
                        if (!AllowedFileTypesForCompression.ContainsValue(file.ContentType) || file.Length < 100000)
                        {
                            fileStream.CopyToAsync(imgData);
                            return;
                        }
                        if (file != null && file.Length > 100000 && file.Length < 30000000)
                        {
                            using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
                            {
                                imageFactory.Load(file.OpenReadStream())
                                        .Format(new WebPFormat())
                                        .Quality(2)
                                        .Save(imgData);
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO: log the error and send the original file back
            }
            return;
        }
    }
}

