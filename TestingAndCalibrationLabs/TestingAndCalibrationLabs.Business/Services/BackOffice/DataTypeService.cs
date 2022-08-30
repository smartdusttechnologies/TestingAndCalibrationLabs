using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Class For Data Type
    /// </summary>
    public class DataTypeService : IDataTypeService
    {
        private readonly IGenericRepository<DataTypeModel> _genericRepository;
        public DataTypeService(IGenericRepository<DataTypeModel> genericRepository)
        {
            _genericRepository = genericRepository; 
        }
        /// <summary>
        /// Get All Records From Data Type
        /// </summary>
        /// <returns></returns>
        public List<DataTypeModel> Get()
        {
            return _genericRepository.Get();
        }
    }
}
