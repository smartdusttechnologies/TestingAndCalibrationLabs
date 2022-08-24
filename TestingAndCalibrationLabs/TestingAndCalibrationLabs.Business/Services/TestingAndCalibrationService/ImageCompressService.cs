using ImageProcessor.Plugins.WebP.Imaging.Formats;
using System.IO;
using ImageProcessor;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Services
{
    public class ImageCompressService : IImageCompressService
    {
        public readonly IWebHostEnvironment _WebHostingEnviroment;
        public readonly IConfiguration _configuration;
        public ImageCompressService(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _WebHostingEnviroment = webHostEnvironment;
            _configuration = configuration;
        }
        public AttachmentModel ImageCompress(IFormFile file)
        {
            if (file.Length < 100000)
            {
                string extensionName = Path.GetExtension(file.FileName);
                var fileName = Guid.NewGuid().ToString() + DateTime.Now.ToString("yyyymmddMMss") + extensionName;
                string filePath = Path.Combine(_WebHostingEnviroment.WebRootPath, _configuration["DownloadData:FolderName"], fileName);
                try
                {
                    using (var imgData = new FileStream(filePath, FileMode.Create))
                    {
                        using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
                        {
                            imageFactory.Load(file.OpenReadStream())
                                    .Save(imgData);
                            var imgDatas = new AttachmentModel()
                            {
                                ContentType = file.ContentType,
                                FilePath = filePath,
                                FileName = fileName,

                            };
                            return imgDatas;
                        }
                    }
                }
                finally
                {

                }

            }
            string ImageUrl;
            if (file != null && file.Length > 100000 && file.Length < 30000000)
            {
                ImageUrl = file.FileName;
                string FilePathDelete = Path.Combine(_WebHostingEnviroment.WebRootPath, _configuration["DownloadData:FolderName"], file.FileName);
                if (File.Exists(FilePathDelete))
                {
                    File.Delete(FilePathDelete);
                }
                //string filePath = Path.Combine(_WebHostingEnviroment.WebRootPath, _configuration["UploadData:FolderName"], ImageUrl);
                string extensionName = Path.GetExtension(file.FileName);
                var fileName = Guid.NewGuid().ToString() + DateTime.Now.ToString("yyyymmddMMss") + extensionName;
                string filePath = Path.Combine(_WebHostingEnviroment.WebRootPath, _configuration["DownloadData:FolderName"], fileName);
                try
                {
                    using (var imgData = new FileStream(filePath, FileMode.Create))
                    {
                        using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
                        {
                            imageFactory.Load(file.OpenReadStream())
                                    .Format(new WebPFormat())
                                    .Quality(2)
                                    .Save(imgData);
                            //TempImages
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
                finally
                {
                    
                }
                
            }
            return null;
        }
    }
}
