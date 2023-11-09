using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Class For SubPermissionModuleType.
    /// </summary>
    public class SubPermissionModuleTypeServices : ISubPermissionModuleTypeService
    {
        
            private readonly IGenericRepository<SubPermissionModuleTypeModel> _genericRepository;
            private readonly ISubPermissionModuleTypeRepository _subPermissionModuleTypeRepository;
            public SubPermissionModuleTypeServices(ISubPermissionModuleTypeRepository subPermissionModuleTypeRepository, IGenericRepository<SubPermissionModuleTypeModel> genericRepository)
            {
                _subPermissionModuleTypeRepository = subPermissionModuleTypeRepository;
                _genericRepository = genericRepository;
            }
            /// <summary>
            /// Get All Records From SubPermissionModuleType.
            /// </summary>
            public List<SubPermissionModuleTypeModel> Get()
            {
            var pageNavigation = _subPermissionModuleTypeRepository.Get();
            bool IgnoreNone = pageNavigation.Any(x => x.Id != (int)Helpers.None.Id);
                if (IgnoreNone)
                {
                    pageNavigation = pageNavigation.Where(x => x.Id != (int)Helpers.None.Id).ToList();
                    // write code to hide None element.
                }
                pageNavigation.ForEach(x => x.Name = string.Format(x.Name, x.PermissionModuleTypeId));
                return pageNavigation;
            }
            /// <summary>
            /// Insert Record In SubPermissionModuleType
            /// </summary>
            /// <param name="subPermissionModuleTypeModel"></param>
            public RequestResult<int> Create(SubPermissionModuleTypeModel subPermissionModuleTypeModel)
            {
                _subPermissionModuleTypeRepository.Create(subPermissionModuleTypeModel);
                return new RequestResult<int>(1);
            }
            /// <summary>
            /// Delete Record From SubPermissionModuleType
            /// </summary>
            /// <param name="id"></param>
            public bool Delete(int id)
            {
                return _genericRepository.Delete(id);
            }
            /// <summary>
            /// Get Record By Id From SubPermissionModuleType
            /// </summary>
            /// <param name="id"></param>
            public SubPermissionModuleTypeModel GetById(int id)
            {
                return _subPermissionModuleTypeRepository.GetById(id);
            }
            /// <summary>
            /// Edit Record By SubPermissionModuleType
            /// </summary>
            /// <param name="id"></param>
            /// <param name="subPermissionModuleTypeModel"></param>
            public RequestResult<int> Update(int id, SubPermissionModuleTypeModel subPermissionModuleTypeModel)
            {
                _subPermissionModuleTypeRepository.Update(subPermissionModuleTypeModel);
                return new RequestResult<int>(1);
            }
   }
}