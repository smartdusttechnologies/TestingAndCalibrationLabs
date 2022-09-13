using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
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
        /// <summary>
        /// To initialise the constructor
        /// </summary>
        /// <param name="genericRepository"></param>
        public DataTypeService(IGenericRepository<DataTypeModel> genericRepository)
        {
            _genericRepository = genericRepository; 
        }
        /// <summary>
        /// To Create Record DataType
        /// </summary>
        /// <param name="dataTypeModel"></param>
        /// <returns></returns>
        public RequestResult<int> Create(DataTypeModel dataTypeModel)
        {
            _genericRepository.Insert(dataTypeModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// To delete Record from DataType
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
          return _genericRepository.Delete(id);
        }
        /// <summary>
        /// To Edit a record Datatype
        /// </summary>
        /// <param name="dataTypeModel"></param>
        /// <returns></returns>
        public RequestResult<int> Edit(DataTypeModel dataTypeModel)
        {
            _genericRepository.Update(dataTypeModel);
            return new RequestResult<int>(1);
        }

        /// <summary>
        /// Get All Records From Data Type
        /// </summary>
        /// <returns></returns>
        public List<DataTypeModel> Get()
        {
            return _genericRepository.Get();
        }
       /// <summary>
       /// Get Record of dataType By Id
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>

        public DataTypeModel GetById(int id)
        {
            return _genericRepository.Get(id);
        }
    }
}
