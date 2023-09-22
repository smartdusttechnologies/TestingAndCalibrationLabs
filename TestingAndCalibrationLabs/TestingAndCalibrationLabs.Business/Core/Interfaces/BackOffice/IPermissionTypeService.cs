using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice
{
    /// <summary>
    /// Service interface for Permission Type Services
    /// </summary>
    public interface IPermissionTypeService
    {
        /// <summary>
        /// Get All Record From Permission Type Services
        /// </summary>
        List<PermissionTypeModel> Get();

        /// <summary>
        /// Insert Record In Permission Type Services
        /// </summary>
        /// <param name="permissionTypeModel"></param>
        /// <returns></returns>
        RequestResult<int> Create(PermissionTypeModel permissionTypeModel);

        /// <summary>
        /// Delete Record In Permission Type Services
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

        /// <summary>
        /// Get Record By Id From Permission Type Services
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PermissionTypeModel GetById(int id);

        /// <summary>
        /// Edit Record From Permission Type Services
        /// </summary>
        /// <param name="permissionTypeModel"></param>
        /// <param Id="id"></param>
        /// <returns></returns>
        RequestResult<int> Update(int id, PermissionTypeModel permissionTypeModel);
    }
}
