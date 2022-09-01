using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    
    public class DataTypeService : IDataTypeService
    {
        private readonly IGenericRepository<DataTypeModel> _genericRepository;
        public DataTypeService(IGenericRepository<DataTypeModel> genericRepository)
        {
            _genericRepository = genericRepository; 
        }

        public RequestResult<int> Create(DataTypeModel dataTypeModel)
        {
            _genericRepository.Insert(dataTypeModel);
            return new RequestResult<int>(1);
        }

        public bool Delete(int id)
        {
          return _genericRepository.Delete(id);
        }

        public RequestResult<int> Edit(DataTypeModel dataTypeModel)
        {
            _genericRepository.Update(dataTypeModel);
            return new RequestResult<int>(1);
        }

        public List<DataTypeModel> Get()
        {
            return _genericRepository.Get();
        }
       

        public DataTypeModel GetById(int id)
        {
            return _genericRepository.Get(id);
        }
    }
}
