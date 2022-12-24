using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    /// <summary>
    /// Declaring Public Properties
    /// </summary>
    public class RecordDTO
    {
        #region Public Properties
        public int Id { get; set; }
        public int UiPageTypeId { get; set; }
        public int ModuleId { get; set; }
        public List<UiPageMetadataDTO> Fields { get; set; }
        public List<UiPageDataDTO> FieldValues { get; set; }
        public IEnumerable<Node<LayoutDTO>> Layout { get; set; }
        public ValidationMessage ErrorMessage { get; set; } = new ValidationMessage();
      
        #endregion
    }
}