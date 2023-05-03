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
        public List<UiPageMetadataDTO> Fields { get; set; }
        public Dictionary<int, List<UiPageDataDTO>> FieldValues { get; set; }
    }
}
