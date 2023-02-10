namespace TestingAndCalibrationLabs.Web.UI.Models
{
    /// <summary>
    /// Declaring properties 
    /// </summary>
    public class UiPageDataDTO
    {
        public int Id { get; set; }
        public int UiPageMetadataId { get; set; }
        public int RecordId { get; set; }
        public int SubRecordId { get; set; }

        public int UiPageTypeId { get; set; }
        public string Value { get; set; }
    }
}
