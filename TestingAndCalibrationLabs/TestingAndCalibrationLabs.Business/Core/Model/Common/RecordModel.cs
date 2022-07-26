using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{

    /// <summary>
    /// Declaring properties for operations
    /// </summary>
    [DbTable("Record")]
    public class RecordModel : Entity
    {
        #region Public Properties
        public int UiPageId { get; set; }

        public List<UiPageMetadataModel> Fields { get; set; }

        public List<UiPageDataModel> FieldValues { get; set; }
        #endregion
    }



}
