using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Class For Ui Control Type
    /// </summary>
    public class UiControlTypeService : IUiControlTypeService
    {
        private readonly IGenericRepository<UiControlTypeModel> _genericRepository;
        public readonly IUiControlTypeRepository _uiControlTypeRepository;

        public UiControlTypeService(IUiControlTypeRepository uiControlTypeRepository,IGenericRepository<UiControlTypeModel> genericRepository)
        {
            _genericRepository = genericRepository;
            _uiControlTypeRepository = uiControlTypeRepository;
        }
        #region Public methods
        /// <summary>
        /// Get Record By Id For Ui Control Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiControlTypeModel GetById(int id)
        {
            return _uiControlTypeRepository.GetById(id);
        }
        /// <summary>
        /// Get All Record For Ui Control Type
        /// </summary>
        /// <returns></returns>
        public List<UiControlTypeModel> Get()
        {
            return _uiControlTypeRepository.Get();
        }
        /// <summary>
        /// Get All Record For Control Type 
        /// </summary>
        /// <returns></returns>
        public List<UiControlTypeModel> GetControl()
        {
            return _uiControlTypeRepository.GetControl();
        }
        /// <summary>
        /// Edit Record From Ui Control Type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uiControlTypeModel"></param>
        /// <returns></returns>
        public RequestResult<int> Update( UiControlTypeModel uiControlTypeModel)
        {
            _uiControlTypeRepository.Update(uiControlTypeModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Insert Record In Ui Control Type
        /// </summary>
        /// <param name="uiControlTypeModel"></param>
        /// <returns></returns>

        public RequestResult<int> Create(UiControlTypeModel uiControlTypeModel)
        {
            _uiControlTypeRepository.Create(uiControlTypeModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Delete Record From Ui Control 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _uiControlTypeRepository.Delete(id);
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
