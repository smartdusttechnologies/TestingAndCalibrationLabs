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
        List<SubPermissionModuleTypeModel> Get();

        /// <summary>
        /// Get Record By Id From SubPermissionModuleType
        /// </summary>
        /// <param name="id"></param>
        SubPermissionModuleTypeModel GetById(int id);
        /// <summary>
        /// Insert Record In SubPermissionModuleType
        /// </summary>
        /// <param name="subPermissionModuleTypeModel"></param>
        int Create(SubPermissionModuleTypeModel subPermissionModuleTypeModel);
        /// <summary>
        /// Update Record In SubPermissionModuleType
        /// </summary>
        /// <param name="subPermissionModuleTypeModel"></param>
        int Update(SubPermissionModuleTypeModel subPermissionModuleTypeModel);
    }
}
