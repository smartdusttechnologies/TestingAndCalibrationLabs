using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Class For Data Type
    /// </summary>
    public class UiNavigationCategoryService : IUiNavigationCategoryService
    {
        private readonly IGenericRepository<UiNavigationCategoryModel> _genericRepository;
        public UiNavigationCategoryService(IGenericRepository<UiNavigationCategoryModel> genericRepository)
        {
            _genericRepository = genericRepository; 
        }
        /// <summary>
        /// Get All Records From Data Type
        /// </summary>
        /// <returns></returns>
        public List<UiNavigationCategoryModel> Get()
        {
            return _genericRepository.Get();
        }
    }
}
