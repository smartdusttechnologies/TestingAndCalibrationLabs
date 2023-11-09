using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice
{
    public interface ISubPermissionModuleTypeService
    {
        /// <summary>
        /// Get All Record From ISubPermissionModuleType Service
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
        RequestResult<int> Create(SubPermissionModuleTypeModel subPermissionModuleTypeModel);
        /// <summary>
        /// Edit Record From SubPermissionModuleType
        /// </summary>
        /// <param name="subPermissionModuleTypeModel"></param>
        /// <param Id="id"></param>
        RequestResult<int> Update(int id, SubPermissionModuleTypeModel subPermissionModuleTypeModel);
        /// <summary>
        /// Delete Record From SubPermissionModuleType
        /// </summary>
        /// <param name="id"></param>
        bool Delete(int id);
    }

}
