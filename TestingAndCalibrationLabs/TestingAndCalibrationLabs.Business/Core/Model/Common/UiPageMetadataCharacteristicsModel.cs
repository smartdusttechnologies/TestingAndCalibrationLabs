using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DbTable("UiPageMetadataCharacteristics")]
    public class UiPageMetadataCharacteristicsModel : Entity
    {
        /// <summary>
        /// 
        /// </summary>
        public int UiPageMetadataId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int LookupId { get; set; }
    }
}
