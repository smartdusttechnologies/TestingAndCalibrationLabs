using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    public class UiPageTypeService : IUiPageTypeService
    {
        public readonly IUiPageTypeRepository _uiPageTypeRepository;
        public UiPageTypeService(IUiPageTypeRepository uiPageTypeRepository)
        {
            _uiPageTypeRepository = uiPageTypeRepository;
        }
        /// <summary>
        /// To Create Record For Ui Page Type
        /// </summary>
        /// <param name="uiPageTypeModel"></param>
        /// <returns></returns>
        public RequestResult<int> Create(UiPageTypeModel uiPageTypeModel)
        {
            _uiPageTypeRepository.Create(uiPageTypeModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// To Delete Record From Ui Page Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _uiPageTypeRepository.Delete(id);
        }
        /// <summary>
        /// To Edit Record For Ui Page Type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uiPageTypeModel"></param>
        /// <returns></returns>
        public RequestResult<int> Edit(int id, UiPageTypeModel uiPageTypeModel)
        {
            _uiPageTypeRepository.Edit(uiPageTypeModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// To Get All Record From Ui Page Type
        /// </summary>
        /// <returns></returns>
        public List<UiPageTypeModel> GetAll()
        {
            return _uiPageTypeRepository.GetAll();
        }
        /// <summary>
        /// To Get All Record From Data Type
        /// </summary>
        /// <returns></returns>
        public List<DataTypeModel> GetDataType()
        {
            return _uiPageTypeRepository.GetDataType();
        }
        /// <summary>
        /// To Get All Records From Ui Page Validation Type
        /// </summary>
        /// <returns></returns>
        public List<UiPageValidationTypeModel> GetUiPageValidationType()
        {
            return _uiPageTypeRepository.GetUiPageValidationType();
        }
        /// <summary>
        /// To Get Record By Id From Ui Page Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiPageTypeModel GetById(int id)
        {
            return _uiPageTypeRepository.GetById(id);
        }
    }
}
