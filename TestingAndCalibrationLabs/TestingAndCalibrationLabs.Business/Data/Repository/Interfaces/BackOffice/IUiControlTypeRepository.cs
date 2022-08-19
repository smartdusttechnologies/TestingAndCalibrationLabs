using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    public interface IUiControlTypeRepository
    {
        /// <summary>
        /// Repository interface for Ui Control Type
        /// </summary>
        UiControlTypeModel Get(int id);
        List<UiControlTypeModel> GetAll();
        int Edit(UiControlTypeModel uiControlTypeModel);
        int Create(UiControlTypeModel uiControlTypeModel);
        bool Delete(int id);


    }
}
