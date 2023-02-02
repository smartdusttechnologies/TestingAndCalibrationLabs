using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV2
{
    /// <summary>
    /// It Consist the property of list type for Area chart and property for other small tiles
    /// </summary>
    public class AreaChartRecap
    {
        public List<string> Month { get; set; }
       
        public List<RecapModel> AreaGraphData { get; set; }
        public List<GoalCompletionList> GoalListData { get; set; }

        public int Revenue { get; set; }
        public int RevenueGrowth { get; set; }
        public int Cost { get; set; }
        public int CostWarning { get; set; }
        public int Profit { get; set; }
        public int ProfitPercentage { get; set; }
        public int Goal { get; set; }
        public int GoalRate { get; set; }

        public string DateRange { get; set; }
        
    }
}
