using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// Declaring properties  here
    /// </summary>
    public class UiPageValidation : Entity
    {
        public int UiPageId { get; set; }
        public int UiPageMetadataId { get; set; }
        public int UiPageValidationTypeId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
