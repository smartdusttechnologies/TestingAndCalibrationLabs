using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Class For Data Type
    /// </summary>
    public class ApplicationService : IApplicationService
    {
        private readonly IGenericRepository<ApplicationModel> _genericRepository;
        public ApplicationService(IGenericRepository<ApplicationModel> genericRepository)
        {
            _genericRepository = genericRepository; 
        }

        
        public List<ApplicationModel> Get()
        {
            return _genericRepository.Get();
        }
        

    }
}
