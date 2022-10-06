using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service Interface For Image Compress
    /// </summary>
    public interface IFileCompressionService
    {
        /// <summary>
        /// This Method Is Used To Compress Images 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        void ImageCompress(IFormFile file,string filePath);
    }
}
