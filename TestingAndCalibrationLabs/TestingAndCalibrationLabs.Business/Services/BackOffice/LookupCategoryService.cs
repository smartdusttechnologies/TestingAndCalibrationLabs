using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
   
    public class LookupCategoryService : ILookupCategoryService
    {
        private readonly IGenericRepository<LookupCategoryModel> _genericRepository;
        public LookupCategoryService(IGenericRepository<LookupCategoryModel> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public RequestResult<int> Create(LookupCategoryModel lookupCategoryModel)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }
        public List<LookupCategoryModel> Get()
        {
            return _genericRepository.Get();
        }

        public LookupCategoryModel GetById(int id)
        {
            return _genericRepository.Get(id);
        }

        public RequestResult<int> Update(LookupCategoryModel lookupCategoryModel)
        {
            throw new System.NotImplementedException();
        }

    }
}
