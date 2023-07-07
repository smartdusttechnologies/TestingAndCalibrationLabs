using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Conatains The Properties for Ui Page Data
    /// </summary>
    [DbTable("UiPageData")]
    public class UiPageDataModel : Entity
    {
        public int SubRecordId { get; set; }
        public int UiPageTypeId { get; set; }
        public int UiPageMetadataId { get; set;}
        public bool MultiValueControl { get; set; }
        public int WorkflowStageId { get; set; }
        private string _value;
        public int UiPageDataId { get; set; }
        public int? ChildId { get; set; }
        public string Value
        {
            get
            {
                return _value?? string.Empty;
            }
            set
            {
                _value = value;
            }
        }
        public int RecordId { get; set; }
       
    }
}
