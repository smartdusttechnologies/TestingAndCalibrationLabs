﻿using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Interface Implementation For Authentication
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Abstract Method For Login
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        RequestResult<LoginToken> Login(LoginRequest loginRequest);
        /// <summary>
        /// Interfaces to Add new and validate existing user for Registration
        /// </summary>
        RequestResult<bool> Add(UserModel user, string password);
        /// <summary>
        /// Interfaces to  Update Password for existing User 
        /// </summary>
        RequestResult<bool> UpdatePassword(ChangePasswordModel changePasswordModel);
    }
}