using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model.QueryBuilder;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces.QueryBuilder
{
    public interface IQueryBuilderService
    {
        List<QueryBuilderModel> GetTableNames();

        QueryRecordModel GetColoumsNames(List<QueryBuilderModel> tableNames);
    }
}
