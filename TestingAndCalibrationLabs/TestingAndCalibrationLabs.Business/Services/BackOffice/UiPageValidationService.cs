using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    public class UiPageValidationService : IUiPageValidationService
    {
        public readonly IUiPageValidationRepository _uiPageValidationTypeRepository;
        public UiPageValidationService(IUiPageValidationRepository uiPageValidationTypeRepository)
        {
            _uiPageValidationTypeRepository = uiPageValidationTypeRepository;
        }
        /// <summary>
        /// To Insert Record In Ui Page Validation 
        /// </summary>
        /// <param name="pageControl"></param>
        /// <returns></returns>
        public RequestResult<int> Create(UiPageValidationModel pageControl)
        {
            _uiPageValidationTypeRepository.Create(pageControl);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// To Delete Record From Ui Page Validation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _uiPageValidationTypeRepository.Delete(id);
        }
        /// <summary>
        /// To Get All Record From Ui Page Validation 
        /// </summary>
        /// <returns></returns>
        public List<UiPageValidationModel> GetAll()
        {
            return _uiPageValidationTypeRepository.GetAll();
        }
        /// <summary>
        /// To Get Record By Id From Ui Page Valdation 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiPageValidationModel GetById(int id)
        {
            return _uiPageValidationTypeRepository.GetById(id);
        }
        /// <summary>
        /// To Edit Record By Ui Page Validation
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
