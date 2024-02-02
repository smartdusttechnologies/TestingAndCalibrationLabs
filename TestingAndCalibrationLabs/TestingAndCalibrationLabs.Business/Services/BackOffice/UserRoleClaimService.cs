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
    public class UserRoleClaimService : IUserRoleClaimService
    {
        private readonly IGenericRepository<UserRoleClaimModel> _genericRepository;
        private readonly IUserRoleClaimRepository _userRoleClaimRepository;
        public UserRoleClaimService(IUserRoleClaimRepository userRoleClaimRepository, IGenericRepository<UserRoleClaimModel> genericRepository)
        {
            _userRoleClaimRepository = userRoleClaimRepository;
            _genericRepository = genericRepository;
        }
        /// <summary>
        /// Get All Records From UserRoleClaim.
        /// </summary>
        public List<UserRoleClaimModel> Get()
        {
            var pageNavigation = _userRoleClaimRepository.Get();
            pageNavigation.ForEach(x => x.RoleName = string.Format(x.RoleName, x.RoleId, x.PermissionId, x.ClaimTypeId));
            return pageNavigation;
        }
        /// <summary>
        /// Insert Record In UserRoleClaim
        /// </summary>
        /// <param name="userRoleClaimModel"></param>
        public RequestResult<int> Create(UserRoleClaimModel userRoleClaimModel)
        {
            _userRoleClaimRepository.Create(userRoleClaimModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Delete Record From UserRoleClaim.
        /// </summary>
        /// <param name="id"></param>
        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }
        /// <summary>
        /// Get Record By Id From UserRoleClaim.
        /// </summary>
        /// <param name="id"></param>
        public UserRoleClaimModel GetById(int id)
        {
            return _userRoleClaimRepository.GetById(id);
        }
        /// <summary>
        /// Edit Record By UserRoleClaim
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userRoleClaimModel"></param>
        public RequestResult<int> Update(int id, UserRoleClaimModel userRoleClaimModel)
        {
            _userRoleClaimRepository.Update(userRoleClaimModel);
            return new RequestResult<int>(1);
        }
    }
}
