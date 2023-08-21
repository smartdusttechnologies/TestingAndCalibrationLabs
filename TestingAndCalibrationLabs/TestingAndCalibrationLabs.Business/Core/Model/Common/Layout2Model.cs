using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    [DbTable("Layout")]
    public class Layout2Model : Entity
    {
        public string Name { get; set; }

    }
}
