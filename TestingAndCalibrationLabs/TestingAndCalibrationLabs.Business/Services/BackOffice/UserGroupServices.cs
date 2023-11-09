using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.BackOffice;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice;

namespace TestingAndCalibrationLabs.Business.Services.BackOffice
{
    public class UserGroupServices : IUserGroupServices
    {
        private readonly IGenericRepository<UserGroupModel> _genericRepository;
        private readonly IUserGroupRepository _userGroupRepository;
        public UserGroupServices(IUserGroupRepository userGroupRepository, IGenericRepository<UserGroupModel> genericRepository)
        {
            _userGroupRepository = userGroupRepository;
            _genericRepository = genericRepository;
        }
        /// <summary>
        /// Get All Records From User Group.
        /// </summary>
        public List<UserGroupModel> Get()
        {
            var pageNavigation = _userGroupRepository.Get();
            pageNavigation.ForEach(x => x.GroupName = string.Format(x.GroupName, x.GroupId, x.UserId));
            return pageNavigation;
        }
        /// <summary>
        /// Insert Record In User Group
        /// </summary>
        /// <param name="userGroupModel"></param>
        public RequestResult<int> Create(UserGroupModel userGroupModel)
        {
            _userGroupRepository.Create(userGroupModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Delete Record From User Group.
        /// </summary>
        /// <param name="id"></param>
        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }
        /// <summary>
        /// Get Record By Id From User Group.
        /// </summary>
        /// <param name="id"></param>
        public UserGroupModel GetById(int id)
        {
            return _userGroupRepository.GetById(id);
        }
        /// <summary>
        /// Edit Record By User Group
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userGroupModel"></param>
        public RequestResult<int> Update(int id, UserGroupModel userGroupModel)
        {
            _userGroupRepository.Update(userGroupModel);
            return new RequestResult<int>(1);
        }
        public UserGroupModel Get(int id)
        {
            return _genericRepository.Get(id);
        }
    }
}
