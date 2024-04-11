using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces.Otp
{
    public interface IOtpEmailService
    {
        /// <summary>
        /// It resends the otp.
        /// </summary>
        /// <param name="otpmodel"></param>
        /// <returns></returns>
        RequestResult<bool> ResendOtp(OtpModel otpmodel);
        /// <summary>
        /// It Send The otp
        /// </summary>
        /// <param name="r"></param>
        /// <param name="isMobile"></param>
        /// <returns></returns>
        RequestResult<bool> SendOtp(OtpModel r);
        /// <summary>
        /// It  Varify The Otp
        /// </summary>
        /// <param name="Otpmodel"></param>
        /// <returns></returns>
        RequestResult<bool> VerifyOtp(OtpModel Otpmodel);
    }
}