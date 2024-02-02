using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.BackOffice
{
    public interface IUserRoleRepository
    {
        /// <summary>
        /// Get All Records From User Role
        /// </summary>
        List<UserRoleModel> Get();

        /// <summary>
        /// Get Record By Id From User Role
        /// </summary>
        /// <param name="id"></param>
        UserRoleModel GetById(int id);
        /// <summary>
        /// Insert Record In User Role
        /// </summary>
        /// <param name="userRoleModel"></param>
        int Create(UserRoleModel userRoleModel);
        /// <summary>
        /// Update Record In User Role
        /// </summary>
        /// <param name="userRoleModel"></param>
        int Update(UserRoleModel userRoleModel);
    }
}
