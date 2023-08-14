using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model.Dashboard;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.QueryBuilder
{
    public interface IDashboardRepository
    {
        public DashboardModel SalesTemplate( string Template);
    }
}
