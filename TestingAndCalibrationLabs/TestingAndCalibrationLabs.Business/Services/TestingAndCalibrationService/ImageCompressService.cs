using ImageProcessor.Plugins.WebP.Imaging.Formats;
using System.IO;
using ImageProcessor;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using TestingAndCalibrationLabs.Business.Core.Model;
using System.Collections.Generic;
using MimeKit;
using Org.BouncyCastle.Utilities.Zlib;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Class For Image Compress
    /// </summary>
    public class ImageCompressService : IImageCompressService
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
        public ImageCompressService(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _WebHostingEnviroment = webHostEnvironment;
            _configuration = configuration;
        }
        /// <summary>
        /// Method To Compress Image 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public AttachmentModel ImageCompress(IFormFile file)
        {
            string ImageUrl;


            ImageUrl = file.FileName;
            string FilePathDelete = Path.Combine(_WebHostingEnviroment.WebRootPath, _configuration["DownloadData:FolderName"], file.FileName);
            if (File.Exists(FilePathDelete))
            {
                File.Delete(FilePathDelete);
            }
            string extensionName = Path.GetExtension(file.FileName);
            var fileName = Guid.NewGuid().ToString() + DateTime.Now.ToString("yyyymmddMMss") + extensionName;
            string filePath = Path.Combine(_WebHostingEnviroment.WebRootPath, _configuration["DownloadData:FolderName"], fileName); 
            try
            {
                using (var imgData = new FileStream(filePath, FileMode.Create))
                {
                    if (!AllowedFileTypesForCompression.ContainsValue(file.ContentType) || file.Length < 100000)
                    {
                        using (Stream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                        {
                            file.CopyTo(fileStream);
                        }

                        //using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
                        //{
                        //    imageFactory.Load(file.OpenReadStream())
                        //            .Save(imgData);

                        var imgDatas = new AttachmentModel()
                            {
                                ContentType = file.ContentType,
                                FilePath = filePath,
                                FileName = fileName,
                            };
                            return imgDatas;
                        
                    }
                    if (file != null && file.Length > 100000 && file.Length < 30000000)
                    {
                        using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
                        {
                            imageFactory.Load(file.OpenReadStream())
                                    .Format(new WebPFormat())
                                    .Quality(2)
                                    .Save(imgData);
                            var imageDatas = new AttachmentModel()
                            {
                                FileName = fileName,
                                FilePath = filePath,
                                ContentType = file.ContentType
                            };
                            return imageDatas;
                        }
                    }

                }
            }
            finally
            {
            }
            return null;
        }
    }
}

