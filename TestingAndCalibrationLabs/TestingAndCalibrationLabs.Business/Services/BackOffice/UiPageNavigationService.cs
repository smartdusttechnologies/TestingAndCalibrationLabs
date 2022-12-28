using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Class For Ui Page Navigation.
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

        #region Public methods
        /// <summary>
        /// Get All Records From Ui Page Navigation With Formated Url.
        /// </summary>
        /// <returns></returns>
        public List<UiPageNavigationModel> Get()
        {
            var pageNavigation = _uiPageNavigationRepository.Get();
            bool IgnoreNone = pageNavigation.Any(x => x.Id != (int)Helpers.None.Id);
            if (IgnoreNone)
            {
                pageNavigation = pageNavigation.Where(x => x.Id != (int)Helpers.None.Id).ToList();
                // write code to hide None element.
            }
            pageNavigation.ForEach(x => x.FormatedUrl = string.Format(x.Url, x.UiPageTypeId));
            return pageNavigation;
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
