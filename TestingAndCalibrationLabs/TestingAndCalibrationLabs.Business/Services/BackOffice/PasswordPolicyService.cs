using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Implemention For Lookup
    /// </summary>
    public class PasswordPolicyService : IPasswordPolicyService
    {
        private readonly IGenericRepository<PasswordPolicyModel> _genericRepository;
        private readonly IPasswordPolicyRepository _PasswordPolicyRepository;
        public PasswordPolicyService(IGenericRepository<PasswordPolicyModel> genericRepository, IPasswordPolicyRepository PasswordPolicyRepository)
        {
            _genericRepository = genericRepository;
            _PasswordPolicyRepository = PasswordPolicyRepository;
        }
        /// <summary>
        /// Get All Records From Lookup
        /// </summary>
        /// <returns></returns>
        public List<PasswordPolicyModel> Get()
        {
            return _PasswordPolicyRepository.Get();
        }
        /// <summary>
        /// Insert Record In Lookup
        /// </summary>
        /// <param name="lookupModel"></param>
        /// <returns></returns>
        public RequestResult<int> Create(PasswordPolicyModel lookupModel)
        {
            int id = _PasswordPolicyRepository.Create(lookupModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Edit Record From Lookup
        /// </summary>
        /// <param name="lookupModel"></param>
        /// <returns></returns>
        public RequestResult<int> Update(PasswordPolicyModel lookupModel)
        {
            _PasswordPolicyRepository.Update(lookupModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Get Record by Id For Lookup
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PasswordPolicyModel GetById(int id)
        {

            return _PasswordPolicyRepository.GetById(id);
        }
        /// <summary>
        /// Delete Record From Lookup
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _PasswordPolicyRepository.Delete(id);
        }

    }
}
