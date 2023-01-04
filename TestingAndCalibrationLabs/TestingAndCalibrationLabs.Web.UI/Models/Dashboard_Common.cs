
using System;
using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class Dashboard_Common
    {

        public Dashboard_SalesGraph Graph { get; set; }
        public SalesModel SalesModel { get; set; }
        public Dashboard_Map map { get; set; }

        public Dashboard_BoxTemplate template { get; set; }
        public Dashboard_To_Do To_Do { get; set; }
    }
}
