﻿
using System.Collections.Generic;

using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    public interface IUiPageMetadataCharacteristicsRepository
    {
        List<UiPageMetadataCharacteristicsModel> Get();
        List<UiPageMetadataCharacteristicsModel> Get(int id);
        List<UiPageMetadataCharacteristicsModel> GetByMetadataId(int id);
    }
}
