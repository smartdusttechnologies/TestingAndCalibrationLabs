using System.Collections.Generic;
using System.Linq;
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
        private readonly IUiPageTypeRepository _uiPageTypeRepository;
        public UiNavigationCategoryService(IGenericRepository<UiNavigationCategoryModel> genericRepository, IUiPageTypeRepository uiPageTypeRepository)
        {
            _genericRepository = genericRepository;
            _uiPageTypeRepository = uiPageTypeRepository;
        }
        /// <summary>
        /// Get All Records From Data Type
        /// </summary>
        /// <returns></returns>
        public List<UiNavigationCategoryModel> Get()
        {
            return _genericRepository.Get();
        }
        public List<UiPageNavigationModel> GetNavigationCategoryWithPageTypes()
        {
            var pageTypeList = _uiPageTypeRepository.Get();
            var navigationCategoryList = _genericRepository.Get();
            List<UiPageNavigationModel> result = new List<UiPageNavigationModel>();
            foreach (var item in navigationCategoryList)
            {
                var pageType = pageTypeList.Where(x => x.UiNavigationCategoryId == item.Id);
                result.Add(new UiPageNavigationModel { Id = item.Id, Name = item.Name, UiPageTypeModels = pageType.ToList() });
            }
            return result;
        }

    }
}
