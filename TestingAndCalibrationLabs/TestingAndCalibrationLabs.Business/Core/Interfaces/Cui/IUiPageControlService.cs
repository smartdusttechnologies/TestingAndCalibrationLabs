using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model.UiPageControl;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces.Cui
{
    public interface IUiPageControlService
    {
        List<UiPageControlModel> GetAll();
        UiPageControlModel GetById(int id);
    }
}
