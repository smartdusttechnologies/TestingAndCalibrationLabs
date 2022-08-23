using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    public class UiPageValidationTypeService : IUiPageValidationTypeService
    {
        private readonly IGenericRepository<UiPageValidationTypeModel> _genericRepository;
        public UiPageValidationTypeService(IGenericRepository<UiPageValidationTypeModel> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        /// <summary>
        /// To Get All Records From Ui Page Validation Type
        /// </summary>
        /// <returns></returns>
        public List<UiPageValidationTypeModel> Get()
        {
            return _genericRepository.Get();

        }
    }
}
