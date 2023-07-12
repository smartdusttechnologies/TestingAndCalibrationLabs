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
        /// Getting all records from Ui Page Navigation
        /// </summary>
        /// <returns></returns>
        public List<UiPageNavigationModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageNavigationModel>(@"Select upt.Id, upt.UiPageTypeId, upt.UiNavigationCategoryId , unc.[Name] as UiNavigationCategoryName, 
                                                    pt.Name as UiPageTypeName, upt.Url, unc.[Orders] as Orders
                                                From[UiPageNavigation] upt
                                                    inner join[UiNavigationCategory] unc on upt.UiNavigationCategoryId = unc.Id
                                                    inner join[UiPageType] pt on upt.UiPageTypeId = pt.Id
											  where
                                                    upt.IsDeleted = 0
                                                    and unc.IsDeleted = 0 ").ToList();
        }
    }
}
