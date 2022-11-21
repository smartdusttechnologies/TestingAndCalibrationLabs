using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Class For Ui Navigation Category
    /// </summary>
    public class UiPageNavigationService : IUiPageNavigationService
    {
        private readonly IGenericRepository<UiNavigationCategoryModel> _genericRepository;
        private readonly IUiPageNavigationRepository _uiPageNavigationRepository;
        public UiPageNavigationService(IGenericRepository<UiNavigationCategoryModel> genericRepository, IUiPageNavigationRepository uiPageNavigationRepository)
        {
            _genericRepository = genericRepository;
            _uiPageNavigationRepository = uiPageNavigationRepository;
        }
       
        /// <summary>
        /// Get All Records From Page Type With Formated Url
        /// </summary>
        /// <returns></returns>
        public List<UiPageNavigationModel> Get()
        {
            var pageNavigation = _uiPageNavigationRepository.Get();
            pageNavigation.ForEach(x => x.FormatedUrl = string.Format(x.Url, x.UiPageTypeId));
            //foreach (var item in pageNavigation)
            //{
            //    item.FormatedUrl = string.Format(item.Url, item.Id);
            //}
            return pageNavigation;
        }
    }
}
