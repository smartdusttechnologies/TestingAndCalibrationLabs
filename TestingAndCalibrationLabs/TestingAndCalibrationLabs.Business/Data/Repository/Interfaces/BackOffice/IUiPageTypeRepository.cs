using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    public interface IUiPageTypeRepository
    {
        List<UiPageTypeModel> Get();
    }
}
