using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public UiPageMetadataService(IHttpContextAccessor httpContextAccessor,IAuthorizationService authorizationService,IUiPageMetadataRepository uiPageMetadataRepository,IGenericRepository<UiPageMetadataModel> genericRepository, IUiPageMetadataCharacteristicsRepository uiPageMetadataCharacteristicsRepository)
        {
            _uiPageMetadataRepository = uiPageMetadataRepository;
            _uiPageMetadataCharacteristicsRepository = uiPageMetadataCharacteristicsRepository;
           _httpContextAccessor= httpContextAccessor;
            _authorizationService= authorizationService;
        }
        /// <summary>
        /// Insert Record In Ui Page Metadata Type
        /// </summary>
        /// <param name="pageControl"></param>
        /// <returns></returns>
        public RequestResult<int> Create(UiPageMetadataModel pageControl)
        {
            if (_authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, pageControl, new[] { Operations.Create }).Result.Succeeded)
            {
                int id = _uiPageMetadataRepository.Create(pageControl);
                return new RequestResult<int>(1);
            }
            return new RequestResult<int>(0);   
        }
        /// <summary>
        /// Delete Record From Ui Page Metadata Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            if (_authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, new UiPageMetadataModel(), new[] { Operations.Delete }).Result.Succeeded)
            {
                return _uiPageMetadataRepository.Delete(id);
            }
            return false;
        }
        /// <summary>
        /// Get Record by Id For Ui Page Metadata Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiPageMetadataModel GetById(int id)
        {
            if (_authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, new UiPageMetadataModel(), new[] { Operations.Read }).Result.Succeeded)
            {
                return _uiPageMetadataRepository.GetById(id);
            }
            return null;
        }
        /// <summary>
        /// Edit Record From Ui Page Metadata Type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uiPageMetadataModel"></param>
        /// <returns></returns>
        public RequestResult<int> Update(int id, UiPageMetadataModel uiPageMetadataModel)
        {
            if (_authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, uiPageMetadataModel, new[] { Operations.Update }).Result.Succeeded)
            {
                _uiPageMetadataRepository.Update(uiPageMetadataModel);
                return new RequestResult<int>(1);
            }
            return new RequestResult<int>(0);
        }
        /// <summary>
        /// Get All Records From Ui Page Metadata Type
        /// </summary>
        /// <returns></returns>
        public List<UiPageMetadataModel> Get()
        {
            if (_authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, new UiPageMetadataModel(), new[] { Operations.Read }).Result.Succeeded)
            {
                return _uiPageMetadataRepository.Get();
            }
            return null;
        }
    }
}
