using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Core.Model.Dashboard;
using TestingAndCalibrationLabs.Business.Core.Model.QueryBuilder;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.QueryBuilder;
using TestingAndCalibrationLabs.Business.Infrastructure;
using TestingAndCalibrationLabs.Business.Common;
using Google.Apis.Drive.v3.Data;
using Newtonsoft.Json;

namespace TestingAndCalibrationLabs.Business.Data.Repository.QueryBuilder
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public DashboardRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public DashboardModel SalesTemplate( string Template)
        {
            using IDbConnection db = _connectionFactory.GetConnection;

            //string JSON = db.Query(" ").ToString();
            string query = @"select JSON from [DashboardJSON] where Name = "+"'"+ Template+"'"+"";
            var JSON =  db.Query(query, new { Template });


            var aalue = Enumerable.First(JSON);
            object Json;
           string json="";
            foreach (var item in aalue)
            {
                //Dataval.value
                Json = item.Value;
                   json = Json.ToString();

            }
            var result = SqlConverter.JsonToSql(json);


            var value = db.Query(result);

            //var value = db.Query(" select Name, count(*) As Value from UiPageType join   UiPageMetadataModuleBridge    on UiPageType.Id = UiPageMetadataModuleBridge.UiPageTypeId group by  UiPageType.Name");
            //var Dataval = new DashboardSalesModel();
            //var obj = new List<DashboardModel>();
            var obj2 = new DashboardModel();
            //var dictionary = value.GroupBy(it => it.Key).ToDictionary(dict => dict.Key, dict => dict.Select(item => item.Value).ToList());

            //Hashtable hashtable = new Hashtable();
            obj2.Dictionary = new Dictionary<string, List<object>>();


            foreach (var item in value)
            {
                foreach (var item2 in item)
                {
                    
                        var key = item2.Key;
                        object Value = item2.Value;

                        //if (obj.Dictionary.ContainsKey(item2.Key))
                        //{
                        //obj2.Dictionary[item2.Key].Add(Value);


                        //}
                        //else
                        //{
                        // obj2.Dictionary[item2.Key], item2.Value);
                        if (!obj2.Dictionary.ContainsKey(key))
                        {
                            //.Add(key, new List<object>());
                            obj2.Dictionary[key] = new List<object>();
                        }


                        obj2.Dictionary[key].Add(Value);
                    }
                    //obj.Add(obj2);


                
            }
            //Val.Add(object);
            // }
            //var value3 = object;
            return obj2;
        }
    }
}
