using System.Collections.Generic;
using System.Linq;
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


        public CommonService(ICommonRepository commonRepository,
            IGenericRepository<RecordModel> recordGenericRepository,
            IGenericRepository<UiPageTypeModel> uiPageTypeGenericRepository,
            IGenericRepository<UiPageDataModel> uiPageDataGenericRepository,
            IGenericRepository<UiPageMetadataModel> uiPageMetaDataGenericRepository,
            IGenericRepository<UiPageValidationTypeModel> uiPageValidationTypesGenericRepository)
        {
            _commonRepository = commonRepository;
            _recordGenericRepository = recordGenericRepository;
            _uiPageTypeGenericRepository = uiPageTypeGenericRepository;
            _uiPageDataGenericRepository = uiPageDataGenericRepository;
            _uiPageMetaDataGenericRepository = uiPageMetaDataGenericRepository;
            _uiPageValidationTypesGenericRepository = uiPageValidationTypesGenericRepository;
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
                    var data = uiPageData.Where(i => i.UiControlId == item.UiControlId).FirstOrDefault();
                    if (data != null)
                    {
                        data.Value = item.Value;
                        _uiPageDataGenericRepository.Update(data);
                    }
                    else
                    {
                        _uiPageDataGenericRepository.Insert(new UiPageDataModel { RecordId = record.Id, UiControlId = item.UiControlId, UiPageId = record.UiPageId, Value = item.Value });
                    }
                };
                return new RequestResult<bool>(true);
            }
            return requestResult;
        }

        public RecordModel GetUiPageMetadata(int uiPageId)
        {
            var uiMetadata = _commonRepository.GetUiPageMetadata(uiPageId);
            return uiMetadata;
        }

        public RecordsModel GetRecords(int uiPageId)
        {
            //var uiPage = _uiPageTypeGenericRepository.Get(UI_PAGE_NAME);
            var uiMetadata = _commonRepository.GetUiPageMetadata(uiPageId);
            var uiPageData = _commonRepository.GetUiPageDataByUiPageId(uiPageId);
            // var validationtypes = _uiPageValidationTypesGenericRepository.Get();
            Dictionary<int, List<UiPageDataModel>> uiPageDataModels = new Dictionary<int, List<UiPageDataModel>>();

            uiPageData.GroupBy(x => x.RecordId).ToList()
                .ForEach(t => uiPageDataModels.Add(t.Key, t.OrderBy(o => o.UiControlId).ToList()));


            return new RecordsModel { UiPageId = uiPageId, Fields = uiMetadata.Fields, FieldValues = uiPageDataModels };
        }

        public RecordModel GetRecordById(int recordId)
        {

            //   var uiPage = _uiPageTypeGenericRepository.Get(UI_PAGE_NAME);
            var recordMdel = _recordGenericRepository.Get(recordId);
            var uiMetadata = _commonRepository.GetUiPageMetadata(recordMdel.UiPageId);
            var uiPageData = _uiPageDataGenericRepository.Get<int>("RecordId", recordId);

            return new RecordModel { Id = recordId, UiPageId = recordMdel.UiPageId, Fields = uiMetadata.Fields, FieldValues = uiPageData };
        }


        #endregion

        #region Private Methods

        private RequestResult<bool> Validate(RecordModel record)
        {
            List<UiPageValidationModel> validations = _commonRepository.GetUiPageValidations(record.UiPageId);
            List<UiPageValidationTypeModel> validationtypes = _uiPageValidationTypesGenericRepository.Get();
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();


            foreach (var field in record.FieldValues)
            {
                foreach (var item in validations)
                {
                    if (item.UiPageMetadataId == field.UiControlId)
                    {
                        var validationlist = _uiPageValidationTypesGenericRepository.Get(item.UiPageValidationTypeId);
                        var uipagedata = _uiPageMetaDataGenericRepository.Get(item.UiPageMetadataId);

                        switch ((ValidationType)item.UiPageValidationTypeId)
                        {
                            case ValidationType.IsRequired:
                                if (string.IsNullOrEmpty(field.Value))
                                {
                                    string errorMessage = string.Format(validationlist.Message, uipagedata.UiControlDisplayName);
                                    validationMessages.Add(new ValidationMessage { Reason = errorMessage, SourceId = item.UiPageMetadataId, Severity = ValidationSeverity.Error });
                                }
                                break;
                            case ValidationType.MinPasswordLength:
                                int minLength = int.Parse(item.Value);
                                if (field.Value.Length < minLength)
                                    validationMessages.Add(new ValidationMessage { Reason = validationlist.Message, SourceId = item.UiPageMetadataId, Severity = ValidationSeverity.Error });
                                break;
                            case ValidationType.Email:
                                int minLengthEmail = int.Parse(item.Value);
                                if (field.Value.Length < minLengthEmail)
                                    validationMessages.Add(new ValidationMessage { Reason = validationlist.Message, SourceId = item.UiPageMetadataId, Severity = ValidationSeverity.Error });
                                break;
                            case ValidationType.AdharLength:
                                int minLengthAdhar = int.Parse(item.Value);
                                if (field.Value.Length != minLengthAdhar)
                                    validationMessages.Add(new ValidationMessage { Reason = validationlist.Message, SourceId = item.UiPageMetadataId, Severity = ValidationSeverity.Error });
                                break;
                            case ValidationType.MobileNumberLength:
                                int minLengtMobileNumberLength = int.Parse(item.Value);
                                if (field.Value.Length != minLengtMobileNumberLength)
                                    validationMessages.Add(new ValidationMessage { Reason = validationlist.Message, SourceId = item.UiPageMetadataId, Severity = ValidationSeverity.Error });
                                break;
                            case ValidationType.Name:
                                int minLengtName = int.Parse(item.Value);
                                if (field.Value.Length < minLengtName)
                                    validationMessages.Add(new ValidationMessage { Reason = validationlist.Message, SourceId = item.UiPageMetadataId, Severity = ValidationSeverity.Error });
                                break;
                            case ValidationType.Year:
                                int minLengtYear = int.Parse(item.Value);
                                if (field.Value.Length != minLengtYear)
                                    validationMessages.Add(new ValidationMessage { Reason = validationlist.Message, SourceId = item.UiPageMetadataId, Severity = ValidationSeverity.Error });
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
