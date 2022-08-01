using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Core.Model.UiPageControl
{
    public class UiPageControlModel : Entity
    {
        #region public properties
        public int UiPageTypeId { get; set; }
        public string UiPageName { get; set; }
        public int UiControlTypeId { get; set; }
        public string UiControlType { get; set; }
        public bool IsRequired { get; set; }
        public string UiControlDisplayName { get; set; }
        public int UiDataTypeId { get; set; }
        public string UiDataTypeName { get; set; }
        #endregion
    }
}
