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
    public class ModuleService : IModuleService
    {
        private readonly IGenericRepository<ModuleModel> _genericRepository;
        public ModuleService(IGenericRepository<ModuleModel> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        /// <summary>
        /// Get All Records From Data Type
        /// </summary>
        /// <returns></returns>
        public List<ModuleModel> Get()
        {
            return _genericRepository.Get();
        }
        public RequestResult<int> Create(ModuleModel ModuleModel)
        {
            _genericRepository.Insert(ModuleModel);
            return new RequestResult<int>(1);
        }
        public RequestResult<int> Update(ModuleModel ModuleModel)
        {
            _genericRepository.Update(ModuleModel);
            return new RequestResult<int>(1);
        }
        public ModuleModel GetById(int id)
        {
            return _genericRepository.Get(id);
        }
        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }

    }
}