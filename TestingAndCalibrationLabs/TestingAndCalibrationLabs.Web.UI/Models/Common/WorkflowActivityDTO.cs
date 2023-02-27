namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class WorkflowActivityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public int WorkflowStageId { get; set; }
        public string WorkflowStageName { get; set; }
    }
}
