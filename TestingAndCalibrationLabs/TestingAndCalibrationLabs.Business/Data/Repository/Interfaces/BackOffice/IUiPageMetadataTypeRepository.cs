using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    /// <summary>
    /// Repository interface for Ui Page Metadata Type
    /// </summary>
    public interface IUiPageMetadataTypeRepository
    {
        List <UiPageMetadataModel> GetAll();
        UiPageMetadataModel GetById(int id);
        int Create(UiPageMetadataModel uiPageMetadataModel);
        int Update(UiPageMetadataModel uiPageMetadataModel);
        bool Delete(int id);
    }
}
