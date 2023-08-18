
using System;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV1;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class Dashboard_Common
    {
        /// <summary>
        /// To store Data for SalesGraph
        /// </summary>
        public Dashboard_SalesGraph Graph { get; set; }
        /// <summary>
        /// To store Data for SalesModel Template
        /// </summary>
        public SalesModel SalesModel { get; set; }
        /// <summary>
        /// To store Data for Map Template
        /// </summary>
        public Dashboard_Map Map { get; set; }
        /// <summary>
        /// To store Data for Box  Template
        /// </summary>

        public Dashboard_BoxTemplate Template { get; set; }
        /// <summary>
        /// To store Data for To-Do Template
        /// </summary>
        public Dashboard_To_Do To_Do { get; set; }
        /// <summary>
        /// To store Data for ChatBox Template
        /// </summary>
        public List<ChatModel> ChatData { get; set; }
    }
}
