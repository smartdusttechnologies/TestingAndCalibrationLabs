using Dapper;
using PagedList;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model.UiControl;
using TestingAndCalibrationLabs.Business.Infrastructure;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.Cui;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Cui
{
    public class UiControlRepo : IUiControlRepo
    {
        public readonly IConnectionFactory _connectionFactory;
        public UiControlRepo(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public UiControlModel Get(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiControlModel>("Select top 1 * From [UiControlType] where id=@id and IsDeleted=0", new { id }).FirstOrDefault();
        }



        public int Edit(UiControlModel conModel)
        {
            string query = @"update [UiControlType] Set  
                                Name = @Name,
                                DisplayName = @DisplayName
                                Where Id = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, conModel);
        }
        public int Create(UiControlModel conModel)
        {
            string query = @"Insert into [UiControlType] (Name,DisplayName)
                                values (@Name, @DisplayName)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, conModel);
        }

        public bool Delete(int id)
        {
            string query = @"Update [UiControlType] set
                                IsDeleted = @isDeleted
                                where id = @Id ";
            using IDbConnection db = _connectionFactory.GetConnection;
            db.Execute(query, new { isDeleted = true, Id = id });
            return true;

        }

        public List<UiControlModel> GetAll()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiControlModel>("Select * From [UiControlType] where IsDeleted=0").ToList();


        }



    }
}
