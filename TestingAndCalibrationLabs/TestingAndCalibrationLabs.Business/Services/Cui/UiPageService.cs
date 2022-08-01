using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces.Cui;
using TestingAndCalibrationLabs.Business.Core.Model.Helper;
using TestingAndCalibrationLabs.Business.Core.Model.UiPage;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.Cui;

namespace TestingAndCalibrationLabs.Business.Services.Cui
{
    public class UiPageService : IUiPageService
    {
        public readonly IUiPageRepo _uiPageRepo;
        public UiPageService(IUiPageRepo uiPageRepo)
        {
            _uiPageRepo = uiPageRepo;
        }

        public RequestResult<int> Create(UiPageModel pageModel)
        {
            _uiPageRepo.Create(pageModel);
            return new RequestResult<int>(1);
        }

        public bool Delete(int id)
        {
            return _uiPageRepo.Delete(id);
        }

        public RequestResult<int> Edit(int id, UiPageModel pageModel)
        {
            _uiPageRepo.Edit(pageModel);
            return new RequestResult<int>(1);
        }

        public List<UiPageModel> GetAll()
        {
            return _uiPageRepo.GetAll();
        }
        
        public List<PageModel> GetPage()
        {
            return _uiPageRepo.GetPage();
        }
        
        public List<DataModel> GetData()
        {
            return _uiPageRepo.GetData();
        }
        
        public List<ControlModel> GetControl()
        {
            return _uiPageRepo.GetControl();
        }

        public UiPageModel GetById(int id)
        {
            return _uiPageRepo.GetById(id);
        }
    }
}
