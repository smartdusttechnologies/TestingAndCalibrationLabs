namespace TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV2
{
    /// <summary>
    /// It consist the property for the Goal Completion List
    /// </summary>
    public class GoalCompletionList
    {
        public string GoalMessage { get; set; }
        public int Target { get; set; }
        public int Reach { get; set; }

        public string AlertType { get; set; }

    }
}
