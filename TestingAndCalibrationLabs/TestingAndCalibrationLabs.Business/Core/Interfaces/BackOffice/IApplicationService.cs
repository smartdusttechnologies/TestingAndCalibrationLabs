using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service Interface For Ui Page Type
    /// </summary>
    /// <returns></returns>
    public interface IApplicationService
    {

        List<ApplicationModel> Get();

        ApplicationModel GetById(int id);

        RequestResult<int> Create(ApplicationModel applicationModel);

        RequestResult<int> Update(ApplicationModel applicationModel);

        bool Delete(int id);

    }
}