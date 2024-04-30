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
        /// it Send the Otp For the User Email or Mobile
        /// </summary>
        /// <param name="r"></param>
        /// <param name="isMobile"></param>
        /// <returns></returns>
        Task<RequestResult<bool>> SendOtp(OtpModel OtpModel);
        /// <summary>
        /// it Verify the otp
        /// </summary>
        /// <param name="r"></param>
        /// <param name="isMobile"></param>
        /// <returns></returns>
        Task<RequestResult<bool>> VerifyOtp(OtpModel OtpModel);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        RequestResult<bool> MobileVerify(string mobile, int userId);
        /// <summary>
        /// it validate the MobileNumber
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        RequestResult<bool> MobileValidate(int userId);
    }
}