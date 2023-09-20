namespace TestingAndCalibrationLabs.Web.UI.Models
{
    /// <summary>
    /// Declaring properties 
    /// </summary>
    public class UiPageDataDTO
    {
        /// <summary>
        /// It Contains The Id of The UiPageData
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// It Contains The Id of The UiPageMetadata
        /// </summary>
        public int UiPageMetadataId { get; set; }
        /// <summary>
        /// It Contains The RecordId of The UiPageData
        /// </summary>
        public int RecordId { get; set; }
        /// <summary>
        /// It Contains The SubRecordId of The UiPageData
        /// </summary>
        public int SubRecordId { get; set; }
        /// <summary>
        /// It Contains The MultiValueControl of The UiPageData
        /// </summary>
        public bool MultiValueControl { get; set; }
        /// <summary>
        /// It Contains The UiPageTypeId of The UiPageData
        /// </summary>
        public int UiPageTypeId { get; set; }
        /// <summary>
        /// It Contains The ChildId of The UiPageData
        /// </summary>
        public int? ChildId { get; set; }
        /// <summary>
        /// It Contains The Value of The UiPageData
        /// </summary>
        public string Value { get; set; }

    }
}
