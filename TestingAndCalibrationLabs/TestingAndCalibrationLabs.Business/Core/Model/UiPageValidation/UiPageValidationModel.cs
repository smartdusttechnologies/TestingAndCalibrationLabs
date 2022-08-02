using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Core.Model.UiPageValidation
{
    public class UiPageValidationModel : Entity
    {
        public int UiPageId { get; set; }
        public string UiPageName { get; set; }
        public int UiPageMetadataId { get; set; }
        public string UiPageMetadataName { get; set; }
        public int UiPageValidationId { get; set; }
        public string UiPageValidationName { get; set; }
    }
}
