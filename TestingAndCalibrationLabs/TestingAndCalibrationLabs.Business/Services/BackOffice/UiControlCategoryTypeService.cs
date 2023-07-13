using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Class For Ui Control Category Type
    /// </summary>
    public class UiControlCategoryTypeService : IUiControlCategoryTypeService
    {
        private readonly IGenericRepository<UiControlCategoryTypeModel> _genericRepository;
        public UiControlCategoryTypeService( IGenericRepository<UiControlCategoryTypeModel> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        /// <summary>
        /// Get Record By Id For Ui Control Category Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiControlCategoryTypeModel Get(int id)
        {
            return _genericRepository.Get(id);
        }
        /// <summary>
        /// Get All Record For Ui Control Category Type
        /// </summary>
        /// <returns></returns>
        public List<UiControlCategoryTypeModel> Get()
        {
            return _genericRepository.Get();
        }
        /// <summary>
        /// Edit Record From Ui Control Category Type
        /// </summary>
        /// <param name="uiControlCategoryTypeModel"></param>
        /// <returns></returns>
        public RequestResult<int> Update(UiControlCategoryTypeModel uiControlCategoryTypeModel)
        {
            _genericRepository.Update(uiControlCategoryTypeModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Insert Record In Ui Control Category Type
        /// </summary>
        /// <param name="uiControlCategoryTypeModel"></param>
        /// <returns></returns>

        public RequestResult<int> Create(UiControlCategoryTypeModel uiControlCategoryTypeModel)
        {
            _genericRepository.Insert(uiControlCategoryTypeModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Delete Record From Ui Control Category Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }
    }
}
