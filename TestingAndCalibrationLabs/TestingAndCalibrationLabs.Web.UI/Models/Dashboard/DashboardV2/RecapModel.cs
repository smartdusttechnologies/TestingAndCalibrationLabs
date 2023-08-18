using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV2
{
    public class RecapModel
    {

        /// <summary>
        /// To store The Month Label for the Recap Graph
        /// </summary>
        public List<string> Month { get; set; }
        /// <summary>
        /// To store the Sales data TO show on Graph
        /// </summary>
        public List<int> SalesData1 { get; set; }
        /// <summary>
        /// To store the Different Sales data TO show on Graph
        /// </summary>
        public List<int> SalesData2 { get; set; }

        /// <summary>
        /// To store the revenue detail 
        /// </summary>
        public int Revenue { get; set; }
        /// <summary>
        /// To store the revenue growth
        /// </summary>
        public int RevenueGrowth { get; set; }
        /// <summary>
        /// To store the cost 
        /// </summary>
        public int Cost { get; set; }
        /// <summary>
        /// To store the cost warning detail
        /// </summary>
        public int CostWarning { get; set; }
        /// <summary>
        /// To store the profit detail
        /// </summary>
        public int Profit { get; set; }
        /// <summary>
        /// To store the profit percentage 
        /// </summary>
        public int ProfitPercentage { get; set; }
        /// <summary>
        /// To store the goal detail
        /// </summary>
        public int Goal { get; set; }
        /// <summary>
        /// To store the rate of Goal
        /// </summary>
        public int GoalRate { get; set; }
        /// <summary>
        /// To store the date Range Of Goal
        /// </summary>
        public string DateRange { get; set; }
        /// <summary>
        /// To store the cart Value
        /// </summary>
        public int CartValue { get; set; }
        /// <summary>
        /// To store the detail of purchase No
        /// </summary>
        public int PurchaseNo { get; set; }
        /// <summary>
        /// To store the detail of Page Visitor
        /// </summary>
        public int PageVisitors { get; set; }
        /// <summary>
        /// To store the detail of InquiriesNo
        /// </summary>
        public int InquiriesNo { get; set; }
    }
}
