using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class UiPageNavigationDTO
    {
        public int Id { get; set; }
        public int UiNavigationCategoryId { get; set; }
        public string Name { get; set; }
        public string UiNavigationCategoryName { get; set; }
        public string Url { get; set; }
        public string FormatedUrl { get; set; }
        public List<UiPageTypeModel> UiPageTypeModels { get; set; }
    }
}
