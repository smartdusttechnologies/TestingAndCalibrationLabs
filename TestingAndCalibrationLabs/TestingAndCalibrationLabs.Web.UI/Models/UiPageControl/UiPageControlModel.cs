namespace TestingAndCalibrationLabs.Web.UI.Models.UiPageControl
{
    public class UiPageControlModel
    {
        public int id { get; set; }
        public int UiPageId { get; set; }
        public int UiControlTypeId { get; set; }
        public bool IsRequired { get; set; }
        public string UiControlDisplayName { get; set; }
        public string DataType { get; set; }
    }
}
