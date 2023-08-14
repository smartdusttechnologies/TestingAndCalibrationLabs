using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Interfaces.QueryBuilder;
using TestingAndCalibrationLabs.Business.Core.Model.Dashboard;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.QueryBuilder;

namespace TestingAndCalibrationLabs.Business.Services.QueryBuilder
{
    public class DashboardService:IDashboardService
    {

        private readonly IDashboardRepository _dashboardRepository;
        
        public DashboardService(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
            
        }
        public DashboardModel Template(string TemplateName)
        {
            var value = _dashboardRepository.SalesTemplate(TemplateName);
            return value;
        }
    }
}
