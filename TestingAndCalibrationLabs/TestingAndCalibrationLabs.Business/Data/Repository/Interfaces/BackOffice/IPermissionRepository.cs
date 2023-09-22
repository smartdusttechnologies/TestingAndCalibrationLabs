using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.BackOffice
{
    /// <summary>
    /// Repository interface for Permission 
    /// </summary>
    public interface IPermissionRepository
    {
        /// <summary>
        /// Get All Records From Permission 
        /// </summary>
        /// <returns></returns>
        List<PermissionModel> Get();

        /// <summary>
        /// Get Record By Id From Permission
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PermissionModel GetById(int id);
        /// <summary>
        /// Insert Record In Permission
        /// </summary>
        /// <param name="permissionModel"></param>
        /// <returns></returns>
        int Create(PermissionModel permissionModel);
        /// <summary>
        /// Update Record In Permission
        /// </summary>
        /// <param name="permissionModel"></param>
        /// <returns></returns>
        int Update(PermissionModel permissionModel);
    }
}
