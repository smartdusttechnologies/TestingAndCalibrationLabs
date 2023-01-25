using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    public interface IModuleRepository
    {
        List<Dictionary<int, string>> GetValues(int moduleId);
    }
}
