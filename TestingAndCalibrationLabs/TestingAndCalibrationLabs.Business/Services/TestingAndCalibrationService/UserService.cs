using System;
using System.Collections.Generic;
using System.Text;
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

        public UserModel EmailValidationStatusUpdate(int userId)
        {
           return _userRepository.EmailValidationStatusUpdate(userId);
        }

        public List<string> Get()
        {
            return _userRepository.Get();
        }

        public UserModel Get(int id)
        {
            return _userRepository.Get(id);
        }

        public UserModel Get(string userName)
        {
            return _userRepository.Get(userName);
        }

        public UserModel GetEmail(string Email)
        {
            return _userRepository.GetEmail(Email);
        }

        public int Insert(UserModel user, PasswordLogin passwordLogin)
        {
            return _userRepository.Insert(user, passwordLogin);
        }

        public UserModel SelectEmail(int userId)
        {
            return _userRepository.SelectEmail(userId);
        }

        public int UpdatePassword(UserModel UserModel)
        {
            return _userRepository.UpdatePassword(UserModel);
        }

        /// <summary>
        /// Method to EmailValidation Status update in DB after OTP validation.
        /// </summary>
        /// <param name="user"></param>
        public RequestResult<int> EmailValidationStatus(int userId)
        {
            _userRepository.EmailValidationStatusUpdate(userId);
            return new RequestResult<int>(1);
        }

        /// <summary>
        /// Method to EmailValidation Status update in DB after OTP validation.
        /// </summary>
        /// <param name="user"></param>
        public RequestResult<int> MobileValidationStatus(int userId)
        {
            _userRepository.MobileValidationStatusUpdate(userId);
            return new RequestResult<int>(1);
        }
    }
}
