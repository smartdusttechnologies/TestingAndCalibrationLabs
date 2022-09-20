using System.Collections.Generic;
using System.Linq;
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
        public LookupService(IGenericRepository<LookupModel> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        /// <summary>
        /// Get All records Of Lookup 
        /// </summary>
        /// <returns></returns>
        public List<LookupModel> Get()
        {
            
            return _genericRepository.Get();
        }
    }
}
