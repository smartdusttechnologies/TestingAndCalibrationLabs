using AutoMapper;
using FluentAssertions;
using Google.Apis.Drive.v3.Data;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Xml.Linq;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Services;
using TestingAndCalibrationLabs.Web.UI.Controllers;
using TestingAndCalibrationLabs.Web.UI.Mappers;
using TestingAndCalibrationLabs.Web.UI.Models;


namespace TestingAndCalibrationLabs.Tests
{
    [TestFixture]
    public class CommonControllerTest
    {
        IMapper _mapper;
        ICommonService _commonService;
        IGoogleDriveService _googleDriveService;

        IWorkflowStageService _workflowStageService;

        List<UiPageValidationModel> validations = new List<UiPageValidationModel>();
        List<UiPageValidationTypeModel> validationlist = new List<UiPageValidationTypeModel>();

        Mock<ICommonRepository> commonRepository = new Mock<ICommonRepository>();
        Mock<IGenericRepository<RecordModel>> igenericRepository = new Mock<IGenericRepository<RecordModel>>();
        Mock<IGenericRepository<UiPageDataModel>> genericRepositoryuipageData = new Mock<IGenericRepository<UiPageDataModel>>();
        Mock<IGenericRepository<UiPageTypeModel>> iGenericRepositoryPageType = new Mock<IGenericRepository<UiPageTypeModel>>();
        Mock<IGenericRepository<UiPageMetadataModel>> iGenericRepositoryPageMetaData = new Mock<IGenericRepository<UiPageMetadataModel>>();
        Mock<IGenericRepository<UiPageValidationTypeModel>> iGenericRepositoryPageValidation = new Mock<IGenericRepository<UiPageValidationTypeModel>>();
        Mock<IUiPageMetadataCharacteristicsRepository> uiPageMetadataCharacteristicsRepository = new Mock<IUiPageMetadataCharacteristicsRepository>();
        Mock<IUiPageMetadataRepository> uiPageMetadataRepository = new Mock<IUiPageMetadataRepository>();
        Mock<IWorkflowActivityService> workflowActivityService = new Mock<IWorkflowActivityService>();
        Mock<IWebHostEnvironment> webHostEnvironment = new Mock<IWebHostEnvironment>();
        Mock<IUiPageMetadataCharacteristicsService> uiPageMetadataCharacteristicsService = new Mock<IUiPageMetadataCharacteristicsService>();




        [SetUp]
        public void SetUp()
        {
            var profile = new MappingProfile();
            var Configuration = new MapperConfiguration(x => x.AddProfile(profile));
            var mapper = new Mapper(Configuration);
            _mapper = mapper;

            validations.Add(new UiPageValidationModel { Id = 4, Name = "MinPasswordLength", UiPageTypeId = 3, UiPageTypeName = "hg", UiPageMetadataId = 3, UiPageMetadataName = "hgy", UiPageValidationTypeId = 4, UiPageValidationTypeName = "iuy", Value = "ju" });
            validations.Add(new UiPageValidationModel { Id = 3, Name = "AdharLength", UiPageMetadataId = 3, UiPageMetadataName = null, UiPageTypeId = 2, UiPageTypeName = null, UiPageValidationTypeId = 3, UiPageValidationTypeName = null, Value = "12" });
            // validations.Add(new UiPageValidationModel { Id = 2, Name = "Email", UiPageMetadataId = 2, UiPageMetadataName = null, UiPageTypeId = 2, UiPageTypeName = null, UiPageValidationTypeId = 2, UiPageValidationTypeName = null, Value = "3" });
            // validations.Add(new UiPageValidationModel { Id = 1, Name = "MobileNumberLength", UiPageMetadataId = 4, UiPageMetadataName = null, UiPageTypeId = 2, UiPageTypeName = null, UiPageValidationTypeId = 4, UiPageValidationTypeName = null, Value = "10" });
            // validations.Add(new UiPageValidationModel { Id = 5, Name = "Year", UiPageMetadataId = 5, UiPageMetadataName = null, UiPageTypeId = 2, UiPageTypeName = null, UiPageValidationTypeId = 5, UiPageValidationTypeName = null, Value = "4" });

            validationlist.Add(new UiPageValidationTypeModel { Id = 1, Name = "MinPasswordLength", Value = "8", Message = "aman" });
            validationlist.Add(new UiPageValidationTypeModel { Id = 2, Message = "Email should have format", Name = "Email", Value = "3" });
            //  validationlist.Add(new UiPageValidationTypeModel { Id = 3, Message = "Aadhar length should be equal to 12", Name = "AdharLength", Value = "12" });
            //  validationlist.Add(new UiPageValidationTypeModel { Id = 4, Message = "Mobile No length eq to 10", Name = "MobileNumberLength", Value = "10" });
            //  validationlist.Add(new UiPageValidationTypeModel { Id = 5, Message = "Year length eq to 4 ", Name = "Year ", Value = "4" });
            // validationlist.Add(new UiPageValidationTypeModel { Id = 6, Message = "{0} Field Required", Name = "IsRequired", Value = "" });

            //var logger = new Mock<ILogger<CommonController>>();
            //var controller = new CommonController(logger.Object, _commonService, _mapper, _googleDriveService);
        }


        /* Description - This unit test cases is to validate the create method of common controller 
         * Step1- Input parameter = Id , Expected = Recordsdto is fetched successfully 
         * Expected Result = It will have the record of recordDTO
         */
        [Test]
        public void Common_Index_Method_Test()
        {
            List<UiPageMetadataModel> uiPageMetaDataModels = new List<UiPageMetadataModel>();
            uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 3, Name = "aman", UiPageTypeId = 8, UiPageTypeName = "deepak", UiControlTypeId = 8, UiControlTypeName = "jjf", IsRequired = true, UiControlDisplayName = "jkf", DataTypeId = 7, DataTypeName = "ddd", LookupCategoryId = 5, LookupCategoryName = "kji", ControlCategoryName = "DataControl", ControlCategoryId = 6, UiControlCategoryTypeId = 4, UiControlCategoryTypeName = "DataControl", UiControlCategoryTypeTemplate = "jio", ParentId = 3, ModuleId = 9, Position = 8, MultiValueControl = true, MetadataModuleBridgeUiControlDisplayName = "kji", Orders = 8 });
            uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 4, Name = "aman4", UiPageTypeId = 48, UiPageTypeName = "4deepak", UiControlTypeId = 78, UiControlTypeName = "jj4f", IsRequired = true, UiControlDisplayName = "jk7f", DataTypeId = 7, DataTypeName = "d7dd", LookupCategoryId = 45, LookupCategoryName = "k4ji", ControlCategoryName = "jmif", ControlCategoryId = 46, UiControlCategoryTypeId = 44, UiControlCategoryTypeName = "ji4u", UiControlCategoryTypeTemplate = "4jio", ParentId = 43, ModuleId = 49, Position = 48, MultiValueControl = true, MetadataModuleBridgeUiControlDisplayName = "kj4i", Orders = 84 });

            List<UiPageDataModel> uipageDataModels = new List<UiPageDataModel>();
            uipageDataModels.Add(new UiPageDataModel { Id = 11, UiPageTypeId = 11, UiPageMetadataId = 11, RecordId = 6, Value = "Name", SubRecordId = 7, MultiValueControl = true });
            uipageDataModels.Add(new UiPageDataModel { Id = 41, UiPageTypeId = 51, UiPageMetadataId = 51, RecordId = 56, Value = "Nam5e", SubRecordId = 47, MultiValueControl = true });

            _commonService = new SampleService(commonRepository.Object, igenericRepository.Object, iGenericRepositoryPageType.Object, genericRepositoryuipageData.Object, iGenericRepositoryPageMetaData.Object, iGenericRepositoryPageValidation.Object, uiPageMetadataCharacteristicsRepository.Object, uiPageMetadataRepository.Object, workflowActivityService.Object, webHostEnvironment.Object, uiPageMetadataCharacteristicsService.Object);

            // Mocking the repository
            //   commonRepository.Setup(x => x.GetUiPageMetadata(It.IsAny<int>())).Returns(new RecordModel { UiPageTypeId = 3, Id = 1, FieldValues = uipageDataModels, Fields = uiPageMetaDataModels, ModuleId = 1, WorkflowStageId = 4, UpdatedDate = DateAndTime });

            commonRepository.Setup(x => x.GetUiPageDataByModuleId(It.IsAny<int>())).Returns(uipageDataModels);

            commonRepository.Setup(x => x.GetUiPageMetadataByModuleId(It.IsAny<int>())).Returns(uiPageMetaDataModels);



            var logger = new Mock<ILogger<CommonController>>();
            Mock<IGoogleDriveService> googleDriveService = new Mock<IGoogleDriveService>();
            Mock<IWorkflowStageService> workflowStageService = new Mock<IWorkflowStageService>();
            var controller = new CommonController(_googleDriveService, logger.Object, _commonService, _mapper, _workflowStageService);

            var result = (ViewResult)controller.Index(3);
            //Expected Result
            List<UiPageMetadataDTO> uiPageMetaDataDTO = new List<UiPageMetadataDTO>();
            uiPageMetaDataDTO.Add(new UiPageMetadataDTO { Id = 3, Name = "aman", UiPageTypeId = 8, UiPageTypeName = "deepak", UiControlTypeId = 8, UiControlTypeName = "jjf", IsRequired = true, UiControlDisplayName = "jkf", DataTypeId = 7, DataTypeName = "ddd", LookupCategoryId = 5, LookupCategoryName = "kji", ControlCategoryName = "DataControl", ControlCategoryId = 6, UiControlCategoryTypeId = 4, UiControlCategoryTypeName = "DataControl", UiControlCategoryTypeTemplate = "jio", ParentId = 3, ModuleId = 9, Position = 8, MultiValueControl = true, MetadataModuleBridgeUiControlDisplayName = "kji", Orders = 8 });
            // uiPageMetaDataDTO.Add(new UiPageMetadataDTO { Id = 4, Name = "aman4", UiPageTypeId = 48, UiPageTypeName = "4deepak", UiControlTypeId = 78, UiControlTypeName = "jj4f", IsRequired = true, UiControlDisplayName = "jk7f", DataTypeId = 7, DataTypeName = "d7dd", LookupCategoryId = 45, LookupCategoryName = "k4ji", ControlCategoryName = "jmif", ControlCategoryId = 46, UiControlCategoryTypeId = 44, UiControlCategoryTypeName = "ji4u", UiControlCategoryTypeTemplate = "4jio", ParentId = 43, ModuleId = 49, Position = 48, MultiValueControl = true, MetadataModuleBridgeUiControlDisplayName = "kj4i", Orders = 84 });
            // uiPageMetaDataDTO.Add(new UiPageMetadataDTO { Id = 4, UiPageTypeId = 4, UiPageTypeName = "ritesh", UiControlTypeId = 33, UiControlTypeName = "raj", UiControlDisplayName = "disp", IsRequired = true, DataTypeId = 127, DataTypeName = "char" });

            //Dictionary<int, List<UiPageDataDTO>> uiPageDataDTO = new Dictionary<int, List<UiPageDataDTO>>();
            // uiPageDataDTO.Add(6, new List<UiPageDataDTO> { new UiPageDataDTO { Id = 11, UiPageTypeId = 11, UiPageMetadataId = 11, RecordId = 6, Value = "Name", SubRecordId = 7, MultiValueControl = true } });


            Dictionary<int, List<UiPageDataDTO>> uiPageDataDTO = new Dictionary<int, List<UiPageDataDTO>>();
            uiPageDataDTO.Add(6, new List<UiPageDataDTO> { new UiPageDataDTO { Id = 11, UiPageTypeId = 11, UiPageMetadataId = 11, RecordId = 6, Value = "Name", SubRecordId = 7, MultiValueControl = true } });
            uiPageDataDTO.Add(56, new List<UiPageDataDTO> { new UiPageDataDTO { Id = 41, UiPageTypeId = 51, UiPageMetadataId = 51, RecordId = 56, Value = "Nam5e", SubRecordId = 47, MultiValueControl = true } });

            List<UiPageDataDTO> uipageDTO = new List<UiPageDataDTO>();


            var ExpectedResult = new RecordsDTO() { Id = 0, ModuleId = 3, Fields = uiPageMetaDataDTO, FieldValues = uiPageDataDTO, FieldValue = uipageDTO };

            result.Model.Should().BeEquivalentTo(ExpectedResult);


        }

        /*
         *   This test case is written to Check the index method with Passing wrong Parameter
         *   Step1 - passind Parameter =Id, Servicees  GetUiPageMetadataMethod = It return the RecordModel, GetUiPageDataByUiPageId Method = It will return the UipagemetadataModel
         *   Expected value = It will return the recordDTO model
         */
        [Test]
        public void Common_Index_wrong_det_Test()
        {
            List<UiPageMetadataModel> uiPageMetaDataModels = new List<UiPageMetadataModel>();
            uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 6, Name = "aman", UiPageTypeId = 8, UiPageTypeName = "deepak", UiControlTypeId = 8, UiControlTypeName = "jjf", IsRequired = true, UiControlDisplayName = "jkf", DataTypeId = 7, DataTypeName = "ddd", LookupCategoryId = 5, LookupCategoryName = "kji", ControlCategoryName = "DataControl", ControlCategoryId = 6, UiControlCategoryTypeId = 4, UiControlCategoryTypeName = "DataControl", UiControlCategoryTypeTemplate = "jio", ParentId = 3, ModuleId = 9, Position = 8, MultiValueControl = true, MetadataModuleBridgeUiControlDisplayName = "kji", Orders = 8 });
            uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 4, Name = "aman4", UiPageTypeId = 48, UiPageTypeName = "4deepak", UiControlTypeId = 78, UiControlTypeName = "jj4f", IsRequired = true, UiControlDisplayName = "jk7f", DataTypeId = 7, DataTypeName = "d7dd", LookupCategoryId = 45, LookupCategoryName = "k4ji", ControlCategoryName = "jmif", ControlCategoryId = 46, UiControlCategoryTypeId = 44, UiControlCategoryTypeName = "ji4u", UiControlCategoryTypeTemplate = "4jio", ParentId = 43, ModuleId = 49, Position = 48, MultiValueControl = true, MetadataModuleBridgeUiControlDisplayName = "kj4i", Orders = 84 });

            List<UiPageDataModel> uipageDataModels = new List<UiPageDataModel>();
            uipageDataModels.Add(new UiPageDataModel { Id = 11, UiPageTypeId = 11, UiPageMetadataId = 11, RecordId = 6, Value = "Name", SubRecordId = 7, MultiValueControl = true });
            uipageDataModels.Add(new UiPageDataModel { Id = 41, UiPageTypeId = 51, UiPageMetadataId = 51, RecordId = 56, Value = "Nam5e", SubRecordId = 47, MultiValueControl = true });

            _commonService = new SampleService(commonRepository.Object, igenericRepository.Object, iGenericRepositoryPageType.Object, genericRepositoryuipageData.Object, iGenericRepositoryPageMetaData.Object, iGenericRepositoryPageValidation.Object, uiPageMetadataCharacteristicsRepository.Object, uiPageMetadataRepository.Object, workflowActivityService.Object, webHostEnvironment.Object, uiPageMetadataCharacteristicsService.Object);

            // Mocking the repository

            commonRepository.Setup(x => x.GetUiPageDataByModuleId(It.IsAny<int>())).Returns(uipageDataModels);

            commonRepository.Setup(x => x.GetUiPageMetadataByModuleId(It.IsAny<int>())).Returns(uiPageMetaDataModels);



            var logger = new Mock<ILogger<CommonController>>();
            Mock<IGoogleDriveService> googleDriveService = new Mock<IGoogleDriveService>();
            Mock<IWorkflowStageService> workflowStageService = new Mock<IWorkflowStageService>();
            var controller = new CommonController(_googleDriveService, logger.Object, _commonService, _mapper, _workflowStageService);

            var result = (ViewResult)controller.Index(3);
            //Expected Result
            List<UiPageMetadataDTO> uiPageMetaDataDTO = new List<UiPageMetadataDTO>();
            uiPageMetaDataDTO.Add(new UiPageMetadataDTO { Id = 3, Name = "aman", UiPageTypeId = 8, UiPageTypeName = "deepak", UiControlTypeId = 8, UiControlTypeName = "jjf", IsRequired = true, UiControlDisplayName = "jkf", DataTypeId = 7, DataTypeName = "ddd", LookupCategoryId = 5, LookupCategoryName = "kji", ControlCategoryName = "DataControl", ControlCategoryId = 6, UiControlCategoryTypeId = 4, UiControlCategoryTypeName = "DataControl", UiControlCategoryTypeTemplate = "jio", ParentId = 3, ModuleId = 9, Position = 8, MultiValueControl = true, MetadataModuleBridgeUiControlDisplayName = "kji", Orders = 8 });

            Dictionary<int, List<UiPageDataDTO>> uiPageDataDTO = new Dictionary<int, List<UiPageDataDTO>>();
            uiPageDataDTO.Add(6, new List<UiPageDataDTO> { new UiPageDataDTO { Id = 11, UiPageTypeId = 11, UiPageMetadataId = 11, RecordId = 6, Value = "Name", SubRecordId = 7, MultiValueControl = true } });
            uiPageDataDTO.Add(56, new List<UiPageDataDTO> { new UiPageDataDTO { Id = 41, UiPageTypeId = 51, UiPageMetadataId = 51, RecordId = 56, Value = "Nam5e", SubRecordId = 47, MultiValueControl = true } });

            List<UiPageDataDTO> uipageDTO = new List<UiPageDataDTO>();


            var ExpectedResult = new RecordsDTO() { Id = 0, ModuleId = 36, Fields = uiPageMetaDataDTO, FieldValues = uiPageDataDTO, FieldValue = uipageDTO };

            result.Model.Should().NotBeEquivalentTo(ExpectedResult);

        }
        /*
         * This Test is to valide the Create [httpget] method 
         * step1- Passing Parameter= Id  , GetUiPageMetadata Method = It returns Record Model 
         * Expected Result = It Returns the recordDTO
         */
        [Test]
        public void Common_Create_Get_Method_Test()
        {
            List<UiPageMetadataModel> uiPageMetaDataModels = new List<UiPageMetadataModel>();
            uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 3, Name = "aman", UiPageTypeId = 8, UiPageTypeName = "deepak", UiControlTypeId = 8, UiControlTypeName = "jjf", IsRequired = true, UiControlDisplayName = "jkf", DataTypeId = 7, DataTypeName = "ddd", LookupCategoryId = 5, LookupCategoryName = "kji", ControlCategoryName = "DataControl", ControlCategoryId = 6, UiControlCategoryTypeId = 4, UiControlCategoryTypeName = "DataControl", UiControlCategoryTypeTemplate = "jio", ParentId = 3, ModuleId = 9, Position = 8, MultiValueControl = true, MetadataModuleBridgeUiControlDisplayName = "kji", Orders = 8 });
            uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 4, Name = "aman4", UiPageTypeId = 48, UiPageTypeName = "4deepak", UiControlTypeId = 78, UiControlTypeName = "jj4f", IsRequired = true, UiControlDisplayName = "jk7f", DataTypeId = 7, DataTypeName = "d7dd", LookupCategoryId = 45, LookupCategoryName = "k4ji", ControlCategoryName = "jmif", ControlCategoryId = 46, UiControlCategoryTypeId = 44, UiControlCategoryTypeName = "ji4u", UiControlCategoryTypeTemplate = "4jio", ParentId = 43, ModuleId = 49, Position = 48, MultiValueControl = true, MetadataModuleBridgeUiControlDisplayName = "kj4i", Orders = 84 });


           
            _commonService = new SampleService(commonRepository.Object, igenericRepository.Object, iGenericRepositoryPageType.Object, genericRepositoryuipageData.Object, iGenericRepositoryPageMetaData.Object, iGenericRepositoryPageValidation.Object, uiPageMetadataCharacteristicsRepository.Object, uiPageMetadataRepository.Object, workflowActivityService.Object, webHostEnvironment.Object, uiPageMetadataCharacteristicsService.Object);

            //  var expectedFieldvalues = new List<UiPageDataDTO>();

            // commonRepository.Setup(x => x.GetUiPageMetadata(It.IsAny<int>())).Returns(new RecordModel { UiPageTypeId = 3, Id = 0, ModuleId=5, WorkflowStageId=5, Fields = uiPageMetaDataModels, FieldValues = null });
            commonRepository.Setup(x => x.GetUiPageMetadata(It.IsAny<int>())).Returns(uiPageMetaDataModels);
            commonRepository.Setup(x => x.GetPageIdBasedOnOrder(It.IsAny<int>())).Returns(0);
            commonRepository.Setup(x => x.GetPageIdBasedOnCurrentWorkflowStage(It.IsAny<int>())).Returns(0);

            var logger = new Mock<ILogger<CommonController>>();
            Mock<IGoogleDriveService> googleDriveService = new Mock<IGoogleDriveService>();
            Mock<IWorkflowStageService> workflowStageService = new Mock<IWorkflowStageService>();
            var controller = new CommonController(_googleDriveService, logger.Object, _commonService, _mapper, _workflowStageService);

            var createResult = (ViewResult)controller.Create(9);


            List<UiPageMetadataDTO> uiPageMetaDataDTO = new List<UiPageMetadataDTO>();
            //uiPageMetaDataDTO.Add(new UiPageMetadataDTO { Id = 3, Name = "aman", UiPageTypeId = 8, UiPageTypeName = "deepak", UiControlTypeId = 8, UiControlTypeName = "jjf", IsRequired = true, UiControlDisplayName = "jkf", DataTypeId = 7, DataTypeName = "ddd", LookupCategoryId = 5, LookupCategoryName = "kji", ControlCategoryName = "DataControl", ControlCategoryId = 6, UiControlCategoryTypeId = 4, UiControlCategoryTypeName = "DataControl", UiControlCategoryTypeTemplate = "jio", ParentId = 3, ModuleId = 9, Position = 8, MultiValueControl = true, MetadataModuleBridgeUiControlDisplayName = "kji", Orders = 8 });
           // uiPageMetaDataDTO.Add(new UiPageMetadataDTO { Id = 4, Name = "aman4", UiPageTypeId = 48, UiPageTypeName = "4deepak", UiControlTypeId = 78, UiControlTypeName = "jj4f", IsRequired = true, UiControlDisplayName = "jk7f", DataTypeId = 7, DataTypeName = "d7dd", LookupCategoryId = 45, LookupCategoryName = "k4ji", ControlCategoryName = "jmif", ControlCategoryId = 46, UiControlCategoryTypeId = 44, UiControlCategoryTypeName = "ji4u", UiControlCategoryTypeTemplate = "4jio", ParentId = 43, ModuleId = 49, Position = 48, MultiValueControl = true, MetadataModuleBridgeUiControlDisplayName = "kj4i", Orders = 84 });

            List<UiPageDataDTO> uipageDTO = new List<UiPageDataDTO>();
             IList<Web.UI.Models.ValidationMessage> validationMessage = new List<Web.UI.Models.ValidationMessage>();
             IEnumerable<Web.UI.Models.Node<LayoutDTO>> layoutDTO = new List<Web.UI.Models.Node<LayoutDTO>>();
            //List<LayoutModel> hirericheys = new List<LayoutModel>();

            var expectedResult = new RecordDTO { Id = 0, UiPageTypeId = 0, ModuleId = 9, WorkflowStageId = 0, Fields = uiPageMetaDataDTO, FieldValues = uipageDTO, Layout= layoutDTO, ErrorMessage= validationMessage };
            createResult.Model.Should().BeEquivalentTo(expectedResult);
        }

        /*
         * It is written to validate the Post Method Of Create
         * Step1 - Passing Parameter = It will pass the Record of RecordDTO
         * step2-  iGenericRepositoryPageValidation = It will return the validation Message List ,GetUiPageValidations= It will return the validations
         * expectedResult = It returns the record RecordDTO
         */
        [Test]
        public void Common_Create_PostMethod_Test()
        {
            List<UiPageDataDTO> uipagedata = new List<UiPageDataDTO>();
            uipagedata.Add(new UiPageDataDTO { RecordId = 0, UiPageMetadataId = 1, Value = "ritesh123", SubRecordId = 4, MultiValueControl = true, UiPageTypeId = 4 });
            // uipagedata.Add(new UiPageDataDTO { UiPageId = 0, UiPageMetadataId = 2, Value = "8709" });

            List<UiPageMetadataModel> uiPageMetaDataModels = new List<UiPageMetadataModel>();
            uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 3, Name = "aman", UiPageTypeId = 8, UiPageTypeName = "deepak", UiControlTypeId = 8, UiControlTypeName = "jjf", IsRequired = true, UiControlDisplayName = "jkf", DataTypeId = 7, DataTypeName = "ddd", LookupCategoryId = 5, LookupCategoryName = "kji", ControlCategoryName = "DataControl", ControlCategoryId = 6, UiControlCategoryTypeId = 4, UiControlCategoryTypeName = "DataControl", UiControlCategoryTypeTemplate = "jio", ParentId = 3, ModuleId = 9, Position = 8, MultiValueControl = true, MetadataModuleBridgeUiControlDisplayName = "kji", Orders = 8 });
           // uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 2, UiPageTypeId = 4, UiPageTypeName = null, UiControlTypeId = 33, UiControlTypeName = null, UiControlDisplayName = "mail", IsRequired = true, DataTypeId = 127, DataTypeName = "string" });


            //validation List
            iGenericRepositoryPageValidation.Setup(x => x.Get()).Returns(validationlist);
            commonRepository.Setup(x => x.GetUiPageValidations(It.IsAny<int>())).Returns(validations);

            commonRepository.Setup(x => x.GetPageIdBasedOnOrder(It.IsAny<int>())).Returns(0);
            commonRepository.Setup(x => x.GetPageIdBasedOnCurrentWorkflowStage(It.IsAny<int>())).Returns(0);
            commonRepository.Setup(x => x.GetUiPageMetadata(It.IsAny<int>())).Returns(uiPageMetaDataModels);

            foreach (var item in validationlist)
            {
                iGenericRepositoryPageValidation.Setup(x => x.Get(item.Id)).Returns(item);
            }


            var record = new RecordDTO { Id = 1, UiPageTypeId = 12, Fields = null, ModuleId = 5, WorkflowStageId = 0, FieldValues = uipagedata };
            var logger = new Mock<ILogger<CommonController>>();


            _commonService = new SampleService(commonRepository.Object, igenericRepository.Object, iGenericRepositoryPageType.Object, genericRepositoryuipageData.Object, iGenericRepositoryPageMetaData.Object, iGenericRepositoryPageValidation.Object, uiPageMetadataCharacteristicsRepository.Object, uiPageMetadataRepository.Object, workflowActivityService.Object, webHostEnvironment.Object, uiPageMetadataCharacteristicsService.Object);

            // _commonService = new SampleService(commonRepository.Object, igenericRepository.Object, iGenericRepositoryPageType.Object, genericRepositoryuipageData.Object, iGenericRepositoryPageMetaData.Object, iGenericRepositoryPageValidation.Object);
            var controller = new CommonController(_googleDriveService, logger.Object, _commonService, _mapper, _workflowStageService);



            // commonRepository.Setup(x => x.GetUiPageMetadata(It.IsAny<int>())).Returns(new RecordModel { UiPageTypeId = 12, Id = 1, Fields = uiPageMetaDataModels, FieldValues = null });
            commonRepository.Setup(x => x.GetUiPageMetadata(It.IsAny<int>())).Returns(uiPageMetaDataModels);



            foreach (var item in uiPageMetaDataModels)
            {
                iGenericRepositoryPageMetaData.Setup(x => x.Get(item.Id)).Returns(item);
            }

            var createResult = (OkObjectResult)controller.Create(record);
            var value = (RecordDTO)createResult.Value;

            var expectField = new List<UiPageDataDTO>();

            List<UiPageMetadataDTO> uiPageMetadataDTO = new List<UiPageMetadataDTO>();
            uiPageMetadataDTO.Add(new UiPageMetadataDTO { Id = 3, Name = "aman", UiPageTypeId = 8, UiPageTypeName = "deepak", UiControlTypeId = 8, UiControlTypeName = "jjf", IsRequired = true, UiControlDisplayName = "jkf", DataTypeId = 7, DataTypeName = "ddd", LookupCategoryId = 5, LookupCategoryName = "kji", ControlCategoryName = "DataControl", ControlCategoryId = 6, UiControlCategoryTypeId = 4, UiControlCategoryTypeName = "DataControl", UiControlCategoryTypeTemplate = "jio", ParentId = 3, ModuleId = 9, Position = 8, MultiValueControl = true, MetadataModuleBridgeUiControlDisplayName = "kji", Orders = 8 });
            // uiPageDTOFields.Add(new UiPageMetadataDTO { Id = 1, UiPageTypeId = 3, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "Password", IsRequired = false, DataTypeId = 12, DataTypeName = "string" });

            IList<Web.UI.Models.ValidationMessage> validationMessage = new List<Web.UI.Models.ValidationMessage>();
            IEnumerable<Web.UI.Models.Node<LayoutDTO>> layoutDTO = new List<Web.UI.Models.Node<LayoutDTO>>();

            var expectedResult = new RecordDTO { Id = 0, UiPageTypeId = 0, ModuleId = 5, WorkflowStageId = 0, Fields = uiPageMetadataDTO, FieldValues = expectField, Layout= layoutDTO , ErrorMessage = validationMessage };

            value.Should().BeEquivalentTo(expectedResult);


        }

        // <summary>
        // Wrong Password and Wrong Mail
        // </summary>
        //*
        // * Description: This test is to validate the wrong Password with the validation message
        // * step1- Passing parameter = Record of RecordDTO   
        // * Expected Result : Record Model with Error Message 
        // */
        //[Test]
        //public void Common_Create_Wrong_Pass_Test()
        //{
        //    List<UiPageDataDTO> uipagedata = new List<UiPageDataDTO>();
        //    uipagedata.Add(new UiPageDataDTO { UiPageId = 0, UiPageMetadataId = 1, Value = "Rit" });


        //    List<UiPageMetadataModel> uiPageMetaDataModels = new List<UiPageMetadataModel>();
        //    uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 3, UiPageTypeId = 1, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "Password", IsRequired = false, DataTypeId = 12, DataTypeName = "string" });


        //    //validation List
        //    iGenericRepositoryPageValidation.Setup(x => x.Get()).Returns(validationlist);
        //    commonRepository.Setup(x => x.GetUiPageValidations(It.IsAny<int>())).Returns(validations);

        //    foreach (var item in validationlist)
        //    {
        //        iGenericRepositoryPageValidation.Setup(x => x.Get(item.Id)).Returns(item);
        //    }


        //    var record = new RecordDTO { Id = 1, UiPageId = 12, Fields = null, FieldValues = uipagedata };
        //    var logger = new Mock<ILogger<CommonController>>();

        //    _commonService = new SampleService(commonRepository.Object, igenericRepository.Object, iGenericRepositoryPageType.Object, genericRepositoryuipageData.Object, iGenericRepositoryPageMetaData.Object, iGenericRepositoryPageValidation.Object);
        //    var controller = new CommonController(logger.Object, _commonService, _mapper);



        //    commonRepository.Setup(x => x.GetUiPageMetadata(It.IsAny<int>())).Returns(new RecordModel { UiPageId = 12, Id = 1, Fields = uiPageMetaDataModels, FieldValues = null });


        //    foreach (var item in uiPageMetaDataModels)
        //    {
        //        iGenericRepositoryPageMetaData.Setup(x => x.Get(item.Id)).Returns(item);
        //    }

        //    var createResult = (BadRequestObjectResult)controller.Create(record);

        //    var value = (RecordDTO)createResult.Value;

        //    var expectField = new List<UiPageDataDTO>();

        //    List<UiPageMetadataDTO> uiPageDTOFields = new List<UiPageMetadataDTO>();
        //    uiPageDTOFields.Add(new UiPageMetadataDTO { Id = 5, UiPageTypeId = 1, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "Password", IsRequired = false, DataTypeId = 12, DataTypeName = "string" });

        //    ValidationMessage error_message = new ValidationMessage();
        //    error_message.Reason = "Minimum Password length  is 8";
        //    error_message.SourceId = 1;
        //    error_message.Severity = ValidationSeverity.Error;
        //    error_message.MessageKey = null;
        //    error_message.Description = null;


        //    var expectedResult = new RecordDTO { Id = 1, UiPageId = 12, Fields = uiPageDTOFields, FieldValues = expectField, ErrorMessage = error_message };

        //    value.ErrorMessage.Should().BeEquivalentTo(expectedResult.ErrorMessage);
        //}

        ///*
        // * Description: This is to validate the Mail with Wrong Email value
        // * Steps- Passing Parameter = Record Of RecordDTO will be passed
        // * Expected Value = RecordModel with an Error Message 
        // */
        //[Test]
        //public void Common_Create_Wrong_Mail_Test()
        //{
        //    List<UiPageDataDTO> uipagedata = new List<UiPageDataDTO>();
        //    uipagedata.Add(new UiPageDataDTO { UiPageId = 0, UiPageMetadataId = 2, Value = "21" });

        //    List<UiPageMetadataModel> uiPageMetaDataModels = new List<UiPageMetadataModel>();
        //    uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 4, UiPageTypeId = 2, UiPageTypeName = null, UiControlTypeId = 33, UiControlTypeName = null, UiControlDisplayName = "mail", IsRequired = true, DataTypeId = 127, DataTypeName = "string" });


        //    //validation List
        //    iGenericRepositoryPageValidation.Setup(x => x.Get()).Returns(validationlist);
        //    commonRepository.Setup(x => x.GetUiPageValidations(It.IsAny<int>())).Returns(validations);

        //    foreach (var item in validationlist)
        //    {
        //        iGenericRepositoryPageValidation.Setup(x => x.Get(item.Id)).Returns(item);
        //    }


        //    var record = new RecordDTO { Id = 1, UiPageId = 12, Fields = null, FieldValues = uipagedata };
        //    var logger = new Mock<ILogger<CommonController>>();

        //    _commonService = new SampleService(commonRepository.Object, igenericRepository.Object, iGenericRepositoryPageType.Object, genericRepositoryuipageData.Object, iGenericRepositoryPageMetaData.Object, iGenericRepositoryPageValidation.Object);
        //    var controller = new CommonController(logger.Object, _commonService, _mapper);



        //    commonRepository.Setup(x => x.GetUiPageMetadata(It.IsAny<int>())).Returns(new RecordModel { UiPageId = 12, Id = 1, Fields = uiPageMetaDataModels, FieldValues = null });



        //    foreach (var item in uiPageMetaDataModels)
        //    {
        //        iGenericRepositoryPageMetaData.Setup(x => x.Get(item.Id)).Returns(item);
        //    }

        //    var createResult = (BadRequestObjectResult)controller.Create(record);

        //    var value = (RecordDTO)createResult.Value;

        //    var expectField = new List<UiPageDataDTO>();

        //    List<UiPageMetadataDTO> uiPageDTOFields = new List<UiPageMetadataDTO>();
        //    uiPageDTOFields.Add(new UiPageMetadataDTO { Id = 6, UiPageTypeId = 4, UiPageTypeName = null, UiControlTypeId = 33, UiControlTypeName = null, UiControlDisplayName = "mail", IsRequired = true, DataTypeId = 127, DataTypeName = "string" });

        //    ValidationMessage error_message = new ValidationMessage();
        //    error_message.Reason = "Email should have format";
        //    error_message.SourceId = 2;
        //    error_message.Severity = ValidationSeverity.Error;
        //    error_message.MessageKey = null;
        //    error_message.Description = null;

        //    var expectedResult = new RecordDTO { Id = 1, UiPageId = 12, Fields = uiPageDTOFields, FieldValues = expectField, ErrorMessage = error_message };

        //    value.ErrorMessage.Should().BeEquivalentTo(expectedResult.ErrorMessage);
        //}

        ///*
        // * Description: To validate the Adhar Detail from validations in Create Post Method 
        // * Step - Passing Parameter =  Record of RecordDTO Model 
        // * Expected Result = It will Return the record of RecordDTO
        // */
        //[Test]
        //public void Common_Create_Post_Correct_Adhar_Test()
        //{
        //    List<UiPageDataDTO> uipagedata = new List<UiPageDataDTO>();
        //    uipagedata.Add(new UiPageDataDTO { UiPageId = 0, UiPageMetadataId = 3, Value = "641568763619" });


        //    List<UiPageMetadataModel> uiPageMetaDataModels = new List<UiPageMetadataModel>();
        //    uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 3, UiPageTypeId = 3, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "AdharNo", IsRequired = false, DataTypeId = 12, DataTypeName = "varchar(12)" });


        //    //validation List
        //    iGenericRepositoryPageValidation.Setup(x => x.Get()).Returns(validationlist);
        //    commonRepository.Setup(x => x.GetUiPageValidations(It.IsAny<int>())).Returns(validations);

        //    foreach (var item in validationlist)
        //    {
        //        iGenericRepositoryPageValidation.Setup(x => x.Get(item.Id)).Returns(item);
        //    }


        //    var record = new RecordDTO { Id = 1, UiPageId = 12, Fields = null, FieldValues = uipagedata };
        //    var logger = new Mock<ILogger<CommonController>>();

        //    _commonService = new SampleService(commonRepository.Object, igenericRepository.Object, iGenericRepositoryPageType.Object, genericRepositoryuipageData.Object, iGenericRepositoryPageMetaData.Object, iGenericRepositoryPageValidation.Object);
        //    var controller = new CommonController(logger.Object, _commonService, _mapper);

        //    commonRepository.Setup(x => x.GetUiPageMetadata(It.IsAny<int>())).Returns(new RecordModel { UiPageId = 12, Id = 1, Fields = uiPageMetaDataModels, FieldValues = null });



        //    foreach (var item in uiPageMetaDataModels)
        //    {
        //        iGenericRepositoryPageMetaData.Setup(x => x.Get(item.Id)).Returns(item);
        //    }

        //    var createResult = (OkObjectResult)controller.Create(record);

        //    var value = (RecordDTO)createResult.Value;

        //    var expectField = new List<UiPageDataDTO>();

        //    List<UiPageMetadataDTO> uiPageDTOFields = new List<UiPageMetadataDTO>();
        //    uiPageDTOFields.Add(new UiPageMetadataDTO { Id = 3, UiPageTypeId = 3, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "AdharNo", IsRequired = false, DataTypeId = 12, DataTypeName = "varchar(12)" });

        //    var expectedResult = new RecordDTO { Id = 1, UiPageId = 12, Fields = uiPageDTOFields, FieldValues = expectField };

        //    value.Should().BeEquivalentTo(expectedResult);
        //}

        ///*
        // * Description: This method is to validate the Mobile No 
        // * step1- Passing Parameter = Record of RecordDTO model 
        // *  Expected Result = It will return the record of RecordDTO
        // */
        //[Test]
        //public void Common_Create_Post_Correct_Mobile_Test()
        //{
        //    List<UiPageDataDTO> uipagedata = new List<UiPageDataDTO>();
        //    uipagedata.Add(new UiPageDataDTO { UiPageId = 0, UiPageMetadataId = 4, Value = "8709282126" });

        //    List<UiPageMetadataModel> uiPageMetaDataModels = new List<UiPageMetadataModel>();
        //    uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 4, UiPageTypeId = 4, UiPageTypeName = null, UiControlTypeId = 33, UiControlTypeName = null, UiControlDisplayName = "MobileNo", IsRequired = true, DataTypeId = 127, DataTypeName = "varchar(10)" });

        //    //validation List
        //    iGenericRepositoryPageValidation.Setup(x => x.Get()).Returns(validationlist);
        //    commonRepository.Setup(x => x.GetUiPageValidations(It.IsAny<int>())).Returns(validations);

        //    foreach (var item in validationlist)
        //    {
        //        iGenericRepositoryPageValidation.Setup(x => x.Get(item.Id)).Returns(item);
        //    }

        //    var record = new RecordDTO { Id = 1, UiPageId = 12, Fields = null, FieldValues = uipagedata };
        //    var logger = new Mock<ILogger<CommonController>>();

        //    _commonService = new SampleService(commonRepository.Object, igenericRepository.Object, iGenericRepositoryPageType.Object, genericRepositoryuipageData.Object, iGenericRepositoryPageMetaData.Object, iGenericRepositoryPageValidation.Object);
        //    var controller = new CommonController(logger.Object, _commonService, _mapper);


        //    commonRepository.Setup(x => x.GetUiPageMetadata(It.IsAny<int>())).Returns(new RecordModel { UiPageId = 12, Id = 1, Fields = uiPageMetaDataModels, FieldValues = null });



        //    foreach (var item in uiPageMetaDataModels)
        //    {
        //        iGenericRepositoryPageMetaData.Setup(x => x.Get(item.Id)).Returns(item);
        //    }

        //    var createResult = (OkObjectResult)controller.Create(record);

        //    var value = (RecordDTO)createResult.Value;

        //    var expectField = new List<UiPageDataDTO>();

        //    List<UiPageMetadataDTO> uiPageDTOFields = new List<UiPageMetadataDTO>();
        //    uiPageDTOFields.Add(new UiPageMetadataDTO { Id = 4, UiPageTypeId = 4, UiPageTypeName = null, UiControlTypeId = 33, UiControlTypeName = null, UiControlDisplayName = "MobileNo", IsRequired = true, DataTypeId = 127, DataTypeName = "varchar(10)" });

        //    var expectedResult = new RecordDTO { Id = 1, UiPageId = 12, Fields = uiPageDTOFields, FieldValues = expectField };

        //    value.Should().BeEquivalentTo(expectedResult);
        //}

        ///// <summary>
        ///// Wrong AAdhar and Mobile 
        ///// </summary>
        // /*
        //  * Description: This method is to validate the Adhar validation Message with wrong adhar Detail
        //  * step1- Passing Parameter = Record of RecordModel 
        //  * ExpectedResult = Record of RecordDTO with Error Message          
        //  */

        //[Test]
        //public void Common_Create_Post_ADhar_Mob_Test()
        //{
        //    List<UiPageDataDTO> uipagedata = new List<UiPageDataDTO>();
        //    //For AAdhar
        //    uipagedata.Add(new UiPageDataDTO { UiPageId = 0, UiPageMetadataId = 3, Value = "64156876361" });

        //    List<UiPageMetadataModel> uiPageMetaDataModels = new List<UiPageMetadataModel>();
        //    uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 3, UiPageTypeId = 3, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "AdharNo", IsRequired = false, DataTypeId = 12, DataTypeName = "varchar(12)" });

        //    //validation List
        //    iGenericRepositoryPageValidation.Setup(x => x.Get()).Returns(validationlist);
        //    commonRepository.Setup(x => x.GetUiPageValidations(It.IsAny<int>())).Returns(validations);

        //    foreach (var item in validationlist)
        //    {
        //        iGenericRepositoryPageValidation.Setup(x => x.Get(item.Id)).Returns(item);
        //    }


        //    var record = new RecordDTO { Id = 1, UiPageId = 12, Fields = null, FieldValues = uipagedata };
        //    var logger = new Mock<ILogger<CommonController>>();

        //    _commonService = new SampleService(commonRepository.Object, igenericRepository.Object, iGenericRepositoryPageType.Object, genericRepositoryuipageData.Object, iGenericRepositoryPageMetaData.Object, iGenericRepositoryPageValidation.Object);
        //    var controller = new CommonController(logger.Object, _commonService, _mapper);



        //    commonRepository.Setup(x => x.GetUiPageMetadata(It.IsAny<int>())).Returns(new RecordModel { UiPageId = 12, Id = 1, Fields = uiPageMetaDataModels, FieldValues = null });



        //    foreach (var item in uiPageMetaDataModels)
        //    {
        //        iGenericRepositoryPageMetaData.Setup(x => x.Get(item.Id)).Returns(item);
        //    }

        //    var createResult = (BadRequestObjectResult)controller.Create(record);

        //    var value = (RecordDTO)createResult.Value;

        //    var expectField = new List<UiPageDataDTO>();
        //    ValidationMessage error = new ValidationMessage();
        //    error.Reason = "Aadhar length should be equal to 12";
        //    error.SourceId = 3;
        //    error.Severity = ValidationSeverity.Error;
        //    error.MessageKey = null;
        //    error.Description = null;


        //    List<UiPageMetadataDTO> uiPageDTOFields = new List<UiPageMetadataDTO>();
        //    uiPageDTOFields.Add(new UiPageMetadataDTO { Id = 3, UiPageTypeId = 3, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "AdharNo", IsRequired = false, DataTypeId = 12, DataTypeName = "varchar(12)" });

        //    var expectedResult = new RecordDTO { Id = 1, UiPageId = 12, Fields = uiPageDTOFields, FieldValues = expectField, ErrorMessage = error };

        //    value.ErrorMessage.Should().BeEquivalentTo(expectedResult.ErrorMessage);


        //}
        ///*
        // *  This test is to validate the Wrong Mobile No For validation
        // *  step1- Passing Parameter = Record with wrong Mobile No , GetUiPageMetadata method = It will return the RecordModel 
        // *  Expected Result = It will return the record recordDTO 
        // */

        //[Test]
        //public void Common_Create_Post_Mob_Test()
        //{
        //    List<UiPageDataDTO> uipagedata = new List<UiPageDataDTO>();

        //    //for MobileNo
        //    uipagedata.Add(new UiPageDataDTO { UiPageId = 0, UiPageMetadataId = 4, Value = "8709282" });

        //    List<UiPageMetadataModel> uiPageMetaDataModels = new List<UiPageMetadataModel>();
        //    uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 4, UiPageTypeId = 4, UiPageTypeName = null, UiControlTypeId = 33, UiControlTypeName = null, UiControlDisplayName = "MobileNo", IsRequired = true, DataTypeId = 127, DataTypeName = "varchar(10)" });


        //    //validation List
        //    iGenericRepositoryPageValidation.Setup(x => x.Get()).Returns(validationlist);
        //    commonRepository.Setup(x => x.GetUiPageValidations(It.IsAny<int>())).Returns(validations);

        //    foreach (var item in validationlist)
        //    {
        //        iGenericRepositoryPageValidation.Setup(x => x.Get(item.Id)).Returns(item);
        //    }


        //    var record = new RecordDTO { Id = 1, UiPageId = 12, Fields = null, FieldValues = uipagedata };
        //    var logger = new Mock<ILogger<CommonController>>();

        //    _commonService = new SampleService(commonRepository.Object, igenericRepository.Object, iGenericRepositoryPageType.Object, genericRepositoryuipageData.Object, iGenericRepositoryPageMetaData.Object, iGenericRepositoryPageValidation.Object);
        //    var controller = new CommonController(logger.Object, _commonService, _mapper);



        //    commonRepository.Setup(x => x.GetUiPageMetadata(It.IsAny<int>())).Returns(new RecordModel { UiPageId = 12, Id = 1, Fields = uiPageMetaDataModels, FieldValues = null });



        //    foreach (var item in uiPageMetaDataModels)
        //    {
        //        iGenericRepositoryPageMetaData.Setup(x => x.Get(item.Id)).Returns(item);
        //    }

        //    var createResult = (BadRequestObjectResult)controller.Create(record);

        //    var value = (RecordDTO)createResult.Value;

        //    var expectField = new List<UiPageDataDTO>();

        //    List<UiPageMetadataDTO> uiPageDTOFields = new List<UiPageMetadataDTO>();
        //    uiPageDTOFields.Add(new UiPageMetadataDTO { Id = 4, UiPageTypeId = 4, UiPageTypeName = null, UiControlTypeId = 33, UiControlTypeName = null, UiControlDisplayName = "MobileNo", IsRequired = true, DataTypeId = 127, DataTypeName = "varchar(10)" });

        //    ValidationMessage error_message = new ValidationMessage();
        //    error_message.Reason = "Mobile No length eq to 10";
        //    error_message.SourceId = 4;
        //    error_message.Severity = ValidationSeverity.Error;
        //    error_message.MessageKey = null;
        //    error_message.Description = null;

        //    var expectedResult = new RecordDTO { Id = 1, UiPageId = 12, Fields = uiPageDTOFields, FieldValues = expectField, ErrorMessage = error_message };

        //    value.ErrorMessage.Should().BeEquivalentTo(expectedResult.ErrorMessage);


        //}
        ///// <summary>
        ///// Correct Year
        ///// </summary>
        //[Test]
        //public void Common_Create_Post_Correct_year_Test()
        //{
        //    List<UiPageDataDTO> uipagedata = new List<UiPageDataDTO>();
        //    //For Year
        //    uipagedata.Add(new UiPageDataDTO { UiPageId = 0, UiPageMetadataId = 5, Value = "2012" });

        //    List<UiPageMetadataModel> uiPageMetaDataModels = new List<UiPageMetadataModel>();
        //    uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 5, UiPageTypeId = 3, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "Year", IsRequired = false, DataTypeId = 12, DataTypeName = "int" });


        //    //validation List
        //    iGenericRepositoryPageValidation.Setup(x => x.Get()).Returns(validationlist);
        //    commonRepository.Setup(x => x.GetUiPageValidations(It.IsAny<int>())).Returns(validations);

        //    foreach (var item in validationlist)
        //    {
        //        iGenericRepositoryPageValidation.Setup(x => x.Get(item.Id)).Returns(item);
        //    }


        //    var record = new RecordDTO { Id = 1, UiPageId = 12, Fields = null, FieldValues = uipagedata };
        //    var logger = new Mock<ILogger<CommonController>>();

        //    _commonService = new SampleService(commonRepository.Object, igenericRepository.Object, iGenericRepositoryPageType.Object, genericRepositoryuipageData.Object, iGenericRepositoryPageMetaData.Object, iGenericRepositoryPageValidation.Object);
        //    var controller = new CommonController(logger.Object, _commonService, _mapper);



        //    commonRepository.Setup(x => x.GetUiPageMetadata(It.IsAny<int>())).Returns(new RecordModel { UiPageId = 12, Id = 1, Fields = uiPageMetaDataModels, FieldValues = null });



        //    foreach (var item in uiPageMetaDataModels)
        //    {
        //        iGenericRepositoryPageMetaData.Setup(x => x.Get(item.Id)).Returns(item);
        //    }

        //    var createResult = (OkObjectResult)controller.Create(record);

        //    var value = (RecordDTO)createResult.Value;

        //    var expectField = new List<UiPageDataDTO>();

        //    List<UiPageMetadataDTO> uiPageDTOFields = new List<UiPageMetadataDTO>();
        //    uiPageDTOFields.Add(new UiPageMetadataDTO { Id = 5, UiPageTypeId = 3, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "Year", IsRequired = false, DataTypeId = 12, DataTypeName = "int" });

        //    var expectedResult = new RecordDTO { Id = 1, UiPageId = 12, Fields = uiPageDTOFields, FieldValues = expectField };

        //    value.Should().BeEquivalentTo(expectedResult);
        //}

        ///*
        // * Description: This method is to validate the Create Method for Passing Wrong Value of Year 
        // * step- Passing Parameter= Record of recordDTO
        // * ExpectedResult = Record of RecordDTO with Error Message
        // */
        //[Test]
        //public void Common_Create_Post_Wrong_year_Test()
        //{
        //    List<UiPageDataDTO> uipagedata = new List<UiPageDataDTO>();
        //    //For Year
        //    uipagedata.Add(new UiPageDataDTO { UiPageId = 0, UiPageMetadataId = 5, Value = "201" });

        //    List<UiPageMetadataModel> uiPageMetaDataModels = new List<UiPageMetadataModel>();
        //    uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 5, UiPageTypeId = 5, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "Year", IsRequired = false, DataTypeId = 12, DataTypeName = "int" });


        //    //validation List
        //    iGenericRepositoryPageValidation.Setup(x => x.Get()).Returns(validationlist);
        //    commonRepository.Setup(x => x.GetUiPageValidations(It.IsAny<int>())).Returns(validations);

        //    foreach (var item in validationlist)
        //    {
        //        iGenericRepositoryPageValidation.Setup(x => x.Get(item.Id)).Returns(item);
        //    }


        //    var record = new RecordDTO { Id = 1, UiPageId = 12, Fields = null, FieldValues = uipagedata };
        //    var logger = new Mock<ILogger<CommonController>>();

        //    _commonService = new SampleService(commonRepository.Object, igenericRepository.Object, iGenericRepositoryPageType.Object, genericRepositoryuipageData.Object, iGenericRepositoryPageMetaData.Object, iGenericRepositoryPageValidation.Object);
        //    var controller = new CommonController(logger.Object, _commonService, _mapper);



        //    commonRepository.Setup(x => x.GetUiPageMetadata(It.IsAny<int>())).Returns(new RecordModel { UiPageId = 12, Id = 1, Fields = uiPageMetaDataModels, FieldValues = null });



        //    foreach (var item in uiPageMetaDataModels)
        //    {
        //        iGenericRepositoryPageMetaData.Setup(x => x.Get(item.Id)).Returns(item);
        //    }

        //    var createResult = (BadRequestObjectResult)controller.Create(record);

        //    var value = (RecordDTO)createResult.Value;

        //    ValidationMessage error_message = new ValidationMessage();
        //    error_message.Reason = "Year length eq to 4 ";
        //    error_message.SourceId = 5;
        //    error_message.Severity = ValidationSeverity.Error;
        //    error_message.MessageKey = null;
        //    error_message.Description = null;

        //    var expectField = new List<UiPageDataDTO>();

        //    List<UiPageMetadataDTO> uiPageDTOFields = new List<UiPageMetadataDTO>();
        //    uiPageDTOFields.Add(new UiPageMetadataDTO { Id = 5, UiPageTypeId = 3, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "Year", IsRequired = false, DataTypeId = 12, DataTypeName = "int" });

        //    var expectedResult = new RecordDTO { Id = 1, UiPageId = 12, Fields = uiPageDTOFields, FieldValues = expectField };

        //    value.Should().NotBeEquivalentTo(expectedResult);
        //}


        ///* Description
        // * IgenericRepository = It is returning a Record model base on the UipageId
        // * Expected = This is returning a recordDTO model 
        //  */
        //[Test]
        //public void Common_Edit_Get_Test()
        //{
        //    List<UiPageMetadataModel> uiPageMetaDataModels = new List<UiPageMetadataModel>();
        //    uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 5, UiPageTypeId = 10, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "Year", IsRequired = false, DataTypeId = 12, DataTypeName = "int" });

        //    List<UiPageDataModel> uiPageDataModels = new List<UiPageDataModel>();

        //    uiPageDataModels.Add(new UiPageDataModel { Id = 3, UiPageId = 10, RecordId = 14, UiPageMetadataId = 4, Value = "Ritesh1244" });
        //    uiPageDataModels.Add(new UiPageDataModel { Id = 5, UiPageId = 10, RecordId = 14, UiPageMetadataId = 5, Value = "Ritesh44" });


        //    igenericRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new RecordModel { Id = 12, UiPageId = 10, Fields = null, FieldValues = null });
        //    commonRepository.Setup(x => x.GetUiPageMetadata(It.IsAny<int>())).Returns(new RecordModel { Id = 0, UiPageId = 10, Fields = uiPageMetaDataModels, FieldValues = null });


        //    genericRepositoryuipageData.Setup(x => x.Get<int>("RecordId", It.IsAny<int>())).Returns(uiPageDataModels);


        //    var logger = new Mock<ILogger<CommonController>>();

        //    _commonService = new SampleService(commonRepository.Object, igenericRepository.Object, iGenericRepositoryPageType.Object, genericRepositoryuipageData.Object, iGenericRepositoryPageMetaData.Object, iGenericRepositoryPageValidation.Object);
        //    var controller = new CommonController(logger.Object, _commonService, _mapper);

        //    var result = (ViewResult)controller.Edit(12);

        //    List<UiPageMetadataDTO> uiPageMetadataDTO = new List<UiPageMetadataDTO>();
        //    uiPageMetadataDTO.Add(new UiPageMetadataDTO { Id = 5, UiPageTypeId = 10, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "Year", IsRequired = false, DataTypeId = 12, DataTypeName = "int" });

        //    List<UiPageDataDTO> uiPageDTO = new List<UiPageDataDTO>();
        //    uiPageDTO.Add(new UiPageDataDTO { UiPageId = 10, UiPageMetadataId = 4, Value = "Ritesh1244" });
        //    uiPageDTO.Add(new UiPageDataDTO { UiPageId = 10, UiPageMetadataId = 5, Value = "Ritesh44" });

        //    var expectedResult = new RecordDTO { Id = 12, UiPageId = 10, Fields = uiPageMetadataDTO, FieldValues = uiPageDTO };

        //    result.Model.Should().BeEquivalentTo(expectedResult);
        //}

        ///*
        // * Description: This method is to validate the post method With valid Record
        // * step1- Passing Parameter = Record of recordDTO 
        // * ExpectedResult = Record of RecordDTO
        // */
        //[Test]
        //public void common_Edit_POST_True_Test()
        //{
        //    List<UiPageDataDTO> uipagedata = new List<UiPageDataDTO>();
        //    uipagedata.Add(new UiPageDataDTO { UiPageId = 0, UiPageMetadataId = 1, Value = "ritesh1267" });
        //    uipagedata.Add(new UiPageDataDTO { UiPageId = 0, UiPageMetadataId = 2, Value = "8709" });

        //    List<UiPageMetadataModel> uiPageMetaDataModels = new List<UiPageMetadataModel>();
        //    uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 1, UiPageTypeId = 3, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "Password", IsRequired = false, DataTypeId = 12, DataTypeName = "string" });
        //    uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 2, UiPageTypeId = 4, UiPageTypeName = null, UiControlTypeId = 33, UiControlTypeName = null, UiControlDisplayName = "mail", IsRequired = true, DataTypeId = 127, DataTypeName = "string" });


        //    List<UiPageDataModel> uiPageDataModels = new List<UiPageDataModel>();
        //    uiPageDataModels.Add(new UiPageDataModel { Id = 13, UiPageId = 12, RecordId = 5, UiPageMetadataId = 1, Value = "Ritesh1244" });
        //    uiPageDataModels.Add(new UiPageDataModel { Id = 5, UiPageId = 12, RecordId = 5, UiPageMetadataId = 2, Value = "Ritesh44" });
        //    genericRepositoryuipageData.Setup(x => x.Get<int>("RecordId", It.IsAny<int>())).Returns(uiPageDataModels);


        //    //validation List

        //    iGenericRepositoryPageValidation.Setup(x => x.Get()).Returns(validationlist);
        //    commonRepository.Setup(x => x.GetUiPageValidations(It.IsAny<int>())).Returns(validations);
        //    igenericRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new RecordModel { Id = 12, UiPageId = 10, Fields = null, FieldValues = null });

        //    foreach (var item in validationlist)
        //    {
        //        iGenericRepositoryPageValidation.Setup(x => x.Get(item.Id)).Returns(item);
        //    }
        //    foreach (var item in uiPageMetaDataModels)
        //    {
        //        iGenericRepositoryPageMetaData.Setup(x => x.Get(item.Id)).Returns(item);
        //    }

        //    List<UiPageMetadataDTO> uiPageMetadataDTO = new List<UiPageMetadataDTO>();
        //    var record = new RecordDTO { Id = 5, UiPageId = 12, Fields = uiPageMetadataDTO, FieldValues = uipagedata };
        //    var logger = new Mock<ILogger<CommonController>>();

        //    _commonService = new SampleService(commonRepository.Object, igenericRepository.Object, iGenericRepositoryPageType.Object, genericRepositoryuipageData.Object, iGenericRepositoryPageMetaData.Object, iGenericRepositoryPageValidation.Object);
        //    var controller = new CommonController(logger.Object, _commonService, _mapper);


        //    commonRepository.Setup(x => x.GetUiPageMetadata(It.IsAny<int>())).Returns(new RecordModel { UiPageId = 12, Id = 1, Fields = uiPageMetaDataModels, FieldValues = null });



        //    var createResult = (OkObjectResult)controller.Edit(record);
        //    var value = (RecordDTO)createResult.Value;

        //    List<UiPageDataDTO> expectField = new List<UiPageDataDTO>();
        //    expectField.Add(new UiPageDataDTO { UiPageId = 12, UiPageMetadataId = 1, Value = "ritesh1267" });
        //    expectField.Add(new UiPageDataDTO { UiPageId = 12, UiPageMetadataId = 2, Value = "8709" });

        //    List<UiPageMetadataDTO> uiPageDTOFields = new List<UiPageMetadataDTO>();
        //    uiPageDTOFields.Add(new UiPageMetadataDTO { Id = 2, UiPageTypeId = 4, UiPageTypeName = null, UiControlTypeId = 33, UiControlTypeName = null, UiControlDisplayName = "mail", IsRequired = true, DataTypeId = 127, DataTypeName = "string" });
        //    uiPageDTOFields.Add(new UiPageMetadataDTO { Id = 1, UiPageTypeId = 3, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "Password", IsRequired = false, DataTypeId = 12, DataTypeName = "string" });

        //    var expectedResult = new RecordDTO { Id = 5, UiPageId = 10, Fields = uiPageDTOFields, FieldValues = expectField };

        //    value.Should().BeEquivalentTo(expectedResult);
        //}


        ///* 
        // * Description: This method is to validate the Record with validation and the existing value 
        // * step - passing parameter = Record of RecordDTO 
        // * ExpectedResult = RecordDTO record with error Message 
        //*/
        //[Test]
        //public void Common_controller_EDIT_POSt_Wrong_value_Test()
        //{
        //    List<UiPageDataDTO> uipagedata = new List<UiPageDataDTO>();
        //    uipagedata.Add(new UiPageDataDTO { UiPageId = 0, UiPageMetadataId = 1, Value = "rites" });
        //    uipagedata.Add(new UiPageDataDTO { UiPageId = 0, UiPageMetadataId = 2, Value = "87" });

        //    List<UiPageMetadataModel> uiPageMetaDataModels = new List<UiPageMetadataModel>();
        //    uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 1, UiPageTypeId = 3, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "Password", IsRequired = false, DataTypeId = 12, DataTypeName = "string" });
        //    uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 2, UiPageTypeId = 4, UiPageTypeName = null, UiControlTypeId = 33, UiControlTypeName = null, UiControlDisplayName = "mail", IsRequired = true, DataTypeId = 127, DataTypeName = "string" });


        //    List<UiPageDataModel> uiPageDataModels = new List<UiPageDataModel>();
        //    uiPageDataModels.Add(new UiPageDataModel { Id = 13, UiPageId = 12, RecordId = 5, UiPageMetadataId = 1, Value = "Ritesh1244" });
        //    uiPageDataModels.Add(new UiPageDataModel { Id = 5, UiPageId = 12, RecordId = 5, UiPageMetadataId = 2, Value = "Ritesh44" });

        //    genericRepositoryuipageData.Setup(x => x.Get<int>("RecordId", It.IsAny<int>())).Returns(uiPageDataModels);
        //    iGenericRepositoryPageValidation.Setup(x => x.Get()).Returns(validationlist);
        //    commonRepository.Setup(x => x.GetUiPageValidations(It.IsAny<int>())).Returns(validations);
        //    igenericRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new RecordModel { Id = 12, UiPageId = 10, Fields = null, FieldValues = null });



        //    foreach (var item in validationlist)
        //    {
        //        iGenericRepositoryPageValidation.Setup(x => x.Get(item.Id)).Returns(item);
        //    }
        //    foreach (var item in uiPageMetaDataModels)
        //    {
        //        iGenericRepositoryPageMetaData.Setup(x => x.Get(item.Id)).Returns(item);
        //    }

        //    List<UiPageMetadataDTO> uiPageMetadataDTO = new List<UiPageMetadataDTO>();
        //    var record = new RecordDTO { Id = 5, UiPageId = 12, Fields = uiPageMetadataDTO, FieldValues = uipagedata };
        //    var logger = new Mock<ILogger<CommonController>>();

        //    _commonService = new SampleService(commonRepository.Object, igenericRepository.Object, iGenericRepositoryPageType.Object, genericRepositoryuipageData.Object, iGenericRepositoryPageMetaData.Object, iGenericRepositoryPageValidation.Object);
        //    var controller = new CommonController(logger.Object, _commonService, _mapper);


        //    commonRepository.Setup(x => x.GetUiPageMetadata(It.IsAny<int>())).Returns(new RecordModel { UiPageId = 12, Id = 1, Fields = uiPageMetaDataModels, FieldValues = null });



        //    var createResult = (BadRequestObjectResult)controller.Edit(record);
        //    var value = (RecordDTO)createResult.Value;

        //    List<UiPageDataDTO> expectField = new List<UiPageDataDTO>();
        //    expectField.Add(new UiPageDataDTO { UiPageId = 0, UiPageMetadataId = 1, Value = "rites" });
        //    expectField.Add(new UiPageDataDTO { UiPageId = 0, UiPageMetadataId = 2, Value = "87" });

        //    List<UiPageMetadataDTO> uiPageDTOFields = new List<UiPageMetadataDTO>();
        //    uiPageDTOFields.Add(new UiPageMetadataDTO { Id = 2, UiPageTypeId = 4, UiPageTypeName = null, UiControlTypeId = 33, UiControlTypeName = null, UiControlDisplayName = "mail", IsRequired = true, DataTypeId = 127, DataTypeName = "string" });
        //    uiPageDTOFields.Add(new UiPageMetadataDTO { Id = 1, UiPageTypeId = 3, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "Password", IsRequired = false, DataTypeId = 12, DataTypeName = "string" });

        //    var expectedResult = new RecordDTO { Id = 5, UiPageId = 10, Fields = uiPageDTOFields, FieldValues = expectField };

        //    value.Should().NotBeEquivalentTo(expectedResult);

        //}



        ///*
        // * Description: This Delete Get method is to get the Record of the Passed Id 
        // * step- Passing Parameter = Id 
        // * ExpectedResult = It will return the record of RecordDTO
        // * 
        // */
        //[Test]
        //public void common_Delete_Test()
        //{
        //    List<UiPageMetadataModel> uiPageMetaDataModels = new List<UiPageMetadataModel>();
        //    uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 5, UiPageTypeId = 10, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "Year", IsRequired = false, DataTypeId = 12, DataTypeName = "int" });

        //    List<UiPageDataModel> uiPageDataModels = new List<UiPageDataModel>();

        //    uiPageDataModels.Add(new UiPageDataModel { Id = 3, UiPageId = 10, RecordId = 14, UiPageMetadataId = 4, Value = "Ritesh1244" });
        //    uiPageDataModels.Add(new UiPageDataModel { Id = 5, UiPageId = 10, RecordId = 14, UiPageMetadataId = 5, Value = "Ritesh44" });


        //    igenericRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new RecordModel { Id = 12, UiPageId = 10, Fields = null, FieldValues = null });
        //    commonRepository.Setup(x => x.GetUiPageMetadata(It.IsAny<int>())).Returns(new RecordModel { Id = 0, UiPageId = 10, Fields = uiPageMetaDataModels, FieldValues = null });


        //    genericRepositoryuipageData.Setup(x => x.Get<int>("RecordId", It.IsAny<int>())).Returns(uiPageDataModels);


        //    var logger = new Mock<ILogger<CommonController>>();

        //    _commonService = new SampleService(commonRepository.Object, igenericRepository.Object, iGenericRepositoryPageType.Object, genericRepositoryuipageData.Object, iGenericRepositoryPageMetaData.Object, iGenericRepositoryPageValidation.Object);
        //    var controller = new CommonController(logger.Object, _commonService, _mapper);

        //    var result = (ViewResult)controller.Delete(12);

        //    List<UiPageMetadataDTO> uiPageMetadataDTO = new List<UiPageMetadataDTO>();
        //    uiPageMetadataDTO.Add(new UiPageMetadataDTO { Id = 5, UiPageTypeId = 10, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "Year", IsRequired = false, DataTypeId = 12, DataTypeName = "int" });

        //    List<UiPageDataDTO> uiPageDTO = new List<UiPageDataDTO>();
        //    uiPageDTO.Add(new UiPageDataDTO { UiPageId = 10, UiPageMetadataId = 4, Value = "Ritesh1244" });
        //    uiPageDTO.Add(new UiPageDataDTO { UiPageId = 10, UiPageMetadataId = 5, Value = "Ritesh44" });

        //    var expectedResult = new RecordDTO { Id = 12, UiPageId = 10, Fields = uiPageMetadataDTO, FieldValues = uiPageDTO };

        //    result.Model.Should().BeEquivalentTo(expectedResult);

        //}

        ///*
        // * Description: This Method is to Delete the Record Of the Passed Id 
        // * Steps: Passing Parameter = Id ,
        // * Expect Result : Record Of RecordDTO
        // */
        //[Test]
        //public void Common_Delete_Post_Test()
        //{

        //    var logger = new Mock<ILogger<CommonController>>();

        //    _commonService = new SampleService(commonRepository.Object, igenericRepository.Object, iGenericRepositoryPageType.Object, genericRepositoryuipageData.Object, iGenericRepositoryPageMetaData.Object, iGenericRepositoryPageValidation.Object);
        //    var controller = new CommonController(logger.Object, _commonService, _mapper);

        //    var result = (RedirectToActionResult)controller.DeleteConfirmed(12);
        //    igenericRepository.Setup(x => x.Delete(It.IsAny<int>()));
        //    var expectedResult = "index";
        //    result.ActionName.Should().BeEquivalentTo(expectedResult);

        //}

        ///*
        // * Description :Passing Null to Validate the Method 
        // * Expected Result : Error 404 
        // */
        //[Test]
        //public void Common_Delete_Post_NUll_Val()
        //{

        //    var logger = new Mock<ILogger<CommonController>>();

        //    _commonService = new SampleService(commonRepository.Object, igenericRepository.Object, iGenericRepositoryPageType.Object, genericRepositoryuipageData.Object, iGenericRepositoryPageMetaData.Object, iGenericRepositoryPageValidation.Object);
        //    var controller = new CommonController(logger.Object, _commonService, _mapper);

        //    var result = (NotFoundResult)controller.DeleteConfirmed(null);
        //    igenericRepository.Setup(x => x.Delete(It.IsAny<int>()));
        //    var expectedResult = 404;
        //    result.StatusCode.Should().Be(expectedResult);

        //}
    }
}

