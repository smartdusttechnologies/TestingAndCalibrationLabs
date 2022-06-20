using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.TestingAndCalibration
{
    public interface INewUIRepository
    {
        int Insert(NewUIModel newUIModel);
        int Get(NewUIModel newUIModel);
        int Update(NewUIModel newUIModel);
        List<NewUIModel> Get();
        NewUIModel Get(int id);
        bool Delete(int id);
        int InsertCollection(List<NewUIModel> newUI);

    }
}
