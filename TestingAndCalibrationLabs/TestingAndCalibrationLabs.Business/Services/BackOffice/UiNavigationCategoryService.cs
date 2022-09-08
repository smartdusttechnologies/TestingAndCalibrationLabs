using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Class For Ui Navigation Category
    /// </summary>
    public class UiNavigationCategoryService : IUiNavigationCategoryService
    {
        private readonly IGenericRepository<UiNavigationCategoryModel> _genericRepository;
        private readonly IUiPageTypeRepository _uiPageTypeRepository;
        private readonly IUiPageNavigationRepository _uiPageNavigationRepository;
        public UiNavigationCategoryService(IGenericRepository<UiNavigationCategoryModel> genericRepository, IUiPageTypeRepository uiPageTypeRepository, IUiPageNavigationRepository uiPageNavigationRepository)
        {
            _genericRepository = genericRepository;
            _uiPageTypeRepository = uiPageTypeRepository;
            _uiPageNavigationRepository = uiPageNavigationRepository;
        }
        /// <summary>
        /// Get All Records From Ui Navigation Category
        /// </summary>
        /// <returns></returns>
        public List<UiNavigationCategoryModel> Get()
        {
            return _genericRepository.Get();
        }
        /// <summary>
        /// Get All Records From Page Type With Formated Url
        /// </summary>
        /// <returns></returns>
        public List<UiPageNavigationModel> GetNavigationCategoryWithPageTypes()
        {
            var pageNavigation = _uiPageNavigationRepository.Get();
            foreach (var item in pageNavigation)
            {
                item.FormatedUrl = string.Format(item.Url, item.Id);
            }
            return pageNavigation;
        }

    }
}
