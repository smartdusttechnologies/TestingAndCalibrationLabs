using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SelectPdf;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using System.Text;
using System.Threading;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Net.Mail;

namespace TestingAndCalibrationLabs.Business.Services
{
    public class CommonService : ICommonService
    {
        internal string UI_PAGE_NAME = string.Empty;
        private readonly ICommonRepository _commonRepository;
        private readonly IGenericRepository<RecordModel> _recordGenericRepository;
        private readonly IGenericRepository<UiPageValidationTypeModel> _uiPageValidationTypesGenericRepository;
        private readonly IUiPageMetadataRepository _uiPageMetadataRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUiPageMetadataCharacteristicsService _uiPageMetadataCharacteristicsService;
        private readonly IAuthorizationService _authorizationService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWorkflowStageService _workflowStageService;
        private readonly IEmailService _emailService;
        public CommonService(ICommonRepository commonRepository,
            IGenericRepository<RecordModel> recordGenericRepository,
            IGenericRepository<UiPageValidationTypeModel> uiPageValidationTypesGenericRepository,
            IUiPageMetadataRepository uiPageMetadataRepository,
            IWebHostEnvironment webHostEnvironment,
            IUiPageMetadataCharacteristicsService uiPageMetadataCharacteristicsService,
            IAuthorizationService authorizationService, IHttpContextAccessor httpContextAccessor,
            IWorkflowStageService workflowStageService,
            IEmailService emailService)

        {
            _commonRepository = commonRepository;
            _recordGenericRepository = recordGenericRepository;
            _uiPageValidationTypesGenericRepository = uiPageValidationTypesGenericRepository;
            _uiPageMetadataRepository = uiPageMetadataRepository;
            _webHostEnvironment = webHostEnvironment;
            _uiPageMetadataCharacteristicsService = uiPageMetadataCharacteristicsService;
            _authorizationService = authorizationService;
            _httpContextAccessor = httpContextAccessor;
            _workflowStageService = workflowStageService;
            _emailService = emailService;
        }
        #region public methods
        /// <summary>
        /// To Insert Record
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public RequestResult<bool> Add(RecordModel record)
        {
            RequestResult<bool> requestResult = new RequestResult<bool>(false);
            if (_authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, record, Operations.Create).Result.Succeeded)
            {
                requestResult = Validate(record);
                if (requestResult.IsSuccessful)
                {
                    //record.WorkflowStageId = GetWorkflowStageId(record.ModuleId);
                    record.Id = _commonRepository.Insert(record);
                    // record.WorkflowStageId = workflowStageId;
                    //_workflowActivityService.WorkflowActivity(record);
                    return new RequestResult<bool>(true);
                }
                return requestResult;
            }
            throw new UnauthorizedAccessException("Your Unauthorized");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="recordId"></param>
        /// <param name="metadataId"></param>
        /// <returns></returns>
        public RequestResult<byte[]> TemplateGenerate(int recordId, int metadataId, string email, bool send)
        {
            var lookupM = _uiPageMetadataCharacteristicsService.Get(metadataId);
            var recordMdel = _recordGenericRepository.Get(recordId);
            var path = Path.Combine(_webHostEnvironment.WebRootPath, lookupM.LookupName);
            var template = File.ReadAllText(path);
            var workflowStage = _workflowStageService.GetStage(recordMdel.ModuleId, recordMdel.Id);
            var pageMetadata = _commonRepository.GetUiPageMetadata(workflowStage.UiPageTypeId);
            var uiPageData = _commonRepository.GetPageData(recordId);

            List<LayoutModel> hirericheys = new List<LayoutModel>();
            pageMetadata.ForEach(x => hirericheys.Add(new LayoutModel
            {
                UiPageMetadata = x,
                UiPageData = uiPageData.SingleOrDefault(y => y.UiPageMetadataId == x.Id)
            }));
            foreach (var item in hirericheys)
            {
                if (item.UiPageMetadata.ControlCategoryName == "DataControl" && item.UiPageMetadata.MultiValueControl != true)
                {
                    if (item.UiPageMetadata.MetadataModuleBridgeUiControlDisplayName != null)
                    {
                        item.UiPageMetadata.UiControlDisplayName = item.UiPageMetadata.MetadataModuleBridgeUiControlDisplayName;
                    }
                    string fieldName = string.Format("**field{0}**", item.UiPageMetadata.Orders);
                    var fieldValues = string.Format("**fieldvalue{0}**", item.UiPageMetadata.Orders);
                    template = template.Replace(fieldName, item.UiPageMetadata.UiControlDisplayName).Replace(fieldValues, item.UiPageData.Value);
                }
            }
            var multiVal = GetMultiControlValue(recordId);
            if (multiVal.Fields.Count() > 0)
            {
                var table = new StringBuilder("<table class='multiValueGrid'  cellspacing='0'> <tr>");
                foreach (var item in multiVal.Fields)
                {
                    table.Append($"<th>{item.UiControlDisplayName}</th>");
                }
                table.Append("</tr> ");
                foreach (var item in multiVal.FieldValues)
                {
                    table.Append("<tr>");
                    foreach (var node in item.Value)
                    {
                        table.Append($"<td> {node.Value}</td>");
                    }
                    table.Append("</tr>");
                }
                table.Append("</table>");
                template = template.Replace("**gridTableMulti**", table.ToString());
            }
            else
            {
                template = template.Replace("**gridTableMulti**","");
            }

            HtmlToPdf converter = new HtmlToPdf();
            PdfDocument doc = converter.ConvertHtmlString(template);
            var pdfPath = Path.Combine(_webHostEnvironment.WebRootPath, "reportTemplate.pdf");
            var pdfByte = doc.Save();
            doc.Close();
            if (send)
            {
                //string emailAd = new string(email);
                var htmlPath = Path.Combine(_webHostEnvironment.WebRootPath, "HtmlMsg.txt");
                var htmlWeb = File.ReadAllText(htmlPath);
                using Stream stream= new MemoryStream(pdfByte);
                Attachment attachment = new Attachment(stream, "report.pdf", "application/pdf");
                EmailModel emailModel = new EmailModel();
                var emailAd = new List<string>
                {
                    email
                };
                emailModel.Email = emailAd;
                
                emailModel.Subject = "Thanks For Visiting Testing And Calibration Labs";
                emailModel.HtmlMsg= htmlWeb;
                var atchmt = new List<Attachment>() { attachment };
                emailModel.Attachments = atchmt;
                var sendMail = _emailService.Sendemail(emailModel);
            }
            return new RequestResult<byte[]>(pdfByte);
        }
        /// <summary>
        /// to Delete Record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            var record = _recordGenericRepository.Get(id);
            if (_authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, record, Operations.Create).Result.Succeeded)
            {
                _recordGenericRepository.Delete(id);
                return true;
            }
            throw new UnauthorizedAccessException("Your Unauthorized");
        }
        /// <summary>
        /// to save the record 
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public RequestResult<bool> Save(RecordModel record)
        {
            RequestResult<bool> requestResult = new RequestResult<bool>();
            if (_authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, record, Operations.Update).Result.Succeeded)
            {
                requestResult = Validate(record);
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
            }
            throw new UnauthorizedAccessException("Your Unauthorized");
        }
        /// <summary>
        /// Get By Module Id For Create
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public RecordModel GetUiPageMetadataCreate(int moduleId)
        {
            RecordModel record = new RecordModel() { ModuleId = moduleId, Id = 0 };
            if (_authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, record, Operations.Read).Result.Succeeded)
            {
                var workflowStage = _workflowStageService.GetStage(moduleId, 0);
                var uiMetadata = _commonRepository.GetUiPageMetadata(workflowStage.UiPageTypeId);
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
                record = new RecordModel
                {
                    ModuleId = moduleId,
                    UiPageTypeId = workflowStage.UiPageTypeId,
                    Layout = hierarchy
                };
                return record;
            }
            throw new UnauthorizedAccessException("Your Unauthorized");
        }
        /// <summary>
        /// This Method Return Data For Grid
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public RecordsModel GetRecords(int moduleId)
        {
            var workflowStage = _workflowStageService.GetStage(moduleId, 0);
            var uiMetadata = _commonRepository.GetUiPageMetadataByModuleId(moduleId);
            var uiPageData = _commonRepository.GetUiPageDataByModuleId(moduleId);
            var metadata = uiMetadata.GroupBy(x => x.Id).Select(y => y.First());
            Dictionary<int, List<UiPageDataModel>> uiPageDataModels = new Dictionary<int, List<UiPageDataModel>>();
            uiPageData.GroupBy(x => x.RecordId).ToList()
                .ForEach(t => uiPageDataModels.Add(t.Key, t.OrderBy(o => o.UiPageMetadataId).ToList()));
            return new RecordsModel { ModuleId = moduleId, Fields = metadata, FieldValues = uiPageDataModels ,WorkflowStageName = workflowStage.Name};
        }

        /// <summary>
        /// Get Record By Record Id
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public RecordModel GetRecordById(int recordId)
        {
            var recordMdel = _recordGenericRepository.Get(recordId);
            if (_authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, recordMdel, Operations.Read).Result.Succeeded)
            {
                var workflowStage = _workflowStageService.GetStage(recordMdel.ModuleId, recordMdel.Id);
                var uiMetadata = _commonRepository.GetUiPageMetadata(workflowStage.UiPageTypeId);
                foreach (var item in uiMetadata)
                { if (item.MetadataModuleBridgeUiControlDisplayName != null) { item.UiControlDisplayName = item.MetadataModuleBridgeUiControlDisplayName; } }
                //var uiPageData = _uiPageDataGenericRepository.Get<int>("RecordId", recordId);
                var uiPageData = _commonRepository.GetPageData(recordId);
                List<LayoutModel> hirericheys = new List<LayoutModel>();
                uiMetadata.ForEach(x => hirericheys.Add(new LayoutModel
                {
                    UiPageMetadata = x,
                    UiPageData = uiPageData.Where(y => y.UiPageMetadataId == x.Id).FirstOrDefault()
                }));
                var hierarchy = hirericheys.Hierarchize(
                     0, // The "root level" key. We're using -1 to indicate root level.
                     f => f.UiPageMetadata.Id, // The ID property on your object
                     f => f.UiPageMetadata.ParentId,// The property on your object that points to its parent
                    f => f.UiPageMetadata.Orders // The property on your object that specifies the order within its parent
                     );
                return new RecordModel { Id = recordId, UiPageTypeId = workflowStage.UiPageTypeId, UpdatedDate = recordMdel.UpdatedDate, ModuleId = recordMdel.ModuleId, Layout = hierarchy };
            }
            throw new UnauthorizedAccessException("Your Unauthorized");
        }

        #region Multi Value Control
        /// <summary>
        /// This Method Returns Data For Multi Value Grid
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public RecordsModel GetMultiControlValue(int recordId)
        {
            var uiMetadata = _commonRepository.GetMultiControlMetadata(recordId);
            var uiPageData = _commonRepository.GetMultiPageData(recordId);
            var metadata = uiMetadata.GroupBy(x => x.Id).Select(y => y.First());

            Dictionary<int, List<UiPageDataModel>> uiPageDataModels = new Dictionary<int, List<UiPageDataModel>>();
            uiPageData.GroupBy(x => x.SubRecordId).ToList()
                .ForEach(t => uiPageDataModels.Add(t.Key, t.OrderBy(o => o.UiPageMetadataId).ToList()));

            return new RecordsModel { Id = recordId, Fields = metadata, FieldValues = uiPageDataModels };
        }
        /// <summary>
        /// Delete Multi Value Records
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public RequestResult<bool> DeleteMultiValue(RecordModel record)
        {
            var previousRecord = _recordGenericRepository.Get(record.Id);
            bool result;
            if (record.UpdatedDate == previousRecord.UpdatedDate)
            {
                result = _commonRepository.DeleteMultiValue(record);
            }
            else
            {
                result = false;
            }
            return new RequestResult<bool>(result);
        }
        #endregion
        #endregion

        #region Private Methods

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
                        string metadataId;
                        metadataId = Helpers.GenerateUiControlId(uipagedata.UiControlTypeName, item.UiPageMetadataId);
                        switch ((ValidationType)item.UiPageValidationTypeId)
                        {
                            case ValidationType.IsRequired:
                                if (string.IsNullOrEmpty(field.Value))
                                {
                                    string errorMessage = string.Format(validationlist.Message, uipagedata.UiControlDisplayName);
                                    validationMessages.Add(new ValidationMessage { MessageKey = field.MultiValueControl.ToString(), Reason = errorMessage, SourceId = metadataId, Severity = ValidationSeverity.Error });
                                }
                                break;
                            case ValidationType.MinPasswordLength:
                                int minLength = int.Parse(item.Value);
                                if (field.Value.Length < minLength)
                                    validationMessages.Add(new ValidationMessage { MessageKey = field.MultiValueControl.ToString(), Reason = validationlist.Message, SourceId = metadataId, Severity = ValidationSeverity.Error });
                                break;
                            case ValidationType.Email:
                                int minLengthEmail = int.Parse(item.Value);
                                if (field.Value.Length < minLengthEmail)
                                    validationMessages.Add(new ValidationMessage { MessageKey = field.MultiValueControl.ToString(), Reason = validationlist.Message, SourceId = metadataId, Severity = ValidationSeverity.Error });
                                break;
                            case ValidationType.AdharLength:
                                int minLengthAdhar = int.Parse(item.Value);
                                if (field.Value.Length != minLengthAdhar)
                                    validationMessages.Add(new ValidationMessage { MessageKey = field.MultiValueControl.ToString(), Reason = validationlist.Message, SourceId = metadataId, Severity = ValidationSeverity.Error });
                                break;
                            case ValidationType.MobileNumberLength:
                                int minLengtMobileNumberLength = int.Parse(item.Value);
                                if (field.Value.Length != minLengtMobileNumberLength)
                                    validationMessages.Add(new ValidationMessage { MessageKey = field.MultiValueControl.ToString(), Reason = validationlist.Message, SourceId = metadataId, Severity = ValidationSeverity.Error });
                                break;
                            case ValidationType.Name:
                                int minLengtName = int.Parse(item.Value);
                                if (field.Value.Length < minLengtName)
                                    validationMessages.Add(new ValidationMessage { MessageKey = field.MultiValueControl.ToString(), Reason = validationlist.Message, SourceId = metadataId, Severity = ValidationSeverity.Error });
                                break;
                            case ValidationType.Year:
                                int minLengtYear = int.Parse(item.Value);
                                if (field.Value.Length != minLengtYear)
                                    validationMessages.Add(new ValidationMessage { MessageKey = field.MultiValueControl.ToString(), Reason = validationlist.Message, SourceId = metadataId, Severity = ValidationSeverity.Error });
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
