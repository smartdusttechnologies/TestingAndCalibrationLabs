using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class UiQueryBuilderColumn
    {
        public string TableName { get; set; }
        public char Alias { get; set; }
        public List<QueryGenerator> ColumnName { get; set; }
    }
}
