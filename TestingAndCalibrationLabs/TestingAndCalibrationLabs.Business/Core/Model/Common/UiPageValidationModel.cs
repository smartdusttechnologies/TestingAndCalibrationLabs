using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// Declaring properties for operations
    /// </summary>
    public class UiPageValidationModel : Entity
    {
        public int UiPageTypeId { get; set; }
        public string UiPageTypeName { get; set; }
        public int UiPageMetadataId { get; set; }
        public string UiPageMetadataName { get; set; }
        public int UiPageValidationTypeId { get; set; }
        public string UiPageValidationTypeName { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
