using System;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    public class UiNavigationCategoryServices : IUiNavigationCategoryServices

    {
        private readonly IGenericRepository<UiNavigationCategoryModel> _genericRepository;
        public UiNavigationCategoryServices(IGenericRepository<UiNavigationCategoryModel> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        #region Public methods
        /// <summary>
        /// Create Record For Ui Page Navigation Category
        /// </summary>
        /// <param name="uiPageTypeModel"></param>
        /// <returns></returns>
        public RequestResult<int> Create(UiNavigationCategoryModel UiNavigationCategoryModel)
        {
            _genericRepository.Insert(UiNavigationCategoryModel);
            return new RequestResult<int>(1);
        }

        /// <summary>
        /// Delete Record From Ui Page Navigation Category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }

        /// <summary>
        /// Edit Record For Ui Navigation Category
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uiPageTypeModel"></param>
        /// <returns></returns>
        public RequestResult<int> Update(int id ,UiNavigationCategoryModel UiNavigationCategoryModel)
        {
            _genericRepository.Update(UiNavigationCategoryModel);
            return new RequestResult<int>(1);
        }

        /// <summary>
        /// Get All Records From Ui Page Navigation Category
        /// </summary>
        /// <returns></returns>
        public List<UiNavigationCategoryModel> Get()
        {
            return _genericRepository.Get();
        }

        /// <summary>
        /// Get Record By Id From Ui Page Navigation Category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiNavigationCategoryModel GetById(int id)
        {
            return _genericRepository.Get(id);
        }
     
        #endregion
    }
}
