using Microsoft.AspNetCore.Http;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service Interface For file Compression
    /// </summary>
    public interface IFileCompressionService
    {
        /// <summary>
        /// This Method Is Used To Compress Images 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        void ImageCompression(IFormFile file,string filePath);
    }
}
