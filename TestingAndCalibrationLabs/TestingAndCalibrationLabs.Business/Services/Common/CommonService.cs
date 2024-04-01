﻿using Microsoft.AspNetCore.Hosting;
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
                    for (var i = 0; i < alllists.Count;   i++)
                    {
                        if (alllists[i].MultiValueControl == true)
                        {

                            multikeys = lastmultikeys;
                            alllists[i].SubRecordId = multikeys;
                        }

                    }
                }

                record.UpdatedDate = DateTime.Now;
                //record.WorkflowStageId = GetWorkflowStageId(record.ModuleId);
                 _commonRepository.Insert(record);
                // record.WorkflowStageId = workflowStageId;
                //_workflowActivityService.WorkflowActivity(record)
                return new RequestResult<bool>(true);
            }
            return requestResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recordId"></param>
        /// <param name="metadataId"></param>
        /// <returns></returns>
        public byte[] TemplateGenerate(int recordId, int metadataId, string email, bool send,int moduleLayoutId, int UipagetypeId)
        {
            var lookupM = _uiPageMetadataCharacteristicsService.GetByMetadataId(metadataId);
            int uiPageId;
            var recordMdel = _recordGenericRepository.Get(recordId);
            var path = Path.Combine(_webHostEnvironment.WebRootPath, lookupM.LookupName);
            var template = File.ReadAllText(path);
            var workflowStage = _workflowStageService.GetStage(recordMdel.ModuleId, recordMdel.Id);
            var pageMetadata = GetMetadata(recordMdel.ModuleId, recordMdel.WorkflowStageId, out uiPageId);
            var uiPageData = _commonRepository.GetPageData(recordId);

            List<LayoutModel> hirericheys = new List<LayoutModel>();
            pageMetadata.ForEach(x => hirericheys.Add(new LayoutModel
            {
                UiPageMetadata = x,
                UiPageData = (List<UiPageDataModel>)uiPageData.Where(y => y.UiPageMetadataId == x.Id)
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
                    template = template.Replace(fieldName, item.UiPageMetadata.UiControlDisplayName).Replace(fieldValues, item.UiPageData.First().Value);
                }
            }
            var multiVal = GetMultiControlValue(recordId, moduleLayoutId, UipagetypeId);
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
                template = template.Replace("**gridTableMulti**", "");
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
                using Stream stream = new MemoryStream(pdfByte);
                Attachment attachment = new Attachment(stream, "report.pdf", "application/pdf");
                EmailModel emailModel = new EmailModel();
                var emailAd = new List<string>
                {
                    email
                };
                emailModel.Email = emailAd;

                emailModel.Subject = "Thanks For Visiting Testing And Calibration Labs";
                emailModel.HtmlMsg = htmlWeb;
                var atchmt = new List<Attachment>() { attachment };
                emailModel.Attachments = atchmt;
                var sendMail = _emailService.Sendemail(emailModel);
            }
            return pdfByte;
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
            int multikeys =0;

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
                    if (alllists.Count > 0 && alllists[0].SubRecordId ==0) 
                    {
                        for (var i = 0; i < alllists.Count;  i++)
                        {
                            if(alllists[i].MultiValueControl == true){
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
            var moduleLayoutId =_moduleLayoutRepository.GetByModuleLayoutId(moduleId);
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
                ModuleLayoutId = moduleLayoutId.Id
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
        public int ImageUpload (FileUploadModel fileUpload)
        {
           var dataDownloaded = _commonRepository.FileUpload(fileUpload);
              return dataDownloaded;
        }
        public FileUploadModel  DownloadImage(string ImageValue)
        { 
             var image = _commonRepository.ImageDownload(ImageValue);
            return image;
        }
        /// <summary>
        /// This Method Returns Data For Multi Value Grid
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public RecordsModel GetMultiControlValue(int recordId, int moduleLayoutId, int UipagetypeId)
        {
            var uiMetadata = _commonRepository.GetMultiControlMetadata(moduleLayoutId, UipagetypeId);
            var uiPageData = _commonRepository.GetMultiPageData(recordId, UipagetypeId);
            var metadata = uiMetadata.GroupBy(x => x.Id).Select(y => y.First());
          
           
            return new RecordsModel { Id = recordId, Fields = metadata, FieldValue = uiPageData, ModuleId = uiMetadata[0].ModuleId, WorkflowStageId= uiMetadata[0].WorkflowStageId };
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
        public int GenerateRecordId(int ModuleId,int  WorkflowStageId)
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
