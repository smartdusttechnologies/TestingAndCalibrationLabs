using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.BackOffice
{
    public interface IUserGroupRepository
    {
        /// <summary>
        /// Get All Records From User Group
        /// </summary>
        List<UserGroupModel> Get();

        /// <summary>
        /// Get Record By Id From User Group
        /// </summary>
        /// <param name="id"></param>
        UserGroupModel GetById(int id);
        /// <summary>
        /// Insert Record In User Group
        /// </summary>
        /// <param name="userGroupModel"></param>
        int Create(UserGroupModel userGroupModel);
        /// <summary>
        /// Update Record In User Group
        /// </summary>
        /// <param name="userGroupModel"></param>
        int Update(UserGroupModel userGroupModel);
    }
}
