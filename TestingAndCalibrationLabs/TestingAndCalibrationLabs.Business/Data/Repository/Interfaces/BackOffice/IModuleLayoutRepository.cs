
using System.Collections.Generic;

using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    /// <summary>
    /// Repostiry Interface For ModuleLayout
    /// </summary>
    public interface IModuleLayoutRepository
    {
        /// <summary>
        /// Get All Records Of ModuleLayout based on moduleId
        /// </summary>
        /// <returns></returns>
        ModuleLayoutModel GetByModuleLayoutId(int moduleId);
        /// <summary>
        /// Get All Records Of ModuleLayout
        /// </summary>
        /// <returns></returns>
        List<ModuleLayoutModel> Get();
        /// <summary>
        /// Get Records By UiPageMetadataId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<ModuleLayoutModel> GetAllByUiPageMetadataId(int id);
        /// <summary>
        /// Get Record By Id From ModuleLayout
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ModuleLayoutModel GetById(int id);
        /// <summary>
        /// Insert Record In ModuleLayout
        /// </summary>
        /// <param name="moduleLayoutModel"></param>
        /// <returns></returns>
        int Create(ModuleLayoutModel moduleLayoutModel);
        /// <summary>
        /// Update Record In ModuleLayout
        /// </summary>
        /// <param name="moduleLayoutModel"></param>
        /// <returns></returns>
        int Update(ModuleLayoutModel moduleLayoutModel);
        /// <summary>
        /// Delete Record From ModuleLayout By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}
