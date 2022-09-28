using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service Interface For Image Compress
    /// </summary>
    public interface IImageCompressService
    {
        /// <summary>
        /// This Method Is Used To Compress Images 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<AttachmentModel> ImageCompress(IFormFile file,CancellationToken cancellationToken);
    }
}
