using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface IUiPageMetadataTypeService
    {
        List<UiPageMetadataModel> GetAll();
        UiPageMetadataModel GetById(int id);
        RequestResult <int> Create(UiPageMetadataModel uiPageMetadataModel);
        RequestResult <int> Update(int id , UiPageMetadataModel uiPageMetadataModel);
        bool Delete(int id);
    }
}
