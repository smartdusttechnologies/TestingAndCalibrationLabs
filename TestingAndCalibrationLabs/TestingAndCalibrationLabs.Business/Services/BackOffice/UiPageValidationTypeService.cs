using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Class For Ui Page Validation Type
    /// </summary>
    public class UiPageValidationTypeService : IUiPageValidationTypeService
    {
        private readonly IGenericRepository<UiPageValidationTypeModel> _genericRepository;
        public UiPageValidationTypeService(IGenericRepository<UiPageValidationTypeModel> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        #region Public methods
        /// <summary>
        /// Get All Records From Ui Page Validation Type
        /// </summary>
        /// <returns></returns>
        public List<UiPageValidationTypeModel> Get()
        {
            return _genericRepository.Get();

        }
        #endregion

        #region Private Methods

        #endregion
    }
}
