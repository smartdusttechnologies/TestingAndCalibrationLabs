using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Conatains The Properties for UiPageMetadataModuleBridge
    /// </summary>
    [DbTable("UiPageMetadataModuleBridge")]
    public class UiPageMetadataModuleBridgeModel : Entity
    {
        /// <summary>
        /// It Contains The UiPageMetadataId of The UiPageMetadataModuleBridge
        /// </summary>
        public int UiPageMetadataId { get; set; }
        /// <summary>
        /// It Contains The UiPageTypeId of The UiPageMetadataModuleBridge
        /// </summary>
        public int UiPageTypeId { get; set; }
        /// <summary>
        /// It Contains The UiPageTypeName of The UiPageType
        /// </summary>
        public string UiPageTypeName { get; set; }
        /// <summary>
        /// It Contains The ModuleId of The UiPageMetadataModuleBridge
        /// </summary>
        public int ModuleId { get; set; }
        /// <summary>
        /// It Contains The ModuleName of The Module
        /// </summary>
        public string ModuleName { get; set; }
        /// <summary>
        /// It Contains The ParentId of The UiPageMetadataModuleBridge
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// It Contains The Orders of The UiPageMetadataModuleBridge
        /// </summary>
        public int Orders { get; set; }
        /// <summary>
        /// It Contains The UiControlDisplayName of The UiPageMetadataModuleBridge
        /// </summary>
        public string UiControlDisplayName { get; set; }
        /// <summary>
        /// It Contains The MultiValueControl of The UiPageMetadataModuleBridge
        /// </summary>
        public string MultiValueControl { get; set; }
    }
}
