using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service interface for Ui Control Type
    /// </summary>
    public interface IUiControlTypeService
    {
        /// <summary>
        /// Get Ui Control Type By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UiControlTypeModel Get(int id);

        List<UiControlTypeModel> GetAll();
        RequestResult<int> Edit( UiControlTypeModel uiControlTypeModel);
        RequestResult<int> Create(UiControlTypeModel uiControlTypeModel);
        bool Delete(int id);
    }
}
