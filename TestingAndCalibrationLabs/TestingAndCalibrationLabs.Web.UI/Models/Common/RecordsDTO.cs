using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    /// <summary>
    /// Declaring properties 
    /// </summary>
    public class RecordsDTO
    {
        public int Id { get; set; }
        public int UiPageId { get; set; }
        public List<UI.Models.UiPageMetadataDTO> Fields { get; set; }
        public Dictionary<int, List<UI.Models.UiPageDataDTO>> FieldValues { get; set; }
    }
}
