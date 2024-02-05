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
        /// <summary>
        /// THis method to Take JSON from DataBase and the convert to query and then to execute 
        /// </summary>
        /// <param name="TemplateName"></param>
        /// <returns></returns>
        public DashboardModel Template(string TemplateName)
        {
            var value = _dashboardRepository.SalesTemplate(TemplateName);
            return value;
        }
    }
}
