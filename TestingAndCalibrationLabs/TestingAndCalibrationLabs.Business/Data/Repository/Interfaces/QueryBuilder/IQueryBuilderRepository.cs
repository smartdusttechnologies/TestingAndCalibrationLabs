using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model.Dashboard;
using TestingAndCalibrationLabs.Business.Core.Model.QueryBuilder;


namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.QueryBuilder
{
    public interface IQueryBuilderRepository
    {
         List<QueryBuilderModel> GetTableName();

        List<QueryBuilderColNames> GetColoumsNames(string tableName);

          int QuerySaver(JsonSaveModel model);


        DashboardModel ExecuteCustomQuery(string query);

       // List<CommonQueryModel> ExecuteCustomQuery(string query);



    }
}
