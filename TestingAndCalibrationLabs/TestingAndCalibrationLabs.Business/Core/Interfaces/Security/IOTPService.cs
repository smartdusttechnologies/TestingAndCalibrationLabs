using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.TestingAndCalibration
{
    public interface IOTPService
    {
        /// <summary>
        /// Interface for Email validation for FogetPassword.
        /// </summary>
        /// <param name="user"></param>
        //RequestResult<int> EmailValidateForgotPassword(OtpModel OtpModel);
        RequestResult<(int UserId, string UserName)> EmailValidateForgotPassword(OtpModel OtpModel);

        /// <summary>
        /// Interface for CreateOTP.
        /// </summary>
        /// <param name="user"></param>
        //RequestResult<int> CreateOtp(OtpModel otpModel, int userId);
        RequestResult<int> CreateOtp(OtpModel otpModel, int userId, string name);

        /// <summary>
        /// Interface for ValidateOTP .
        /// </summary>
        /// <param name="user"></param>
        RequestResult<int> ValidateOTP(OtpModel OtpModel);
        /// <summary>
        /// Interface for Resend OTP .
        /// </summary>
        /// <param name="user"></param>
        RequestResult<int> ResendOTP(OtpModel OtpModel);


    }
}