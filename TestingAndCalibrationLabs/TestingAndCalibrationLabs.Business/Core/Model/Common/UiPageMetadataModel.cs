using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Conatains The Properties for Ui Page Validation 
    /// </summary>
    [DbTable("UiPageMetadata")]
    public class UiPageMetadataModel : Entity
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
        /// It Contains The Id of The Ui Control Type
        /// </summary>
        public int UiControlTypeId { get; set; }
        /// <summary>
        /// It Contains The Name of The Ui Control Type
        /// </summary>
        public string UiControlTypeName { get; set; }
        /// <summary>
        /// It Contains The IsRequired of The Ui Page Metadata
        /// </summary>
        public bool IsRequired { get; set; }
        /// <summary>
        /// It Contains The UiControlDisplayName of The Ui Page Metadata
        /// </summary>
        public string UiControlDisplayName { get; set; }
        /// <summary>
        /// It Contains The Id of The Data Type
        /// </summary>
        public int DataTypeId { get; set; }
        /// <summary>
        /// It Contains The Name of The Data Type
        /// </summary>
        public string DataTypeName { get; set; }
        /// <summary>
        /// it Contains The Id Of Lookup Category
        /// </summary>
        public int? LookupCategoryId { get; set; }
        /// <summary>
        /// It Contains the Name Of The Lookup Category
        /// </summary>
        public string LookupCategoryName { get; set; }
        /// <summary>
        /// It Contains The SelectedLookupId From ComboTree
        /// </summary>
        public List<int> SelectedLookupId { get; set; }
        /// <summary>
        /// It Contains The List Of UiPageMetadataCharacteristics For Ui Page Metadata
        /// </summary>
        public List<UiPageMetadataCharacteristicsModel> uiPageMetadataCharacteristics { get; set; }
    }
}
