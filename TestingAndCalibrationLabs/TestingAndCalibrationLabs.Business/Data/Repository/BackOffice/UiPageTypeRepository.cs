using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Infrastructure;

namespace TestingAndCalibrationLabs.Business.Data.Repository
{
    public class UiPageTypeRepository : IUiPageTypeRepository
    {
        private IConnectionFactory _connectionFactory;
        public UiPageTypeRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<UiPageTypeModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageTypeModel>(@"Select upt.Id, unc.[Id] as UiNavigationCategoryId, unc.[Name] as UiNavigationCategoryName, 
                                                    upt.Name
                                                From[UiPageType] upt
                                                    inner join[UiNavigationCategory] unc on upt.UiNavigationCategoryId = unc.Id
                                                where
                                                     upt.IsDeleted = 0
                                                    and unc.IsDeleted = 0 ").ToList();
        }
        public int Insert(UiPageTypeModel uiPageTypeModel)
        {
            string query = @"Insert into [UiPageType] (Name,UiNavigationCategoryId)
                                values (@UiPageTypeId,@Name,@UiNavigationCategoryId)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, uiPageTypeModel);
        }
    }
}
