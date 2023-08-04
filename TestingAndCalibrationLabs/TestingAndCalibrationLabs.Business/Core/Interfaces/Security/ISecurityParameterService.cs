﻿using Google.Apis.Drive.v3.Data;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

using TestingAndCalibrationLabs.Business.Core.Model;
namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface ISecurityParameterService
    {
        /// <summary>
        /// Interfaces to validate Newuser Policy
        /// </summary>
        RequestResult<bool> ValidateNewuserPolicy(UserModel user);
        RequestResult<bool> ValidatePasswordPolicy( int orgId, string Password);
        RequestResult<bool> ChangePasswordCondition(ForgotPasswordModel forgotPasswordModel);
    }
}