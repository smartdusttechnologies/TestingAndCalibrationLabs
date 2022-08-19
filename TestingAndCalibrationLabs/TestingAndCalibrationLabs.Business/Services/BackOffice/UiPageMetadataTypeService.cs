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

        public RequestResult<int> Create(UiPageMetadataModel pageControl)
        {
            _uiPageMetadataTypeRepository.Create(pageControl);
            return new RequestResult<int>(1);
        }

        public bool Delete(int id)
        {
            return _uiPageMetadataTypeRepository.Delete(id);
        }

        public UiPageMetadataModel GetById(int id)
        {
            return _uiPageMetadataTypeRepository.GetById(id);
        }

        public RequestResult<int> Update(int id, UiPageMetadataModel pageControl)
        {
            _uiPageMetadataTypeRepository.Update(pageControl);
            return new RequestResult<int>(1);
        }

        public List<UiPageMetadataModel> GetAll()
        {
            return _uiPageMetadataTypeRepository.GetAll();
        }
    }
}
