using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice
{
    /// <summary>
    /// Service interface for Permission Module Type Services
    /// </summary>
    public interface IPermissionModuleTypeService
    {
        /// <summary>
        /// Get All Record From Permission Module Type Services
        /// </summary>
        List<PermissionModuleTypeModel> Get();

        /// <summary>
        /// Insert Record In Permission Module Type Services
        /// </summary>
        /// <param name="permissionModuleTypeModel"></param>
        /// <returns></returns>
        RequestResult<int> Create(PermissionModuleTypeModel permissionModuleTypeModel);

        /// <summary>
        /// Delete Record In Permission Module Type Services
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

        /// <summary>
        /// Get Record By Id From Permission Module Type Services
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PermissionModuleTypeModel GetById(int id);

        /// <summary>
        /// Edit Record From Permission Module Type Services
        /// </summary>
        /// <param name="permissionModuleTypeModel"></param>
        /// <param Id="id"></param>
        /// <returns></returns>
        RequestResult<int> Update(int id, PermissionModuleTypeModel permissionModuleTypeModel);
    }
}