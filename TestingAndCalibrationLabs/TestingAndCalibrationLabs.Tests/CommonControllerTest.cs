using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Services;
using TestingAndCalibrationLabs.Web.UI.Controllers;
using TestingAndCalibrationLabs.Web.UI.Mappers;
using TestingAndCalibrationLabs.Web.UI.Models;


//namespace TestingAndCalibrationLabs.Tests
//{

//    / <summary>
//    / Decaring Class
//    / </summary>
//    #region public
//    public class SampleTests
//    {
//        / <summary>
//        / creating services 
//        / </summary>
//        ICommonService _sampleService;
//        ISampleRepository _sampleRepository;
//        IMapper _mapper;
//        ILogger<SampleController> _logger;

//        Web.UI.Models.Sample.SampleModelDTO detailToadd = new Web.UI.Models.Sample.SampleModelDTO
//        {
//            Name = "India",
//            Description = "Abc"
//        };
//        List<SampleModel> details = new List<SampleModel>
//            {
//                new SampleModel
//                {
//                    Id = 1, Name = "India", Description = "abc"
//                }
//            };


//        / <summary>
//        / Setuping Mock
//        / </summary>
//        [SetUp]
//        public void Setup()
//        {
//            mock mapper.

//            Mock<IMapper> mapper = new Mock<IMapper>();
//            mapper.Setup(m => m.Map<List<SampleModel>, List<Web.UI.Models.Sample.SampleModelDTO>>(details)).Returns(MapDetails(details));
//            mapper.Setup(m => m.Map<SampleModel, Web.UI.Models.Sample.SampleModelDTO>(details[0])).Returns(MapDetails(details[0]));
//            mapper.Setup(m => m.Map<Web.UI.Models.Sample.SampleModelDTO, SampleModel>(detailToadd)).Returns(details[0]);


//            mock repository\DB calls.
//            Mock<ISampleRepository> sampleRepo = new Mock<ISampleRepository>();
//            sampleRepo.Setup(mock => mock.Get()).Returns(details);
//            sampleRepo.Setup(mock => mock.Get(1)).Returns(details[0]);
//            sampleRepo.Setup(mock => mock.Insert(details[0])).Returns(details[0].Id);
//            sampleRepo.Setup(mock => mock.Delete(1)).Returns(true);
//            sampleRepo.Setup(mock => mock.Update(details[0])).Returns(details[0].Id);


//            resolve dependencies.
//            _mapper = mapper.Object;
//            _sampleRepository = sampleRepo.Object;
//            _sampleService = new SampleService(_sampleRepository);
//        }


//        / <summary>
//        / testing For getting all Details from Database
//        / </summary>
//        [Test]
//        public void SampleTestGetAllDetails()
//        {
//            SampleController sampleController = new SampleController(_logger, _sampleService, _mapper);
//            IActionResult response = sampleController.Index();
//            var data = response as ViewResult;
//            Assert.AreEqual(1, (data.Model as List<Web.UI.Models.Sample.SampleModelDTO>).Count);
//        }


//        / <summary>
//        / testing for adding a details
//        / </summary>
//        [Test]
//        public void SampleTestAddDetails()
//        {
//            SampleController sampleController = new SampleController(_logger, _sampleService, _mapper);
//            IActionResult response = sampleController.Create(1);
//            var data = response as ViewResult;
//            Assert.IsNotNull(data);
//            Assert.IsNotNull(data.Model);
//            Assert.IsTrue(string.IsNullOrEmpty(data.ViewName) || data.ViewName == "Index");

//        }

//        / <summary>
//        /testing  for updating details
//        / </summary>
//        [Test]
//        public void SampleTestUpdateDetails()
//        {
//            SampleController sampleController = new SampleController(_logger, _sampleService, _mapper);
//            IActionResult response = sampleController.Edit(1);
//            var data = response as ViewResult;
//            Assert.IsNotNull(data);
//            Assert.IsNotNull(data.Model);
//            Assert.IsTrue(string.IsNullOrEmpty(data.ViewName) || data.ViewName == "Index");
//        }


//        / <summary>
//        / testing for Deleting Details
//        / </summary>
//        [Test]
//        public void SampleTestDeleteDetails()
//        {
//            SampleController sampleController = new SampleController(_logger, _sampleService, _mapper);
//            IActionResult response = sampleController.Delete(1);
//            ViewResult data = response as ViewResult;
//            Assert.IsNotNull(data);
//            Assert.IsNotNull(data.Model);
//            Assert.IsTrue(string.IsNullOrEmpty(data.ViewName) || data.ViewName == "Index");
//        }
//        #endregion

//        #region Private methods
//        private List<Web.UI.Models.Sample.SampleModelDTO> MapDetails(List<SampleModel> samples)
//        {
//            List<Web.UI.Models.Sample.SampleModelDTO> list = new List<Web.UI.Models.Sample.SampleModelDTO>();
//            foreach (var details in samples)
//            {
//                list.Add(new Web.UI.Models.Sample.SampleModelDTO { Description = details.Description, Name = details.Name });
//            }
//            return list;
//        }
//        private Web.UI.Models.Sample.SampleModelDTO MapDetails(SampleModel details)
//        {
//            return new Web.UI.Models.Sample.SampleModelDTO { Description = details.Description, Name = details.Name };
//        }
//        #endregion

//    }
//}

namespace TestProject1
{
    [TestFixture]
    public class CommonControllerTest
    {
        IMapper _mapper;
        ICommonService _commonService;
        List<UiPageValidationModel> validations = new List<UiPageValidationModel>();
        List<UiPageValidationTypeModel> validationlist = new List<UiPageValidationTypeModel>();
        // ICommonRepository _commonRepository;

        Mock<ICommonRepository> commonRepository = new Mock<ICommonRepository>();
        Mock<IGenericRepository<RecordModel>> igenericRepository = new Mock<IGenericRepository<RecordModel>>();
        Mock<IGenericRepository<UiPageDataModel>> genericRepositoryuipageData = new Mock<IGenericRepository<UiPageDataModel>>();
        Mock<IGenericRepository<UiPageTypeModel>> iGenericRepositoryPageType = new Mock<IGenericRepository<UiPageTypeModel>>();
        Mock<IGenericRepository<UiPageMetadataModel>> iGenericRepositoryPageMetaData = new Mock<IGenericRepository<UiPageMetadataModel>>();
        Mock<IGenericRepository<UiPageValidationTypeModel>> iGenericRepositoryPageValidation = new Mock<IGenericRepository<UiPageValidationTypeModel>>();



        [SetUp]
        public void SetUp()
        {
            var profile = new MappingProfile();
            var Configuration = new MapperConfiguration(x => x.AddProfile(profile));
            var mapper = new Mapper(Configuration);
            _mapper = mapper;


            validations.Add(new UiPageValidationModel { Id = 4, Name = "MinPasswordLength", UiPageMetadataId = 1, UiPageMetadataName = null, UiPageTypeId = 2, UiPageTypeName = null, UiPageValidationTypeId = 1, UiPageValidationTypeName = null, Value = "8" });
            validations.Add(new UiPageValidationModel { Id = 3, Name = "AdharLength", UiPageMetadataId = 3, UiPageMetadataName = null, UiPageTypeId = 2, UiPageTypeName = null, UiPageValidationTypeId = 3, UiPageValidationTypeName = null, Value = "12" });
            validations.Add(new UiPageValidationModel { Id = 2, Name = "Email", UiPageMetadataId = 2, UiPageMetadataName = null, UiPageTypeId = 2, UiPageTypeName = null, UiPageValidationTypeId = 2, UiPageValidationTypeName = null, Value = "3" });
            validations.Add(new UiPageValidationModel { Id = 1, Name = "MobileNumberLength", UiPageMetadataId = 4, UiPageMetadataName = null, UiPageTypeId = 2, UiPageTypeName = null, UiPageValidationTypeId = 4, UiPageValidationTypeName = null, Value = "10" });
            validations.Add(new UiPageValidationModel { Id = 5, Name = "Year", UiPageMetadataId = 5, UiPageMetadataName = null, UiPageTypeId = 2, UiPageTypeName = null, UiPageValidationTypeId = 5, UiPageValidationTypeName = null, Value = "4" });


            //validation List 

            validationlist.Add(new UiPageValidationTypeModel { Id = 1, Message = "Minimum Password length  is 8", Name = "MinPasswordLength", Value = "8" });
            validationlist.Add(new UiPageValidationTypeModel { Id = 2, Message = "Email should have format", Name = "Email", Value = "3" });
            validationlist.Add(new UiPageValidationTypeModel { Id = 3, Message = "Aadhar length should be equal to 12", Name = "AdharLength", Value = "12" });
            validationlist.Add(new UiPageValidationTypeModel { Id = 4, Message = "Mobile No length eq to 10", Name = "MobileNumberLength", Value = "10" });
            validationlist.Add(new UiPageValidationTypeModel { Id = 5, Message = "Year length eq to 4 ", Name = "Year ", Value = "4" });
            validationlist.Add(new UiPageValidationTypeModel { Id = 6, Message = "{0} Field Required", Name = "IsRequired", Value = "" });




            var logger = new Mock<ILogger<CommonController>>();
            var controller = new CommonController(logger.Object, _commonService, _mapper);
        }

        /// <summary>
        /// common index method value with valid details 
        /// </summary>
        [Test]
        public void Common_Index_Method_Test()
        {
            List<UiPageMetadataModel> uiPageMetaDataModels = new List<UiPageMetadataModel>();
            uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 3, UiPageTypeId = 3, UiPageTypeName = "First", UiControlTypeId = 6, UiControlTypeName = "Display1", UiControlDisplayName = "Control1", IsRequired = false, DataTypeId = 12, DataTypeName = "int" });
            uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 4, UiPageTypeId = 4, UiPageTypeName = "ritesh", UiControlTypeId = 33, UiControlTypeName = "raj", UiControlDisplayName = "disp", IsRequired = true, DataTypeId = 127, DataTypeName = "char" });

            List<UiPageDataModel> uipageDataModels = new List<UiPageDataModel>();
            uipageDataModels.Add(new UiPageDataModel { Id = 11, UiPageId = 11, UiPageMetadataId = 11, RecordId = 6, Value = "Name" });
            uipageDataModels.Add(new UiPageDataModel { Id = 5, UiPageId = 14, UiPageMetadataId = 55, RecordId = 12, Value = "King" });

            _commonService = new SampleService(commonRepository.Object, igenericRepository.Object, iGenericRepositoryPageType.Object, genericRepositoryuipageData.Object, iGenericRepositoryPageMetaData.Object, iGenericRepositoryPageValidation.Object);

            // Mocking the repository
            commonRepository.Setup(x => x.GetUiPageMetadata(It.IsAny<int>())).Returns(new RecordModel { UiPageId = 3, Id = 1, FieldValues = uipageDataModels, Fields = uiPageMetaDataModels });

            commonRepository.Setup(x => x.GetUiPageDataByUiPageId(It.IsAny<int>())).Returns(uipageDataModels);


            var logger = new Mock<ILogger<CommonController>>();

            var controller = new CommonController(logger.Object, _commonService, _mapper);

            var result = (ViewResult)controller.Index(3);
            //Expected Result
            List<UiPageMetadataDTO> uiPageMetaDataDTO = new List<UiPageMetadataDTO>();
            uiPageMetaDataDTO.Add(new UiPageMetadataDTO { Id = 3, UiPageTypeId = 3, UiPageTypeName = "First", UiControlTypeId = 6, UiControlTypeName = "Display1", UiControlDisplayName = "Control1", IsRequired = false, DataTypeId = 12, DataTypeName = "int" });
            uiPageMetaDataDTO.Add(new UiPageMetadataDTO { Id = 4, UiPageTypeId = 4, UiPageTypeName = "ritesh", UiControlTypeId = 33, UiControlTypeName = "raj", UiControlDisplayName = "disp", IsRequired = true, DataTypeId = 127, DataTypeName = "char" });

            Dictionary<int, List<UiPageDataDTO>> uiPageModels = new Dictionary<int, List<UiPageDataDTO>>();
            uiPageModels.Add(6, new List<UiPageDataDTO> { new UiPageDataDTO { UiPageId = 11, UiPageMetadataId = 11, Value = "Name" } });
            uiPageModels.Add(12, new List<UiPageDataDTO> { new UiPageDataDTO { UiPageId = 14, UiPageMetadataId = 55, Value = "King" } });

            var ExpectedResult = new RecordsDTO() { Id = 0, UiPageId = 3, Fields = uiPageMetaDataDTO, FieldValues = uiPageModels };

            result.Model.Should().BeEquivalentTo(ExpectedResult);


        }
        /// <summary>
        /// Index method with wrong value 
        /// </summary>
        [Test]
        public void Common_Index_wrong_det_Test()
        {
            List<UiPageMetadataModel> uiPageMetaDataModels = new List<UiPageMetadataModel>();
            uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 3, UiPageTypeId = 3, UiPageTypeName = "First", UiControlTypeId = 6, UiControlTypeName = "Display1", UiControlDisplayName = "Control1", IsRequired = false, DataTypeId = 12, DataTypeName = "int" });
            uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 4, UiPageTypeId = 4, UiPageTypeName = "ritesh", UiControlTypeId = 33, UiControlTypeName = "raj", UiControlDisplayName = "disp", IsRequired = true, DataTypeId = 127, DataTypeName = "char" });

            List<UiPageDataModel> uipageDataModels = new List<UiPageDataModel>();
            uipageDataModels.Add(new UiPageDataModel { Id = 11, UiPageId = 11, UiPageMetadataId = 11, RecordId = 6, Value = "Name" });
            uipageDataModels.Add(new UiPageDataModel { Id = 5, UiPageId = 14, UiPageMetadataId = 55, RecordId = 12, Value = "King" });


            _commonService = new SampleService(commonRepository.Object, igenericRepository.Object, iGenericRepositoryPageType.Object, genericRepositoryuipageData.Object, iGenericRepositoryPageMetaData.Object, iGenericRepositoryPageValidation.Object);


            commonRepository.Setup(x => x.GetUiPageMetadata(It.IsAny<int>())).Returns(new RecordModel { UiPageId = 3, Id = 1, FieldValues = uipageDataModels, Fields = uiPageMetaDataModels });
            commonRepository.Setup(x => x.GetUiPageDataByUiPageId(It.IsAny<int>())).Returns(uipageDataModels);


            var logger = new Mock<ILogger<CommonController>>();


            var controller = new CommonController(logger.Object, _commonService, _mapper);

            var modelResult = (ViewResult)controller.Index();

            List<UiPageMetadataDTO> uiPageMetaDataDTO = new List<UiPageMetadataDTO>();
            uiPageMetaDataDTO.Add(new UiPageMetadataDTO { Id = 3, UiPageTypeId = 3, UiPageTypeName = "First", UiControlTypeId = 6, UiControlTypeName = "Display1", UiControlDisplayName = "Control1", IsRequired = false, DataTypeId = 12, DataTypeName = "int" });
            uiPageMetaDataDTO.Add(new UiPageMetadataDTO { Id = 4, UiPageTypeId = 4, UiPageTypeName = "ritesh", UiControlTypeId = 33, UiControlTypeName = "raj", UiControlDisplayName = "disp", IsRequired = true, DataTypeId = 127, DataTypeName = "char" });

            Dictionary<int, List<UiPageDataDTO>> uiPageModels = new Dictionary<int, List<UiPageDataDTO>>();
            uiPageModels.Add(6, new List<UiPageDataDTO> { new UiPageDataDTO { UiPageId = 11, UiPageMetadataId = 11, Value = "Name" } });
            uiPageModels.Add(12, new List<UiPageDataDTO> { new UiPageDataDTO { UiPageId = 14, UiPageMetadataId = 55, Value = "King" } });

            var ExpectedResult = new RecordsDTO() { Id = 0, UiPageId = 3, Fields = uiPageMetaDataDTO, FieldValues = uiPageModels };
            modelResult.Model.Should().NotBeEquivalentTo(ExpectedResult);

        }
        /// <summary>
        /// Create method
        /// </summary>
        [Test]
        public void Common_Create_Get_Method_Test()
        {
            List<UiPageMetadataModel> uiPageMetaDataModels = new List<UiPageMetadataModel>();
            uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 3, UiPageTypeId = 3, UiPageTypeName = "First", UiControlTypeId = 6, UiControlTypeName = "Display1", UiControlDisplayName = "Control1", IsRequired = false, DataTypeId = 12, DataTypeName = "int" });
            uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 4, UiPageTypeId = 4, UiPageTypeName = "ritesh", UiControlTypeId = 33, UiControlTypeName = "raj", UiControlDisplayName = "disp", IsRequired = true, DataTypeId = 127, DataTypeName = "char" });


            _commonService = new SampleService(commonRepository.Object, igenericRepository.Object, iGenericRepositoryPageType.Object, genericRepositoryuipageData.Object, iGenericRepositoryPageMetaData.Object, iGenericRepositoryPageValidation.Object);

            var expectedFieldvalues = new List<UiPageDataDTO>();
            commonRepository.Setup(x => x.GetUiPageMetadata(It.IsAny<int>())).Returns(new RecordModel { UiPageId = 3, Id = 0, Fields = uiPageMetaDataModels, FieldValues = null });

            var logger = new Mock<ILogger<CommonController>>();

            var controller = new CommonController(logger.Object, _commonService, _mapper);

            var createResult = (ViewResult)controller.Create(5);


            List<UiPageMetadataDTO> uiPageMetaDataDTO = new List<UiPageMetadataDTO>();
            uiPageMetaDataDTO.Add(new UiPageMetadataDTO { Id = 3, UiPageTypeId = 3, UiPageTypeName = "First", UiControlTypeId = 6, UiControlTypeName = "Display1", UiControlDisplayName = "Control1", IsRequired = false, DataTypeId = 12, DataTypeName = "int" });
            uiPageMetaDataDTO.Add(new UiPageMetadataDTO { Id = 4, UiPageTypeId = 4, UiPageTypeName = "ritesh", UiControlTypeId = 33, UiControlTypeName = "raj", UiControlDisplayName = "disp", IsRequired = true, DataTypeId = 127, DataTypeName = "char" });



            var expectedResult = new RecordDTO { Id = 0, UiPageId = 3, Fields = uiPageMetaDataDTO, FieldValues = expectedFieldvalues };
            createResult.Model.Should().BeEquivalentTo(expectedResult);
        }

        /// <summary>
        /// Post method with valid email and password
        /// </summary>
        [Test]
        public void Common_Create_PostMethod_Test()
        {
            List<UiPageDataDTO> uipagedata = new List<UiPageDataDTO>();
            uipagedata.Add(new UiPageDataDTO { UiPageId = 0, UiPageMetadataId = 1, Value = "ritesh123" });
            uipagedata.Add(new UiPageDataDTO { UiPageId = 0, UiPageMetadataId = 2, Value = "8709" });

            List<UiPageMetadataModel> uiPageMetaDataModels = new List<UiPageMetadataModel>();
            uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 1, UiPageTypeId = 3, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "Password", IsRequired = false, DataTypeId = 12, DataTypeName = "string" });
            uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 2, UiPageTypeId = 4, UiPageTypeName = null, UiControlTypeId = 33, UiControlTypeName = null, UiControlDisplayName = "mail", IsRequired = true, DataTypeId = 127, DataTypeName = "string" });


            //validation List
            iGenericRepositoryPageValidation.Setup(x => x.Get()).Returns(validationlist);
            commonRepository.Setup(x => x.GetUiPageValidations(It.IsAny<int>())).Returns(validations);

            foreach (var item in validationlist)
            {
                iGenericRepositoryPageValidation.Setup(x => x.Get(item.Id)).Returns(item);
            }


            var record = new RecordDTO { Id = 1, UiPageId = 12, Fields = null, FieldValues = uipagedata };
            var logger = new Mock<ILogger<CommonController>>();

            _commonService = new SampleService(commonRepository.Object, igenericRepository.Object, iGenericRepositoryPageType.Object, genericRepositoryuipageData.Object, iGenericRepositoryPageMetaData.Object, iGenericRepositoryPageValidation.Object);
            var controller = new CommonController(logger.Object, _commonService, _mapper);



            commonRepository.Setup(x => x.GetUiPageMetadata(It.IsAny<int>())).Returns(new RecordModel { UiPageId = 12, Id = 1, Fields = uiPageMetaDataModels, FieldValues = null });

            //validation Mocking 
            //


            foreach (var item in uiPageMetaDataModels)
            {
                iGenericRepositoryPageMetaData.Setup(x => x.Get(item.Id)).Returns(item);
            }

            //var createResult = (BadRequestObjectResult)controller.Create(record);
            var createResult = (OkObjectResult)controller.Create(record);
            var value = (RecordDTO)createResult.Value;

            var expectField = new List<UiPageDataDTO>();

            List<UiPageMetadataDTO> uiPageDTOFields = new List<UiPageMetadataDTO>();
            uiPageDTOFields.Add(new UiPageMetadataDTO { Id = 2, UiPageTypeId = 4, UiPageTypeName = null, UiControlTypeId = 33, UiControlTypeName = null, UiControlDisplayName = "mail", IsRequired = true, DataTypeId = 127, DataTypeName = "string" });
            uiPageDTOFields.Add(new UiPageMetadataDTO { Id = 1, UiPageTypeId = 3, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "Password", IsRequired = false, DataTypeId = 12, DataTypeName = "string" });

            var expectedResult = new RecordDTO { Id = 1, UiPageId = 12, Fields = uiPageDTOFields, FieldValues = expectField };

            value.Should().BeEquivalentTo(expectedResult);


        }

        /// <summary>
        /// Wrong Password and Wrong Mail
        /// </summary>
        [Test]
        public void Common_Create_Wrong_Pass_Mail_Test()
        {
            List<UiPageDataDTO> uipagedata = new List<UiPageDataDTO>();
            uipagedata.Add(new UiPageDataDTO { UiPageId = 0, UiPageMetadataId = 3, Value = "Rit" });
            uipagedata.Add(new UiPageDataDTO { UiPageId = 0, UiPageMetadataId = 4, Value = "21@" });

            List<UiPageMetadataModel> uiPageMetaDataModels = new List<UiPageMetadataModel>();
            uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 3, UiPageTypeId = 3, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "Password", IsRequired = false, DataTypeId = 12, DataTypeName = "string" });
            uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 4, UiPageTypeId = 4, UiPageTypeName = null, UiControlTypeId = 33, UiControlTypeName = null, UiControlDisplayName = "mail", IsRequired = true, DataTypeId = 127, DataTypeName = "string" });


            //validation List
            iGenericRepositoryPageValidation.Setup(x => x.Get()).Returns(validationlist);
            commonRepository.Setup(x => x.GetUiPageValidations(It.IsAny<int>())).Returns(validations);

            foreach (var item in validationlist)
            {
                iGenericRepositoryPageValidation.Setup(x => x.Get(item.Id)).Returns(item);
            }


            var record = new RecordDTO { Id = 1, UiPageId = 12, Fields = null, FieldValues = uipagedata };
            var logger = new Mock<ILogger<CommonController>>();

            _commonService = new SampleService(commonRepository.Object, igenericRepository.Object, iGenericRepositoryPageType.Object, genericRepositoryuipageData.Object, iGenericRepositoryPageMetaData.Object, iGenericRepositoryPageValidation.Object);
            var controller = new CommonController(logger.Object, _commonService, _mapper);



            commonRepository.Setup(x => x.GetUiPageMetadata(It.IsAny<int>())).Returns(new RecordModel { UiPageId = 12, Id = 1, Fields = uiPageMetaDataModels, FieldValues = null });



            foreach (var item in uiPageMetaDataModels)
            {
                iGenericRepositoryPageMetaData.Setup(x => x.Get(item.Id)).Returns(item);
            }

            var createResult = (BadRequestObjectResult)controller.Create(record);

            var value = (RecordDTO)createResult.Value;

            var expectField = new List<UiPageDataDTO>();

            List<UiPageMetadataDTO> uiPageDTOFields = new List<UiPageMetadataDTO>();
            uiPageDTOFields.Add(new UiPageMetadataDTO { Id = 6, UiPageTypeId = 4, UiPageTypeName = null, UiControlTypeId = 33, UiControlTypeName = null, UiControlDisplayName = "mail", IsRequired = true, DataTypeId = 127, DataTypeName = "string" });
            uiPageDTOFields.Add(new UiPageMetadataDTO { Id = 5, UiPageTypeId = 3, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "Password", IsRequired = false, DataTypeId = 12, DataTypeName = "string" });

            ValidationMessage error_message = new ValidationMessage();
            error_message.Reason = "Aadhar length should be equal to 12"; 

            var expectedResult = new RecordDTO { Id = 1, UiPageId = 12, Fields = uiPageDTOFields, FieldValues = expectField, ErrorMessage = error_message };

            value.ErrorMessage.Should().NotBeEquivalentTo(expectedResult.ErrorMessage);
        }
        /// <summary>
        /// Correct Adhar and mobile no 
        /// </summary>
        [Test]
        public void Common_Create_Post_Correct_Adhar_Mob_Test()
        {
            List<UiPageDataDTO> uipagedata = new List<UiPageDataDTO>();
            uipagedata.Add(new UiPageDataDTO { UiPageId = 0, UiPageMetadataId = 3, Value = "641568763619" });
            uipagedata.Add(new UiPageDataDTO { UiPageId = 0, UiPageMetadataId = 4, Value = "8709282126" });

            List<UiPageMetadataModel> uiPageMetaDataModels = new List<UiPageMetadataModel>();
            uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 3, UiPageTypeId = 3, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "AdharNo", IsRequired = false, DataTypeId = 12, DataTypeName = "varchar(12)" });
            uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 4, UiPageTypeId = 4, UiPageTypeName = null, UiControlTypeId = 33, UiControlTypeName = null, UiControlDisplayName = "MobileNo", IsRequired = true, DataTypeId = 127, DataTypeName = "varchar(10)" });


            //validation List
            iGenericRepositoryPageValidation.Setup(x => x.Get()).Returns(validationlist);
            commonRepository.Setup(x => x.GetUiPageValidations(It.IsAny<int>())).Returns(validations);

            foreach (var item in validationlist)
            {
                iGenericRepositoryPageValidation.Setup(x => x.Get(item.Id)).Returns(item);
            }


            var record = new RecordDTO { Id = 1, UiPageId = 12, Fields = null, FieldValues = uipagedata };
            var logger = new Mock<ILogger<CommonController>>();

            _commonService = new SampleService(commonRepository.Object, igenericRepository.Object, iGenericRepositoryPageType.Object, genericRepositoryuipageData.Object, iGenericRepositoryPageMetaData.Object, iGenericRepositoryPageValidation.Object);
            var controller = new CommonController(logger.Object, _commonService, _mapper);



            commonRepository.Setup(x => x.GetUiPageMetadata(It.IsAny<int>())).Returns(new RecordModel { UiPageId = 12, Id = 1, Fields = uiPageMetaDataModels, FieldValues = null });



            foreach (var item in uiPageMetaDataModels)
            {
                iGenericRepositoryPageMetaData.Setup(x => x.Get(item.Id)).Returns(item);
            }

            var createResult = (OkObjectResult)controller.Create(record);

            var value = (RecordDTO)createResult.Value;

            var expectField = new List<UiPageDataDTO>();

            List<UiPageMetadataDTO> uiPageDTOFields = new List<UiPageMetadataDTO>();
            uiPageDTOFields.Add(new UiPageMetadataDTO { Id = 4, UiPageTypeId = 4, UiPageTypeName = null, UiControlTypeId = 33, UiControlTypeName = null, UiControlDisplayName = "MobileNo", IsRequired = true, DataTypeId = 127, DataTypeName = "varchar(10)" });
            uiPageDTOFields.Add(new UiPageMetadataDTO { Id = 3, UiPageTypeId = 3, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "AdharNo", IsRequired = false, DataTypeId = 12, DataTypeName = "varchar(12)" });

            var expectedResult = new RecordDTO { Id = 1, UiPageId = 12, Fields = uiPageDTOFields, FieldValues = expectField };

            value.Should().BeEquivalentTo(expectedResult);
        }

        /// <summary>
        /// Wrong AAdhar and Mobile 
        /// </summary>
        [Test]
        public void Common_Create_Post_ADh_Mob_Test()
        {
            List<UiPageDataDTO> uipagedata = new List<UiPageDataDTO>();
            //For AAdhar
            uipagedata.Add(new UiPageDataDTO { UiPageId = 0, UiPageMetadataId = 3, Value = "64156876361" });
            //for MobileNo
            uipagedata.Add(new UiPageDataDTO { UiPageId = 0, UiPageMetadataId = 4, Value = "8709282126" });

            List<UiPageMetadataModel> uiPageMetaDataModels = new List<UiPageMetadataModel>();
            uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 3, UiPageTypeId = 3, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "AdharNo", IsRequired = false, DataTypeId = 12, DataTypeName = "varchar(12)" });
            uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 4, UiPageTypeId = 4, UiPageTypeName = null, UiControlTypeId = 33, UiControlTypeName = null, UiControlDisplayName = "MobileNo", IsRequired = true, DataTypeId = 127, DataTypeName = "varchar(10)" });


            //validation List
            iGenericRepositoryPageValidation.Setup(x => x.Get()).Returns(validationlist);
            commonRepository.Setup(x => x.GetUiPageValidations(It.IsAny<int>())).Returns(validations);

            foreach (var item in validationlist)
            {
                iGenericRepositoryPageValidation.Setup(x => x.Get(item.Id)).Returns(item);
            }


            var record = new RecordDTO { Id = 1, UiPageId = 12, Fields = null, FieldValues = uipagedata };
            var logger = new Mock<ILogger<CommonController>>();

            _commonService = new SampleService(commonRepository.Object, igenericRepository.Object, iGenericRepositoryPageType.Object, genericRepositoryuipageData.Object, iGenericRepositoryPageMetaData.Object, iGenericRepositoryPageValidation.Object);
            var controller = new CommonController(logger.Object, _commonService, _mapper);



            commonRepository.Setup(x => x.GetUiPageMetadata(It.IsAny<int>())).Returns(new RecordModel { UiPageId = 12, Id = 1, Fields = uiPageMetaDataModels, FieldValues = null });



            foreach (var item in uiPageMetaDataModels)
            {
                iGenericRepositoryPageMetaData.Setup(x => x.Get(item.Id)).Returns(item);
            }

            var createResult = (BadRequestObjectResult)controller.Create(record);

            var value = (RecordDTO)createResult.Value;

            var expectField = new List<UiPageDataDTO>();

            List<UiPageMetadataDTO> uiPageDTOFields = new List<UiPageMetadataDTO>();
            uiPageDTOFields.Add(new UiPageMetadataDTO { Id = 4, UiPageTypeId = 4, UiPageTypeName = null, UiControlTypeId = 33, UiControlTypeName = null, UiControlDisplayName = "MobileNo", IsRequired = true, DataTypeId = 127, DataTypeName = "varchar(10)" });
            uiPageDTOFields.Add(new UiPageMetadataDTO { Id = 3, UiPageTypeId = 3, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "AdharNo", IsRequired = false, DataTypeId = 12, DataTypeName = "varchar(12)" });

            var expectedResult = new RecordDTO { Id = 1, UiPageId = 12, Fields = uiPageDTOFields, FieldValues = expectField };

            value.Should().NotBeEquivalentTo(expectedResult);
        }

        /// <summary>
        /// Correct Year
        /// </summary>
        [Test]
        public void Common_Create_Post_Correct_year_Test()
        {
            List<UiPageDataDTO> uipagedata = new List<UiPageDataDTO>();
            //For Year
            uipagedata.Add(new UiPageDataDTO { UiPageId = 0, UiPageMetadataId = 5, Value = "2012" });

            List<UiPageMetadataModel> uiPageMetaDataModels = new List<UiPageMetadataModel>();
            uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 5, UiPageTypeId = 3, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "Year", IsRequired = false, DataTypeId = 12, DataTypeName = "int" });


            //validation List
            iGenericRepositoryPageValidation.Setup(x => x.Get()).Returns(validationlist);
            commonRepository.Setup(x => x.GetUiPageValidations(It.IsAny<int>())).Returns(validations);

            foreach (var item in validationlist)
            {
                iGenericRepositoryPageValidation.Setup(x => x.Get(item.Id)).Returns(item);
            }


            var record = new RecordDTO { Id = 1, UiPageId = 12, Fields = null, FieldValues = uipagedata };
            var logger = new Mock<ILogger<CommonController>>();

            _commonService = new SampleService(commonRepository.Object, igenericRepository.Object, iGenericRepositoryPageType.Object, genericRepositoryuipageData.Object, iGenericRepositoryPageMetaData.Object, iGenericRepositoryPageValidation.Object);
            var controller = new CommonController(logger.Object, _commonService, _mapper);



            commonRepository.Setup(x => x.GetUiPageMetadata(It.IsAny<int>())).Returns(new RecordModel { UiPageId = 12, Id = 1, Fields = uiPageMetaDataModels, FieldValues = null });



            foreach (var item in uiPageMetaDataModels)
            {
                iGenericRepositoryPageMetaData.Setup(x => x.Get(item.Id)).Returns(item);
            }

            var createResult = (OkObjectResult)controller.Create(record);

            var value = (RecordDTO)createResult.Value;

            var expectField = new List<UiPageDataDTO>();

            List<UiPageMetadataDTO> uiPageDTOFields = new List<UiPageMetadataDTO>();
            uiPageDTOFields.Add(new UiPageMetadataDTO { Id = 5, UiPageTypeId = 3, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "Year", IsRequired = false, DataTypeId = 12, DataTypeName = "int" });

            var expectedResult = new RecordDTO { Id = 1, UiPageId = 12, Fields = uiPageDTOFields, FieldValues = expectField };

            value.Should().BeEquivalentTo(expectedResult);
        }
        /// <summary>
        /// wrong Year
        /// </summary>
        [Test]
        public void Common_Create_Post_Wrong_year_Test()
        {
            List<UiPageDataDTO> uipagedata = new List<UiPageDataDTO>();
            //For Year
            uipagedata.Add(new UiPageDataDTO { UiPageId = 0, UiPageMetadataId = 5, Value = "201" });

            List<UiPageMetadataModel> uiPageMetaDataModels = new List<UiPageMetadataModel>();
            uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 5, UiPageTypeId = 3, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "Year", IsRequired = false, DataTypeId = 12, DataTypeName = "int" });


            //validation List
            iGenericRepositoryPageValidation.Setup(x => x.Get()).Returns(validationlist);
            commonRepository.Setup(x => x.GetUiPageValidations(It.IsAny<int>())).Returns(validations);

            foreach (var item in validationlist)
            {
                iGenericRepositoryPageValidation.Setup(x => x.Get(item.Id)).Returns(item);
            }


            var record = new RecordDTO { Id = 1, UiPageId = 12, Fields = null, FieldValues = uipagedata };
            var logger = new Mock<ILogger<CommonController>>();

            _commonService = new SampleService(commonRepository.Object, igenericRepository.Object, iGenericRepositoryPageType.Object, genericRepositoryuipageData.Object, iGenericRepositoryPageMetaData.Object, iGenericRepositoryPageValidation.Object);
            var controller = new CommonController(logger.Object, _commonService, _mapper);



            commonRepository.Setup(x => x.GetUiPageMetadata(It.IsAny<int>())).Returns(new RecordModel { UiPageId = 12, Id = 1, Fields = uiPageMetaDataModels, FieldValues = null });



            foreach (var item in uiPageMetaDataModels)
            {
                iGenericRepositoryPageMetaData.Setup(x => x.Get(item.Id)).Returns(item);
            }

            var createResult = (BadRequestObjectResult)controller.Create(record);

            var value = (RecordDTO)createResult.Value;

            var expectField = new List<UiPageDataDTO>();

            List<UiPageMetadataDTO> uiPageDTOFields = new List<UiPageMetadataDTO>();
            uiPageDTOFields.Add(new UiPageMetadataDTO { Id = 5, UiPageTypeId = 3, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "Year", IsRequired = false, DataTypeId = 12, DataTypeName = "int" });

            var expectedResult = new RecordDTO { Id = 1, UiPageId = 12, Fields = uiPageDTOFields, FieldValues = expectField };

            value.Should().NotBeEquivalentTo(expectedResult);
        }

        /// <summary>
        /// httpget[edit Method]
        /// </summary>
        [Test]
        public void Common_Edit_Get_Test()
        {
            List<UiPageMetadataModel> uiPageMetaDataModels = new List<UiPageMetadataModel>();
            uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 5, UiPageTypeId = 10, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "Year", IsRequired = false, DataTypeId = 12, DataTypeName = "int" });

            List<UiPageDataModel> uiPageDataModels = new List<UiPageDataModel>();
            //for line 107 common service
            uiPageDataModels.Add(new UiPageDataModel { Id = 3, UiPageId = 10, RecordId = 14, UiPageMetadataId = 4, Value = "Ritesh1244" });
            uiPageDataModels.Add(new UiPageDataModel { Id = 5, UiPageId = 10, RecordId = 14, UiPageMetadataId = 5, Value = "Ritesh44" });


            igenericRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new RecordModel { Id = 12, UiPageId = 10, Fields = null, FieldValues = null });
            commonRepository.Setup(x => x.GetUiPageMetadata(It.IsAny<int>())).Returns(new RecordModel { Id = 0, UiPageId = 10, Fields = uiPageMetaDataModels, FieldValues = null });


            genericRepositoryuipageData.Setup(x => x.Get<int>("RecordId", It.IsAny<int>())).Returns(uiPageDataModels);


            var logger = new Mock<ILogger<CommonController>>();

            _commonService = new SampleService(commonRepository.Object, igenericRepository.Object, iGenericRepositoryPageType.Object, genericRepositoryuipageData.Object, iGenericRepositoryPageMetaData.Object, iGenericRepositoryPageValidation.Object);
            var controller = new CommonController(logger.Object, _commonService, _mapper);

            var result = (ViewResult)controller.Edit(12);

            List<UiPageMetadataDTO> uiPageMetadataDTO = new List<UiPageMetadataDTO>();
            uiPageMetadataDTO.Add(new UiPageMetadataDTO { Id = 5, UiPageTypeId = 10, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "Year", IsRequired = false, DataTypeId = 12, DataTypeName = "int" });

            List<UiPageDataDTO> uiPageDTO = new List<UiPageDataDTO>();
            uiPageDTO.Add(new UiPageDataDTO { UiPageId = 10, UiPageMetadataId = 4, Value = "Ritesh1244" });
            uiPageDTO.Add(new UiPageDataDTO { UiPageId = 10, UiPageMetadataId = 5, Value = "Ritesh44" });

            var expectedResult = new RecordDTO { Id = 12, UiPageId = 10, Fields = uiPageMetadataDTO, FieldValues = uiPageDTO };

            result.Model.Should().BeEquivalentTo(expectedResult);
        }

        /// <summary>
        /// Post Method of edit 
        /// </summary>
        [Test]
        public void common_Edit_POST_True_Test()
        {
            List<UiPageDataDTO> uipagedata = new List<UiPageDataDTO>();
            uipagedata.Add(new UiPageDataDTO { UiPageId = 0, UiPageMetadataId = 1, Value = "ritesh1267" });
            uipagedata.Add(new UiPageDataDTO { UiPageId = 0, UiPageMetadataId = 2, Value = "8709" });

            List<UiPageMetadataModel> uiPageMetaDataModels = new List<UiPageMetadataModel>();
            uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 1, UiPageTypeId = 3, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "Password", IsRequired = false, DataTypeId = 12, DataTypeName = "string" });
            uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 2, UiPageTypeId = 4, UiPageTypeName = null, UiControlTypeId = 33, UiControlTypeName = null, UiControlDisplayName = "mail", IsRequired = true, DataTypeId = 127, DataTypeName = "string" });


            List<UiPageDataModel> uiPageDataModels = new List<UiPageDataModel>();
            uiPageDataModels.Add(new UiPageDataModel { Id = 13, UiPageId = 12, RecordId = 5, UiPageMetadataId = 1, Value = "Ritesh1244" });
            uiPageDataModels.Add(new UiPageDataModel { Id = 5, UiPageId = 12, RecordId = 5, UiPageMetadataId = 2, Value = "Ritesh44" });
            genericRepositoryuipageData.Setup(x => x.Get<int>("RecordId", It.IsAny<int>())).Returns(uiPageDataModels);


            //validation List

            iGenericRepositoryPageValidation.Setup(x => x.Get()).Returns(validationlist);
            commonRepository.Setup(x => x.GetUiPageValidations(It.IsAny<int>())).Returns(validations);
            igenericRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new RecordModel { Id = 12, UiPageId = 10, Fields = null, FieldValues = null });

            foreach (var item in validationlist)
            {
                iGenericRepositoryPageValidation.Setup(x => x.Get(item.Id)).Returns(item);
            }
            foreach (var item in uiPageMetaDataModels)
            {
                iGenericRepositoryPageMetaData.Setup(x => x.Get(item.Id)).Returns(item);
            }

            List<UiPageMetadataDTO> uiPageMetadataDTO = new List<UiPageMetadataDTO>();
            var record = new RecordDTO { Id = 5, UiPageId = 12, Fields = uiPageMetadataDTO, FieldValues = uipagedata };
            var logger = new Mock<ILogger<CommonController>>();

            _commonService = new SampleService(commonRepository.Object, igenericRepository.Object, iGenericRepositoryPageType.Object, genericRepositoryuipageData.Object, iGenericRepositoryPageMetaData.Object, iGenericRepositoryPageValidation.Object);
            var controller = new CommonController(logger.Object, _commonService, _mapper);


            commonRepository.Setup(x => x.GetUiPageMetadata(It.IsAny<int>())).Returns(new RecordModel { UiPageId = 12, Id = 1, Fields = uiPageMetaDataModels, FieldValues = null });



            var createResult = (OkObjectResult)controller.Edit(record);
            var value = (RecordDTO)createResult.Value;

            List<UiPageDataDTO> expectField = new List<UiPageDataDTO>();
            expectField.Add(new UiPageDataDTO { UiPageId = 12, UiPageMetadataId = 1, Value = "ritesh1267" });
            expectField.Add(new UiPageDataDTO { UiPageId = 12, UiPageMetadataId = 2, Value = "8709" });

            List<UiPageMetadataDTO> uiPageDTOFields = new List<UiPageMetadataDTO>();
            uiPageDTOFields.Add(new UiPageMetadataDTO { Id = 2, UiPageTypeId = 4, UiPageTypeName = null, UiControlTypeId = 33, UiControlTypeName = null, UiControlDisplayName = "mail", IsRequired = true, DataTypeId = 127, DataTypeName = "string" });
            uiPageDTOFields.Add(new UiPageMetadataDTO { Id = 1, UiPageTypeId = 3, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "Password", IsRequired = false, DataTypeId = 12, DataTypeName = "string" });

            var expectedResult = new RecordDTO { Id = 5, UiPageId = 10, Fields = uiPageDTOFields, FieldValues = expectField };

            value.Should().BeEquivalentTo(expectedResult);
        }

        /// <summary>
        /// Edit Post method with Wrong detail
        /// </summary>
        [Test]
        public void Common_controller_EDIT_POSt_Wrong_value_Test()
        {
            List<UiPageDataDTO> uipagedata = new List<UiPageDataDTO>();
            uipagedata.Add(new UiPageDataDTO { UiPageId = 0, UiPageMetadataId = 1, Value = "rites" });
            uipagedata.Add(new UiPageDataDTO { UiPageId = 0, UiPageMetadataId = 2, Value = "87" });

            List<UiPageMetadataModel> uiPageMetaDataModels = new List<UiPageMetadataModel>();
            uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 1, UiPageTypeId = 3, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "Password", IsRequired = false, DataTypeId = 12, DataTypeName = "string" });
            uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 2, UiPageTypeId = 4, UiPageTypeName = null, UiControlTypeId = 33, UiControlTypeName = null, UiControlDisplayName = "mail", IsRequired = true, DataTypeId = 127, DataTypeName = "string" });


            List<UiPageDataModel> uiPageDataModels = new List<UiPageDataModel>();
            uiPageDataModels.Add(new UiPageDataModel { Id = 13, UiPageId = 12, RecordId = 5, UiPageMetadataId = 1, Value = "Ritesh1244" });
            uiPageDataModels.Add(new UiPageDataModel { Id = 5, UiPageId = 12, RecordId = 5, UiPageMetadataId = 2, Value = "Ritesh44" });

            genericRepositoryuipageData.Setup(x => x.Get<int>("RecordId", It.IsAny<int>())).Returns(uiPageDataModels);
            iGenericRepositoryPageValidation.Setup(x => x.Get()).Returns(validationlist);
            commonRepository.Setup(x => x.GetUiPageValidations(It.IsAny<int>())).Returns(validations);
            igenericRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new RecordModel { Id = 12, UiPageId = 10, Fields = null, FieldValues = null });


            //validation List

            foreach (var item in validationlist)
            {
                iGenericRepositoryPageValidation.Setup(x => x.Get(item.Id)).Returns(item);
            }
            foreach (var item in uiPageMetaDataModels)
            {
                iGenericRepositoryPageMetaData.Setup(x => x.Get(item.Id)).Returns(item);
            }

            List<UiPageMetadataDTO> uiPageMetadataDTO = new List<UiPageMetadataDTO>();
            var record = new RecordDTO { Id = 5, UiPageId = 12, Fields = uiPageMetadataDTO, FieldValues = uipagedata };
            var logger = new Mock<ILogger<CommonController>>();

            _commonService = new SampleService(commonRepository.Object, igenericRepository.Object, iGenericRepositoryPageType.Object, genericRepositoryuipageData.Object, iGenericRepositoryPageMetaData.Object, iGenericRepositoryPageValidation.Object);
            var controller = new CommonController(logger.Object, _commonService, _mapper);


            commonRepository.Setup(x => x.GetUiPageMetadata(It.IsAny<int>())).Returns(new RecordModel { UiPageId = 12, Id = 1, Fields = uiPageMetaDataModels, FieldValues = null });



            var createResult = (BadRequestObjectResult)controller.Edit(record);
            var value = (RecordDTO)createResult.Value;

            List<UiPageDataDTO> expectField = new List<UiPageDataDTO>();
            expectField.Add(new UiPageDataDTO { UiPageId = 0, UiPageMetadataId = 1, Value = "rites" });
            expectField.Add(new UiPageDataDTO { UiPageId = 0, UiPageMetadataId = 2, Value = "87" });

            List<UiPageMetadataDTO> uiPageDTOFields = new List<UiPageMetadataDTO>();
            uiPageDTOFields.Add(new UiPageMetadataDTO { Id = 2, UiPageTypeId = 4, UiPageTypeName = null, UiControlTypeId = 33, UiControlTypeName = null, UiControlDisplayName = "mail", IsRequired = true, DataTypeId = 127, DataTypeName = "string" });
            uiPageDTOFields.Add(new UiPageMetadataDTO { Id = 1, UiPageTypeId = 3, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "Password", IsRequired = false, DataTypeId = 12, DataTypeName = "string" });

            var expectedResult = new RecordDTO { Id = 5, UiPageId = 10, Fields = uiPageDTOFields, FieldValues = expectField };

            value.Should().NotBeEquivalentTo(expectedResult);
        }


        /// <summary>
        /// Delete Method of common controller 
        /// </summary>
        [Test]
        public void common_Delete_Test()
        {
            List<UiPageMetadataModel> uiPageMetaDataModels = new List<UiPageMetadataModel>();
            uiPageMetaDataModels.Add(new UiPageMetadataModel { Id = 5, UiPageTypeId = 10, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "Year", IsRequired = false, DataTypeId = 12, DataTypeName = "int" });

            List<UiPageDataModel> uiPageDataModels = new List<UiPageDataModel>();

            uiPageDataModels.Add(new UiPageDataModel { Id = 3, UiPageId = 10, RecordId = 14, UiPageMetadataId = 4, Value = "Ritesh1244" });
            uiPageDataModels.Add(new UiPageDataModel { Id = 5, UiPageId = 10, RecordId = 14, UiPageMetadataId = 5, Value = "Ritesh44" });


            igenericRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new RecordModel { Id = 12, UiPageId = 10, Fields = null, FieldValues = null });
            commonRepository.Setup(x => x.GetUiPageMetadata(It.IsAny<int>())).Returns(new RecordModel { Id = 0, UiPageId = 10, Fields = uiPageMetaDataModels, FieldValues = null });


            genericRepositoryuipageData.Setup(x => x.Get<int>("RecordId", It.IsAny<int>())).Returns(uiPageDataModels);


            var logger = new Mock<ILogger<CommonController>>();

            _commonService = new SampleService(commonRepository.Object, igenericRepository.Object, iGenericRepositoryPageType.Object, genericRepositoryuipageData.Object, iGenericRepositoryPageMetaData.Object, iGenericRepositoryPageValidation.Object);
            var controller = new CommonController(logger.Object, _commonService, _mapper);

            var result = (ViewResult)controller.Delete(12);

            List<UiPageMetadataDTO> uiPageMetadataDTO = new List<UiPageMetadataDTO>();
            uiPageMetadataDTO.Add(new UiPageMetadataDTO { Id = 5, UiPageTypeId = 10, UiPageTypeName = null, UiControlTypeId = 6, UiControlTypeName = null, UiControlDisplayName = "Year", IsRequired = false, DataTypeId = 12, DataTypeName = "int" });

            List<UiPageDataDTO> uiPageDTO = new List<UiPageDataDTO>();
            uiPageDTO.Add(new UiPageDataDTO { UiPageId = 10, UiPageMetadataId = 4, Value = "Ritesh1244" });
            uiPageDTO.Add(new UiPageDataDTO { UiPageId = 10, UiPageMetadataId = 5, Value = "Ritesh44" });

            var expectedResult = new RecordDTO { Id = 12, UiPageId = 10, Fields = uiPageMetadataDTO, FieldValues = uiPageDTO };

            result.Model.Should().BeEquivalentTo(expectedResult);

        }
        /// <summary>
        /// Delete post method 
        /// </summary>
        [Test]
        public void Common_Delete_Post_Test()
        {

            var logger = new Mock<ILogger<CommonController>>();

            _commonService = new SampleService(commonRepository.Object, igenericRepository.Object, iGenericRepositoryPageType.Object, genericRepositoryuipageData.Object, iGenericRepositoryPageMetaData.Object, iGenericRepositoryPageValidation.Object);
            var controller = new CommonController(logger.Object, _commonService, _mapper);

            var result = (RedirectToActionResult)controller.DeleteConfirmed(12);
            igenericRepository.Setup(x => x.Delete(It.IsAny<int>()));
            var expectedResult = "index";
            result.ActionName.Should().BeEquivalentTo(expectedResult);

        }
        /// <summary>
        /// passing null value to Delete Post method
        /// </summary>
        [Test]
        public void Common_Delete_Post_NUll_Val()
        {

            var logger = new Mock<ILogger<CommonController>>();

            _commonService = new SampleService(commonRepository.Object, igenericRepository.Object, iGenericRepositoryPageType.Object, genericRepositoryuipageData.Object, iGenericRepositoryPageMetaData.Object, iGenericRepositoryPageValidation.Object);
            var controller = new CommonController(logger.Object, _commonService, _mapper);

            var result = (NotFoundResult)controller.DeleteConfirmed(null);
            igenericRepository.Setup(x => x.Delete(It.IsAny<int>()));
            var expectedResult = 404;
            result.StatusCode.Should().Be(expectedResult);

        }
    }
}

