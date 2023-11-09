using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    public class PermissionModuleTypeService : IPermissionModuleTypeService
    {
        private readonly IGenericRepository<PermissionModuleTypeModel> _genericRepository;
        public PermissionModuleTypeService(IGenericRepository<PermissionModuleTypeModel> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        /// <summary>
        /// Get All Records From Permission Module Type Services 
        /// </summary>
        public List<PermissionModuleTypeModel> Get()
        {
            var pageNavigation = _genericRepository.Get();
            return pageNavigation;
        }
        /// <summary>
        /// Insert Record In Permission Module Type Services
        /// </summary>
        /// <param name="permissionModuleTypeModel"></param>
        public RequestResult<int> Create(PermissionModuleTypeModel permissionModuleTypeModel)
        {
            _genericRepository.Insert(permissionModuleTypeModel);

            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Delete Record From Permission Module Type Services
        /// </summary>
        /// <param name="id"></param>
        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }
        /// <summary>
        /// Get Record By Id From Permission Module Type Services
        /// </summary>
        /// <param name="id"></param>
        public PermissionModuleTypeModel GetById(int id)
        {
            return _genericRepository.Get(id);
        }
        /// <summary>
        /// Edit Record By Permission Module Type Services
        /// </summary>
        /// <param name="id"></param>
        /// <param name="permissionTypeModel"></param>
        public RequestResult<int> Update(int id, PermissionModuleTypeModel permissionModuleTypeModel)
        {
            _genericRepository.Update(permissionModuleTypeModel);
            return new RequestResult<int>(1);
        }
    }
}
