using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV2
{
    public class RecapModel
    {
        public List<string> Month { get; set; }
        public List<int> salesData1 { get; set; }
        public List<int> SalesData2 { get; set; }

        public int Revenue { get; set; }
        public int RevenueGrowth { get; set; }
        public int Cost { get; set; }
        public int CostWarning { get; set; }
        public int Profit { get; set; }
        public int ProfitPercentage { get; set; }
        public int Goal { get; set; }
        public int GoalRate { get; set; }

        public string DateRange { get; set; }
        public int CartValue { get; set; }
        public int PurchaseNo { get; set; }
        public int PageVisitors { get; set; }
        public int InquiriesNo { get; set; }
    }
}
