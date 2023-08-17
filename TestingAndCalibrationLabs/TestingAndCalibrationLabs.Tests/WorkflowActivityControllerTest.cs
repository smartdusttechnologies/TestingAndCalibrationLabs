using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    public class WorkflowActivityControllerTest
    {
        IActivityService _activityService;
        IWorkflowActivityService _workflowActivityService;
        IMapper _mapper;
        IWorkflowStageService _workflowStageService;

        Mock<IGenericRepository<UiPageDataModel>> genericRepository = new Mock<IGenericRepository<UiPageDataModel>>();
        Mock<IWorkflowActivityRepository> workflowActivityRepository = new Mock<IWorkflowActivityRepository>();
        Mock<IConfiguration> configuration = new Mock<IConfiguration>();
        Mock<IWebHostEnvironment> webhost = new Mock<IWebHostEnvironment>();
        Mock<IEmailService> emailservice = new Mock<IEmailService>();
        Mock<IActivityMetadataService> activity = new Mock<IActivityMetadataService>();
        Mock<IGenericRepository<WorkflowActivityModel>> activityGeneric = new Mock<IGenericRepository<WorkflowActivityModel>>();

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
            List<WorkflowActivityModel> workflowActivityModel = new List<WorkflowActivityModel>();
            workflowActivityModel.Add(new WorkflowActivityModel { Id = 6, Name = "Aman", ActivityId = 5, ActivityName = "aman", WorkflowStageId = 6, WorkflowStageName = "ritesh" });
            workflowActivityModel.Add(new WorkflowActivityModel { Id = 36, Name = "wAman", ActivityId = 35, ActivityName = "faman", WorkflowStageId = 65, WorkflowStageName = "writesh" });


            _workflowActivityService = new WorkflowActivityService(configuration.Object,webhost.Object,emailservice.Object,activity.Object, workflowActivityRepository.Object, genericRepository.Object,activityGeneric.Object);

            workflowActivityRepository.Setup(x => x.Get()).Returns(workflowActivityModel);


            var controller = new WorkflowActivityController(_mapper, _workflowStageService, _activityService, _workflowActivityService);

            var result = (ViewResult)controller.Index();

            List<WorkflowActivityDTO> workflowActivityDTO = new List<WorkflowActivityDTO>();
            workflowActivityDTO.Add(new WorkflowActivityDTO { Id = 6, Name = "Aman", ActivityId = 5, ActivityName = "aman", WorkflowStageId = 6, WorkflowStageName = "ritesh" });
            workflowActivityDTO.Add(new WorkflowActivityDTO { Id = 36, Name = "wAman", ActivityId = 35, ActivityName = "faman", WorkflowStageId = 65, WorkflowStageName = "writesh" });

            var ExpectedResult = workflowActivityDTO;

            result.Model.Should().BeEquivalentTo(ExpectedResult);


        }
        [Test]
        public void Edit_Get_Test()
        {
            //List<WorkflowActivityModel> workflowActivityModel = new List<WorkflowActivityModel>();
            //workflowActivityModel.Add(new WorkflowActivityModel { Id = 6, Name = "Aman", ActivityId = 5, ActivityName = "aman", WorkflowStageId = 6, WorkflowStageName = "ritesh" });
            //workflowActivityModel.Add(new WorkflowActivityModel { Id = 36, Name = "wAman", ActivityId = 35, ActivityName = "faman", WorkflowStageId = 65, WorkflowStageName = "writesh" });

            _workflowActivityService = new WorkflowActivityService(configuration.Object, webhost.Object, emailservice.Object, activity.Object, workflowActivityRepository.Object, genericRepository.Object, activityGeneric.Object);

            workflowActivityRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(new WorkflowActivityModel { Id = 6, Name = "Aman", ActivityId = 5, ActivityName = "aman", WorkflowStageId = 6, WorkflowStageName = "ritesh" });
            var controller = new WorkflowActivityController(_mapper, _workflowStageService, _activityService, _workflowActivityService);

            var result = (ViewResult)controller.Edit(6);
            var ExpectedResult = new WorkflowActivityDTO() { Id = 6, Name = "Aman", ActivityId = 5, ActivityName = "aman", WorkflowStageId = 6, WorkflowStageName = "ritesh" };

            result.Model.Should().BeEquivalentTo(ExpectedResult);



        }
        [Test]
        public void Edit_get_null_Id()
        {

            _workflowActivityService = new WorkflowActivityService(configuration.Object, webhost.Object, emailservice.Object, activity.Object, workflowActivityRepository.Object, genericRepository.Object, activityGeneric.Object);

            var controller = new WorkflowActivityController(_mapper, _workflowStageService, _activityService, _workflowActivityService);

            var createResult = (NotFoundResult)controller.Edit(null);
            var expectedResult = 404;

            createResult.StatusCode.Should().Be(expectedResult);



        }
        [Test]
        public void Edit_post_Test()
        {

            WorkflowActivityModel workflowActivityModel = new WorkflowActivityModel { Id = 6, Name = "Aman", ActivityId = 5, ActivityName = "aman", WorkflowStageId = 6, WorkflowStageName = "ritesh" };

            var workflowActivityDTO = new WorkflowActivityDTO { Id = 6, Name = "Aman", ActivityId = 5, ActivityName = "aman", WorkflowStageId = 6, WorkflowStageName = "ritesh" };

            _workflowActivityService = new WorkflowActivityService(configuration.Object, webhost.Object, emailservice.Object, activity.Object, workflowActivityRepository.Object, genericRepository.Object, activityGeneric.Object);

            workflowActivityRepository.Setup(x => x.Update(workflowActivityModel)).Returns(0);

            var controller = new WorkflowActivityController(_mapper, _workflowStageService, _activityService, _workflowActivityService);
            var createResult = (RedirectToActionResult)controller.Edit(6, workflowActivityDTO);
            var expectedResult = "Index";

            createResult.ActionName.Should().BeEquivalentTo(expectedResult);



        }
        [Test]
        public void Edit_Null_Id_Post_Test()
        {
            var workflowActivityDTO = new WorkflowActivityDTO { Id = 6, Name = "Aman", ActivityId = 5, ActivityName = "aman", WorkflowStageId = 6, WorkflowStageName = "ritesh" };


            _workflowActivityService = new WorkflowActivityService(configuration.Object, webhost.Object, emailservice.Object, activity.Object, workflowActivityRepository.Object, genericRepository.Object, activityGeneric.Object);

            var controller = new WorkflowActivityController(_mapper, _workflowStageService, _activityService, _workflowActivityService);

            var createResult = (NotFoundResult)controller.Edit(1, workflowActivityDTO);
            var expectedResult = 404;

            createResult.StatusCode.Should().Be(expectedResult);


        }
        [Test]
        public void Create_Get_Test()
        {

            _workflowActivityService = new WorkflowActivityService(configuration.Object, webhost.Object, emailservice.Object, activity.Object, workflowActivityRepository.Object, genericRepository.Object, activityGeneric.Object);

            var controller = new WorkflowActivityController(_mapper, _workflowStageService, _activityService, _workflowActivityService);

            var result = (ViewResult)controller.Create(6);
            var ExpectedResult = new WorkflowActivityDTO() { Id = 6 };

            result.Model.Should().BeEquivalentTo(ExpectedResult);



        }
        [Test]
        public void Create_post_Test()
        {
            WorkflowActivityModel workflowActivityModel = new WorkflowActivityModel { Id = 6, Name = "Aman", ActivityId = 5, ActivityName = "aman", WorkflowStageId = 6, WorkflowStageName = "ritesh" };

            var workflowActivityDTO = new WorkflowActivityDTO { Id = 6, Name = "Aman", ActivityId = 5, ActivityName = "aman", WorkflowStageId = 6, WorkflowStageName = "ritesh" };



            _workflowActivityService = new WorkflowActivityService(configuration.Object, webhost.Object, emailservice.Object, activity.Object, workflowActivityRepository.Object, genericRepository.Object, activityGeneric.Object);
            workflowActivityRepository.Setup(x => x.Create(workflowActivityModel)).Returns(0);


            // _workflowActivityService = new WorkflowActivityService(workflowActivityRepository.Object, genericRepository.Object);

            var controller = new WorkflowActivityController(_mapper, _workflowStageService, _activityService, _workflowActivityService);

            var createResult = (RedirectToActionResult)controller.Create(workflowActivityDTO);
            var expectedResult = "Index";

            createResult.ActionName.Should().BeEquivalentTo(expectedResult);






        }
        [Test]
        public void Delete_get_Test()
        {
            WorkflowActivityModel workflowActivityModel = new WorkflowActivityModel { Id = 6, Name = "Aman", ActivityId = 5, ActivityName = "aman", WorkflowStageId = 6, WorkflowStageName = "ritesh" };

            _workflowActivityService = new WorkflowActivityService(configuration.Object, webhost.Object, emailservice.Object, activity.Object, workflowActivityRepository.Object, genericRepository.Object, activityGeneric.Object);
            workflowActivityRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(workflowActivityModel);

            var controller = new WorkflowActivityController(_mapper, _workflowStageService, _activityService, _workflowActivityService);

            var createResult = (ViewResult)controller.Delete(6);
            var expectedResult = new WorkflowActivityDTO() { Id = 6, Name = "Aman", ActivityId = 5, ActivityName = "aman", WorkflowStageId = 6, WorkflowStageName = "ritesh" };

            createResult.Model.Should().BeEquivalentTo(expectedResult);



        }
        [Test]
        public void Delete_get_null_Id()
        {


            _workflowActivityService = new WorkflowActivityService(configuration.Object, webhost.Object, emailservice.Object, activity.Object, workflowActivityRepository.Object, genericRepository.Object, activityGeneric.Object);
            var controller = new WorkflowActivityController(_mapper, _workflowStageService, _activityService, _workflowActivityService);

            var createResult = (NotFoundResult)controller.Delete(null);

            var expectedResult = 404;

            createResult.StatusCode.Should().Be(expectedResult);



        }

        [Test]
        public void Delete_Confirmed_IdNull()
        {

            _workflowActivityService = new WorkflowActivityService(configuration.Object, webhost.Object, emailservice.Object, activity.Object, workflowActivityRepository.Object, genericRepository.Object, activityGeneric.Object);
            var controller = new WorkflowActivityController(_mapper, _workflowStageService, _activityService, _workflowActivityService);

            var createResult = (NotFoundResult)controller.DeleteConfirmed(null);

            var expectedResult = 404;

            createResult.StatusCode.Should().Be(expectedResult);




        }

    }
}
