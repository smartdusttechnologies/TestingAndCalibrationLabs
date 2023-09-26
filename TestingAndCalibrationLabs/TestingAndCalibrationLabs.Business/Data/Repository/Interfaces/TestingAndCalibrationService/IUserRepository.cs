using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;
namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Interface To Select User.
        /// </summary>
        List<string> Get();
        /// <summary>
        /// Interface to get username on t5he basis of Id.
        /// </summary>
        /// <param name="id"></param>
        UserModel Get(int id);
        /// <summary>
        /// Interface For authenticate At time of login
        /// </summary>
        /// <param name="userName"></param>
        UserModel Get(string userName);
        /// <summary>
        /// Interface To Insert password 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="passwordLogin"></param>
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
        UserModel SelectEmail(int userId);

    }
}