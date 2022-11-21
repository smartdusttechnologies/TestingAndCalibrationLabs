namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class UiPageNavigationModel : Entity
    {
        public string Url { get; set; }
        public int UiPageTypeId { get; set; }
        public string UiPageTypeName { get; set; }
        public int UiNavigationCategoryId { get; set; }
        public string UiNavigationCategoryName { get; set; }
        public string FormatedUrl { get; set; }
        public string Orders { get; set; }
    }
}
