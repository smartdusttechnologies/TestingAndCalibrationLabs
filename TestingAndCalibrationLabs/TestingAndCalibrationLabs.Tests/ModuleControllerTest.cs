//using AutoMapper;
//using FluentAssertions;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using Moq;
//using MySqlX.XDevAPI.Common;
//using NUnit.Framework;
//using System.Collections.Generic;
//using TestingAndCalibrationLabs.Business.Core.Interfaces;
//using TestingAndCalibrationLabs.Business.Core.Model;
//using TestingAndCalibrationLabs.Business.Data.Repository;
//using TestingAndCalibrationLabs.Business.Data.Repository.common;
//using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
//using TestingAndCalibrationLabs.Business.Services;
//using TestingAndCalibrationLabs.Business.Services.TestingAndCalibrationService;
//using TestingAndCalibrationLabs.Web.UI.Controllers;
//using TestingAndCalibrationLabs.Web.UI.Mappers;
//using TestingAndCalibrationLabs.Web.UI.Models;

//namespace TestingAndCalibrationLabs.Tests
//{
//    [TestFixture]
//    public class ModuleControllerTest
//    {
//        IMapper _mapper;
//        IApplicationService _applicationService;
//        IModuleService _moduleService;



//        Mock<IModuleRepository> moduleRepository = new Mock<IModuleRepository>();
//        Mock<IGenericRepository<ModuleModel>> genericRepository = new Mock<IGenericRepository<ModuleModel>>();


//        [SetUp]
//        public void SetUp()
//        {
//            var profile = new MappingProfile();
//            var Configuration = new MapperConfiguration(x => x.AddProfile(profile));
//            var mapper = new Mapper(Configuration);
//            _mapper = mapper;

//        }

//        [Test]
//        public void Common_Index_Method_Test()
//        {
//            List<ModuleModel> moduleModel = new List<ModuleModel>();
//            moduleModel.Add(new ModuleModel { Id = 3, Name = "aman", ApplicationId = 8, ApplicationName = "ritesh" });

//            _moduleService = new ModuleService(genericRepository.Object,moduleRepository.Object);

//          //  moduleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new ModuleModel { Id = 1, Name = "Aman", ApplicationId = 8, ApplicationName = "ritesh" });
//            genericRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new ModuleModel { Id = 1, Name = "Aman", ApplicationId = 8, ApplicationName = "ritesh" });

//            var controller = new ModuleController(_mapper, _moduleService, _applicationService);


//            var result = (ViewResult)controller.Index();
//            //Expected Result
//            List<ModuleDTO> moduleDTO = new List<ModuleDTO>();


//            var ExpectedResult = new ModuleDTO() { Id = 3, Name = "aman", ApplicationId = 8, ApplicationName = "ritesh" };

//            result.Model.Should().BeEquivalentTo(ExpectedResult);



//        }
//    }
//}

