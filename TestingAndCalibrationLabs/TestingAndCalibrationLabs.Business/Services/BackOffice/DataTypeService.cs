using System.Collections.Generic;
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
        public List<DataTypeModel> Get()
        {
            return _genericRepository.Get();
        }
    }
}
