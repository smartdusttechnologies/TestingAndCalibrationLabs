using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class QueryBuilderRecordDTO
    {
        public Dictionary<QueryBuilderDTO, List<Models.QueryBuilderColNamesDTO>> FieldValues { get; set; }

    }
}
