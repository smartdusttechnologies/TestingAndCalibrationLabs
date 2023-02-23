using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    public interface IModuleRepository
    {
        List<Dictionary<int, string>> GetValues(int moduleId);

        List<ModuleModel> Get();

        ModuleModel GetById(int id);

        int Create(ModuleModel moduleModel);

        int Update(ModuleModel moduleModel);

        bool Delete(int id);

    }
}