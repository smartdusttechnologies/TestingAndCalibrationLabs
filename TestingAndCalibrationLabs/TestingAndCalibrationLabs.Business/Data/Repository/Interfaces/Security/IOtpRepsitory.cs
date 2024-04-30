using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    public interface IOtpRepsitory
    {
        /// <summary>
        /// Interface to insert and update otp in DB.
        /// </summary>
        /// <param name="otp"></param>
        /// <param name="userId"></param>
        OtpModel InsertOtp(string otp, int userId);
        /// <summary>
        /// Inetface to Select Otp.
        /// </summary>
        /// <param name="userId"></param>
        OtpModel GetOTP(int userId);
    }
}
