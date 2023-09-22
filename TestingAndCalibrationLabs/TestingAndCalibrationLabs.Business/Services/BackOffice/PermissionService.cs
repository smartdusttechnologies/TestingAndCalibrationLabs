using Google.Apis.Drive.v3.Data;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.BackOffice;

namespace TestingAndCalibrationLabs.Business.Services.BackOffice
{
    /// <summary>
    /// Service Class For Permission.
    /// </summary>
    public class PermissionService : IPermissionService
    {
        private readonly IGenericRepository<PermissionModel> _genericRepository;
        private readonly IPermissionRepository _permissionRepository;
        public PermissionService(IPermissionRepository permissionRepository, IGenericRepository<PermissionModel> genericRepository)
        {
            _permissionRepository = permissionRepository;
            _genericRepository = genericRepository;
        }
        /// <summary>
        /// Get All Records From Permission.
        /// </summary>
        /// <returns></returns
        public List<PermissionModel> Get()
        {
            var pageNavigation = _permissionRepository.Get();
            bool IgnoreNone = pageNavigation.Any(x => x.Id != (int)Helpers.None.Id);
            if (IgnoreNone)
            {
                pageNavigation = pageNavigation.Where(x => x.Id != (int)Helpers.None.Id).ToList();
                // write code to hide None element.
            }
            pageNavigation.ForEach(x =>x.Name = string.Format( x.Name, x.PermissionModuleTypeId, x.PermissionTypeId));
            return pageNavigation;
        }
        /// <summary>
        /// Insert Record In Permission
        /// </summary>
        /// <param name="PermissionModel"></param>
        /// <returns></returns>
        public RequestResult<int> Create(PermissionModel PermissionModel)
        {
            _permissionRepository.Create(PermissionModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Delete Record From Permission.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }
        /// <summary>
        /// Get Record By Id From Permission.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PermissionModel GetById(int id)
        {
            return _permissionRepository.GetById(id);
        }
        /// <summary>
        /// Edit Record By Permission
        /// </summary>
        /// <param name="id"></param>
        /// <param name="permissionModel"></param>
        /// <returns></returns>
        public RequestResult<int> Update(int id, PermissionModel permissionModel)
        {
            _permissionRepository.Update(permissionModel);
            return new RequestResult<int>(1);
        }
    }
}
