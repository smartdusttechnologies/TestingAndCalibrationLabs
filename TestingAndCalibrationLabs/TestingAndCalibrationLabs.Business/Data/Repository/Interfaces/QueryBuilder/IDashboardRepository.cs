using TestingAndCalibrationLabs.Business.Core.Model.Dashboard;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.QueryBuilder
{
    public interface IDashboardRepository
    {
        /// <summary>
        /// This will take the Template Name and execute in DB and get the Json 
        /// </summary>
        /// <param name="Template"></param>
        /// <returns></returns>
        public DashboardModel SalesTemplate( string Template);
    }
}
