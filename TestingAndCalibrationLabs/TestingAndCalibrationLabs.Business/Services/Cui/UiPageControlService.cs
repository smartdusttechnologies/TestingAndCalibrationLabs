using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces.Cui;
using TestingAndCalibrationLabs.Business.Core.Model.UiControl;
using TestingAndCalibrationLabs.Business.Core.Model.UiPageControl;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.Cui;

namespace TestingAndCalibrationLabs.Business.Services.Cui
{
    public class UiPageControlService : IUiPageControlService
    {
        public readonly IUiPageControlRepo _uiPageControlRepo;
        public UiPageControlService(IUiPageControlRepo uiPageControlRepo)
        {
            _uiPageControlRepo = uiPageControlRepo;
        }

        public RequestResult<int> Create(UiPageControlModel pageControl)
        {
            _uiPageControlRepo.Create(pageControl);
            return new RequestResult<int>(1);
        }

        public bool Delete(int id)
        {
            return _uiPageControlRepo.Delete(id);
        }

        public UiPageControlModel GetById(int id)
        {
            return _uiPageControlRepo.GetById(id);
        }

        List<UiPageControlModel> IUiPageControlService.GetAll()
        {
            return _uiPageControlRepo.GetAll();
        }
    }
}
