using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using SelectPdf;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    public class CommonService : ICommonService
    {
        internal string UI_PAGE_NAME = string.Empty;
        private readonly ICommonRepository _commonRepository;
        private readonly IGenericRepository<RecordModel> _recordGenericRepository;
        private readonly IGenericRepository<UiPageTypeModel> _uiPageTypeGenericRepository;
        private readonly IGenericRepository<UiPageDataModel> _uiPageDataGenericRepository;
        private readonly IGenericRepository<UiPageMetadataModel> _uiPageMetaDataGenericRepository;
        private readonly IGenericRepository<UiPageValidationTypeModel> _uiPageValidationTypesGenericRepository;
        private readonly IUiPageMetadataCharacteristicsRepository _uiPageMetadataCharacteristicsRepository;
        private readonly IUiPageMetadataRepository _uiPageMetadataRepository;
        private readonly IWorkflowActivityService _workflowActivityService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUiPageMetadataCharacteristicsService _uiPageMetadataCharacteristicsService;

        public CommonService(ICommonRepository commonRepository,
            IGenericRepository<RecordModel> recordGenericRepository,
            IGenericRepository<UiPageTypeModel> uiPageTypeGenericRepository,
            IGenericRepository<UiPageDataModel> uiPageDataGenericRepository,
            IGenericRepository<UiPageMetadataModel> uiPageMetaDataGenericRepository,
            IGenericRepository<UiPageValidationTypeModel> uiPageValidationTypesGenericRepository,
            IUiPageMetadataCharacteristicsRepository uiPageMetadataCharacteristicsRepository,
            IUiPageMetadataRepository uiPageMetadataRepository,
            IWorkflowActivityService workflowActivityService,
            IWebHostEnvironment webHostEnvironment,
            IUiPageMetadataCharacteristicsService uiPageMetadataCharacteristicsService)

        {
            _commonRepository = commonRepository;
            _recordGenericRepository = recordGenericRepository;
            _uiPageTypeGenericRepository = uiPageTypeGenericRepository;
            _uiPageDataGenericRepository = uiPageDataGenericRepository;
            _uiPageMetaDataGenericRepository = uiPageMetaDataGenericRepository;
            _uiPageValidationTypesGenericRepository = uiPageValidationTypesGenericRepository;
            _uiPageMetadataCharacteristicsRepository = uiPageMetadataCharacteristicsRepository;
            _uiPageMetadataRepository = uiPageMetadataRepository;
            _workflowActivityService = workflowActivityService;
            _webHostEnvironment = webHostEnvironment;
            _uiPageMetadataCharacteristicsService = uiPageMetadataCharacteristicsService;
        }
        #region public methods
        /// <summary>
        /// To Insert Record
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public RequestResult<bool> Add(RecordModel record)
        {
            RequestResult<bool> requestResult = Validate(record);
            if (requestResult.IsSuccessful)
            {
                //record.WorkflowStageId = GetWorkflowStageId(record.ModuleId);
               record.Id =  _commonRepository.Insert(record);
               // record.WorkflowStageId = workflowStageId;
                //_workflowActivityService.WorkflowActivity(record);
                return new RequestResult<bool>(true);
            }
            return requestResult;
        }
        public string TemplateGenerate(int recordId,int metadataId )
        {
            var lookupM = _uiPageMetadataCharacteristicsService.Get(metadataId);
            int uiPageId;
            var recordMdel = _recordGenericRepository.Get(recordId);
            var path = Path.Combine(_webHostEnvironment.WebRootPath, lookupM.LookupName);
            var template = File.ReadAllText(path);
            var pageMetadata = GetMetadata(recordMdel.ModuleId, recordMdel.WorkflowStageId,out uiPageId);
            var uiPageData = _uiPageDataGenericRepository.Get<int>("RecordId", recordId);
            List<LayoutModel> hirericheys = new List<LayoutModel>();
            pageMetadata.ForEach(x => hirericheys.Add(new LayoutModel
            {
                UiPageMetadata = x,
                UiPageData = uiPageData.SingleOrDefault(y => y.UiPageMetadataId == x.Id)
            }));
            foreach (var item in hirericheys)
            {
                if (item.UiPageMetadata.ControlCategoryName == "DataControl")
                {
                    if (item.UiPageMetadata.MetadataModuleBridgeUiControlDisplayName != null)
                    {
                        item.UiPageMetadata.UiControlDisplayName = item.UiPageMetadata.MetadataModuleBridgeUiControlDisplayName;
                    }
                    string fieldName = string.Format("**field{0}**",item.UiPageMetadata.Orders);
                    var fieldValues = string.Format("**fieldvalue{0}**", item.UiPageMetadata.Orders);
                    template = template.Replace(fieldName, item.UiPageMetadata.UiControlDisplayName).Replace(fieldValues,item.UiPageData.Value);
                }
            }
            HtmlToPdf converter = new HtmlToPdf();
            PdfDocument doc = converter.ConvertHtmlString(template);
            //var sdf = doc.Save();
            var pdfPath = Path.Combine(_webHostEnvironment.WebRootPath, "reportTemplate.pdf");
            var fileName = "reportTemplate.pdf";
            doc.Save(pdfPath);
            doc.Close();

            return pdfPath;
        }
        /// <summary>
        /// to Delete Record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            _recordGenericRepository.Delete(id);
            return true;
        }
        /// <summary>
        /// to save the record 
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public RequestResult<bool> Save(RecordModel record)
        {
            RequestResult<bool> requestResult = Validate(record);
            if (requestResult.IsSuccessful)
            {
                var oldRecord = _recordGenericRepository.Get(record.Id);
                if (oldRecord.UpdatedDate == record.UpdatedDate)
                {
                    record.UpdatedDate = DateTime.Now;
                    _commonRepository.Save(record);
                    //record.WorkflowStageId = oldRecord.WorkflowStageId;
                    //_workflowActivityService.WorkflowActivity(record);
                    return new RequestResult<bool>(true);
                }
                return new RequestResult<bool>(false);
            }
            return requestResult;
        }
        public RecordModel GetUiPageMetadataCreate(int moduleId)
        {
            int uiPageTypeId;
            var uiMetadata = GetMetadata(moduleId, 0, out uiPageTypeId);
            foreach (var item in uiMetadata)
            { if (item.MetadataModuleBridgeUiControlDisplayName != null) { item.UiControlDisplayName = item.MetadataModuleBridgeUiControlDisplayName; } }
            List<LayoutModel> hirericheys = new List<LayoutModel>();
            uiMetadata.ForEach(x => hirericheys.Add(new LayoutModel { UiPageMetadata = x }));
            var hierarchy = hirericheys.Hierarchize(
             0, // The "root level" key. We're using -1 to indicate root level.
             f => f.UiPageMetadata.Id, // The ID property on your object
             f => f.UiPageMetadata.ParentId,// The property on your object that points to its parent
            f => f.UiPageMetadata.Orders // The property on your object that specifies the order within its parent
             );
            var record = new RecordModel
            {
                ModuleId = moduleId,
                UiPageTypeId = uiPageTypeId,
                Layout = hierarchy
            };
            return record;
        }
        /// <summary>
        /// This Method Return Data For Grid
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public RecordsModel GetRecords(int moduleId)
        {
            var uiMetadata = _commonRepository.GetUiPageMetadataByModuleId(moduleId);
            uiMetadata = uiMetadata.GroupBy(x => x.Id).Select(y => y.First()).OrderBy(x => x.Id).ToList();
            var uiPageData = _commonRepository.GetUiPageDataByModuleId(moduleId);
            var meta = uiMetadata.GroupBy(x => x.Id).Select(y => y.First());
            Dictionary<int, List<UiPageDataModel>> uiPageDataModels = new Dictionary<int, List<UiPageDataModel>>();
            uiPageData.GroupBy(x => x.RecordId).ToList()
                .ForEach(t => uiPageDataModels.Add(t.Key, t.OrderBy(o => o.UiPageMetadataId).ToList()));
            Dictionary<int, List<UiPageMetadataCharacteristicsModel>> metadataContent = new Dictionary<int, List<UiPageMetadataCharacteristicsModel>>();
            return new RecordsModel { ModuleId = moduleId, Fields = meta, FieldValues = uiPageDataModels };
        }
        /// <summary>
        /// Get Record By Record Id
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public RecordModel GetRecordById(int recordId)
        {
            int uiPageTypeId;
            var recordMdel = _recordGenericRepository.Get(recordId);
            var uiMetadata = GetMetadata(recordMdel.ModuleId, recordMdel.WorkflowStageId, out uiPageTypeId);
            foreach (var item in uiMetadata)
            { if (item.MetadataModuleBridgeUiControlDisplayName != null) { item.UiControlDisplayName = item.MetadataModuleBridgeUiControlDisplayName; } }
            var uiPageData = _uiPageDataGenericRepository.Get<int>("RecordId", recordId);
            List<LayoutModel> hirericheys = new List<LayoutModel>();
            uiMetadata.ForEach(x => hirericheys.Add(new LayoutModel
            {
                UiPageMetadata = x,
                UiPageData = uiPageData.SingleOrDefault(y => y.UiPageMetadataId == x.Id)
            }));
            var hierarchy = hirericheys.Hierarchize(
                 0, // The "root level" key. We're using -1 to indicate root level.
                 f => f.UiPageMetadata.Id, // The ID property on your object
                 f => f.UiPageMetadata.ParentId,// The property on your object that points to its parent
                f => f.UiPageMetadata.Orders // The property on your object that specifies the order within its parent
                 );
            return new RecordModel { Id = recordId, UiPageTypeId = uiPageTypeId, UpdatedDate = recordMdel.UpdatedDate, ModuleId = recordMdel.ModuleId, Layout = hierarchy };
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// To Get Metadata Based On Module Id And stageId
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="stageId"></param>
        /// <param name="uiPageId"></param>
        /// <returns></returns>
        private List<UiPageMetadataModel> GetMetadata(int moduleId, int stageId, out int uiPageId)
        {
            //TODO: All this can be done in one call inside GetUiMetadata , one call to database
            if (stageId == 0)
            {
                uiPageId = _commonRepository.GetPageIdBasedOnOrder(moduleId);
            }
            else
            {
                uiPageId = _commonRepository.GetPageIdBasedOnCurrentWorkflowStage(stageId);

            }
            var metadata = _commonRepository.GetUiPageMetadata(uiPageId);
            return metadata;
        }
        private int GetWorkflowStageId(int moduleId)
        {
            return _commonRepository.GetWorkflowStageBasedOnOrder(moduleId);
        }

        private RequestResult<bool> Validate(RecordModel record)
        {
            List<UiPageValidationModel> validations = _commonRepository.GetUiPageValidations(record.UiPageTypeId);
            List<UiPageValidationTypeModel> validationtypes = _uiPageValidationTypesGenericRepository.Get();
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();
            foreach (var field in record.FieldValues)
            {
                foreach (var item in validations)
                {
                    if (item.UiPageMetadataId == field.UiPageMetadataId)
                    {
                        var validationlist = _uiPageValidationTypesGenericRepository.Get(item.UiPageValidationTypeId);
                        var uipagedata = _uiPageMetadataRepository.GetById(item.UiPageMetadataId);
                        string metadataId = Helpers.GenerateUiControlId(uipagedata.UiControlTypeName, item.UiPageMetadataId);
                        switch ((ValidationType)item.UiPageValidationTypeId)
                        {
                            case ValidationType.IsRequired:
                                if (string.IsNullOrEmpty(field.Value))
                                {
                                    string errorMessage = string.Format(validationlist.Message, uipagedata.UiControlDisplayName);
                                    validationMessages.Add(new ValidationMessage { Reason = errorMessage, SourceId = metadataId, Severity = ValidationSeverity.Error });
                                }
                                break;
                            case ValidationType.MinPasswordLength:
                                int minLength = int.Parse(item.Value);
                                if (field.Value.Length < minLength)
                                    validationMessages.Add(new ValidationMessage { Reason = validationlist.Message, SourceId = metadataId, Severity = ValidationSeverity.Error });
                                break;
                            case ValidationType.Email:
                                int minLengthEmail = int.Parse(item.Value);
                                if (field.Value.Length < minLengthEmail)
                                    validationMessages.Add(new ValidationMessage { Reason = validationlist.Message, SourceId = metadataId, Severity = ValidationSeverity.Error });
                                break;
                            case ValidationType.AdharLength:
                                int minLengthAdhar = int.Parse(item.Value);
                                if (field.Value.Length != minLengthAdhar)
                                    validationMessages.Add(new ValidationMessage { Reason = validationlist.Message, SourceId = metadataId, Severity = ValidationSeverity.Error });
                                break;
                            case ValidationType.MobileNumberLength:
                                int minLengtMobileNumberLength = int.Parse(item.Value);
                                if (field.Value.Length != minLengtMobileNumberLength)
                                    validationMessages.Add(new ValidationMessage { Reason = validationlist.Message, SourceId = metadataId, Severity = ValidationSeverity.Error });
                                break;
                            case ValidationType.Name:
                                int minLengtName = int.Parse(item.Value);
                                if (field.Value.Length < minLengtName)
                                    validationMessages.Add(new ValidationMessage { Reason = validationlist.Message, SourceId = metadataId, Severity = ValidationSeverity.Error });
                                break;
                            case ValidationType.Year:
                                int minLengtYear = int.Parse(item.Value);
                                if (field.Value.Length != minLengtYear)
                                    validationMessages.Add(new ValidationMessage { Reason = validationlist.Message, SourceId = metadataId, Severity = ValidationSeverity.Error });
                                break;
                        }
                    }
                }
            }
            return new RequestResult<bool>(validationMessages);
        }

       
        #endregion
    }
}
