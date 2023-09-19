using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface IDocumentService
    {
        /// <summary>
        /// To Convert into File 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public FileUploadModel FileUpload(IFormFile file);

        public IFormFile FileConverter(int Id);

        /// <summary>
        /// To Update in a File
        /// </summary>
        /// <param name="id"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public bool ImageFileUpdate(int id, IFormFile file);

    }
}
