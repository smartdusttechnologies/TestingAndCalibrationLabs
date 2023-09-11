using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model.Dashboard;
using TestingAndCalibrationLabs.Business.Core.Model.QueryBuilder;


namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.QueryBuilder
{
    public interface IQueryBuilderRepository
    {
        /// <summary>
        /// This method will get the tableName which is available in Database
        /// </summary>
        /// <returns></returns>
         List<QueryBuilderModel> GetTableName();
        /// <summary>
        /// This Method Will get the columnName from DB
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        List<QueryBuilderColNames> GetColoumsNames(string tableName);

        /// <summary>
        /// This Method will save the JSON to the DB
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
          int QuerySaver(JsonSaveModel model);


        DashboardModel ExecuteCustomQuery(string query);

       // List<CommonQueryModel> ExecuteCustomQuery(string query);



    }
}
