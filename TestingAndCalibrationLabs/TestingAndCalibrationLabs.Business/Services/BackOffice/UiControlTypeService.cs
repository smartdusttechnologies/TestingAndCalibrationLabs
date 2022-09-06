using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Class For Ui Control Type
    /// </summary>
    public class UiControlTypeService : IUiControlTypeService
    {
        private readonly IGenericRepository<UiControlTypeModel> _genericRepository;
        public UiControlTypeService( IGenericRepository<UiControlTypeModel> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        /// <summary>
        /// Get Record By Id For Ui Control Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiControlTypeModel GetById(int id)
        {
            return _genericRepository.Get(id);
        }
        /// <summary>
        /// Get All Record For Ui Control Type
        /// </summary>
        /// <returns></returns>
        public List<UiControlTypeModel> Get()
        {
            return _genericRepository.Get();
        }
        /// <summary>
        /// Edit Record From Ui Control Type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uiControlTypeModel"></param>
        /// <returns></returns>
        public RequestResult<int> Update( UiControlTypeModel uiControlTypeModel)
        {
            _genericRepository.Update(uiControlTypeModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Insert Record In Ui Control Type
        /// </summary>
        /// <param name="uiControlTypeModel"></param>
        /// <returns></returns>

        public RequestResult<int> Create(UiControlTypeModel uiControlTypeModel)
        {
            _genericRepository.Insert(uiControlTypeModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Delete Record From Ui Control 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }
    }
}
