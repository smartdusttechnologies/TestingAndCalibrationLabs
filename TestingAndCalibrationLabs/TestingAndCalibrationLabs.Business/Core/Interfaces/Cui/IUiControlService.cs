using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model.UiControl;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces.Cui
{
    public interface IUiControlService
    {
        UiControlModel Get(int id);

        List<UiControlModel> GetAll();
        RequestResult<int> Edit(int id, UiControlModel conModel);
        RequestResult<int> Create(UiControlModel conModel);
        bool Delete(int id);
    }
}
