using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Interfaces.QueryBuilder;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Core.Model.QueryBuilder;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.QueryBuilder;

namespace TestingAndCalibrationLabs.Business.Services.QueryBuilder
{
    public class QueryBuilderService : IQueryBuilderService
    {

        private readonly IQueryBuilderRepository _querybuilderRepository;
        private readonly ILogger _logger;
        public QueryBuilderService(IQueryBuilderRepository querybuilderRepository, ILogger logger)
        {
            _querybuilderRepository = querybuilderRepository;
            _logger = logger;
        }

        public List<QueryBuilderModel> GetTableNames()
        {
            return _querybuilderRepository.GetTableName();
        }

        public QueryRecordModel GetColoumsNames(List<QueryBuilderModel> tableNames)
        {
            Dictionary<QueryBuilderModel, List<QueryBuilderColNames>> queryBuilderData = new Dictionary<QueryBuilderModel, List<QueryBuilderColNames>>();
            foreach (QueryBuilderModel table in tableNames)
            {
                queryBuilderData.Add(table, _querybuilderRepository.GetColoumsNames(table.tableName));
            }
            return new QueryRecordModel { FieldValues = queryBuilderData };
        }
        public int UiToJsonQueryBuilder(List<UiQueryGenerator> person, List<JoinModelDTO> JoinInfo, List<ConditionModel> conditionModels, string TemplateName)
        {



            for (var i = 0; i < JoinInfo.Count; i++)
            {

                foreach (var item2 in JoinInfo[i].JoinInfo)
                {
                    foreach (var item in person)
                    {
                        if (item2.Columns.Contains(item.TableName))
                        {
                            item2.Columns = item2.Columns.Replace(item.TableName, item.Alias.ToString());
                        }
                        if (item2.Column2.Contains(item.TableName))
                        {
                            item2.Column2 = item2.Column2.Replace(item.TableName, item.Alias.ToString());
                        }
                    }
                }
                foreach (var item in person)
                {


                    if (item.TableName == JoinInfo[i].TableChoice)
                    {
                        JoinInfo[i].TableChoice += " " + item.Alias;

                    }
                    if (item.TableName == JoinInfo[i].TableFrom)
                    {
                        JoinInfo[i].TableFrom += " " + item.Alias;

                    }

                }
            }
            var QueryJson = "{ 'head': {  'tables': [      {       'type': 'select'  ,    'tableName': " + '"' + JoinInfo[0].TableFrom + '"' + ",    'column': [";

            var column = "";

            foreach (var row in person)
            {
                for (var item2 = 0; item2 < row.ColumnName.Count; item2++)
                {
                    column = column + "{'columnName': " + '"' + row.Alias + "." + row.ColumnName[item2].Name + '"' + ", 'As': " + '"' + row.ColumnName[item2].Title + '"' + "},";

                }
            }
            column = column.Remove(column.Length - 1, 1);
            column = column + "] ,";
            var QueryJsonEnd = " } ] } }";
            var foriegn = "'foriegn': [";
            var foriegnData = "";

            foreach (var row in JoinInfo)
            {
                var OnTypeData = "";

                if (row.JoinInfo.Count == 1)
                {
                    foreach (var item in row.JoinInfo)
                    {
                        OnTypeData += " 'on': {  'pKey': " + '"' + item.Columns + '"' + ", 'optor':" + '"' + item.Operator + '"' + " , 'fKey': " + '"' + item.Column2 + '"' + "   },";

                    }
                    OnTypeData = OnTypeData.Remove(OnTypeData.Length - 1, 1);
                }
                else
                {
                    foreach (var item2 in row.JoinInfo)
                    {
                        OnTypeData += "{ 'pKey': " + '"' + item2.Columns + '"' + ", 'optor':" + '"' + item2.Operator + '"' + " , 'fKey': " + '"' + item2.Column2 + '"' + "   },";
                        if (item2.Condition != null)
                        {
                            OnTypeData += "{'Condition': " + '"' + item2.Condition + '"' + "},";
                        }
                    }
                    OnTypeData = OnTypeData.Remove(OnTypeData.Length - 1, 1);

                    OnTypeData = "'on':[ " + OnTypeData + " ]";
                }




                foriegnData += "{ 'joinType':" + '"' + row.JoinType + '"' + ",  'tableName':" + '"' + row.TableChoice + '"' + ",  'foriegnTableName': " + '"' + row.TableFrom + '"' + ", " + OnTypeData + "  },";

            }
            foriegnData = foriegnData.Remove(foriegnData.Length - 1, 1);
            foriegn += foriegnData + "]";
            
            if (conditionModels.Count != 0)
            {
                var condition = "'condition':[";
                foreach (var item in conditionModels)
                {
                    condition += "{ 'value': " + '"' + item.value + '"' + ", 'Where':" + '"' + item.Where + '"' + " , 'operators': " + '"' + item.operators + '"' + ", 'TableName':" + '"' + item.TableName + '"' + ", 'OperatorType':" + '"' + item.OperatorType + '"' + "   },";

                }

                condition = condition.Remove(condition.Length - 1, 1);
                condition += "],";






                QueryJson = QueryJson + column + condition + foriegn + QueryJsonEnd;


            }
            else
            {
                QueryJson = QueryJson + column  + foriegn + QueryJsonEnd;
            }




            if (Validator(QueryJson))
            {
                var model = new JsonSaveModel();
                model.Template = TemplateName;
                model.JSON = QueryJson;
                return  _querybuilderRepository.QuerySaver(model);
                
            }
            else
            {
                return 0;
            }
        }

        public bool Validator(string QueryJson)
        {
            try
            {
                JToken.Parse(QueryJson);
                return true;
            }
            catch (JsonReaderException ex)
            {
                Trace.WriteLine(ex);
                return false;
            }
        }
    }
}
