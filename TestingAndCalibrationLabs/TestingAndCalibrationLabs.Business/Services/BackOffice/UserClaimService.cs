using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.BackOffice;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Data.Repository.BackOffice;
using TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice;

namespace TestingAndCalibrationLabs.Business.Services.BackOffice
{
    public class UserClaimService : IUserClaimService
    {
        private readonly IGenericRepository<UserClaimModel> _genericRepository;
        private readonly IUserClaimRepository _userClaimRepository;
        public UserClaimService(IUserClaimRepository userClaimRepository, IGenericRepository<UserClaimModel> genericRepository)
        {
            _userClaimRepository = userClaimRepository;
            _genericRepository = genericRepository;
        }
        /// <summary>
        /// Get All Records From UserClaim.
        /// </summary>
        public List<UserClaimModel> Get()
        {
            var pageNavigation = _userClaimRepository.Get();
            pageNavigation.ForEach(x => x.UserName = string.Format(x.UserName, x.UserId, x.PermissionId, x.ClaimTypeId));
            return pageNavigation;
        }
        /// <summary>
        /// Insert Record In UserClaim
        /// </summary>
        /// <param name="userClaimModel"></param>
        public RequestResult<int> Create(UserClaimModel userClaimModel)
        {
            _userClaimRepository.Create(userClaimModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Delete Record From UserClaim.
        /// </summary>
        /// <param name="id"></param>
        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }
        /// <summary>
        /// Get Record By Id From UserClaim.
        /// </summary>
        /// <param name="id"></param>
        public UserClaimModel GetById(int id)
        {
            return _userClaimRepository.GetById(id);
        }
        /// <summary>
        /// Edit Record By UserClaim
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userClaimModel"></param>
        public RequestResult<int> Update(int id, UserClaimModel userClaimModel)
        {
            _userClaimRepository.Update(userClaimModel);
            return new RequestResult<int>(1);
        }
    }
}
