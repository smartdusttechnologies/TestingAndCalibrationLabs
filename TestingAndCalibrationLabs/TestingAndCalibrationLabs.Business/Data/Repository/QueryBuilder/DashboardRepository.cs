using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Model.Dashboard;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.QueryBuilder;
using TestingAndCalibrationLabs.Business.Infrastructure;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Data.Repository.QueryBuilder
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public DashboardRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// This method will get the Template Name and Return Value in the form of DashboardModel
        /// </summary>
        /// <param name="Template"></param>
        /// <returns></returns>

        public DashboardModel SalesTemplate( string Template)
        {
            using IDbConnection db = _connectionFactory.GetConnection;

            
            string query = @"select JSON from [DashboardJSON] where Name = "+"'"+ Template+"'"+"";
            var JSON =  db.Query(query, new { Template });


            var aalue = Enumerable.First(JSON);
            object Json;
           string json="";
            foreach (var item in aalue)
            {
            
                Json = item.Value;
                   json = Json.ToString();

            }
            var result = SqlConverter.JsonToSql(json);


            var value = db.Query(result);

            
            var obj2 = new DashboardModel();
            
            obj2.Dictionary = new Dictionary<string, List<object>>();


            foreach (var item in value)
            {
                foreach (var item2 in item)
                {
                    
                        var key = item2.Key;
                        object Value = item2.Value;

                      
                        if (!obj2.Dictionary.ContainsKey(key))
                        {
                            
                            obj2.Dictionary[key] = new List<object>();
                        }


                        obj2.Dictionary[key].Add(Value);
                    }
                   


                
            }
           
            return obj2;
        }
    }
}
