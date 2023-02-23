namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class WorkflowStageDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UiPageTypeId { get; set; }
        public string UiPageTypeName { get; set; }
        public int WorkflowId { get; set; }
        public string WorkflowName { get; set; }
        public int Orders { get; set; }
    }
}
