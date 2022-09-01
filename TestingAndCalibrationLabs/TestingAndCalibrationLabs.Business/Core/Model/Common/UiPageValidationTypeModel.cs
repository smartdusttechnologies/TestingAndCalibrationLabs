using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Conatains The Properties for Ui Page Validation Type
    /// </summary>
    [DbTable("UiPageValidationType")]
    public class UiPageValidationTypeModel: Entity
    {
        /// <summary>
        /// It Contains The Name of The Ui Page Validation Type
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// It Contains The Value of The Ui Page Validation Type
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// It Contains The Messege of The Ui Page Validation Type
        /// </summary>
        public string Message { get; set; }
    }
}
