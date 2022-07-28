using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model.UiControl;
using PagedList;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.Cui
{
    public interface IUiControlRepo
    {

        UiControlModel Get(int id);
        List<UiControlModel> GetAll();
        int Edit(UiControlModel conModel);
        int Create(UiControlModel conModel);
        bool Delete(int id);


    }
}
