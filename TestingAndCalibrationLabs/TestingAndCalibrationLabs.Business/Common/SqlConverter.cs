
using Microsoft.AspNetCore.StaticFiles;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Common
{
    public class SqlConverter
    {

        public static string JsonToSql(string json)
        {
            //var str = ReadAllText(json);
            dynamic ob = JObject.Parse(json);
            if (ob != null)
            {
                string typ = ob.head.tables[0].type.ToString();
                StringBuilder query = new StringBuilder(typ);
                if (ob.head.tables != null)
                {
                    foreach (var table in ob.head.tables)
                    {
                        Column( table, ref query);



                        query.Append($" FROM {ob.head.tables[0].tableName.ToString()} ");

                             

                        JoinType(table, ref query);

                        if (table.GroupBy != null)
                        {
                            query.Append($" GROUP BY {table.GroupBy} ");
                        }

                        OrderType(table, ref query);

                        Condition(ref ob, ref query);

                    }
                }


                return query.ToString();
            }
            return null;
        }


        public static void Column( dynamic ob, ref StringBuilder query)
        {

            foreach (var col in ob.column)
            {

                //query.Append($" {col.tableName}.{col.columnName} AS {col.As} ,");
                if(col.Aggregation!=null && ob.GroupBy!=null)
                {
                    query.Append($" {col.Aggregation}(");
                }
                if (col.tableName != null)
                {
                    query.Append($" {col.tableName}.");
                }

                query.Append($"{col.columnName} ,");

                if(col.Aggregation!= null && ob.GroupBy != null)
                {
                    query.Remove(query.Length - 1, 1);
                    query.Append($" ) ,");
                }

                if (col.As != null && col.columnName != "*")
                {
                    query.Remove(query.Length - 1, 1);
                    query.Append($" As {col.As} ,");
                }
                
            }
            query.Remove(query.Length - 1, 1);


        }

        public static void Condition(ref dynamic ob, ref StringBuilder query)
        {


            if (ob.head.tables[0].condition != null)
            {
                query.Append(" where ");
                foreach (var cond in ob.head.tables[0].condition)
                {
                    if (cond.OperatorType != null)
                    {
                        query.Append(cond.OperatorType);
                    }
                    query.Append($" {cond.where} {cond.operators} '{cond.value}' ");


                }

            }
        }
        public static void JoinType(dynamic ob, ref StringBuilder query)
        {

            if (ob.foriegn != null)
            {
                foreach (var forign in ob.foriegn)
                {
                    query.Append($" {forign.joinType} {forign.tableName} ON {forign.tableName}.{forign.on.pKey} {forign.on.optor} {forign.foriegnTableName}.{forign.on.fKey} ");
                }
            }
        }
        public static void OrderType(dynamic ob, ref StringBuilder query)
        {
            if(ob.OrderBy != null)
            {
                foreach (var order in ob.OrderBy)
                {
                    query.Append($" ORDER BY  {order.ColumnName}  {order.OrderType}");
                }
            }
        }
    }
}
