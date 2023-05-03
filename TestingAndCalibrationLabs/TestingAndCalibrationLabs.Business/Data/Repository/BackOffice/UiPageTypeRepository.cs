using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Infrastructure;

namespace TestingAndCalibrationLabs.Business.Data.Repository
{
    /// <summary>
    /// Repository Class For Ui Page Type
    /// </summary>
    public class UiPageTypeRepository : IUiPageTypeRepository
    {
        private IConnectionFactory _connectionFactory;
        public UiPageTypeRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Getting All Records From Ui Page Type
        /// </summary>
        /// <returns></returns>
        public List<UiPageTypeModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageTypeModel>(@"Select upt.Id, unc.[Id] as UiNavigationCategoryId, unc.[Name] as UiNavigationCategoryName, 
                                                    upt.Name, upt.Url
                                                From[UiPageType] upt
                                                    inner join[UiNavigationCategory] unc on upt.UiNavigationCategoryId = unc.Id
                                                where
                                                     upt.IsDeleted = 0
                                                    and unc.IsDeleted = 0 ").ToList();
        }
        /// <summary>
        /// Insert Record in Ui Page Type
        /// </summary>
        /// <param name="uiPageTypeModel"></param>
        /// <returns></returns>
        public int Insert(UiPageTypeModel uiPageTypeModel)
        {
            string query = @"Insert into [UiPageType] (Name,UiNavigationCategoryId,Url)
                                values (@Name,@UiNavigationCategoryId,@Url)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, uiPageTypeModel);
        }
        /// <summary>
        /// Edit Record For Ui Page Type 
        /// </summary>
        /// <param name="uiPageTypeModel"></param>
        /// <returns></returns>
        public int Update(UiPageTypeModel uiPageTypeModel)
        {
            string query = @"update [UiPageType] Set  
                                Name = @Name,
                                UiNavigationCategoryId = @UiNavigationCategoryId,
                                Url = @Url
                                Where Id = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, uiPageTypeModel);
        }
        /// <summary>
        /// Getting Record By Id For Ui Page Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiPageTypeModel GetById(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageTypeModel>(@"Select upt.Id, unc.[Id] as UiNavigationCategoryId, unc.[Name] as UiNavigationCategoryName, 
                                                    upt.Name, upt.Url
                                                From[UiPageType] upt
                                                    inner join[UiNavigationCategory] unc on upt.UiNavigationCategoryId = unc.Id
                                                where

                                                    upt.Id = @Id and
                                                     upt.IsDeleted = @isDeleted
                                                    and unc.IsDeleted = @isDeleted", new { isDeleted = 0, Id = id }).FirstOrDefault();
        }
    }
}
