using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class UiQueryBuilderColumn
    {

        /// <summary>
        /// This will store the Tablename For the QueryBuilder
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// it store the alias Name For TableName
        /// </summary>
        public char Alias { get; set; }
        /// <summary>
        /// It will store the column name and its title which is Alias For ColumnNamd\e
        /// </summary>
        public List<QueryGenerator> ColumnName { get; set; }
    }
}
