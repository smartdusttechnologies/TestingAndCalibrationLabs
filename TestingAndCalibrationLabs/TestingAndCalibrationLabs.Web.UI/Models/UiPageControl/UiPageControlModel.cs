namespace TestingAndCalibrationLabs.Web.UI.Models.UiPageControl
{
    public class UiPageControlModel
    {
        public int id { get; set; }
        public int UiPageTypeId { get; set; }
        public string UiPageName { get; set; }
        public int UiControlTypeId { get; set; }
        public string UiControlType { get; set; }
        public bool IsRequired { get; set; }
        public string UiControlDisplayName { get; set; }
        public int UiDataTypeId { get; set; }
        public string UiDataTypeName { get; set; }
    }
}
