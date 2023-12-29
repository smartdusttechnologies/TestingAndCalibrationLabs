using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces.Otp
{
    public interface IOtpEmailService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <param name="isMobile"></param>
        /// <returns></returns>
        RequestResult<bool> ResendOtp(OtpModel r);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <param name="isMobile"></param>
        /// <returns></returns>
        RequestResult<bool> SendOtp(OtpModel r);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <param name="isMobile"></param>
        /// <returns></returns>
        RequestResult<bool> VerifyOtp(OtpModel r);
    }
}