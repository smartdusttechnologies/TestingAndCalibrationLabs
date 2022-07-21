using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{

    [DbTable("UiPageMetadata")]
    public class UiPageMetadataModel : Entity
    {
        public int UiPageId { get; set; }
        public string UiPageName { get; set; }
        public int UiControlTypeId { get; set; }
        public string UiControlType { get; set; }
        public bool IsRequired { get; set; }
        public string UiControlDisplayName { get; set; }

    }
}
