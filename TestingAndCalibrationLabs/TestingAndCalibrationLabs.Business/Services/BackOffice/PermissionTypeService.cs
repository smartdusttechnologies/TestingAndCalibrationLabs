using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services.BackOffice
{
    public class PermissionTypeService : IPermissionTypeService
    {
        private readonly IGenericRepository<PermissionTypeModel> _genericRepository;
        public PermissionTypeService(IGenericRepository<PermissionTypeModel> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        /// <summary>
        /// Get All Records From Permission Type Services
        /// </summary>
        public List<PermissionTypeModel> Get()
        {
            var pageNavigation = _genericRepository.Get();
            return pageNavigation;
        }
        /// <summary>
        /// Insert Record In Permission Type Services
        /// </summary>
        /// <param name="permissionTypeModel"></param>
        /// <returns></returns>
        public RequestResult<int> Create(PermissionTypeModel permissionTypeModel)
        {
            _genericRepository.Insert(permissionTypeModel);

            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Delete Record From Permission Type Services
        /// </summary>
        /// <param name="id"></param>
        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }
        /// <summary>
        /// Get Record By Id From Permission Type Services
        /// </summary>
        /// <param name="id"></param>
        public PermissionTypeModel GetById(int id)
        {
            return _genericRepository.Get(id);
        }
        /// <summary>
        /// Edit Record By Permission Type Services
        /// </summary>
        /// <param name="id"></param>
        /// <param name="permissionTypeModel"></param>
        public RequestResult<int> Update(int id, PermissionTypeModel permissionTypeModel)
        {
            _genericRepository.Update(permissionTypeModel);
            return new RequestResult<int>(1);
        }
    }
}
