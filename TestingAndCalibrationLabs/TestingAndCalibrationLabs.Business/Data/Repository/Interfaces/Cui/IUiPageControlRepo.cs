using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model.UiPageControl;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.Cui
{
    public interface IUiPageControlRepo
    {
        List <UiPageControlModel> GetAll();
        UiPageControlModel GetById(int id);
        int Create(UiPageControlModel pageCon);
        int Update(UiPageControlModel pageCon);
        bool Delete(int id);
    }
}
