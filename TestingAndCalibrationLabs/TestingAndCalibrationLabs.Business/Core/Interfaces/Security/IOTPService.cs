using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.TestingAndCalibration
{
    public interface IOTPservice
    {
        RequestResult<bool> ResendEmailOtp(OtpModel OtpModel);
        RequestResult<bool> ResendOtp(OtpModel r, bool isMobile);
        RequestResult<bool> SendOtp(OtpModel r, bool isMobile);
        RequestResult<bool> VerifyOtp(OtpModel r, bool isMobile);
    }
}