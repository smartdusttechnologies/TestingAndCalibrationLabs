using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Class For Ui Page Validation
    /// </summary>
    public class UiPageValidationService : IUiPageValidationService
    {
        private readonly IGenericRepository<UiPageValidationModel> _genericRepository;
        private readonly IUiPageValidationRepository _uiPageValidationTypeRepository;
        public UiPageValidationService(IUiPageValidationRepository uiPageValidationTypeRepository,IGenericRepository<UiPageValidationModel> genericRepository )
        {
            _uiPageValidationTypeRepository = uiPageValidationTypeRepository;
            _genericRepository = genericRepository;
        }
        /// <summary>
        /// Insert Record In Ui Page Validation 
        /// </summary>
        /// <param name="pageControl"></param>
        /// <returns></returns>
        public RequestResult<int> Create(UiPageValidationModel pageControl)
        {
            _uiPageValidationTypeRepository.Create(pageControl);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Delete Record From Ui Page Validation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }
        /// <summary>
        /// Get All Record From Ui Page Validation 
        /// </summary>
        /// <returns></returns>
        public List<UiPageValidationModel> Get()
        {
            return _uiPageValidationTypeRepository.Get();
        }
        /// <summary>
        /// Get Record By Id From Ui Page Valdation 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiPageValidationModel GetById(int id)
        {
            return _uiPageValidationTypeRepository.GetById(id);
        }
        /// <summary>
        /// Edit Record By Ui Page Validation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageControl"></param>
        /// <returns></returns>
        public RequestResult<int> Update(int id, UiPageValidationModel pageControl)
        {
            _uiPageValidationTypeRepository.Update(pageControl);
            return new RequestResult<int>(1);
        }
    }
}
