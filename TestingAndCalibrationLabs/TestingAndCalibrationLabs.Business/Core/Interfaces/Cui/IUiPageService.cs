using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model.Helper;
using TestingAndCalibrationLabs.Business.Core.Model.UiPage;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces.Cui
{
    public interface IUiPageService
    {
        List<UiPageModel> GetAll();
        List<PageModel> GetPage();
        List<DataModel> GetData();
        List<ControlModel> GetControl();
        UiPageModel GetById(int id);
        RequestResult<int> Create(UiPageModel pageModel);
        RequestResult <int> Edit(int id ,UiPageModel pageModel);
        bool Delete(int id);

    }
}
