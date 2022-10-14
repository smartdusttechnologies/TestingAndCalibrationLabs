using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

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
        public List<UiPageDataDTO> FieldValues { get; set; }
        public Dictionary<int, List<UiPageDataDTO>> FieldValuesForGrid { get; set; }
        public IEnumerable<Node<UiPageMetadataModel>> Layout { get; set; }
        public ValidationMessage ErrorMessage { get; set; } = new ValidationMessage();
      
        #endregion
    }
}