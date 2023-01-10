using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Conatains The Properties for Records
    /// </summary>
    public class RecordsModel : Entity
    {
        [DbColumn]
        public int UiPageId { get; set; }
        public List<UiPageMetadataModel> Fields { get; set; }
        public Dictionary<int, List<Core.Model.UiPageDataModel>> FieldValues { get; set; }
    }
}
