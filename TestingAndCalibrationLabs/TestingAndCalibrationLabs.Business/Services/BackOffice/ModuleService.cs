﻿using System.Collections.Generic;
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
        private readonly IModuleRepository _moduleRepository;
        public ModuleService(IGenericRepository<ModuleModel> genericRepository, IModuleRepository moduleRepository)
        {
            _genericRepository = genericRepository;
            _moduleRepository = moduleRepository;
        }
        /// <summary>
        /// Get All Records From Data Type
        /// </summary>
        /// <returns></returns>
        public List<ModuleModel> Get()
        {
            return _genericRepository.Get();
        }
        public List<Dictionary<int, string>> GetValues(int moduleId)
        {
            return _moduleRepository.GetValues(moduleId);
        }
    }
}
