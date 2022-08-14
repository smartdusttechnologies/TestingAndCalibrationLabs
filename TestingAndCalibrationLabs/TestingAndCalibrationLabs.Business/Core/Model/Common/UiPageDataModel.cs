using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model.Common
{
    /// <summary>
    /// Declaring properties for operations
    /// </summary>
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
