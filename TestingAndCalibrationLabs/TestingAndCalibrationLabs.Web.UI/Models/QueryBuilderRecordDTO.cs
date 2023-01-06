using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model.QueryBuilder;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class QueryBuilderRecordDTO
    {
        public Dictionary<QueryBuilderDTO, List<Models.QueryBuilderColNamesDTO>> FieldValues { get; set; }

    }
}
