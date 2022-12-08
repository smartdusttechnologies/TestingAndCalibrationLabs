using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public List<UserRoleClaim> GetRoleByOrganizationWithClaims(string userName)
        {
            return _roleRepository.GetRoleByOrganizationWithClaims(userName);
        }

        public List<(int, string)> GetRoleWithOrg(string userName)
        {
            return _roleRepository.GetRoleWithOrg(userName);
        }
    }
}
