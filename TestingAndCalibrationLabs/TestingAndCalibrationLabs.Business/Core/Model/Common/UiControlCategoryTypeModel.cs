using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    [DbTable("UiControlCategoryType")]
    public class UiControlCategoryTypeModel : Entity
    {
        public string Name { get; set; }
        public string Template { get; set; }
        public int UiControlTypeId { get; set; }
    }
}
