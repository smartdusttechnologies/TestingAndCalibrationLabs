using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model.Dashboard;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces.QueryBuilder
{
    public interface IDashboardService
    {
        /// <summary>
        /// It will Take the Template Name and get the Json and Query
        /// </summary>
        /// <param name="Template"></param>
        /// <returns></returns>
        public DashboardModel Template(string Template);
    }
}
