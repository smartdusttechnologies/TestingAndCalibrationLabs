
using System;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV1;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class Dashboard_Common
    {

        public Dashboard_SalesGraph Graph { get; set; }
        public SalesModel SalesModel { get; set; }
        public Dashboard_Map map { get; set; }

        public Dashboard_BoxTemplate template { get; set; }
        public Dashboard_To_Do To_Do { get; set; }
        public List<ChatModel> ChatData { get; set; }
    }
}
