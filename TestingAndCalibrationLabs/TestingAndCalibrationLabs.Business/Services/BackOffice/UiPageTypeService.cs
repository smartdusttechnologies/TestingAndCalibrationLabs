using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Class For Ui Page Type
    /// </summary>
    public class UiPageTypeService : IUiPageTypeService
    {
       
        private readonly IGenericRepository<UiPageTypeModel> _genericRepository;
        private readonly IUiPageTypeRepository _uiPageTypeRepository;
        public UiPageTypeService( IGenericRepository<UiPageTypeModel> genericRepository, IUiPageTypeRepository uiPageTypeRepository)
        {
            _genericRepository = genericRepository;
            _uiPageTypeRepository = uiPageTypeRepository;
        }
        /// <summary>
        /// Create Record For Ui Page Type
        /// </summary>
        /// <param name="uiPageTypeModel"></param>
        /// <returns></returns>
        public RequestResult<int> Create(UiPageTypeModel uiPageTypeModel)
        {
            _genericRepository.Insert(uiPageTypeModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Delete Record From Ui Page Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }
        /// <summary>
        /// Edit Record For Ui Page Type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uiPageTypeModel"></param>
        /// <returns></returns>
        public RequestResult<int> Update( UiPageTypeModel uiPageTypeModel)
        {
            _genericRepository.Update(uiPageTypeModel);
            return new RequestResult<int>(1);
        }
       public List<UiPageTypeModel> Get()
        {
            return _uiPageTypeRepository.Get();
        }
        
        
        /// <summary>
        /// Get Record By Id From Ui Page Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiPageTypeModel GetById(int id)
        {
            return _genericRepository.Get(id);
        }
    }
}
