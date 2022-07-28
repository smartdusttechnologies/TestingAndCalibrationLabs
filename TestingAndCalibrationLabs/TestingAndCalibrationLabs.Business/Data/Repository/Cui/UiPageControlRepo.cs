using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model.UiPageControl;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.Cui;
using TestingAndCalibrationLabs.Business.Infrastructure;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Cui
{
    public class UiPageControlRepo : IUiPageControlRepo
    {
        public readonly IConnectionFactory _connectionFactory;
        public UiPageControlRepo(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public int Create(UiPageControlModel pageCon)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<UiPageControlModel> GetAll()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageControlModel>("Select * From [UiPageMetadata] where IsDeleted=0").ToList();
        }

        public UiPageControlModel GetById(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageControlModel>("Select Top 1 * From [UiPageMetaData] Where Id = @Id && Isdeleted = 0", new { isDeleted = 0, Id = id }).FirstOrDefault();
        }

        public int Update(UiPageControlModel pageCon)
        {
            throw new NotImplementedException();
        }
    }
}
