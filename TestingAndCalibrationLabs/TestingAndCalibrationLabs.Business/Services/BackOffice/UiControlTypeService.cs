using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    public class UiControlTypeService : IUiControlTypeService
    {
        public readonly IUiControlTypeRepository _uiControlTypeRepository;
        public UiControlTypeService(IUiControlTypeRepository uiControlTypeRepository)
        {
            _uiControlTypeRepository = uiControlTypeRepository;
        }
        /// <summary>
        /// To Get Record By Id For Ui Control Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiControlTypeModel Get(int id)
        {
            return _uiControlTypeRepository.Get(id);
        }
        /// <summary>
        /// To Get All Record For Ui Control Type
        /// </summary>
        /// <returns></returns>
        public List<UiControlTypeModel> GetAll()
        {
            return _uiControlTypeRepository.GetAll();
        }
        /// <summary>
        /// To Edit Record From Ui Control Type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uiControlTypeModel"></param>
        /// <returns></returns>
        public RequestResult<int> Edit(int id, UiControlTypeModel uiControlTypeModel)
        {
            _uiControlTypeRepository.Edit(uiControlTypeModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// To Insert Record In Ui Control Type
        /// </summary>
        /// <param name="uiControlTypeModel"></param>
        /// <returns></returns>

        public RequestResult<int> Create(UiControlTypeModel uiControlTypeModel)
        {
            _uiControlTypeRepository.Create(uiControlTypeModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// To Delete Record From Ui Control 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _uiControlTypeRepository.Delete(id);
        }
    }
}
