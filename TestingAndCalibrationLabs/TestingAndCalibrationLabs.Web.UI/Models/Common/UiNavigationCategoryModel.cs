﻿using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class UiNavigationCategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public List<UiPageTypeModel> UiPageTypeModels { get; set; }
    }
}
