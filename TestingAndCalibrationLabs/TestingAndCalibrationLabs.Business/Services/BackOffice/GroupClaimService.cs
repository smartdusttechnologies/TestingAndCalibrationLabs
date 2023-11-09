using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.BackOffice;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice;

namespace TestingAndCalibrationLabs.Business.Services.BackOffice
{
    public class GroupClaimService : IGroupClaimService
    {
        private readonly IGenericRepository<GroupClaimModel> _genericRepository;
        private readonly IGroupClaimRepository _groupClaimRepository;
        public GroupClaimService(IGroupClaimRepository groupClaimRepository, IGenericRepository<GroupClaimModel> genericRepository)
        {
            _groupClaimRepository = groupClaimRepository;
            _genericRepository = genericRepository;
        }
        /// <summary>
        /// Get All Records From GroupClaim.
        /// </summary>
        public List<GroupClaimModel> Get()
        {
            var pageNavigation = _groupClaimRepository.Get();
            pageNavigation.ForEach(x => x.GroupName = string.Format(x.GroupName, x.GroupId, x.ClaimTypeId, x.PermissionId));
            return pageNavigation;
        }
        /// <summary>
        /// Insert Record In GroupClaim
        /// </summary>
        /// <param name="groupClaimModel"></param>
        public RequestResult<int> Create(GroupClaimModel groupClaimModel)
        {
            _groupClaimRepository.Create(groupClaimModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Delete Record From GroupClaim.
        /// </summary>
        /// <param name="id"></param>
        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }
        /// <summary>
        /// Get Record By Id From GroupClaim.
        /// </summary>
        /// <param name="id"></param>
        public GroupClaimModel GetById(int id)
        {
            return _groupClaimRepository.GetById(id);
        }
        /// <summary>
        /// Edit Record By GroupClaim
        /// </summary>
        /// <param name="id"></param>
        /// <param name="groupClaimModel"></param>
        public RequestResult<int> Update(int id, GroupClaimModel groupClaimModel)
        {
            _groupClaimRepository.Update(groupClaimModel);
            return new RequestResult<int>(1);
        }
    }
}
