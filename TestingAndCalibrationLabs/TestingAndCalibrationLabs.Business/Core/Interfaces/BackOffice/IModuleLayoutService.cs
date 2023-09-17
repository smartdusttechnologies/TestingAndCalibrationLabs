using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service Interface For ModuleLayout
    /// </summary>
    public interface IModuleLayoutService
    {
        /// <summary>
        /// Get Records By ModuleLayout
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<ModuleLayoutModel> GetByMetadataId(int id);
        /// <summary>
        /// Get All Record From ModuleLayout
        /// </summary>
        /// <returns></returns>
        List<ModuleLayoutModel> Get();
        /// <summary>
        /// Get Records By ModuleLayout based on metadataId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ModuleLayoutModel GetByUiPageMetadataId(int uiPageMetadataId);
        /// <summary>
        /// Get Records By ModuleLayout based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ModuleLayoutModel GetById(int id);
        /// <summary>
        /// Get Records By ModuleLayout
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        RequestResult<int> Update(ModuleLayoutModel moduleLayoutModel);
        /// <summary>
        /// Insert Record In ModuleLayout
        /// </summary>
        /// <param name="uiControlTypeModel"></param>
        /// <returns></returns>
        RequestResult<int> Create(ModuleLayoutModel moduleLayoutModel);
        /// <summary>
        /// Delete Record From ModuleLayout
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}
