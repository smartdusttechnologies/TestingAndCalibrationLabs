using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using System.Linq;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.common;
using TestingAndCalibrationLabs.Business.Core.Model.Common;

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
        private readonly IGenericRepository<UiPageValidationTypes> _uiPageValidationTypesGenericRepository;

        public SampleService(ICommonCrudRepository genericCrudRepository,
            IGenericRepository<RecordModel> recordGenericRepository,
            IGenericRepository<UiPageTypeModel> uiPageTypeGenericRepository,
            IGenericRepository<UiPageDataModel> uiPageDataGenericRepository,
            IGenericRepository<UiPageValidationTypes> uiPageValidationTypesGenericRepository)
        {
            _genericCrudRepository = genericCrudRepository;
            _recordGenericRepository = recordGenericRepository;
            _uiPageTypeGenericRepository = uiPageTypeGenericRepository;
            _uiPageDataGenericRepository = uiPageDataGenericRepository;
            _uiPageValidationTypesGenericRepository = uiPageValidationTypesGenericRepository;
        }

        #region public methods

        public RequestResult<bool> Add(RecordModel record)
        {
            RequestResult<bool> requestResult = Validate(record);
            if (requestResult.IsSuccessful)
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
            var uiMetadata = _genericCrudRepository.GetUiPageMetadata(uiPageId);
            return uiMetadata;
        }

        public RecordsModel GetRecords()
        {
            var uiPage = _uiPageTypeGenericRepository.Get(SAMPLE_UI_PAGE_NAME);
            var uiMetadata = _genericCrudRepository.GetUiPageMetadata(uiPage.Id);
            var uiPageData = _genericCrudRepository.GetUiPageDataByUiPageId(uiPage.Id);
            // var validationtypes = _uiPageValidationTypesGenericRepository.Get();
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
        public UiPageValidationTypes GetValidationTypeById(int validationtypeId)
        {
            var validationtypes = _uiPageValidationTypesGenericRepository.Get(validationtypeId);
            return new UiPageValidationTypes { Id = validationtypeId, Value = validationtypes.Value, Name = validationtypes.Name };
        }
        #endregion


        private RequestResult<bool> Validate(RecordModel record)
        {
            List<UiPageValidation> validations = _genericCrudRepository.GetUiPageValidations(record.UiPageId);
            List<UiPageValidationTypes> validationtypes = _uiPageValidationTypesGenericRepository.Get();
            List<ValidationMessage> validationMessages = new List<ValidationMessage>();

            foreach (var field in record.FieldValues)
            {
                foreach (var item in validations)
                {
                    var validationlist = validationtypes.Where(x => x.Id == item.UiPageValidationTypeId).SingleOrDefault();
                    if (item.UiPageMetadataId == field.UiControlId)
                    {
                        
                       // var validationlistList = validationtypes.Where(x => x.Id ==item.UiPageValidationTypeId).ToList();
                           
                               if (item.UiPageValidationTypeId == validationlist.Id)
                               {
                                  if (field.Value.Length < int.Parse(validationlist.Value))
                                     {
                                        validationMessages.Add(new ValidationMessage { Reason = " " + validationlist.Message + " ", Fid=item.UiPageMetadataId, Severity = ValidationSeverity.Error });
                                      }
                            
                        }
                    }
                }
            }
            return new RequestResult<bool>(validationMessages);
        }
    }
}
