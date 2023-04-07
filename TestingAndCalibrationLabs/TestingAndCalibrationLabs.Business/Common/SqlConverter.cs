
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Common
{
    public class SqlConverter
    {

        public static string JsonToSql(string json)
        {
            var str = File.ReadAllText("SqlQuery.json");
            dynamic ob = JObject.Parse(str);
            if (ob != null)
            {
                string typ = ob.head.tables[0].type.ToString();
                StringBuilder query = new StringBuilder(typ);
                if (ob.head.tables != null)
                {
                    foreach (var col in ob.head.tables[0].column)
                    {

                        //query.Append($" {col.tableName}.{col.columnName} AS {col.As} ,");
                        query.Append($" {col.columnName} ,");

                        if (col.As != null && col.columnName != "*")
                        {
                            query.Remove(query.Length - 1, 1);
                            query.Append($" As {col.As} ,");
                        }

                    }
                    query.Remove(query.Length - 1, 1);

                    query.Append($" FROM {ob.head.tables[0].tableName.ToString()} ");

                    if (ob.head.tables[0].condition != null)
                    {
                        query.Append($" Where {ob.head.tables[0].condition.where} {ob.head.tables[0].condition.operators} '{ob.head.tables[0].condition.value}' ");
                    }
                }


                return query.ToString();
            }
            return null;
        }


        public static string Column(string json)
        {
            
            return "";
        }
    }
}
