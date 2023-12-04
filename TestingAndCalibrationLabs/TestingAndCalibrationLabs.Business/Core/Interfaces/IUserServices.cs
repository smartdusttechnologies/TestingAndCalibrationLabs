using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// To Get all Records From User table.
        /// </summary>
        /// <returns></returns>
        List<UserModel> Get();
    }
}
