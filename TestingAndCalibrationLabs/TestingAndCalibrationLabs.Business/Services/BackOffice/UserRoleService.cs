using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.BackOffice;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice;

namespace TestingAndCalibrationLabs.Business.Services.BackOffice
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IGenericRepository<UserRoleModel> _genericRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        public UserRoleService(IUserRoleRepository userRoleRepository, IGenericRepository<UserRoleModel> genericRepository)
        {
            _userRoleRepository = userRoleRepository;
            _genericRepository = genericRepository;
        }
        /// <summary>
        /// Get All Records From User Role.
        /// </summary>
        public List<UserRoleModel> Get()
        {
            var pageNavigation = _userRoleRepository.Get();
            pageNavigation.ForEach(x => x.UserName = string.Format(x.UserName, x.UserId, x.RoleId));
            return pageNavigation;
        }
        /// <summary>
        /// Insert Record In User Role
        /// </summary>
        /// <param name="userRoleModel"></param>
        public RequestResult<int> Create(UserRoleModel userRoleModel)
        {
            _userRoleRepository.Create(userRoleModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Delete Record From User Role.
        /// </summary>
        /// <param name="id"></param>
        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }
        /// <summary>
        /// Get Record By Id From User Role.
        /// </summary>
        /// <param name="id"></param>
        public UserRoleModel GetById(int id)
        {
            return _userRoleRepository.GetById(id);
        }
        /// <summary>
        /// Edit Record By User Role
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userRoleModel"></param>
        public RequestResult<int> Update(int id, UserRoleModel userRoleModel)
        {
            _userRoleRepository.Update(userRoleModel);
            return new RequestResult<int>(1);
        }
        public UserRoleModel Get(int id)
        {
            return _genericRepository.Get(id);
        }
    }
}
