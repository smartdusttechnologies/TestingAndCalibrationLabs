using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice
{
    public interface IPermissionService
    {
        /// <summary>
        /// Get All Record From Permission
        /// </summary>
        List<PermissionModel> Get();

        /// <summary>
        /// Get Record By Id From Permission 
        /// </summary>
        /// <param name="id"></param>
        PermissionModel GetById(int id);
        /// <summary>
        /// Insert Record From Permission 
        /// </summary>
        /// <param name="permissionModel"></param>
        RequestResult<int> Create(PermissionModel permissionModel);
        /// <summary>
        /// Edit Record From Permission 
        /// </summary>
        /// <param name="permissionModel"></param>
        /// <param Id="id"></param>
        RequestResult<int> Update(int id, PermissionModel permissionModel);
        /// <summary>
        /// Delete Record From Permission 
        /// </summary>
        /// <param name="id"></param>
        bool Delete(int id);
    }
}
