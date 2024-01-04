using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Infrastructure;

namespace TestingAndCalibrationLabs.Business.Data.Repository
{
    /// <summary>
    /// Repository class for Ui Page Navigation 
    /// </summary>
    public class UiPageNavigationRepository : IUiPageNavigationRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public UiPageNavigationRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Insert Record In Ui Page Navigation 
        /// </summary>
        /// <param name="uiPageNavigationModel"></param>
        /// <returns></returns>
        public int Create(UiPageNavigationModel uiPageNavigationModel)
        {
            string query = @"Insert into [UiPageNavigation] (Url,ModuleId,UiNavigationCategoryId,IconName)
                                values (@Url,@ModuleId,@UiNavigationCategoryId,@IconName)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, uiPageNavigationModel);
        }
        /// <summary>
        /// Getting all records from Ui Page Navigation
        /// </summary>
        /// <returns></returns>
        public List<UiPageNavigationModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageNavigationModel>(@"SELECT upt.Id, upt.ModuleId, upt.UiNavigationCategoryId, unc.[Name] as UiNavigationCategoryName,
       unc.[NavigationTypeId] as NavigationType, pt.Name as ModuleName, upt.Url, unc.[Orders] as Orders,
       upt.IconName as IconName, unc.IconName as UiPageNavigationCategoryIcon
FROM [UiPageNavigation] upt
INNER JOIN [UiNavigationCategory] unc ON upt.UiNavigationCategoryId = unc.Id
INNER JOIN [Module] pt ON upt.ModuleId = pt.Id
WHERE upt.IsDeleted = 0
  AND unc.IsDeleted = 0
  AND pt.IsDeleted = 0").ToList();
        }

        /// <summary>
        /// Getting Record By Id For Ui Page Navigation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiPageNavigationModel GetById(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageNavigationModel>(@"SELECT upt.Id,upt.ModuleId, upt.UiNavigationCategoryId , unc.[Name] as UiNavigationCategoryName, 
                                                    pt.Name as ModuleName, upt.Url, unc.[Orders] as Orders,upt.IconName as IconName
                                                    From[UiPageNavigation] upt
                                                    inner join[UiNavigationCategory] unc on upt.UiNavigationCategoryId = unc.Id
                                                    inner join[Module] pt on upt.ModuleId = pt.Id
											        where
                                                    upt.Id=@Id and
                                                    pt.IsDeleted=0 and
                                                    upt.IsDeleted = 0
                                                    and unc.IsDeleted = 0", new { isDeleted = 0, Id = id }).FirstOrDefault();
        }
        /// <summary>
        /// Edit Record From Ui Page Navigation 
        /// </summary>
        /// <param name="UiPageNavigationModel"></param>
        /// <returns></returns>
        public int Update(UiPageNavigationModel uiPageNavigationModel)
        {
            string query = @"update [UiPageNavigation] Set 
                                    Url=@Url,
                                  ModuleId = @ModuleId,
                                 UiNavigationCategoryId = @UiNavigationCategoryId,
                                 IconName = @IconName
                                 Where
                                IsDeleted = 0 and
                                Id = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;

            return db.Execute(query, uiPageNavigationModel);
        }
    }
}