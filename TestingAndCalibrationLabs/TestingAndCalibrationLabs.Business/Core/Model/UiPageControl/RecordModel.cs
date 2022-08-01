using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model.UiPageControl
{
    [DbTable("Record")]
    public class RecordModel : Entity
    {
        #region Public Properties
        public int UiPageId { get; set; }

        public List<UiPageControlModel> Fields { get; set; }

        //public List<UiPageDataModel> FieldValues { get; set; }
        #endregion
    }



}
