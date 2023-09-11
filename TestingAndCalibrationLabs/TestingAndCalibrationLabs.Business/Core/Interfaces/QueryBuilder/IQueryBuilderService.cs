using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Core.Model.Dashboard;
using TestingAndCalibrationLabs.Business.Core.Model.QueryBuilder;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces.QueryBuilder
{
    public interface IQueryBuilderService
    {
        /// <summary>
        /// THis will get the table Name
        /// </summary>
        /// <returns></returns>
        List<QueryBuilderModel> GetTableNames();

        /// <summary>
        /// THis interface is to get the Column
        /// </summary>
        /// <param name="tableNames"></param>
        /// <returns></returns>
        QueryRecordModel GetColoumsNames(List<QueryBuilderModel> tableNames);
        /// <summary>
        /// This is the convert the string to json format
        /// </summary>
        /// <param name="tableNames"></param>
        /// <param name="JoinInfo"></param>
        /// <param name="conditionModels"></param>
        /// <param name="TemplateName"></param>
        /// <returns></returns>
        //public int UiToJsonQueryBuilder(List<UiQueryGenerator> tableNames,List<JoinModelDTO>JoinInfo,List<ConditionModel> conditionModels, string TemplateName);
        //List<CommonQueryModel> UiToJsonQueryBuilder(List<UiQueryGenerator> person, List<JoinModelDTO> JoinInfo, List<ConditionModel> conditionModels, string TemplateName);
        DashboardModel UiToJsonQueryBuilder(List<UiQueryGenerator> person, List<JoinModelDTO> JoinInfo, List<ConditionModel> conditionModels, string TemplateName);
        /// <summary>
        /// This is to validate the json which is created
        /// </summary>
        /// <param name="Json"></param>
        /// <returns></returns>
        public bool Validator(string Json);
    }
}
