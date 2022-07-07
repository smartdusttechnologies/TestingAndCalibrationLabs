using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using System.Linq;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.common;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// sampleService is implimenting the services from ISampleService
    /// </summary>
    public class SampleService : ISampleService
    {
        private const string SAMPLE_UI_PAGE_NAME = "SamplePage";

        private readonly ICommonCrudRepository _genericCrudRepository;
        private readonly IGenericRepository<RecordModel> _recordGenericRepository;
        private readonly IGenericRepository<UiPageTypeModel> _uiPageTypeGenericRepository;
        private readonly IGenericRepository<UiPageDataModel> _uiPageDataGenericRepository;

        public SampleService(ICommonCrudRepository genericCrudRepository,
            IGenericRepository<RecordModel> recordGenericRepository,
            IGenericRepository<UiPageTypeModel> uiPageTypeGenericRepository,
            IGenericRepository<UiPageDataModel> uiPageDataGenericRepository)
        {
            _genericCrudRepository = genericCrudRepository;
            _recordGenericRepository = recordGenericRepository;
            _uiPageTypeGenericRepository = uiPageTypeGenericRepository;
            _uiPageDataGenericRepository = uiPageDataGenericRepository;
        }

        #region public methods

        public RequestResult<bool> Add(RecordModel record)
        {
           RequestResult<bool> requestResult = Validate(record);
           if(requestResult.IsSuccessful)
            {
                _genericCrudRepository.Insert(record);
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
            var uiPageData = _uiPageDataGenericRepository.Get("RecordId", record.Id);
            foreach (var item in record.FieldValues)
            {
                var data = uiPageData.Where(i => i.UiControlId == item.UiControlId).FirstOrDefault();
                if (data != null)
                {
                    data.Value = item.Value;
                    RequestResult<bool> requestResult = Validate(record);
                    if (requestResult.IsSuccessful)
                    {
                        _uiPageDataGenericRepository.Update(data);
                    }
                       
                }
                else
                {
                    RequestResult<bool> requestResult = Validate(record);
                    if (requestResult.IsSuccessful)
                    {
                        _uiPageDataGenericRepository.Insert(new UiPageDataModel { RecordId = record.Id, UiControlId = item.UiControlId, UiPageId = record.UiPageId, Value = item.Value });
                    }
                    return requestResult;
                }
            };
            return new RequestResult<bool>(true);
        }

        public RecordModel GetUiPageMetadata(int uiPageId)
        {
            var uiMetadata = _genericCrudRepository.GetUiPageMetadata(uiPageId);
            return uiMetadata;
        }

        public RecordsModel GetRecords()
        {
            var uiPage = _uiPageTypeGenericRepository.Get(SAMPLE_UI_PAGE_NAME);
            var uiMetadata = _genericCrudRepository.GetUiPageMetadata(uiPage.Id);
            var uiPageData = _genericCrudRepository.GetUiPageDataByUiPageId(uiPage.Id);

            Dictionary<int, List<UiPageDataModel>> uiPageDataModels = new Dictionary<int, List<UiPageDataModel>>();

            uiPageData.GroupBy(x => x.RecordId).ToList()
                .ForEach(t => uiPageDataModels.Add(t.Key, t.OrderBy(o => o.UiControlId).ToList()));


            return new RecordsModel { UiPageId = uiPage.Id, Fields = uiMetadata.Fields, FieldValues = uiPageDataModels };
        }

        public RecordModel GetRecordById(int recordId)
        {
            var uiPage = _uiPageTypeGenericRepository.Get(SAMPLE_UI_PAGE_NAME);
            var uiMetadata = _genericCrudRepository.GetUiPageMetadata(uiPage.Id);
            var uiPageData = _uiPageDataGenericRepository.Get<int>("RecordId", recordId);

            return new RecordModel { Id = recordId, UiPageId = uiPage.Id, Fields = uiMetadata.Fields, FieldValues = uiPageData };
        }

        #endregion


        private RequestResult<bool> Validate(RecordModel record)
        {
            List<UiPageValidation> validations = _genericCrudRepository.GetUiPageValidations(record.UiPageId);
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();

            foreach (var field in record.FieldValues)
            {
                foreach (var item in validations)
                {
                    if (item.UiPageMetadataId == field.UiControlId)
                    {
                        switch ((ValidationType)item.UiPageValidationTypeId)
                        {
                            case ValidationType.MinPasswordLength:
                                int minLength = int.Parse(item.Value);
                                if (field.Value.Length < minLength)
                                    validationMessages.Add(new ValidationMessage { Reason = "Minimum length of the password should be " + minLength + "characters long", Severity = ValidationSeverity.Error });
                                break;
                            case ValidationType.MinAdharLength:
                                int minAdharLength = int.Parse(item.Value);
                                if(field.Value.Length != minAdharLength)
                                 validationMessages.Add(new ValidationMessage { Reason = "Length of the Aadhar should be equal to" + minAdharLength + "characters long", Severity = ValidationSeverity.Error });
                                break;
                            case ValidationType.MobileNumberLenth:
                                int minMobilelength = int.Parse(item.Value);
                                if (field.Value.Length != minMobilelength)
                                    validationMessages.Add(new ValidationMessage { Reason = "length of the Mobile Number  should be equal to " + minMobilelength + "characters long", Severity = ValidationSeverity.Error });
                                break;
                            case ValidationType.YearLenth:
                                int minyearlength = int.Parse(item.Value);
                                if (field.Value.Length != minyearlength)
                                    validationMessages.Add(new ValidationMessage { Reason = "length of the Mobile Number  should be equal to " + minyearlength + "characters long", Severity = ValidationSeverity.Error });
                                break;

                        }
                    }
                }
            }
            return new RequestResult<bool>(validationMessages);
        }

    }
}
