using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice
{
    public interface IUserRoleService
    {
        /// <summary>
        /// Get All Record From User Role
        /// </summary>
        List<UserRoleModel> Get();

        /// <summary>
        /// Get Record By Id From User Role 
        /// </summary>
        /// <param name="id"></param>
        UserRoleModel GetById(int id);
        /// <summary>
        /// Insert Record From User Role  
        /// </summary>
        /// <param name="userRoleModel"></param>
        RequestResult<int> Create(UserRoleModel userRoleModel);
        /// <summary>
        /// Edit Record From User Role 
        /// </summary>
        /// <param name="userRoleModel"></param>
        /// <param Id="id"></param>
        RequestResult<int> Update(int id, UserRoleModel userRoleModel);
        /// <summary>
        /// Delete Record From User Role  
        /// </summary>
        /// <param name="id"></param>
        bool Delete(int id);
    }
}
