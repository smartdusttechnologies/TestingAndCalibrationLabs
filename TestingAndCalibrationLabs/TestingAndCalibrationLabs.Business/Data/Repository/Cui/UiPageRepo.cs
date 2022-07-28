
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model.UiPage;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.Cui;
using TestingAndCalibrationLabs.Business.Infrastructure;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Cui
{
    public class UiPageRepo : IUiPageRepo
    {
        public readonly IConnectionFactory _connectionFactory;
        public UiPageRepo(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public int Create(UiPageModel pageModel)
        {
            string query = @"Insert into [UiPageType] (Name)
                                values (@Name)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, pageModel);

        }

        public bool Delete(int id)
        {
            string query = @"Update [UiPageType] set
                                IsDeleted = @isDeleted
                                where id = @Id ";
            using IDbConnection db = _connectionFactory.GetConnection;
            db.Execute(query, new { isDeleted = true, Id = id });
            return true;
        }

        public List<UiPageModel> GetAll()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageModel>("Select * From [UiPageType] where IsDeleted=0").ToList();
        }

        public UiPageModel GetById(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageModel>("Select top 1 * From [UiPageType] where id=@id and IsDeleted=0", new { id }).FirstOrDefault();
        }

        public int Edit(UiPageModel pageModel)
        {
            string query = @"update [UiPageType] Set  
                                Name = @Name
                                Where Id = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query,pageModel);
        }
    }
}
