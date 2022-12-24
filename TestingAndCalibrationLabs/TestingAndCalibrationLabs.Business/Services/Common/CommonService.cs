using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        private readonly IWorkflowStageService _workflowStageService;

        public CommonService(ICommonRepository commonRepository,
            IGenericRepository<RecordModel> recordGenericRepository,
            IGenericRepository<UiPageTypeModel> uiPageTypeGenericRepository,
            IGenericRepository<UiPageDataModel> uiPageDataGenericRepository,
            IGenericRepository<UiPageMetadataModel> uiPageMetaDataGenericRepository,
            IGenericRepository<UiPageValidationTypeModel> uiPageValidationTypesGenericRepository,
            IUiPageMetadataCharacteristicsRepository uiPageMetadataCharacteristicsRepository,
            IUiPageMetadataRepository uiPageMetadataRepository,
            IWorkflowStageService workflowStageService)
        {
            _commonRepository = commonRepository;
            _recordGenericRepository = recordGenericRepository;
            _uiPageTypeGenericRepository = uiPageTypeGenericRepository;
            _uiPageDataGenericRepository = uiPageDataGenericRepository;
            _uiPageMetaDataGenericRepository = uiPageMetaDataGenericRepository;
            _uiPageValidationTypesGenericRepository = uiPageValidationTypesGenericRepository;
            _uiPageMetadataCharacteristicsRepository = uiPageMetadataCharacteristicsRepository;
            _uiPageMetadataRepository = uiPageMetadataRepository;
            _workflowStageService = workflowStageService;
        }
        #region public methods
        public RequestResult<bool> Add(RecordModel record)
        {
            RequestResult<bool> requestResult = Validate(record);
            if (requestResult.IsSuccessful)
            {
                _commonRepository.Insert(record);
                return new RequestResult<bool>(true);
            }
            return requestResult;
        }
        public bool Delete(int id)
        {
            _recordGenericRepository.Delete(id);
            return true;
        }
        public RequestResult<bool> Update(RecordModel record)
        {
            RequestResult<bool> requestResult = Validate(record);
            if (requestResult.IsSuccessful)
            {
                var uiPageData = _uiPageDataGenericRepository.Get("RecordId", record.Id);
                foreach (var item in record.FieldValues)
                {
                    var data = uiPageData.Where(i => i.UiPageMetadataId == item.UiPageMetadataId).FirstOrDefault();
                    if (data != null)
                    {
                        data.Value = item.Value;
                        _uiPageDataGenericRepository.Update(data);
                    }
                    else
                    {
                        _uiPageDataGenericRepository.Insert(new UiPageDataModel { RecordId = record.Id, UiPageMetadataId = item.UiPageMetadataId, Value = item.Value });
                    }
                };
                return new RequestResult<bool>(true);
            }
            return requestResult;
        }
        public RecordModel GetUiPageMetadataCreate(int moduleId)
        {
            int uiPageTypeId;
            var uiMetadata = GetMetadata((int)UiControlType.workflowStage, moduleId, 0,out uiPageTypeId);
            List<LayoutModel> hirericheys = new List<LayoutModel>();
            uiMetadata.ForEach(x=> hirericheys.Add(new LayoutModel {  UiPageMetadata = x }));
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
                Fields = uiMetadata,
                Layout = hierarchy
            };
            return record;
        }
        public RecordsModel GetRecords(int moduleId)
        {
            var uiMetadata = _commonRepository.GetUiPageMetadataByModuleId(moduleId);
            uiMetadata = uiMetadata.GroupBy(x => x.Id).Select(y => y.First()).OrderBy(x=>x.Id).ToList();
            var uiPageData = _commonRepository.GetUiPageDataByModuleId(moduleId);
            var meta =  uiMetadata.GroupBy(x => x.Id).Select(y => y.First()) ;
            Dictionary<int, List<UiPageDataModel>> uiPageDataModels = new Dictionary<int, List<UiPageDataModel>>();
            uiPageData.GroupBy(x => x.RecordId).ToList()
                .ForEach(t => uiPageDataModels.Add(t.Key, t.OrderBy(o => o.UiPageMetadataId).ToList()));
            Dictionary<int, List<UiPageMetadataCharacteristicsModel>> metadataContent = new Dictionary<int, List<UiPageMetadataCharacteristicsModel>>();
            return new RecordsModel { ModuleId = moduleId, Fields = meta, FieldValues = uiPageDataModels };
        }
        public RecordModel GetRecordById(int recordId)
        {
            int uiPageTypeId;
            var recordMdel = _recordGenericRepository.Get(recordId);
            var uiMetadata = GetMetadata((int)UiControlType.workflowStage,recordMdel.ModuleId,recordId,out uiPageTypeId);
            var uiPageData = _uiPageDataGenericRepository.Get<int>("RecordId", recordId);
            List<LayoutModel> hirericheys = new List<LayoutModel>();
            uiMetadata.ForEach(x => hirericheys.Add(new LayoutModel {
                UiPageMetadata = x ,
                 UiPageData = uiPageData.SingleOrDefault(y=> y.UiPageMetadataId== x.Id)            
            }));
            var hierarchy = hirericheys.Hierarchize(
                 0, // The "root level" key. We're using -1 to indicate root level.
                 f => f.UiPageMetadata.Id, // The ID property on your object
                 f => f.UiPageMetadata.ParentId,// The property on your object that points to its parent
                f => f.UiPageMetadata.Orders // The property on your object that specifies the order within its parent
                 );
                return new RecordModel { Id = recordId,UiPageTypeId = uiPageTypeId, ModuleId = recordMdel.ModuleId, Layout = hierarchy,Fields = uiMetadata };
            }
            #endregion

            #region Private Methods
        private List<UiPageMetadataModel>GetMetadata(int uiControlTypeId,int moduleId, int recordId,out int uiPageId)
        {
            
            if(recordId == 0) {
                uiPageId = _commonRepository.GetPageIdBasedOnOrder(moduleId);
            }
            else
            {
                uiPageId = _commonRepository.GetPageIdBasedOnCurrentWorkflowStage(uiControlTypeId, moduleId,recordId);
            }
            var metadata = _commonRepository.GetUiPageMetadata(uiPageId);
            return metadata;
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
