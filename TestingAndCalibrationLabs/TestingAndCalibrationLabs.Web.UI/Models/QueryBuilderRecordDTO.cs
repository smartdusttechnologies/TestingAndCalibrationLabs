using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class QueryBuilderRecordDTO
    {
        /// <summary>
        /// This will be a key value Pair for Table and its Column Pair
        /// </summary>
        public Dictionary<QueryBuilderDTO, List<Models.QueryBuilderColNamesDTO>> FieldValues { get; set; }
        public Dictionary<string, List<object>> Dictionary { get; set; }
    }
}
