using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Infrastructure;

namespace TestingAndCalibrationLabs.Business.Data.Repository
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public ModuleRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<Dictionary<int, string>> GetValues(int moduleId)
        {
            using IDbConnection con = _connectionFactory.GetConnection;
            var query = @"select r.Id as Keys , upd.Value as [Values] From Record r 
                            Inner Join UiPageData upd on r.Id = upd.RecordId
                        where r.ModuleId = @moduleId and upd.UiPageMetadataId = 3014 and r.IsDeleted = 0 and upd.IsDeleted = 0";
            var df=  con.Query<Dictionary<int, string>>(query, new {moduleId}).ToList();
            return df;
        }
    }
}
