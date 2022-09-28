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
using System.Threading;
using System.Threading.Tasks;

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
        /// <summary>
        /// Cunstructor
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        /// <param name="configuration"></param>
        public ImageCompressService(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _WebHostingEnviroment = webHostEnvironment;
            _configuration = configuration;
        }
        /// <summary>
        /// Method To Compress Image And If File Is not Compressable Type Then Saving To DownloadedTemp And Then Returning FilePath
        /// </summary>
        /// <param name="file"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async  Task<AttachmentModel> ImageCompress(IFormFile file, CancellationToken cancellationToken)
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
                    using (var fileStream = file.OpenReadStream())
                    {
                        await fileStream.CopyToAsync(imgData, cancellationToken);

                        if (!AllowedFileTypesForCompression.ContainsValue(file.ContentType) || file.Length < 100000)
                        {
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
            }
            catch(Exception ex)
            {

                Console.WriteLine(ex);
                return null;
            }
            return null;
        }
    }
}

