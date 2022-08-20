using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    public class UiPageMetadataTypeService : IUiPageMetadataTypeService
    {
        public readonly IUiPageMetadataTypeRepository _uiPageMetadataTypeRepository;
        public UiPageMetadataTypeService(IUiPageMetadataTypeRepository uiPageMetadataTypeRepository)
        {
            _uiPageMetadataTypeRepository = uiPageMetadataTypeRepository;
        }
        /// <summary>
        ///  To Insert Record In Ui Page Metadata Type
        /// </summary>
        /// <param name="pageControl"></param>
        /// <returns></returns>
        public RequestResult<int> Create(UiPageMetadataModel pageControl)
        {
            _uiPageMetadataTypeRepository.Create(pageControl);
            return new RequestResult<int>(1);
        }
        /// <summary>
        ///  To Delete Record From Ui Page Metadata Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _uiPageMetadataTypeRepository.Delete(id);
        }
        /// <summary>
        /// To Get Record by Id For Ui Page Metadata Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiPageMetadataModel GetById(int id)
        {
            return _uiPageMetadataTypeRepository.GetById(id);
        }
        /// <summary>
        /// To Edit Record From Ui Page Metadata Type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageControl"></param>
        /// <returns></returns>
        public RequestResult<int> Update(int id, UiPageMetadataModel pageControl)
        {
            _uiPageMetadataTypeRepository.Update(pageControl);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// To Get All Records From Ui Page Metadata Type
        /// </summary>
        /// <returns></returns>
        public List<UiPageMetadataModel> GetAll()
        {
            return _uiPageMetadataTypeRepository.GetAll();
        }
    }
}
