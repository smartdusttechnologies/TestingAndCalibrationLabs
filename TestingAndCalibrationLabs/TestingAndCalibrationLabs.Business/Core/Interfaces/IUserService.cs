using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// To accesss the user list 
        /// </summary>
        /// <returns></returns>
       List<UserModel> Get();
    }
}
