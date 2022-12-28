using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
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
        private readonly IUiPageTypeRepository _uiPageTypeRepository;
        public UiPageTypeService(IHttpContextAccessor httpContextAccessor, IGenericRepository<UiPageTypeModel> genericRepository,
            IUiPageTypeRepository uiPageTypeRepository,
            IAuthorizationService authorizationService)
        {
            _httpContextAccessor = httpContextAccessor;
            _authorizationService = authorizationService;
            _genericRepository = genericRepository;
            _uiPageTypeRepository = uiPageTypeRepository;
        }
        /// <summary>
        /// Create Record For Ui Page Type
        /// </summary>
        /// <param name="uiPageTypeModel"></param>
        /// <returns></returns>
        public RequestResult<int> Create(UiPageTypeModel uiPageTypeModel)
        {
            //if (_authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, uiPageTypeModel, new[] { Operations.Create }).Result.Succeeded)
            if (_authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, uiPageTypeModel, PolicyTypes.UIPageType.Add).Result.Succeeded)
            {
                _uiPageTypeRepository.Insert(uiPageTypeModel);
                return new RequestResult<int>(1);
            }
            return new RequestResult<int>(0);
        }
        /// <summary>
        /// Delete Record From Ui Page Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }
        /// <summary>
        /// Edit Record For Ui Page Type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uiPageTypeModel"></param>
        /// <returns></returns>
        public RequestResult<int> Update( UiPageTypeModel uiPageTypeModel)
        {
            _uiPageTypeRepository.Update(uiPageTypeModel);
            return new RequestResult<int>(1);
        }
       public List<UiPageTypeModel> Get()
        {return  _uiPageTypeRepository.Get();;
        }
       
        /// <summary>
        /// Get Record By Id From Ui Page Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiPageTypeModel GetById(int id)
        {
            return _uiPageTypeRepository.GetById(id);
        }
    }
}
