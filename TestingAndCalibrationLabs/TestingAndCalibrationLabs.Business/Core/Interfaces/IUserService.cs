using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Get All Record From User Services
        /// </summary>
        List<UserModel> Get();

        /// <summary>
        /// Insert Record In User Services
        /// </summary>
        /// <param name="userModel"></param>
        RequestResult<int> Create(UserModel userModel);

        /// <summary>
        /// Delete Record In User Services
        /// </summary>
        /// <param name="id"></param>
        bool Delete(int id);

        /// <summary>
        /// Get Record By Id From User Services
        /// </summary>
        /// <param name="id"></param>
        UserModel GetById(int id);

        /// <summary>
        /// Edit Record From User Services
        /// </summary>
        /// <param name="userModel"></param>
        /// <param Id="id"></param>
        RequestResult<int> Update(int id, UserModel userModel);

        public UserModel Get(int id);
    }
}