using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    /// <summary>
    /// Declaring Public Properties
    /// </summary>
    public class RecordDTO
    {
        #region Public Properties
        public int Id { get; set; }
        public int UiPageId { get; set; }
        public List<UiPageMetadataDTO> Fields { get; set; }
        public List<UI.Models.UiPageDataDTO> FieldValues { get; set; }
        public ValidationMessage ErrorMessage { get; set; } = new ValidationMessage();
        #endregion
    }
}