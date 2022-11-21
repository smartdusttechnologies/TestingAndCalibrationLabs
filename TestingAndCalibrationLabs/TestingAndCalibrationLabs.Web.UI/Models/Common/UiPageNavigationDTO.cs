namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class UiPageNavigationDTO
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int UiPageTypeId { get; set; }
        public string UiPageTypeName { get; set; }
        public int UiNavigationCategoryId { get; set; }
        public string UiNavigationCategoryName { get; set; }
        public string FormatedUrl { get; set; }
        public string Orders { get; set; }
    }
}
