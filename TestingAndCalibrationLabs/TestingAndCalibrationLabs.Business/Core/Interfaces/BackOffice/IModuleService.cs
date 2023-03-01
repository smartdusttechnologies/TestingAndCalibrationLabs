using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service interface for Module
    /// </summary>
    public interface IModuleService
    {
        /// <summary>
        /// Get All Record From Module
        /// </summary>
        List<ModuleModel> Get();
        /// <summary>
        /// Get Record By Id From Module
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ModuleModel GetById(int id);
        /// <summary>
        /// Update Record In Module
        /// </summary>    
        /// <param name="moduleModel"></param>
        /// <returns></returns>
        RequestResult<int> Update(ModuleModel moduleModel);
        /// <summary>
        /// Insert Record In Module
        /// </summary>
        /// <param name="moduleModel"></param>
        /// <returns></returns>
        RequestResult<int> Create(ModuleModel moduleModel);
        /// <summary>
        /// Delete Record In Module
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);


    }
}