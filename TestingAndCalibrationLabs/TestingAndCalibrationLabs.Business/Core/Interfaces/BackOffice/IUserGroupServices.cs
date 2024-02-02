using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice
{
    public interface IUserGroupServices
    {
        /// <summary>
        /// Get All Record From User Group
        /// </summary>
        List<UserGroupModel> Get();

        /// <summary>
        /// Get Record By Id From User Group 
        /// </summary>
        /// <param name="id"></param>
        UserGroupModel GetById(int id);
        /// <summary>
        /// Insert Record From User Group  
        /// </summary>
        /// <param name="userGroupModel"></param>
        RequestResult<int> Create(UserGroupModel userGroupModel);
        /// <summary>
        /// Edit Record From User Group 
        /// </summary>
        /// <param name="userGroupModel"></param>
        /// <param Id="id"></param>
        RequestResult<int> Update(int id, UserGroupModel userGroupModel);
        /// <summary>
        /// Delete Record From User Group  
        /// </summary>
        /// <param name="id"></param>
        bool Delete(int id);
    }
}
