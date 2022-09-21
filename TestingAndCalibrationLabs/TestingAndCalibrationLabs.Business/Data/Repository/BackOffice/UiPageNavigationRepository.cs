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
    /// Repository Class For Ui Page Navigation 
    /// </summary>
    public class UiPageNavigationRepository : IUiPageNavigationRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public UiPageNavigationRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Getting All Records From Ui Page Navigation
        /// </summary>
        /// <returns></returns>
        public List<UiPageTypeModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UiPageTypeModel>(@"Select upt.Id, unc.[Id] as UiNavigationCategoryId, unc.[Name] as UiNavigationCategoryName, 
                                                    upt.Name, upt.Url, unc.[Order] as Orders
                                                From [UiPageType] upt
                                                    right join [UiNavigationCategory] unc on upt.UiNavigationCategoryId = unc.Id and upt.IsDeleted = 0
                                                where
                                                     unc.IsDeleted = 0 ").ToList();
        }
    }
}
