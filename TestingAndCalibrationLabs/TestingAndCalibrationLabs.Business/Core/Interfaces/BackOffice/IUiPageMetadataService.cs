using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service interface for Ui Page Metadata Type
    /// </summary>
    public interface IUiPageMetadataService
    {
        List<UiPageMetadataModel> GetAll();
        UiPageMetadataModel GetById(int id);
        RequestResult <int> Create(UiPageMetadataModel uiPageMetadataModel);
        RequestResult <int> Update(int id , UiPageMetadataModel uiPageMetadataModel);
        bool Delete(int id);
    }
}
