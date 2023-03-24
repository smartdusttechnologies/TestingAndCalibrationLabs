using AutoMapper;
using FluentAssertions;
using MailKit.Search;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Mysqlx.Crud;
using Mysqlx.Session;
using MySqlX.XDevAPI.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository;
using TestingAndCalibrationLabs.Business.Data.Repository.BackOffice;
using TestingAndCalibrationLabs.Business.Data.Repository.common;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Services;
using TestingAndCalibrationLabs.Web.UI.Controllers;
using TestingAndCalibrationLabs.Web.UI.Mappers;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Tests
{
    [TestFixture]
    public class WorkflowStageControllerTest
    {
          IWorkflowStageService _workflowStageService;
          IWorkflowService _workflowService;
          IUiPageTypeService _uiPageTypeService;
          IMapper _mapper;

        Mock<IWorkflowRepository> workflowRepository = new Mock<IWorkflowRepository>();
        Mock<IWorkflowStageRepository> workflowStageRepository = new Mock<IWorkflowStageRepository>();
        Mock<IGenericRepository<UiPageTypeModel>> genericRepository = new Mock<IGenericRepository<UiPageTypeModel>>();
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
            List<WorkflowStageModel> workflowStageModel = new List<WorkflowStageModel>();
            workflowStageModel.Add(new WorkflowStageModel { Id = 6, Name = "Aman", UiPageTypeId = 5, UiPageTypeName = "aman", WorkflowId = 6, WorkflowName = "ritesh", Orders =4});
            workflowStageModel.Add(new WorkflowStageModel { Id = 26, Name = "wAman", UiPageTypeId = 75, UiPageTypeName = "daman", WorkflowId = 46, WorkflowName = "jritesh", Orders = 54 });


            _workflowStageService = new WorkflowStageService(workflowStageRepository.Object);

            workflowStageRepository.Setup(x => x.Get()).Returns(workflowStageModel);


            var controller = new WorkflowStageController(_workflowStageService, _mapper, _uiPageTypeService, _workflowService);

            var result = (ViewResult)controller.Index();

            List<WorkflowStageDTO> workflowStageDTO = new List<WorkflowStageDTO>();
            workflowStageDTO.Add(new WorkflowStageDTO { Id = 6, Name = "Aman", UiPageTypeId = 5, UiPageTypeName = "aman", WorkflowId = 6, WorkflowName = "ritesh", Orders = 4 });
            workflowStageDTO.Add(new WorkflowStageDTO { Id = 26, Name = "wAman", UiPageTypeId = 75, UiPageTypeName = "daman", WorkflowId = 46, WorkflowName = "jritesh", Orders = 54 });

            var ExpectedResult = workflowStageDTO;

            result.Model.Should().BeEquivalentTo(ExpectedResult);


        }
        [Test]
        public void Edit_Get_Test()
        {
            //List<WorkflowActivityModel> workflowActivityModel = new List<WorkflowActivityModel>();
            //workflowActivityModel.Add(new WorkflowActivityModel { Id = 6, Name = "Aman", ActivityId = 5, ActivityName = "aman", WorkflowStageId = 6, WorkflowStageName = "ritesh" });
            //workflowActivityModel.Add(new WorkflowActivityModel { Id = 36, Name = "wAman", ActivityId = 35, ActivityName = "faman", WorkflowStageId = 65, WorkflowStageName = "writesh" });

              _workflowStageService = new WorkflowStageService(workflowStageRepository.Object);

            workflowStageRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(new WorkflowStageModel { Id = 6, Name = "Aman", UiPageTypeId = 5, UiPageTypeName = "aman", WorkflowId = 6, WorkflowName = "ritesh", Orders = 4 });
            var controller = new WorkflowStageController(_workflowStageService, _mapper, _uiPageTypeService, _workflowService);

            var result = (ViewResult)controller.Edit(6);
            var ExpectedResult = new WorkflowStageDTO() { Id = 6, Name = "Aman", UiPageTypeId = 5, UiPageTypeName = "aman", WorkflowId = 6, WorkflowName = "ritesh", Orders = 4 };

            result.Model.Should().BeEquivalentTo(ExpectedResult);



        }
        [Test]
        public void Edit_get_null_Id()
        {
            _workflowStageService = new WorkflowStageService(workflowStageRepository.Object);


            var controller = new WorkflowStageController(_workflowStageService, _mapper, _uiPageTypeService, _workflowService);

            var createResult = (NotFoundResult)controller.Edit(null);

            var expectedResult = 404;

            createResult.StatusCode.Should().Be(expectedResult);



        }
        [Test]
        public void Edit_post_Test()
        {

            WorkflowStageModel workflowStageModel = new WorkflowStageModel { Id = 6, Name = "Aman", UiPageTypeId = 5, UiPageTypeName = "aman", WorkflowId = 6, WorkflowName = "ritesh", Orders = 4 };

            var workflowStageDTO = new WorkflowStageDTO { Id = 6, Name = "Aman", UiPageTypeId = 5, UiPageTypeName = "aman", WorkflowId = 6, WorkflowName = "ritesh", Orders = 4 };

            _workflowStageService = new WorkflowStageService(workflowStageRepository.Object);

            workflowStageRepository.Setup(x => x.Update(workflowStageModel)).Returns(0);

            var controller = new WorkflowStageController(_workflowStageService, _mapper, _uiPageTypeService, _workflowService);
            var createResult = (RedirectToActionResult)controller.Edit(6, workflowStageDTO);
            var expectedResult = "Index";

            createResult.ActionName.Should().BeEquivalentTo(expectedResult);



        }
        [Test]
        public void Edit_Null_Id_Post_Test()
        {
            var workflowStageDTO = new WorkflowStageDTO { Id = 6, Name = "Aman", UiPageTypeId = 5, UiPageTypeName = "aman", WorkflowId = 6, WorkflowName = "ritesh", Orders = 4 };


            _workflowStageService = new WorkflowStageService(workflowStageRepository.Object);

            var controller = new WorkflowStageController(_workflowStageService, _mapper, _uiPageTypeService, _workflowService);

            var createResult = (NotFoundResult)controller.Edit(1, workflowStageDTO);
            var expectedResult = 404;

            createResult.StatusCode.Should().Be(expectedResult);


        }
        [Test]
        public void Create_post_Test()
        {
            WorkflowStageModel workflowStageModel = new WorkflowStageModel { Id = 6, Name = "Aman", UiPageTypeId = 5, UiPageTypeName = "aman", WorkflowId = 6, WorkflowName = "ritesh", Orders = 4 };

            var workflowStageDTO = new WorkflowStageDTO { Id = 6, Name = "Aman", UiPageTypeId = 5, UiPageTypeName = "aman", WorkflowId = 6, WorkflowName = "ritesh", Orders = 4 };



            _workflowStageService = new WorkflowStageService(workflowStageRepository.Object);


            workflowStageRepository.Setup(x => x.Create(workflowStageModel)).Returns(0);


            // _workflowActivityService = new WorkflowActivityService(workflowActivityRepository.Object, genericRepository.Object);

            var controller = new WorkflowStageController(_workflowStageService, _mapper, _uiPageTypeService, _workflowService);

            var createResult = (RedirectToActionResult)controller.Create(workflowStageDTO);
            var expectedResult = "Index";

            createResult.ActionName.Should().BeEquivalentTo(expectedResult);






        }
        [Test]
        public void Delete_get_Test()
        {
            WorkflowStageModel workflowStageModel = new WorkflowStageModel { Id = 6, Name = "Aman", UiPageTypeId = 5, UiPageTypeName = "aman", WorkflowId = 6, WorkflowName = "ritesh", Orders = 4 };

            _workflowStageService = new WorkflowStageService(workflowStageRepository.Object);

            workflowStageRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(workflowStageModel);

            var controller = new WorkflowStageController(_workflowStageService, _mapper, _uiPageTypeService, _workflowService);

            var createResult = (ViewResult)controller.Delete(6);
            var expectedResult = new WorkflowStageDTO() { Id = 6, Name = "Aman", UiPageTypeId = 5, UiPageTypeName = "aman", WorkflowId = 6, WorkflowName = "ritesh", Orders = 4 };

            createResult.Model.Should().BeEquivalentTo(expectedResult);



        }
        [Test]
        public void Delete_get_null_Id()
        {

            _workflowStageService = new WorkflowStageService(workflowStageRepository.Object);
            var controller = new WorkflowStageController(_workflowStageService, _mapper, _uiPageTypeService, _workflowService);

            var createResult = (NotFoundResult)controller.Delete(null);

            var expectedResult = 404;

            createResult.StatusCode.Should().Be(expectedResult);



        }
        [Test]
        public void DeleteConfirmed_Test()
        {
            workflowStageRepository.Setup(x => x.Delete(It.IsAny<int>())).Returns(true);

            _workflowStageService = new WorkflowStageService(workflowStageRepository.Object);
            var controller = new WorkflowStageController(_workflowStageService, _mapper, _uiPageTypeService, _workflowService);


            var createResult = (RedirectToActionResult)controller.DeleteConfirmed(5);
            var expectedResult = "Index";

            createResult.ActionName.Should().BeEquivalentTo(expectedResult);



        }
        [Test]
        public void Delete_Confirmed_IdNull()
        {

            _workflowStageService = new WorkflowStageService(workflowStageRepository.Object);
            var controller = new WorkflowStageController(_workflowStageService, _mapper, _uiPageTypeService, _workflowService);

            var createResult = (NotFoundResult)controller.DeleteConfirmed(null);

            var expectedResult = 404;

            createResult.StatusCode.Should().Be(expectedResult);




        }
    }
}

