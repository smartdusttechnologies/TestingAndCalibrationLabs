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
        public bool MultiValueControl { get; set; }
        public int WorkflowStageId { get; set; }

        public int UiPageTypeId { get; set; }
        public int UiPageDataId { get; set; }
        public int ChildId { get; set; }
        public string Value { get; set; }

        //public string ParentId { get; set; }
        //public string Name { get; set; }

    }
}
