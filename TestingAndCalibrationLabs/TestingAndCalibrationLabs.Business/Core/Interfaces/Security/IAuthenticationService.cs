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
        //TODo: This should be moved to User service.
        RequestResult<bool> Add(UserModel user, string password);
        /// <summary>
        /// Interface to update the user password when user forget password and reset password
        /// </summary>
        /// <param name="UserModel"></param>
        RequestResult<bool> UpdatePassword(UserModel UserModel);
        /// <summary>
        /// Interface for Update EmailValidationStatus  if user sign-up Successfully with OTP validation.
        /// </summary>
        /// <param name="user"></param>
        RequestResult<int> EmailValidationStatus(UserModel user);

         RequestResult<int> ExistingEmailVerify(UserModel user);
        //RequestResult<bool> ExistingEmailVerify(UserModel user);


    }
}