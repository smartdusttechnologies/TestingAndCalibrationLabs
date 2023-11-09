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
    public class RoleClaimService : IRoleClaimService
    {
        private readonly IGenericRepository<RoleClaimModel> _genericRepository;
        private readonly IRoleClaimRepository _roleClaimRepository;
        public RoleClaimService(IRoleClaimRepository roleClaimRepository, IGenericRepository<RoleClaimModel> genericRepository)
        {
            _roleClaimRepository = roleClaimRepository;
            _genericRepository = genericRepository;
        }
        /// <summary>
        /// Get All Records From RoleClaim.
        /// </summary>
        public List<RoleClaimModel> Get()
        {
            var pageNavigation = _roleClaimRepository.Get();
            pageNavigation.ForEach(x => x.RoleName = string.Format(x.RoleName, x.RoleId, x.PermissionId, x.ClaimTypeId));
            return pageNavigation;
        }
        /// <summary>
        /// Insert Record In RoleClaim
        /// </summary>
        /// <param name="roleClaimModel"></param>
        public RequestResult<int> Create(RoleClaimModel roleClaimModel)
        {
            _roleClaimRepository.Create(roleClaimModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Delete Record From RoleClaim.
        /// </summary>
        /// <param name="id"></param>
        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }
        /// <summary>
        /// Get Record By Id From RoleClaim.
        /// </summary>
        /// <param name="id"></param>
        public RoleClaimModel GetById(int id)
        {
            return _roleClaimRepository.GetById(id);
        }
        /// <summary>
        /// Edit Record By RoleClaim
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roleClaimModel"></param>
        public RequestResult<int> Update(int id, RoleClaimModel roleClaimModel)
        {
            _roleClaimRepository.Update(roleClaimModel);
            return new RequestResult<int>(1);
        }
    }
}
