using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Contains The Properties For Layout
    /// </summary>
    [DbTable("Layout")]
    public class Layout2Model : Entity
    {
        /// <summary>
        /// It Contains The Name of The Layout
        /// </summary>
        public string Name { get; set; }

    }
}
