using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using NPOI.OpenXmlFormats.Spreadsheet;
using System;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Class For Ui Page Type
    /// </summary>
    public class UiPageTypeService : IUiPageTypeService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthorizationService _authorizationService;
        private readonly IGenericRepository<UiPageTypeModel> _genericRepository;
        private readonly IWorkflowStageRepository _workflowStageRepository;
        public readonly IUiPageMetadataRepository _uiPageMetadataRepository;
        private readonly IModuleLayoutRepository _moduleLayoutRepository;
        public UiPageTypeService(IHttpContextAccessor httpContextAccessor, IGenericRepository<UiPageTypeModel> genericRepository,
            IAuthorizationService authorizationService, IWorkflowStageRepository workflowStageRepository, IUiPageMetadataRepository uiPageMetadataRepository, IModuleLayoutRepository moduleLayoutRepository)
        {
            _workflowStageRepository = workflowStageRepository;
            _httpContextAccessor = httpContextAccessor;
            _authorizationService = authorizationService;
            _genericRepository = genericRepository;
            _uiPageMetadataRepository = uiPageMetadataRepository;
            _moduleLayoutRepository = moduleLayoutRepository;
        }

        #region Public methods
        /// <summary>
        /// Create Record For Ui Page Type
        /// </summary>
        /// <param name="uiPageTypeModel"></param>
        /// <returns></returns>
        public RequestResult<int> Create(UiPageTypeModel uiPageTypeModel)
        {
            if (!_authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, uiPageTypeModel, new[] { Operations.Create }).Result.Succeeded)
            {
                throw new UnauthorizedAccessException("Your Unauthorized");
            }
            if (uiPageTypeModel.WorkflowStageId == 0 && uiPageTypeModel.WorkflowStageId == null)
            {
                _genericRepository.Insert(uiPageTypeModel);

            }
            if (uiPageTypeModel.WorkflowStageId !=0 && uiPageTypeModel.WorkflowStageId != null)
            {
               
                var workflowStages = _workflowStageRepository.GetbyModuleId(uiPageTypeModel.ModuleId);
                var getModuleId = _moduleLayoutRepository.GetByModuleLayoutId(uiPageTypeModel.ModuleId);
                var CountStage = workflowStages.Count;
                var lists = new UiPageMetadataModel();

                lists.UiControlTypeId = 29;
                lists.IsRequired = false;
                lists.UiControlDisplayName = uiPageTypeModel.Name;
                lists.DataTypeId = 1;
                lists.UiControlCategoryTypeId = 1017;
                lists.Name = uiPageTypeModel.Name;
                lists.ModuleLayoutId = getModuleId.Id;
                lists.WorkflowStageId = uiPageTypeModel.WorkflowStageId;
                lists.ModuleId = uiPageTypeModel.ModuleId;
                    var insertMetadata = _uiPageMetadataRepository.CreateUsingPages(lists, CountStage);
            }
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Delete Record From Ui Page Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            if (!_authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, new UiPageTypeModel(), new[] { Operations.Delete }).Result.Succeeded)
            {
                throw new UnauthorizedAccessException("Your Unauthorized");
            }
            return _genericRepository.Delete(id);
        }
        /// <summary>
        /// Edit Record For Ui Page Type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uiPageTypeModel"></param>
        /// <returns></returns>
        public RequestResult<int> Update(UiPageTypeModel uiPageTypeModel)
        {
            if (!_authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, uiPageTypeModel, new[] { Operations.Update }).Result.Succeeded)
            {
                throw new UnauthorizedAccessException("Your Unauthorized");
            }
            _genericRepository.Update(uiPageTypeModel);
            return new RequestResult<int>(1);
        }
        public List<UiPageTypeModel> Get()
        {
            if (!_authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, new UiPageTypeModel(), new[] { Operations.Read }).Result.Succeeded)
            {
                throw new UnauthorizedAccessException("Your Unauthorized");
            }
            return _genericRepository.Get();
        }

        /// <summary>
        /// Get Record By Id From Ui Page Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiPageTypeModel GetById(int id)
        {
            if (!_authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, new UiPageTypeModel(), new[] { Operations.Read }).Result.Succeeded)
            {
                throw new UnauthorizedAccessException("Your Unauthorized");
            }
            return _genericRepository.Get(id);
        }
        #endregion
    }
}