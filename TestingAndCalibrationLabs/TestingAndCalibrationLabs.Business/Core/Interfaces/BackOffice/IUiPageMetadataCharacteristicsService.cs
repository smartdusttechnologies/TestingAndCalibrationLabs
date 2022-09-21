using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface IUiPageMetadataCharacteristicsService
    {
        List<UiPageMetadataCharacteristicsModel> Get(int id);
        List<UiPageMetadataCharacteristicsModel> Get();
        List<UiPageMetadataCharacteristicsModel> GetByMetadataId(int id);
    }
}
