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
        ModuleModel GetById(int id);
        RequestResult<int> Update(ModuleModel moduleModel);
        RequestResult<int> Create(ModuleModel moduleModel);
        bool Delete(int id);


    }
}