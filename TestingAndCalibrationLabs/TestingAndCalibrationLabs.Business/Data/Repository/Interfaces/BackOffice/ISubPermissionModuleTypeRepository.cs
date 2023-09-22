using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    /// <summary>
    /// Repository interface for SubPermissionModuleType
    /// </summary>
    public interface ISubPermissionModuleTypeRepository
    {
        /// <summary>
        /// Get All Records From SubPermissionModuleType
        /// </summary>
        /// <returns></returns>
        List<SubPermissionModuleTypeModel> Get();

        /// <summary>
        /// Get Record By Id From SubPermissionModuleType
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SubPermissionModuleTypeModel GetById(int id);
        /// <summary>
        /// Insert Record In SubPermissionModuleType
        /// </summary>
        /// <param name="subPermissionModuleTypeModel"></param>
        /// <returns></returns>
        int Create(SubPermissionModuleTypeModel subPermissionModuleTypeModel);
        /// <summary>
        /// Update Record In SubPermissionModuleType
        /// </summary>
        /// <param name="subPermissionModuleTypeModel"></param>
        /// <returns></returns>
        int Update(SubPermissionModuleTypeModel subPermissionModuleTypeModel);
    }
}
