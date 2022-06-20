using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface IGoogleUploadService
    {
        //void UploadFile(IFormFile dataUrl, NewUIModel getbusinessModel);
        string CreateFolder(string v1, string v2);
        void UploadFile(NewUIModel getbusinessModel);
        
    }
}