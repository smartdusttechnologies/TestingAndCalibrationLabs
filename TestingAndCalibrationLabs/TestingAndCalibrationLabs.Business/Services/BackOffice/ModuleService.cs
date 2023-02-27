using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    
    public class ModuleService : IModuleService
    {
        private readonly IGenericRepository<ModuleModel> _genericRepository;
        private readonly IModuleRepository _moduleRepository;
        public ModuleService(IGenericRepository<ModuleModel> genericRepository, IModuleRepository moduleRepository)
        {
            _genericRepository = genericRepository;
            _moduleRepository = moduleRepository;
        }
       
        public List<ModuleModel> Get()
        {
            return _moduleRepository.Get();
        }
        
        public RequestResult<int> Create(ModuleModel ModuleModel)
        {
            int id = _moduleRepository.Create(ModuleModel);
            return new RequestResult<int>(1);
        }

        public RequestResult<int> Update(ModuleModel ModuleModel)
        {
            _moduleRepository.Update(ModuleModel);
            return new RequestResult<int>(1);
        }
     
        public ModuleModel GetById(int id)
        {

            return _moduleRepository.GetById(id);
        }
        public bool Delete(int id)
        {
            return _moduleRepository.Delete(id);
        }

    }
}