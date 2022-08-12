using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    [DbTable("UiPageData")]
    public class UiPageDataModel : Entity
    {
        public int UiPageId { get; set; }
        public int UiControlId { get; set; }

        private string _value;
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
