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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.Net.Mail;
using TestingAndCalibrationLabs.Business.Data.Repository;
using static TestingAndCalibrationLabs.Business.Core.Model.PolicyTypes;
using NPOI.POIFS.Properties;

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
        private readonly IModuleLayoutRepository _moduleLayoutRepository;
        public CommonService(ICommonRepository commonRepository,
            IGenericRepository<RecordModel> recordGenericRepository,
            IGenericRepository<UiPageValidationTypeModel> uiPageValidationTypesGenericRepository,
            IUiPageMetadataRepository uiPageMetadataRepository,
            IWebHostEnvironment webHostEnvironment,
            IUiPageMetadataCharacteristicsService uiPageMetadataCharacteristicsService,
            IAuthorizationService authorizationService, IHttpContextAccessor httpContextAccessor,
            IWorkflowStageService workflowStageService,
            IEmailService emailService,
            IModuleLayoutRepository moduleLayoutRepository)

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
            _moduleLayoutRepository = moduleLayoutRepository;
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
            //if (!_authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, record, Operations.Create).Result.Succeeded)
            //{
            //    throw new UnauthorizedAccessException("Your Unauthorized");
            //}
            int multikeys = 0;

            requestResult = Validate(record);
            if (requestResult.IsSuccessful)
            {
                var alllists = record.FieldValues;

                var lastmultikeys = _commonRepository.Getkey();
                if (alllists[0].SubRecordId == 0)
                {
                    for (var i = 0; i < alllists.Count; i++)
                    {
                        if (alllists[i].MultiValueControl == true)
                        {

                            multikeys = lastmultikeys;
                            alllists[i].SubRecordId = multikeys;
                        }

                    }
                }
                record.UpdatedDate = DateTime.Now;
                _commonRepository.Insert(record);
                return new RequestResult<bool>(true);
            }
            return requestResult;
        }
        /// </summary>
        /// <param name="recordId"></param>
        /// <param name="metadataId"></param>
        /// <returns></returns>
        public byte[] TemplateGenerate(int recordId, int metadataId, string email, bool send, int moduleLayoutId, int UipagetypeId, int parentId, int fileId)
        {
            var lookupM = _uiPageMetadataCharacteristicsService.GetByMetadataId(metadataId);
            int uiPageId;
            var recordMdel = _recordGenericRepository.Get(recordId);
            string template;

            //var File = DownloadImage(/*fileId*/);
            var File = DownloadImage(fileId);

            //string template;

            using (var memoryStream = new MemoryStream(File.DataFiles))
            using (var reader = new StreamReader(memoryStream))
            {
                template = reader.ReadToEnd();

            }
            //var template = File.ReadAllText(path);
            var workflowStage = _workflowStageService.GetStage(recordMdel.ModuleId, recordMdel.Id);
            var pageMetadata = GetMetadata(recordMdel.ModuleId, recordMdel.WorkflowStageId, out uiPageId);
            var uiPageData = _commonRepository.GetPageData(recordId);

            List<LayoutModel> hirericheys = new List<LayoutModel>();
            pageMetadata.ForEach(x => hirericheys.Add(new LayoutModel
            {
                UiPageMetadata = x,
                UiPageData = (List<UiPageDataModel>)uiPageData.Where(y => y.UiPageMetadataId == x.Id).ToList(),

            }));

            foreach (var item in hirericheys)
            {
                if (item.UiPageMetadata.ControlCategoryName == "DataControl" && item.UiPageMetadata.MultiValueControl != true)
                {
                    if (item.UiPageMetadata.MetadataModuleBridgeUiControlDisplayName != null)
                    {
                        item.UiPageMetadata.UiControlDisplayName = item.UiPageMetadata.MetadataModuleBridgeUiControlDisplayName;
                    }

                    string fieldValues = "**" + item.UiPageMetadata.UiControlDisplayName + "**";
                    string replacementValue = item.UiPageData.Count == 0 ? "null" : item.UiPageData.First().Value;

                    template = template.Replace(fieldValues, replacementValue);
                }
            }

            // Process multi-value controls
            var multiVal = GetMultiControlValue(recordId, moduleLayoutId, UipagetypeId, parentId);

            if (multiVal != null && multiVal.Fields.Count() > 0)
            {
                var groupedData = multiVal.FieldValue
                    .GroupBy(fv => fv.SubRecordId)
                    .ToDictionary(g => g.Key, g => g.ToList());

                var fieldNames = multiVal.Fields.Select(f => f.UiControlDisplayName).ToList();
                var rowBuilder = new StringBuilder();
                var headbuilder = new StringBuilder();

                //foreach (var hedname in multiVal.Fields)
                //{
                    headbuilder.Append("<tr>");
                    foreach (var field in multiVal.Fields)
                    {
                        var value = field.UiControlDisplayName;
                        headbuilder.Append($"<th>{System.Net.WebUtility.HtmlEncode(value ?? "null")}</th>");
                    }
                    headbuilder.Append("</tr>");
                //}
                // Generate the rows for the table body
                foreach (var group in groupedData)
                {
                    rowBuilder.Append("<tr>");
                    foreach (var field in multiVal.Fields)
                    {
                        var value = group.Value.FirstOrDefault(fv => fv.UiPageMetadataId == field.Id)?.Value;
                        rowBuilder.Append($"<td>{System.Net.WebUtility.HtmlEncode(value ?? "null")}</td>");
                    }
                    rowBuilder.Append("</tr>");
                }
                string placeholderhed = "{tablehead}";
                template = template.Replace(placeholderhed, headbuilder.ToString());
                // Replace the placeholder in the template with generated rows
                string placeholder = "{tableRows}";
                template = template.Replace(placeholder, rowBuilder.ToString());

                // Debug log for final template
                Console.WriteLine("Final Template: " + template);
            }
            else
            {
                template = template.Replace("<table class=\"TemplateTable\" >", "");
            }
            // Generate PDF
            HtmlToPdf converter = new HtmlToPdf();
            PdfDocument doc = converter.ConvertHtmlString(template);
            var pdfByte = doc.Save();
            doc.Close();

            // Send PDF via email if required
            if (send)
            {
                using Stream stream = new MemoryStream(pdfByte);
                Attachment attachment = new Attachment(stream, "report.pdf", "application/pdf");

                EmailModel emailModel = new EmailModel
                {
                    Email = new List<string> { email },
                    Subject = "Thanks For Visiting Testing And Calibration Labs",
                    Attachments = new List<Attachment> { attachment }
                };

                var sendMail = _emailService.Sendemail(emailModel);
            }

            return (pdfByte);
        }
        /// <summary>
        /// to Delete Record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            var record = _recordGenericRepository.Get(id);
            if (!_authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, record, Operations.Create).Result.Succeeded)
            {
                throw new UnauthorizedAccessException("Your Unauthorized");
            }
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
            int multikeys = 0;

            RequestResult<bool> requestResult = new RequestResult<bool>();
            //if (!_authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, record, Operations.Update).Result.Succeeded)
            //{
            //    throw new UnauthorizedAccessException("Your Unauthorized");
            //}
            requestResult = Validate(record);
            if (requestResult.IsSuccessful)
            {
                var lastmultikeys = _commonRepository.Getkey();
                var alllists = record.FieldValues;

                var oldRecord = _recordGenericRepository.Get(record.Id);
                if (oldRecord.UpdatedDate == record.UpdatedDate)
                {
                    if (alllists.Count > 0 && alllists[0].SubRecordId == 0)
                    {
                        for (var i = 0; i < alllists.Count; i++)
                        {
                            if (alllists[i].MultiValueControl == true)
                            {
                                multikeys = lastmultikeys;
                                alllists[i].SubRecordId = multikeys;

                            }
                        }
                    }
                    record.UpdatedDate = DateTime.Now;
                    _commonRepository.Save(record);
                    //record.WorkflowStageId = oldRecord.WorkflowStageId;
                    //_workflowActivityService.WorkflowActivity(record);
                }
                return new RequestResult<bool>(true);

            }
            return new RequestResult<bool>(false);
        }
        /// <summary>
        /// Get By Module Id For Create
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public RecordModel GetUiPageMetadataCreate(int moduleId)
        {
            int uiPageTypeId;
            RecordModel record = new RecordModel() { ModuleId = moduleId, Id = 0 };
            //if (!_authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, record, Operations.Read).Result.Succeeded)
            //{
            //    throw new UnauthorizedAccessException("Your Unauthorized");
            //}
            var workflowStage = _workflowStageService.GetStage(moduleId, 0);
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

            record = new RecordModel
            {

                ModuleId = moduleId,
                UiPageTypeId = uiPageTypeId,
                Layout = hierarchy,
                //ModuleLayoutId = moduleLayoutId.Id
                ModuleLayoutId = 1

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
            var uiPageData = _commonRepository.GetUiPageDataByModuleId(moduleId);
            var metadata = uiMetadata.GroupBy(x => x.Id).Select(y => y.First());
            Dictionary<int, List<UiPageDataModel>> uiPageDataModels = new Dictionary<int, List<UiPageDataModel>>();
            uiPageData.GroupBy(x => x.RecordId).ToList()
                .ForEach(t => uiPageDataModels.Add(t.Key, t.OrderBy(o => o.UiPageMetadataId).ToList()));
            return new RecordsModel { ModuleId = moduleId, Fields = metadata, FieldValues = uiPageDataModels };
        }

        /// <summary>
        /// This Method Return Data For Grid
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public RecordsModel GetRecordsIndex(int moduleId)
        {
            var uiMetadata = _commonRepository.GetrecordIndexbyModuleId(moduleId);
            var uiPageData = _commonRepository.GetUiPageDataByModuleId(moduleId);
            var metadata = uiMetadata.GroupBy(x => x.Id).Select(y => y.First());
            Dictionary<int, List<UiPageDataModel>> uiPageDataModels = new Dictionary<int, List<UiPageDataModel>>();
            uiPageData.GroupBy(x => x.RecordId).ToList()
                .ForEach(t => uiPageDataModels.Add(t.Key, t.OrderBy(o => o.UiPageMetadataId).ToList()));
            return new RecordsModel { ModuleId = moduleId, Fields = metadata, FieldValues = uiPageDataModels };
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
            //if (!_authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, recordMdel, Operations.Read).Result.Succeeded)
            //{
            //    throw new UnauthorizedAccessException("Your Unauthorized");
            //}

            var uiMetadata = GetMetadata(recordMdel.ModuleId, recordMdel.WorkflowStageId, out uiPageTypeId);
            foreach (var item in uiMetadata)
            { if (item.MetadataModuleBridgeUiControlDisplayName != null) { item.UiControlDisplayName = item.MetadataModuleBridgeUiControlDisplayName; } }
            var uiPageData = _commonRepository.GetPageData(recordId);
            List<LayoutModel> hirericheys = new List<LayoutModel>();
            uiMetadata.ForEach(x => hirericheys.Add(new LayoutModel
            {
                UiPageMetadata = x,
                UiPageData = uiPageData.Where(y => y.UiPageMetadataId == x.Id).ToList()
            }));

            var hierarchy = hirericheys.Hierarchize(
                 0, // The "root level" key. We're using -1 to indicate root level.
                 f => f.UiPageMetadata.Id, // The ID property on your object
                 f => f.UiPageMetadata.ParentId,// The property on your object that points to its parent
                f => f.UiPageMetadata.Orders // The property on your object that specifies the order within its parent
                 );
            return new RecordModel { Id = recordId, UiPageTypeId = uiPageTypeId, UpdatedDate = recordMdel.UpdatedDate, ModuleId = recordMdel.ModuleId, WorkflowStageId = recordMdel.WorkflowStageId, Layout = hierarchy };
        }

        #region Multi Value Control
        public int ImageUpload(FileUploadModel fileUpload)
        {
            var dataDownloaded = _commonRepository.FileUpload(fileUpload);
            return dataDownloaded;
        }
        public FileUploadModel DownloadImage(int ImageValue)
        {
            var image = _commonRepository.ImageDownload(ImageValue);
            return image;
        }

        public FileUploadModel OnlyimageDownload(string ImageValue)
        {
            var image = _commonRepository.ImageonlyDownload(ImageValue);
            return image;
        }
        /// <summary>
        /// This Method Returns Data For Multi Value Grid
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public RecordsModel GetMultiControlValue(int recordId, int moduleLayoutId, int UipagetypeId, int parentId)
        {
            var uiMetadata = _commonRepository.GetMultiControlMetadata(moduleLayoutId, UipagetypeId);
            var uiPageData = _commonRepository.GetMultiPageData(recordId, UipagetypeId);
            var metadata = uiMetadata.GroupBy(x => x.ParentId).Select(y => y.ToList());
            var parentbaseddata = _commonRepository.GetMultiControlMetadataByparentId(moduleLayoutId, UipagetypeId, parentId);

            return new RecordsModel { Id = recordId, ParentFields = parentbaseddata, Fields = uiMetadata, FieldValue = uiPageData, ModuleId = uiMetadata[0].ModuleId, WorkflowStageId = uiMetadata[0].WorkflowStageId };
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

        public bool FileUpdate(int id, FileUploadModel fileUploadModel)
        {
            return _commonRepository.FileUpload(id, fileUploadModel);

        }
        #endregion
        #endregion

        #region Private Methods
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
        public int GenerateRecordId(int ModuleId, int WorkflowStageId)
        {
            var getRecordid = _commonRepository.GetRecordId(ModuleId, WorkflowStageId);
            return getRecordid;
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
                        switch ((Common.ValidationType)item.UiPageValidationTypeId)
                        {
                            case Common.ValidationType.IsRequired:
                                if (string.IsNullOrEmpty(field.Value))
                                {
                                    string errorMessage = string.Format(validationlist.Message, uipagedata.UiControlDisplayName);
                                    validationMessages.Add(new ValidationMessage { MessageKey = field.MultiValueControl.ToString(), Reason = errorMessage, SourceId = metadataId, Severity = ValidationSeverity.Error });
                                }
                                break;
                            case Common.ValidationType.MinPasswordLength:
                                int minLength = int.Parse(item.Value);
                                if (field.Value.Length < minLength)
                                    validationMessages.Add(new ValidationMessage { MessageKey = field.MultiValueControl.ToString(), Reason = validationlist.Message, SourceId = metadataId, Severity = ValidationSeverity.Error });
                                break;
                            case Common.ValidationType.Email:
                                int minLengthEmail = int.Parse(item.Value);
                                if (field.Value.Length < minLengthEmail)
                                    validationMessages.Add(new ValidationMessage { MessageKey = field.MultiValueControl.ToString(), Reason = validationlist.Message, SourceId = metadataId, Severity = ValidationSeverity.Error });
                                break;
                            case Common.ValidationType.AdharLength:
                                int minLengthAdhar = int.Parse(item.Value);
                                if (field.Value.Length != minLengthAdhar)
                                    validationMessages.Add(new ValidationMessage { MessageKey = field.MultiValueControl.ToString(), Reason = validationlist.Message, SourceId = metadataId, Severity = ValidationSeverity.Error });
                                break;
                            case Common.ValidationType.MobileNumberLength:
                                int minLengtMobileNumberLength = int.Parse(item.Value);
                                if (field.Value.Length != minLengtMobileNumberLength)
                                    validationMessages.Add(new ValidationMessage { MessageKey = field.MultiValueControl.ToString(), Reason = validationlist.Message, SourceId = metadataId, Severity = ValidationSeverity.Error });
                                break;
                            case Common.ValidationType.Name:
                                int minLengtName = int.Parse(item.Value);
                                if (field.Value.Length < minLengtName)
                                    validationMessages.Add(new ValidationMessage { MessageKey = field.MultiValueControl.ToString(), Reason = validationlist.Message, SourceId = metadataId, Severity = ValidationSeverity.Error });
                                break;
                            case Common.ValidationType.Year:
                                int minLengtYear = int.Parse(item.Value);
                                if (field.Value.Length != minLengtYear)
                                    validationMessages.Add(new ValidationMessage { MessageKey = field.MultiValueControl.ToString(), Reason = validationlist.Message, SourceId = metadataId, Severity = ValidationSeverity.Error });
                                break;

                        }
                    }
                }
                foreach (var items in validationtypes)
                {
                    if (items.Id == 8 && field.Value != "")
                    {
                        var validationlist = _uiPageValidationTypesGenericRepository.Get(items.Id);

                        var uipagedata = _uiPageMetadataRepository.GetById(field.UiPageMetadataId);
                        string metadataId;
                        metadataId = Helpers.GenerateUiControlId(uipagedata.UiControlTypeName, field.UiPageMetadataId);
                        if (field.DataTypeId == (int)ValidationType.Int)
                        {
                            if (!int.TryParse(field.Value, out _))
                            {
                                string errorMessage = string.Format(validationlist.Message, $"{uipagedata.DataTypeName} {uipagedata.UiControlDisplayName}");
                                validationMessages.Add(new ValidationMessage { MessageKey = field.MultiValueControl.ToString(), Reason = errorMessage, SourceId = metadataId, Severity = ValidationSeverity.Error });

                            }
                        }
                        if (field.DataTypeId == (int)ValidationType.String)
                        {
                            if (int.TryParse(field.Value, out _))
                            {
                                string errorMessage = string.Format(validationlist.Message, $"{uipagedata.DataTypeName} {uipagedata.UiControlDisplayName}");
                                validationMessages.Add(new ValidationMessage { MessageKey = field.MultiValueControl.ToString(), Reason = errorMessage, SourceId = metadataId, Severity = ValidationSeverity.Error });

                            }
                        }


                    }

                }

            }
            return new RequestResult<bool>(validationMessages);
        }

        #endregion
    }
}
