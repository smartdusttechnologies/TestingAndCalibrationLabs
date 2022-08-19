using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface IUiControlTypeService
    {
        UiControlTypeModel Get(int id);

        List<UiControlTypeModel> GetAll();
        RequestResult<int> Edit(int id, UiControlTypeModel uiControlTypeModel);
        RequestResult<int> Create(UiControlTypeModel uiControlTypeModel);
        bool Delete(int id);
    }
}
