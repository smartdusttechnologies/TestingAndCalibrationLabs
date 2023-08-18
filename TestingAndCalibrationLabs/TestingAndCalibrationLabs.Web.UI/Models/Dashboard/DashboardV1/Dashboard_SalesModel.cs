using System.Collections.Generic;
using System;

namespace TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV1
{
    public class SalesModel
    {

        /// <summary>
        /// To store the Month Detail
        /// </summary>
        public List<object> Month { get; set; }

        /// <summary>
        /// To store the Color Related and Data 
        /// </summary>
        public List<SalesComponentDataModel> SalesData { get; set; }

        
        /// <summary>
        /// To store the salesName
        /// </summary>
        public List<string> SalesName { get; set; }
        /// <summary>
        /// To store the dataset for PieGraph
        /// </summary>
        public List<int> DataSet { get; set; }


    }
}
