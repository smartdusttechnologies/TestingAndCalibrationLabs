using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Services specific to sample feature will be written here.
    /// </summary>
    public class SampleService : CommonService, ISampleService
    {
        public SampleService(ICommonRepository commonRepository,
            IGenericRepository<RecordModel> recordGenericRepository,
            IGenericRepository<UiPageValidationTypeModel> uiPageValidationTypesGenericRepository,
            IUiPageMetadataRepository uiPageMetadataRepository,
            IWebHostEnvironment webHostEnvironment,
            IUiPageMetadataCharacteristicsService uiPageMetadataCharacteristicsService,IWorkflowStageService workflowStageService,
            IAuthorizationService authorizationService, IHttpContextAccessor httpContextAccessor)
            : base(commonRepository,
                  recordGenericRepository,
                  uiPageValidationTypesGenericRepository,
                  uiPageMetadataRepository,
                  webHostEnvironment,
                  uiPageMetadataCharacteristicsService,
                  authorizationService,httpContextAccessor,workflowStageService)
        {
            UI_PAGE_NAME = "SamplePage";
        }

        #region Public Methods

        #endregion
        #region Private Methods

        #endregion


    }
}