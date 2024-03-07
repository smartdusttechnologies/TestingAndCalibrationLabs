using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    /// <summary>
    /// It Conatains The Properties for Ui Page Metadata 
    /// </summary>
    public class UiPageMetadataDTO
    {
        /// <summary>
        /// It Contains The Id of The UiPageMetadata
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// It Contains The Name of The UiPageMetadata
        /// </summary>

        public string Name { get; set; }
        /// <summary>
        /// It Contains The UiPageTypeId of The UiPageMetadata
        /// </summary>
        public int UiPageTypeId { get; set; }
        /// <summary>
        /// It Contains The Name of The Ui Page Type
        /// </summary>
        public string UiPageTypeName { get; set; }
        /// <summary>
        /// It Contains The UiControlTypeId of The UiPageMetadata
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
        /// It Contains the Name Of The Lookup Category
        /// </summary>
        public string ControlCategoryName { get; set; }
        public string ControlTypeName { get; set; }
        /// <summary>
        /// It Contains The Id From Lookup
        /// </summary>
        public int? ControlCategoryId { get; set; }
        /// <summary>
        /// It Contains The UiControlCategoryTypeId From UiPageMetadata
        /// </summary>
        public int UiControlCategoryTypeId { get; set; }
        /// <summary>
        /// It Contains The UiControlCategoryTypeName From Lookup
        /// </summary>
        public string UiControlCategoryTypeName { get; set; }
        /// <summary>
        /// It Contains The UiControlCategoryTypeTemplate From UiControlCategoryType
        /// </summary>
        public string UiControlCategoryTypeTemplate { get; set; }
        /// <summary>
        /// It Contains The ParentId From UiPageMetadataModuleBridge
        /// </summary>

        public int ParentId { get; set; }
        /// <summary>
        /// It Contains The ParentDisplayName From ComboTree
        /// </summary>
        public string ParentDisplayName { get; set; }
        /// <summary>
        /// It Contains The Orders From UiPageMetadataModuleBridge
        /// </summary>
        public int Orders { get; set; }
        /// <summary>
        /// It Contains The MetadataModuleBridgeId From UiPageMetadataModuleBridge
        /// </summary>
        public int MetadataModuleBridgeId { get; set; }
        /// <summary>
        /// It Contains The ModuleLayoutId From UiPageMetadata
        /// </summary>
        public int ModuleLayoutId { get; set; }
        /// <summary>
        /// It Contains The ModuleLayoutName From ModuleLayout
        /// </summary>
        public string ModuleLayoutName { get; set; }
        /// <summary>
        /// It Contains The Position From ComboTree
        /// </summary>
        public int Position { get; set; }
        /// <summary>
        /// It Contains The MultiValueControl From UiPageMetadataModuleBridge
        /// </summary>
        public bool MultiValueControl { get;set; }
        /// <summary>
        /// It Contains The UiPageMetadata From ComboTree
        /// </summary>
        public string UiPageMetadata { get; set; }
        /// <summary>
        /// It Contains The UiPageMetadataId From UiPageMetadata
        /// </summary>
        public int UiPageMetadataId { get; set; }
        public int ModuleId { get; set; }
        public int WorkflowStageId { get; set; }


    }
}