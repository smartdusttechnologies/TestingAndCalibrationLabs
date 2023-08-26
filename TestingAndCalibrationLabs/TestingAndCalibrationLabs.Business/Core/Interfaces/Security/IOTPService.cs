using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.TestingAndCalibration
{
    public interface IOTPService
    {
        RequestResult<int> EmailValidateForgotPassword(OtpModel OtpModel);
        RequestResult<int> CreateOtp(OtpModel otpModel, int userId);
        RequestResult<int> ValidateOTP(OtpModel OtpModel);
        //void CreateOtp(string email, int userId);
    }
}