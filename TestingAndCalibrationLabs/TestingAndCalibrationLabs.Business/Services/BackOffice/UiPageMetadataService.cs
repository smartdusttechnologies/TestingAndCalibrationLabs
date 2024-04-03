using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Class For Ui Page Metadata
    /// </summary>
    public class UiPageMetadataService : IUiPageMetadataService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUiPageMetadataCharacteristicsRepository _uiPageMetadataCharacteristicsRepository;
        public readonly IUiPageMetadataRepository _uiPageMetadataRepository;
        public UiPageMetadataService(IHttpContextAccessor httpContextAccessor, IAuthorizationService authorizationService, IUiPageMetadataRepository uiPageMetadataRepository, IGenericRepository<UiPageMetadataModel> genericRepository, IUiPageMetadataCharacteristicsRepository uiPageMetadataCharacteristicsRepository)
        {
            _uiPageMetadataRepository = uiPageMetadataRepository;
            _uiPageMetadataCharacteristicsRepository = uiPageMetadataCharacteristicsRepository;
            _httpContextAccessor = httpContextAccessor;
            _authorizationService = authorizationService;
        }
        #region Public methods
        /// <summary>
        /// Insert Record In Ui Page Metadata Type
        /// </summary>
        /// <param name="uiPageMetadataModel"></param>
        /// <returns></returns>
        public RequestResult<int> Create(UiPageMetadataModel uiPageMetadataModel)
        {
            if (!_authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, uiPageMetadataModel, new[] { Operations.Create }).Result.Succeeded)
            {
                throw new UnauthorizedAccessException("Your Unauthorized");
            }
            int id = _uiPageMetadataRepository.Create(uiPageMetadataModel);
            return new RequestResult<int>(1);

        }
        /// <summary>
        /// Delete Record From Ui Page Metadata Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id, int metadataModuleBridgeId)
        {
            if (!_authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, new UiPageMetadataModel(), new[] { Operations.Delete }).Result.Succeeded)
            {
                throw new UnauthorizedAccessException("Your Unauthorized");
            }
            return _uiPageMetadataRepository.Delete(id, metadataModuleBridgeId);
        }
        /// <summary>
        /// Get Record by Id For Ui Page Metadata Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiPageMetadataModel GetById(int id)
        {
            if (!_authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, new UiPageMetadataModel(), new[] { Operations.Read }).Result.Succeeded)
            {
                throw new UnauthorizedAccessException("Your Unauthorized");
            }
            return _uiPageMetadataRepository.GetById(id);
        }
        /// <summary>
        /// Edit Record From Ui Page Metadata Type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uiPageMetadataModel"></param>
        /// <returns></returns>
        public RequestResult<int> Update(UiPageMetadataModel uiPageMetadataModel)
        {
            if (!_authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, uiPageMetadataModel, new[] { Operations.Update }).Result.Succeeded)
            {
                throw new UnauthorizedAccessException("Your Unauthorized");
            }
            _uiPageMetadataRepository.Update(uiPageMetadataModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// <param name="moduleLayoutId"></param>
        /// Get all page based on moduleLayoutId
        /// <returns></returns>
        public List<UiPageTypeModel> Getpages(int moduleLayoutId )
        {
          return  _uiPageMetadataRepository.GetPages(moduleLayoutId);
        }
        
        /// <summary>
        /// Get All Records From Ui Page Metadata Type
        /// </summary>
        /// <returns></returns>
        public List<UiPageMetadataModel> Get()
        {
            if (!_authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, new UiPageMetadataModel(), new[] { Operations.Read }).Result.Succeeded)
            {
                throw new UnauthorizedAccessException("Your Unauthorized");
            }
            return _uiPageMetadataRepository.Get();
        }
        /// <summary>
        /// Get All Records by moduleLayoutId From Ui Page Metadata Type
        /// </summary>
        /// <returns></returns>
        public List<UiPageMetadataModel> GetResult( int moduleLayoutId)
        {

            return _uiPageMetadataRepository.GetExistingMetadata(moduleLayoutId);
        }
        /// <summary>
        /// Get All UIDisplayName  From Ui Page Metadata Type
        /// </summary>
        /// <returns></returns>
        public List<UiPageMetadataModel> GetDisplayName(int moduleLayoutId,int ModuleIds)
        {
            return _uiPageMetadataRepository.GetDisplayName(moduleLayoutId, ModuleIds);
        }
        /// <summary>
        /// Get Record by Id and uiPageTypeId ,metadataModuleBridgeId For Ui Page Metadata Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiPageMetadataModel GetByPageId(int id, int uiPageTypeId, int metadataModuleBridgeId)
        {

            return _uiPageMetadataRepository.GetByUiPageTypeId(id, uiPageTypeId, metadataModuleBridgeId);
        }
        #endregion
    }
}
