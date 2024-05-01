using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services.TestingAndCalibrationService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        /// <summary>
        /// Check Email Status and get validate
        /// </summary>
        /// <param name="userId"></param>
        public UserModel EmailValidationStatusUpdate(int userId)
        {
           return _userRepository.EmailValidationStatusUpdate(userId);
        }
        /// <summary>
        /// Get the user Email
        /// </summary>
        public List<string> Get()
        {
            return _userRepository.Get();
        }
        /// <summary>
        /// Get user Detail based on Id
        /// </summary>
        /// <param name="id"></param>
        public UserModel Get(int id)
        {
            return _userRepository.Get(id);
        }
        /// <summary>
        /// GET User Deatail based on userName
        /// </summary>
        /// <param name="userName"></param>
        public UserModel Get(string userName)
        {
            return _userRepository.Get(userName);
        }
        /// <summary>
        /// Get User Email
        /// </summary>
        /// <param name="Email"></param>
        public UserModel GetEmail(string Email)
        {
            return _userRepository.GetEmail(Email);
        }
        /// <summary>
        /// inser user detail 
        /// </summary>
        /// <param name="user"></param>
        public int Insert(UserModel user, PasswordLogin passwordLogin)
        {
            return _userRepository.Insert(user, passwordLogin);
        }
        /// <summary>
        /// Send Email For the user register Email
        /// </summary>
        /// <param name="userId"></param>
        public UserModel SelectEmail(int userId)
        {
            return _userRepository.SelectEmail(userId);
        }
        /// <summary>
        /// Update user password
        /// </summary>
        /// <param name="user"></param>
        public int UpdatePassword(UserModel UserModel)
        {
            return _userRepository.UpdatePassword(UserModel);
        }

        /// <summary>
        /// Method to EmailValidation Status update in DB after Email validation.
        /// </summary>
        /// <param name="user"></param>
        public RequestResult<int> EmailValidationStatus(int userId)
        {
            _userRepository.EmailValidationStatusUpdate(userId);
            return new RequestResult<int>(1);
        }

        /// <summary>
        /// Method to MobileValidation Status update in DB after Mobile validation.
        /// </summary>
        /// <param name="user"></param>
        public RequestResult<int> MobileValidationStatus(int userId)
        {
            _userRepository.MobileValidationStatusUpdate(userId);
            return new RequestResult<int>(1);
        }
    }
}
