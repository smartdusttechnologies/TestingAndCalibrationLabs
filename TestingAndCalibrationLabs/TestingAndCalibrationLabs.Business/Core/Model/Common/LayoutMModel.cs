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
    public class LayoutMModel : Entity
    {
        /// <summary>
        /// It Contains The Name of The Layout
        /// </summary>
        [DbColumn]
        public string Name { get; set; }

    }
}
