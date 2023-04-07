using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{   /// <summary>
    /// Repository interface for Module
    /// </summary>
    public interface IModuleRepository
    {
        List<Dictionary<int, string>> GetValues(int moduleId);
        /// <summary>
        /// Get All Records From Module
        /// </summary>
        /// <returns></returns>
        List<ModuleModel> Get();
        /// <summary>
        /// Get Record By Id From Module
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ModuleModel GetById(int id);
        /// <summary>
        /// Insert Record In Module
        /// </summary>
        /// <param name="moduleModel"></param>
        /// <returns></returns>
        int Create(ModuleModel moduleModel);
        /// <summary>
        /// Update Record In Module
        /// </summary>
        /// <param name="moduleModel"></param>
        /// <returns></returns>
        int Update(ModuleModel moduleModel);
        /// <summary>
        /// Delete Record From Module By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
    

    }
}