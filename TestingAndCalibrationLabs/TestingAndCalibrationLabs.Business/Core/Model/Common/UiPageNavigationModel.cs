﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class UiPageNavigationModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UiPageTypeModel> UiPageTypeModels { get; set; }
    }
}
