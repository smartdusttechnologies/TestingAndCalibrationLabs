using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// Declaring properties for operations
    /// </summary>
    [DbTable("UiPageValidationType")]
    public class UiPageValidationTypes: Entity
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Message { get; set; }
    }
}
