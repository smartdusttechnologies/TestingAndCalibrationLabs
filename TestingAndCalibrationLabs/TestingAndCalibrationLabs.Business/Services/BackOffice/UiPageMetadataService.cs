using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    public class UiPageMetadataService : IUiPageMetadataService
    {
        public readonly IUiPageMetadataRepository _uiPageMetadataRepository;
        public UiPageMetadataService(IUiPageMetadataRepository uiPageMetadataRepository)
        {
            _uiPageMetadataRepository = uiPageMetadataRepository;
        }
        /// <summary>
        ///  To Insert Record In Ui Page Metadata Type
        /// </summary>
        /// <param name="pageControl"></param>
        /// <returns></returns>
        public RequestResult<int> Create(UiPageMetadataModel pageControl)
        {
            _uiPageMetadataRepository.Create(pageControl);
            return new RequestResult<int>(1);
        }
        /// <summary>
        ///  To Delete Record From Ui Page Metadata Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _uiPageMetadataRepository.Delete(id);
        }
        /// <summary>
        /// To Get Record by Id For Ui Page Metadata Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiPageMetadataModel GetById(int id)
        {
            return _uiPageMetadataRepository.GetById(id);
        }
        /// <summary>
        /// To Edit Record From Ui Page Metadata Type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageControl"></param>
        /// <returns></returns>
        public RequestResult<int> Update(int id, UiPageMetadataModel pageControl)
        {
            _uiPageMetadataRepository.Update(pageControl);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// To Get All Records From Ui Page Metadata Type
        /// </summary>
        /// <returns></returns>
        public List<UiPageMetadataModel> GetAll()
        {
            return _uiPageMetadataRepository.GetAll();
        }
    }
}
