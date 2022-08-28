using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Conatains The Properties for Ui Page Validation
    /// </summary>
    public class UiPageValidationModel : Entity
    {
        /// <summary>
        /// It Contains The Id of The Ui Page Type
        /// </summary>
        public int UiPageTypeId { get; set; }
        /// <summary>
        /// It Contains The Name of The Ui Page Type
        /// </summary>
        public string UiPageTypeName { get; set; }
        /// <summary>
        /// It Contains The Id of The Ui Page Metadata
        /// </summary>
        public int UiPageMetadataId { get; set; }
        /// <summary>
        /// It Contains The Name of The Ui Page Metadata
        /// </summary>
        public string UiPageMetadataName { get; set; }
        /// <summary>
        /// It Contains The Id of The Ui Page Validation Type
        /// </summary>
        public int UiPageValidationTypeId { get; set; }
        /// <summary>
        /// It Contains The Name of The Ui Page Validation Type
        /// </summary>
        public string UiPageValidationTypeName { get; set; }
        /// <summary>
        /// It Contains The Name of The Ui Page Validation 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// It Contains The Value of The Ui Page Validation 
        /// </summary>
        public string Value { get; set; }
    }
}
