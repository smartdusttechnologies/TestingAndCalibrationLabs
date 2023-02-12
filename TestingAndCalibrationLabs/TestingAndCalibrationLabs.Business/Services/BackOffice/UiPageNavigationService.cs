﻿using System.Collections.Generic;
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
        private readonly IGenericRepository<UiPageNavigationModel> _genericRepository;
        private readonly IUiPageNavigationRepository _uiPageNavigationTypeRepository;
        public UiPageNavigationService(IUiPageNavigationRepository uiPageNavigationTypeRepository, IGenericRepository<UiPageNavigationModel> genericRepository)
        {
            _uiPageNavigationTypeRepository = uiPageNavigationTypeRepository;
            _genericRepository = genericRepository;
        }
        /// <summary>
        /// Get All Records From Ui Page Navigation With Formated Url.
        /// </summary>
        /// <returns></returns>
        //public List<UiPageNavigationModel> Get()
        //{
        //    var pageNavigation = _uiPageNavigationTypeRepository.Get();
        //    bool IgnoreNone = pageNavigation.Any(x => x.Id != (int)Helpers.None.Id);
        //    if (IgnoreNone)
        //    {
        //        pageNavigation = pageNavigation.Where(x => x.Id != (int)Helpers.None.Id).ToList();
        //        ////// ////////        // write code to hide None element.
        //    }
        //    pageNavigation.ForEach(x => x.FormatedUrl = string.Format(x.Url, x.ModuleId));
        //    return pageNavigation;
        //}
        #region Public methods
        /// <summary>
        /// Insert Record In Ui Page Navigation 
        /// </summary>
        /// <param name="pageControl"></param>
        /// <returns></returns>
        public RequestResult<int> Create(UiPageNavigationModel pageControl)
        {
            _uiPageNavigationTypeRepository.Create(pageControl);
            return new RequestResult<int>(1);
        }

        public RequestResult<int> Create(int id, UiPageNavigationModel uiPageNavigationModel)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Delete Record From Ui Page Validation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }
        /// <summary>
        /// Get All Record From Ui Page Validation 
        /// </summary>
        /// <returns></returns>
        public List<UiPageNavigationModel> Get()
        {
            return _uiPageNavigationTypeRepository.Get();
        }
        /// <summary>
        /// Get Record By Id From Ui Page Valdation 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiPageNavigationModel GetById(int id)
        {
            return _uiPageNavigationTypeRepository.GetById(id);
        }
        /// <summary>
        /// Edit Record By Ui Page Navigation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageControl"></param>
        /// <returns></returns>
        public RequestResult<int> Update(int id, UiPageNavigationModel pageControl)
        {
            _uiPageNavigationTypeRepository.Update(pageControl);
            return new RequestResult<int>(1);
        }

        #endregion

        #region Private Methods

        #endregion
    }
}