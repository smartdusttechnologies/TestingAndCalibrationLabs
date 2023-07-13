using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
   /// <summary>
   /// Service Implementation For Lookup Category
   /// </summary>
    public class LookupCategoryService : ILookupCategoryService
    {
        private readonly IGenericRepository<LookupCategoryModel> _genericRepository;
        public LookupCategoryService(IGenericRepository<LookupCategoryModel> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        #region Public methods
        /// <summary>
        /// Insert Record In LookupCategory
        /// </summary>
        /// <param name="lookupCategoryModel"></param>
        /// <returns></returns>
        public RequestResult<int> Create(LookupCategoryModel lookupCategoryModel)
        {
            _genericRepository.Insert(lookupCategoryModel);
            return new RequestResult<int>(1);
        }

        /// <summary>
        /// Delete Record From LookupCategory
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }

        /// <summary>
        /// Edit Record From LookupCategory
        /// </summary>
        /// <param name="lookupCategoryModel"></param>
        /// <returns></returns>
        public RequestResult<int> Update(LookupCategoryModel lookupCategoryModel)
        {
            _genericRepository.Update(lookupCategoryModel);
            return new RequestResult<int>(1);
        }

        /// <summary>
        /// Get All Records From LookupCategory
        /// </summary>
        /// <returns></returns>
        public List<LookupCategoryModel> Get()
        {
            return _genericRepository.Get();
        }

        /// <summary>
        /// Get Record by Id For LookupCategory
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public LookupCategoryModel GetById(int id)
        {
            return _genericRepository.Get(id);
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
