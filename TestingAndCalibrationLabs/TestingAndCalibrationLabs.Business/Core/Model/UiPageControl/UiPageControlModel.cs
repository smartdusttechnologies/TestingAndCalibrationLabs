using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Core.Model.UiPageControl
{
    public class UiPageControlModel : Entity
    {
        #region public properties
        public int UiPageId { get; set; }
        public int UiControlTypeId { get; set; }
        public bool IsRequired { get; set; }
        public string UiControlDisplayName { get; set; }
        public string DataType { get; set; }
        #endregion
    }
}
