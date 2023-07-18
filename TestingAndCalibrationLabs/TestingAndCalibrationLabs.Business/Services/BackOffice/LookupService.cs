﻿using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Implemention For Lookup
    /// </summary>
    public class LookupService : ILookupService
    {
        private readonly IGenericRepository<LookupModel> _genericRepository;
        private readonly ILookupRepository _lookupRepository;
        public LookupService(IGenericRepository<LookupModel> genericRepository, ILookupRepository lookupRepository)
        {
            _genericRepository = genericRepository;
            _lookupRepository = lookupRepository;
        }
        /// <summary>
        /// Get All records Of Lookup 
        /// </summary>
        /// <returns></returns>
        public List<LookupModel> Get()
        {

            return _genericRepository.Get();
        }
        public List<LookupModel> GetByLookupCategoryId(int lookupCategoryId)
        {
            return _lookupRepository.GetByLookupCategoryId(lookupCategoryId);
        }
        public List<LookupModel> GetLookupCategoryId(int lookupCategoryId)
        {

            return _lookupRepository.GetLookupCategoryId(lookupCategoryId);
        }
        /// <summary>
        /// Insert Record In Lookup
        /// </summary>
        /// <param name="lookupModel"></param>
        /// <returns></returns>
        public RequestResult<int> Create(LookupModel lookupModel)
        {
            int id = _lookupRepository.Create(lookupModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Edit Record From Lookup
        /// </summary>
        /// <param name="lookupModel"></param>
        /// <returns></returns>
        public RequestResult<int> Update(LookupModel lookupModel)
        {
            _lookupRepository.Update(lookupModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Get Record by Id For Lookup
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public LookupModel GetById(int id)
        {

            return _lookupRepository.GetById(id);
        }
        /// <summary>
        /// Delete Record From Lookup
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _lookupRepository.Delete(id);
        }
    }
}
