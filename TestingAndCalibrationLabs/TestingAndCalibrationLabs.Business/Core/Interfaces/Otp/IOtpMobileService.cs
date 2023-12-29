using System.Threading.Tasks;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces.Otp
{
    public interface IOtpMobileService
    {
        /// <summary>
        /// Interface Method For Resend Otp Of Email
        /// </summary>
        /// <param name="OtpModel"></param>
        /// <returns>RequestResult</returns>
        Task<RequestResult<bool>> ResendOtp(OtpModel OtpModel);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <param name="isMobile"></param>
        /// <returns></returns>
        Task<RequestResult<bool>> SendOtp(OtpModel r);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <param name="isMobile"></param>
        /// <returns></returns>
        Task<RequestResult<bool>> VerifyOtp(OtpModel r);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        RequestResult<bool> MobileVerify(string mobile, int userId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        RequestResult<bool> MobileValidate(int userId);
    }
}