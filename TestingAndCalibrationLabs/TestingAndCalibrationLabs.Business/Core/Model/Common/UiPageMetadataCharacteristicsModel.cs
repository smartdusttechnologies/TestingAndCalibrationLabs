namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class UiPageMetadataCharacteristicsModel : Entity
    {
        public int UiPageMetadataId { get; set; }
        public string Value { get; set; }
        public string Category { get; set; }

        public int LookupId { get; set; }
    }
}
