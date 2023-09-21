using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    /// Service Class For Ui Control Type
    /// </summary>
    public class UiControlTypeService : IUiControlTypeService
    {
        private readonly IGenericRepository<UiControlTypeModel> _genericRepository;
        public readonly IUiControlTypeRepository _uiControlTypeRepository;
        private readonly IAuthorizationService _authorizationService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UiControlTypeService(IUiControlTypeRepository uiControlTypeRepository,IGenericRepository<UiControlTypeModel> genericRepository, IAuthorizationService authorizationService, IHttpContextAccessor httpContextAccessor)

        
        {
            _genericRepository = genericRepository;
            _authorizationService = authorizationService;
            _httpContextAccessor = httpContextAccessor;
            _uiControlTypeRepository = uiControlTypeRepository;
        }
        #region Public methods
        /// <summary>
        /// Get Record By Id For Ui Control Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiControlTypeModel GetById(int id)
        {
            if (!_authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, new UiControlTypeModel(), Operations.Read).Result.Succeeded)
            {
                throw new UnauthorizedAccessException("Your Unauthorized");
            }
            return _uiControlTypeRepository.GetById(id);
        }
        /// <summary>
        /// Get All Record For Ui Control Type
        /// </summary>
        /// <returns></returns>
        public List<UiControlTypeModel> Get()
        {
            if (!_authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, new UiControlTypeModel(), Operations.Read).Result.Succeeded)
            {
                throw new UnauthorizedAccessException("Your Unauthorized");
            }
            
            return _uiControlTypeRepository.Get();
        }
        /// <summary>
        /// Get All Record For Control Type 
        /// </summary>
        /// <returns></returns>
        public List<UiControlTypeModel> GetControl()
        {
            return _uiControlTypeRepository.GetControl();
            
        }
        /// <summary>
        /// Edit Record From Ui Control Type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uiControlTypeModel"></param>
        /// <returns></returns>
        public RequestResult<int> Update(UiControlTypeModel uiControlTypeModel)
        {
            var result = new RequestResult<int>(1);
            if (!_authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, uiControlTypeModel, Operations.Update).Result.Succeeded)
            {
                throw new UnauthorizedAccessException("Your Unauthorized");
            }
            _uiControlTypeRepository.Update(uiControlTypeModel);
            return result;
        }
        /// <summary>
        /// Insert Record In Ui Control Type
        /// </summary>
        /// <param name="uiControlTypeModel"></param>
        /// <returns></returns>
        public RequestResult<int> Create(UiControlTypeModel uiControlTypeModel)
        {
            if (!_authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, uiControlTypeModel, Operations.Create).Result.Succeeded)
            {
                throw new UnauthorizedAccessException("Your Unauthorized");
            }
            _uiControlTypeRepository.Create(uiControlTypeModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Delete Record From Ui Control 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            if (!_authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, new UiControlTypeModel(), Operations.Delete).Result.Succeeded)
            {
                throw new UnauthorizedAccessException("Your Unauthorized");
            }
            return _uiControlTypeRepository.Delete(id);
        }
        #endregion
    }
}
