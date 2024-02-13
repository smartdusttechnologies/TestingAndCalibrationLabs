using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    /// <summary>
    /// Declaring properties 
    /// </summary>
    public class RecordsDTO
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public string WorkflowStageName { get; set; }
        public int WorkflowStageId { get; set; }

        public List<UiPageMetadataDTO> Fields { get; set; }
        public Dictionary<int, List<UiPageDataDTO>> FieldValues { get; set; }
        public  List<UiPageDataDTO> FieldValue { get; set; }
    }
}
