using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces.Cui;
using TestingAndCalibrationLabs.Business.Core.Model.UiControl;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.Cui;

namespace TestingAndCalibrationLabs.Business.Services.Cui
{
    public class UiControlService : IUiControlService
    {
        public readonly IUiControlRepo _uiControlRepo;
        public UiControlService(IUiControlRepo uiControlRepo)
        {
            _uiControlRepo = uiControlRepo;
        }
        public UiControlModel Get(int id)
        {
            return _uiControlRepo.Get(id);
        }
        public List<UiControlModel> GetAll()
        {
            return _uiControlRepo.GetAll();
        }
        public RequestResult<int> Edit(int id, UiControlModel canModel)
        {
            _uiControlRepo.Edit(canModel);
            return new RequestResult<int>(1);
        }

        public RequestResult<int> Create(UiControlModel conModel)
        {
            _uiControlRepo.Create(conModel);
            return new RequestResult<int>(1);
        }
        public bool Delete(int id)
        {
            return _uiControlRepo.Delete(id);
        }
    }
}
