using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Core.Model.Common
{
    public class RecordsModel : Entity
    {
        public int UiPageId { get; set; }
        public List<UiPageMetadataModel> Fields { get; set; }
        public Dictionary<int, List<Core.Model.Common.UiPageDataModel>> FieldValues { get; set; }
    }
}
