using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model.Dashboard;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces.QueryBuilder
{
    public interface IDashboardService
    {
        public DashboardModel Template(string Template);
    }
}
