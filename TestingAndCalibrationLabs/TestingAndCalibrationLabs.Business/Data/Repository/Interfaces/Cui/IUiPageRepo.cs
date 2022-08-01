using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model.Helper;
using TestingAndCalibrationLabs.Business.Core.Model.UiPage;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.Cui
{
    public interface IUiPageRepo
    {
        List<UiPageModel> GetAll();
        List<DataModel> GetData();
        List<PageModel> GetPage();
        List<ControlModel> GetControl();
        UiPageModel GetById(int id);
        int Create(UiPageModel pageModel);
        int Edit(UiPageModel pageMOdel);
        bool Delete(int id);
    }
}
