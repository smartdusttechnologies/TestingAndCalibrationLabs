using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class UiPageMetadataDTO
    {
        /// <summary>
        /// Declaring properties 
        /// </summary>
        public int Id { get; set; }
        [Required(ErrorMessage = "Testing Type is required")]
        public int UiPageTypeId { get; set; }
        public string UiPageTypeName { get; set; }
        public int UiControlTypeId { get; set; }
        public string UiControlTypeName { get; set; }
        public bool IsRequired { get; set; }
        [Required(ErrorMessage = "Please enter your uicontroldisplayname")]
        public string UiControlDisplayName { get; set; }
        public int DataTypeId { get; set; }
        public string DataTypeName { get; set; }


    }
}
