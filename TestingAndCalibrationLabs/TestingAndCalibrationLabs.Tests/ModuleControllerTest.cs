using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
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

namespace TestingAndCalibrationLabs.Tests
{
    [TestFixture]
    public class ModuleControllerTest
    {
        IMapper _mapper;
        IApplicationService _applicationService;
        IModuleService _moduleService;



        Mock<IModuleRepository> moduleRepository = new Mock<IModuleRepository>();
        Mock<IGenericRepository<ModuleModel>> genericRepository = new Mock<IGenericRepository<ModuleModel>>();


        [SetUp]
        public void SetUp()
        {
            var profile = new MappingProfile();
            var Configuration = new MapperConfiguration(x => x.AddProfile(profile));
            var mapper = new Mapper(Configuration);
            _mapper = mapper;

        }

        [Test]
        public void Index_Method_Test()
        {
            List<ModuleModel> moduleModel = new List<ModuleModel>();
            moduleModel.Add(new ModuleModel { Id = 3, Name = "aman", ApplicationId = 8, ApplicationName = "ritesh" });
            moduleModel.Add(new ModuleModel { Id = 5, Name = "amane", ApplicationId = 85, ApplicationName = "tritesh" });

            _moduleService = new ModuleService(genericRepository.Object, moduleRepository.Object);

            moduleRepository.Setup(x => x.Get()).Returns(moduleModel);

            //   moduleRepository.Setup(x => x.Get().Returns(moduleModel);
            // genericRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(moduleModel);

            var controller = new ModuleController(_mapper, _moduleService, _applicationService);


            var result = (ViewResult)controller.Index();
            //Expected Result
            List<ModuleDTO> moduleDTO = new List<ModuleDTO>();
            moduleDTO.Add(new ModuleDTO { Id = 3, Name = "aman", ApplicationId = 8, ApplicationName = "ritesh" });
            moduleDTO.Add(new ModuleDTO { Id = 5, Name = "amane", ApplicationId = 85, ApplicationName = "tritesh" });


            var ExpectedResult = moduleDTO;

            result.Model.Should().BeEquivalentTo(ExpectedResult);

        }
        [Test]
        public void Edit()
        {
            //List<ApplicationDTO> applicationModel = new List<ApplicationDTO>();
            //applicationModel.Add(new ApplicationDTO { Id = 3, Name = "Aman", Description = "Kumar" });
            //applicationModel.Add(new ApplicationDTO { Id = 6, Name = "Amane", Description = "Kiumar" });


            //List<ModuleModel> moduleModel = new List<ModuleModel>();
            //moduleModel.Add(new ModuleModel { Id = 3, Name = "aman", ApplicationId = 8, ApplicationName = "ritesh" });
            //moduleModel.Add(new ModuleModel { Id = 5, Name = "amane", ApplicationId = 85, ApplicationName = "tritesh" });


            _moduleService = new ModuleService(genericRepository.Object, moduleRepository.Object);
            // _applicationService = new ApplicationService(genericRepository.Object);
            //  genericRepository.Setup(x => x.Get()).Returns();
            moduleRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(new ModuleModel { Id = 3, Name = "aman", ApplicationId = 8, ApplicationName = "ritesh" });

            var controller = new ModuleController(_mapper, _moduleService, _applicationService);

            var result = (ViewResult)controller.Edit(3);
            var ExpectedResult = new ModuleDTO() { Id = 3, Name = "aman", ApplicationId = 8, ApplicationName = "ritesh" };

            result.Model.Should().BeEquivalentTo(ExpectedResult);


        }

        [Test]
        public void Edit_getbyId_null_Id()
        {

            _moduleService = new ModuleService(genericRepository.Object, moduleRepository.Object);
            // _applicationService = new ApplicationService(genericRepository.Object);
            //  genericRepository.Setup(x => x.Get()).Returns();
            moduleRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(new ModuleModel { Id = 3, Name = "aman", ApplicationId = 8, ApplicationName = "ritesh" });

            var controller = new ModuleController(_mapper, _moduleService, _applicationService);

            var createResult = (NotFoundResult)controller.Edit(0);
            //  var ExpectedResult = new ModuleDTO() { Id = 3, Name = "aman", ApplicationId = 8, ApplicationName = "ritesh" };
            var expectedResult = 404;

            createResult.StatusCode.Should().Be(expectedResult);



        }
        [Test]
        public void Edit_Get_NullId_Test()
        {
            _moduleService = new ModuleService(genericRepository.Object, moduleRepository.Object);

            var controller = new ModuleController(_mapper, _moduleService, _applicationService);

            var createResult = (NotFoundResult)controller.Edit(0);

            var expectedResult = 404;

            createResult.StatusCode.Should().Be(expectedResult);


        }
        [Test]
        public void Edit_post_Test()
        {
            ModuleModel moduleModel = new ModuleModel { Id = 3, Name = "aman", ApplicationId = 8, ApplicationName = "ritesh" };

            var moduleDTO = new ModuleDTO { Id = 3, Name = "aman", ApplicationId = 8, ApplicationName = "ritesh" };

            _moduleService = new ModuleService(genericRepository.Object, moduleRepository.Object);

            moduleRepository.Setup(x => x.Update(moduleModel)).Returns(0);

            var controller = new ModuleController(_mapper, _moduleService, _applicationService);


            var createResult = (RedirectToActionResult)controller.Edit(moduleDTO);
            var expectedResult = "Index";

            createResult.ActionName.Should().BeEquivalentTo(expectedResult);

        }
        [Test]
        public void Create_Get()
        {


            _moduleService = new ModuleService(genericRepository.Object, moduleRepository.Object);

            var controller = new ModuleController(_mapper, _moduleService, _applicationService);

            var result = (ViewResult)controller.Create(3);
            var ExpectedResult = new ModuleDTO() { Id = 3 };

            result.Model.Should().BeEquivalentTo(ExpectedResult);


        }
        [Test]
        public void Create_post_Test()
        {

            ModuleModel moduleModel = new ModuleModel { Id = 3, Name = "aman", ApplicationId = 8, ApplicationName = "ritesh" };

            var moduleDTO = new ModuleDTO { Id = 3, Name = "aman", ApplicationId = 8, ApplicationName = "ritesh" };

            moduleRepository.Setup(x => x.Create(moduleModel)).Returns(0);

            _moduleService = new ModuleService(genericRepository.Object, moduleRepository.Object);
            var controller = new ModuleController(_mapper, _moduleService, _applicationService);


            var createResult = (RedirectToActionResult)controller.Create(moduleDTO);
            var expectedResult = "Index";

            createResult.ActionName.Should().BeEquivalentTo(expectedResult);


        }
        [Test]
        public void Delete()
        {

            moduleRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(new ModuleModel { Id = 3, Name = "aman", ApplicationId = 8, ApplicationName = "ritesh" });
            _moduleService = new ModuleService(genericRepository.Object, moduleRepository.Object);

            var controller = new ModuleController(_mapper, _moduleService, _applicationService);

            var result = (ViewResult)controller.Delete(3);
            var ExpectedResult = new ModuleDTO() { Id = 3, Name = "aman", ApplicationId = 8, ApplicationName = "ritesh" };

            result.Model.Should().BeEquivalentTo(ExpectedResult);

        }
        [Test]
        public void Delete_get_null_Id()
        {

            _moduleService = new ModuleService(genericRepository.Object, moduleRepository.Object);
            var controller = new ModuleController(_mapper, _moduleService, _applicationService);

            var createResult = (NotFoundResult)controller.Delete(null);
            //   moduleRepository.Setup(x => x.Delete(It.IsAny<int>()));

            var expectedResult = 404;

            createResult.StatusCode.Should().Be(expectedResult);



        }

        [Test]
        public void Delete_getbyId_null()
        {
            moduleRepository.Setup(x => x.GetById(It.IsAny<int>()));

            _moduleService = new ModuleService(genericRepository.Object, moduleRepository.Object);
            var controller = new ModuleController(_mapper, _moduleService, _applicationService);

            var createResult = (NotFoundResult)controller.Delete(5);


            var expectedResult = 404;

            createResult.StatusCode.Should().Be(expectedResult);


        }
        //[Test]
        //public void Delete_Confirmed()
        //{

        //    moduleRepository.Setup(x => x.Delete(It.IsAny<int>())).Returns(true);

        //    _moduleService = new ModuleService(genericRepository.Object, moduleRepository.Object);
        //    var controller = new ModuleController(_mapper, _moduleService, _applicationService);


        //    var createResult = (RedirectToActionResult)controller.DeleteConfirmed(5);
        //    var expectedResult = "Index";

        //    createResult.ActionName.Should().BeEquivalentTo(expectedResult);


        //}
        [Test]
        public void Delete_Confirmed_IdNull()
        {

            _moduleService = new ModuleService(genericRepository.Object, moduleRepository.Object);
            var controller = new ModuleController(_mapper, _moduleService, _applicationService);

            var createResult = (NotFoundResult)controller.DeleteConfirmed(null);

            var expectedResult = 404;

            createResult.StatusCode.Should().Be(expectedResult);




        }
    }
}