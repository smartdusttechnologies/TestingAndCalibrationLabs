using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;
namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        List<string> Get();
        UserModel Get(int id);
        UserModel Get(string userName);
        int Insert(UserModel user, PasswordLogin passwordLogin);
        /// <summary>
        /// Interface to update the user password when user forget password and reset password
        /// </summary>
        /// <param name="UserModel"></param>
        int UpdatePassword(UserModel UserModel);
        /// <summary>
        /// Interface for Update EmailValidationStatus if user sign-up Successfully with OTP validation.
        /// </summary>
        /// <param name="user"></param>
        UserModel EmailValidationStatusUpdate(int userId);
        /// <summary>
        /// Interface for  Existing Email
        /// </summary>
        /// <param name="user"></param>
        UserModel GetEmail(string Email);
    }
}