using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
        /// <summary>
        /// It Conatains The Properties for Ui Page Validation
        /// </summary>
    public class UiPageValidationDTO
    {
        /// <summary>
        /// It Contains The Id of The Ui Page Validation
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// It Contains The Id of The Ui Page Type
        /// </summary>
        [Required(ErrorMessage = "Please Select Page Type")]
        public int UiPageTypeId { get; set; }
        /// <summary>
        /// It Contains The Name of The Ui Page Type
        /// </summary>
        public string UiPageTypeName { get; set; }
        /// <summary>
        /// It Contains The Id of The Ui Page Metadata
        /// </summary>
        [Required(ErrorMessage = "Please Select Page Metadata")]
        public int UiPageMetadataId { get; set; }
        /// <summary>
        /// It Contains The Name of The Ui Page Metadata
        /// </summary>
        public string UiPageMetadataName { get; set; }
        /// <summary>
        /// It Contains The Id of The Ui Page Validation Type
        /// </summary>
        [Required(ErrorMessage = "Please Select Page Validation Type")]
        public int UiPageValidationTypeId { get; set; }
        /// <summary>
        /// It Contains The Name of The Ui Page Validation Type
        /// </summary>
        public string UiPageValidationTypeName { get; set; }

    }
}
