using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Services.TestingAndCalibrationService
{
    /// <summary>
    /// This class is To Perform all Document Related Work
    /// </summary>
    public class DocumentService : IDocumentService
    {

        private readonly ICommonService _commonService;

        public DocumentService(ICommonService commonService)
        {
            _commonService = commonService;


        }
        /// <summary>
        /// THis will convert the Image into ITs Original File
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

        public IFormFile FileConverter(int Id)
        {

            IFormFile formFile;
            FileUploadModel attachment = _commonService.DownloadImage(Id);


            using (var memoryStream = new MemoryStream(attachment.DataFiles))
            {

               
                formFile = new FormFile(memoryStream, 0, memoryStream.Length, null, attachment.Name)
                {
                    Headers = new HeaderDictionary
                    {
                       { "Content-Disposition", $"attachment; filename=\"{attachment.Name}\"" }
                    },
                    ContentType = attachment.FileType
                };


            }
            return formFile;

        }
        /// <summary>
        /// This method is to insert a File
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public FileUploadModel FileUpload(IFormFile file)
        {

            
            var ImageName = Path.GetFileName(file.FileName);
            
            var ImageExtension = Path.GetExtension(ImageName);
            
            var NewImageName = String.Concat(Convert.ToString(Guid.NewGuid()), ImageExtension);
            var ObjImage = new FileUploadModel()
            {
                Name = NewImageName,
                FileType = ImageExtension,
                CreatedOn = DateTime.Now
            };
            using (var target = new MemoryStream())
            {
                file.CopyTo(target);
                ObjImage.DataFiles = target.ToArray();
            }

            return (ObjImage);

        }
       
        /// <summary>
        /// To Update the File
        /// </summary>
        /// <param name="id"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public bool ImageFileUpdate(int id, IFormFile file)
        {
            var ObjImage = FileUpload(file);


            return _commonService.FileUpdate(id, ObjImage);
             
        }
    }
}
