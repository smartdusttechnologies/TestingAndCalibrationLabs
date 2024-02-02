using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services.BackOffice
{
    public class ClaimTypeService : IClaimTypeService
    {
        private readonly IGenericRepository<ClaimTypeModel> _genericRepository;
        public ClaimTypeService(IGenericRepository<ClaimTypeModel> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        /// <summary>
        /// Get All Records From Claim Type Service
        /// </summary>
        public List<ClaimTypeModel> Get()
        {
            var pageNavigation = _genericRepository.Get();
            return pageNavigation;
        }
        /// <summary>
        /// Insert Record In Claim Type Service
        /// </summary>
        /// <param name="claimTypeModel"></param>
        public RequestResult<int> Create(ClaimTypeModel claimTypeModel)
        {
            _genericRepository.Insert(claimTypeModel);

            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Delete Record From Claim Type Service
        /// </summary>
        /// <param name="id"></param>
        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }
        /// <summary>
        /// Get Record By Id From Claim Type Service
        /// </summary>
        /// <param name="id"></param>
        public ClaimTypeModel GetById(int id)
        {
            return _genericRepository.Get(id);
        }
        /// <summary>
        /// Edit Record By Claim Type Service
        /// </summary>
        /// <param name="id"></param>
        /// <param name="claimTypeModel"></param>
        public RequestResult<int> Update(int id, ClaimTypeModel claimTypeModel)
        {
            _genericRepository.Update(claimTypeModel);
            return new RequestResult<int>(1);
        }
    }
}
