using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using System.Linq;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// sampleService is implimenting the services from ISampleService
    /// </summary>
    public class SampleService : ISampleService
    {
        private const string SAMPLE_UI_PAGE_NAME = "SamplePage";

        private readonly ISampleRepository _sampleRepository;
        private readonly IGenericRepository<RecordModel> _recordGenericRepository;
        private readonly IGenericRepository<UiPageTypeModel> _uiPageTypeGenericRepository;
        private readonly IGenericRepository<UiPageDataModel> _uiPageDataGenericRepository;

        public SampleService(ISampleRepository sampleRepository,
            IGenericRepository<RecordModel> recordGenericRepository,
            IGenericRepository<UiPageTypeModel> uiPageTypeGenericRepository,
            IGenericRepository<UiPageDataModel> uiPageDataGenericRepository)
        {
            _sampleRepository = sampleRepository;
            _recordGenericRepository = recordGenericRepository;
            _uiPageTypeGenericRepository = uiPageTypeGenericRepository;
            _uiPageDataGenericRepository = uiPageDataGenericRepository;
        }

        #region public methods

        public RequestResult<int> Add(RecordModel record)
        {
            RequestResult<bool> requestResult = Validate(record);
            _sampleRepository.Insert(record);
            return new RequestResult<int>(1);
        }

        public bool Delete(int id)
        {
            _recordGenericRepository.Delete(id);
            return true;
        }

        public RequestResult<int> Update(RecordModel record)
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
            return new RequestResult<int>(1);
        }

        public RecordModel GetUiPageMetadata(int uiPageId)
        {
            var uiMetadata = _sampleRepository.GetUiPageMetadata(uiPageId);
            return uiMetadata;
        }

        public RecordsModel GetRecords()
        {
            var uiPage = _uiPageTypeGenericRepository.Get(SAMPLE_UI_PAGE_NAME);
            var uiMetadata = _sampleRepository.GetUiPageMetadata(uiPage.Id);
            var uiPageData = _sampleRepository.GetUiPageDataByUiPageId(uiPage.Id);

            Dictionary<int, List<UiPageDataModel>> uiPageDataModels = new Dictionary<int, List<UiPageDataModel>>();

            uiPageData.GroupBy(x => x.RecordId).ToList()
                .ForEach(t => uiPageDataModels.Add(t.Key, t.OrderBy(o => o.UiControlId).ToList()));


            return new RecordsModel { UiPageId = uiPage.Id, Fields = uiMetadata.Fields, FieldValues = uiPageDataModels };
        }

        public RecordModel GetRecordById(int recordId)
        {
            var uiPage = _uiPageTypeGenericRepository.Get(SAMPLE_UI_PAGE_NAME);
            var uiMetadata = _sampleRepository.GetUiPageMetadata(uiPage.Id);
            var uiPageData = _uiPageDataGenericRepository.Get<int>("RecordId", recordId);

            return new RecordModel { Id = recordId, UiPageId = uiPage.Id, Fields = uiMetadata.Fields, FieldValues = uiPageData };
        }

        #endregion


        private RequestResult<bool> Validate(RecordModel record)
        {
            List<UiPageValidation> validations = _sampleRepository.GetUiPageValidations(record.UiPageId);
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
                        }
                    }
                }
            }
            return new RequestResult<bool>(validationMessages);
        }

    }
}
