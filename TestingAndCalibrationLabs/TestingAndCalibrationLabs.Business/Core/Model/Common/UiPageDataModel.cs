using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Conatains The Properties for Ui Page Data
    /// </summary>
    [DbTable("UiPageData")]
    public class UiPageDataModel : Entity
    {
        [DbColumn]
        public int UiPageId { get; set; }
        [DbColumn]
        public int UiPageMetadataId { get; set; }

        private string _value;
        [DbColumn]
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
        [DbColumn]
        public int RecordId { get; set; }
    }
}
