using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    [DbTable("UiControlCategoryType")]
    public class UiControlCategoryTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int UiControlTypeId { get; set; }
    }
}
