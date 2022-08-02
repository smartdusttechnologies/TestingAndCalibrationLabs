
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model.Helper;
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
        //fetch pages
        public List<PageModel> GetPage()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<PageModel>("SELECT p.Name as PageName, p.Id as PageId from UiPageType p where IsDeleted=0").ToList();
        }
        
        public List<DataModel> GetData()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<DataModel>("SELECT d.DataTypeName as DataName, d.DataTypeId as DataId from UiDataType d where IsDeleted=0").ToList();
      }
        
        public List<ControlModel> GetControl()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<ControlModel>("SELECT c.Name as ControlName, c.Id as ControlId from UiControlType c where IsDeleted=0").ToList();
        }
        
        public List<ValModel> GetVal()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<ValModel>("SELECT v.Name as ValName, v.Id as ValId from UiPageValidationType v where IsDeleted=0").ToList();
        }
        
        public List<MetadataModel> GetMetadata()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<MetadataModel>("SELECT m.UiControlDisplayName as MetadataName, m.Id as MetadataId from UiPageMetadata m where IsDeleted=0").ToList();
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
