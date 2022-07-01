using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class UiPageMetadataDTO
    {
        public int Id { get; set; }
        public int UiPageId { get; set; }
        public string UiPageName { get; set; }
        public int UiControlTypeId { get; set; }
        public string UiControlType { get; set; }
        public bool IsRequired { get; set; }
        
      
        public string UiControlDisplayName { get; set; }
    }
}
