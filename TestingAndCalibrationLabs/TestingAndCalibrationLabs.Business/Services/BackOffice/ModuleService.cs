using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Class For Module
    /// </summary>
    public class ModuleService : IModuleService
    {
        private readonly IGenericRepository<ModuleModel> _genericRepository;
        private readonly IModuleRepository _moduleRepository;
        public ModuleService(IGenericRepository<ModuleModel> genericRepository, IModuleRepository moduleRepository)
        {
            _genericRepository = genericRepository;
            _moduleRepository = moduleRepository;
        }
        /// <summary>
        /// Get All Records From Module
        /// </summary>
        /// <returns></returns>
        public List<ModuleModel> Get()
        {
            return _moduleRepository.Get();
        }
        /// <summary>
        /// Insert Record In Module
        /// </summary>
        /// <param name="moduleModel"></param>
        /// <returns></returns>
        public RequestResult<int> Create(ModuleModel moduleModel)
        {
            int id = _moduleRepository.Create(moduleModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Edit Record From Module
        /// </summary>
        /// <param name="moduleModel"></param>
        /// <returns></returns>
        public RequestResult<int> Update(ModuleModel moduleModel)
        {
            _moduleRepository.Update(moduleModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Get Record by Id For Module
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ModuleModel GetById(int id)
        {
            return _moduleRepository.GetById(id);
        }
        /// <summary>
        /// Delete Record From Module
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }
    }
}