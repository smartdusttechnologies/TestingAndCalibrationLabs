
using System.Collections.Generic;


namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class UiQueryGenerator
    {
        /// <summary>
        /// this will store the tableName
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// This will store the Alias for tablename
        /// </summary>
        public char Alias { get; set; }
        /// <summary>
        /// This will contain the Column Name and its alias
        /// </summary>
        public List<UiQueryBuilder> ColumnName { get; set; }
    }
}
