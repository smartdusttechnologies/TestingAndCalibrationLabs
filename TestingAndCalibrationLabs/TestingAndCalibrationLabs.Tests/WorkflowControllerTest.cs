using AutoMapper;
using FluentAssertions;
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
    public class WorkFlowControllerTest
    {
          IWorkflowService _workflowService;
          IMapper _mapper;
          IModuleService _moduleService;

        Mock<IModuleRepository> genericRepository = new Mock<IModuleRepository>();
        Mock<IWorkflowRepository> workflowRepository = new Mock<IWorkflowRepository>();

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
            List<WorkflowModel> workflowModel = new List<WorkflowModel>();
            workflowModel.Add(new WorkflowModel { Id = 6, Name = "Aman", ModuleId = 5, ModuleName = "aman"});
            workflowModel.Add(new WorkflowModel { Id = 26, Name = "eAman", ModuleId =25, ModuleName = "eaman" });

            _workflowService = new WorkflowService(workflowRepository.Object);

            workflowRepository.Setup(x => x.Get()).Returns(workflowModel);


            var controller = new WorkFlowController(_workflowService,_mapper, _moduleService);

            var result = (ViewResult)controller.Index();
            List<WorkflowDTO> workflowDTO = new List<WorkflowDTO>();
            workflowDTO.Add(new WorkflowDTO { Id = 6, Name = "Aman", ModuleId = 5, ModuleName = "aman" });
            workflowDTO.Add(new WorkflowDTO { Id = 26, Name = "eAman", ModuleId = 25, ModuleName = "eaman" });

            var ExpectedResult = workflowDTO;

            result.Model.Should().BeEquivalentTo(ExpectedResult);

        }
        [Test]
        public void Edit_Get_Test()
        {
            _workflowService = new WorkflowService(workflowRepository.Object);


            workflowRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(new WorkflowModel { Id = 6, Name = "Aman", ModuleId = 5, ModuleName = "aman" });
            var controller = new WorkFlowController(_workflowService, _mapper, _moduleService);

            var result = (ViewResult)controller.Edit(6);
            var ExpectedResult = new WorkflowDTO() { Id = 6, Name = "Aman", ModuleId = 5, ModuleName = "aman" };

            result.Model.Should().BeEquivalentTo(ExpectedResult);



        }

        [Test]
        public void Edit_post_Test()
        {
            WorkflowModel workflowModel = new WorkflowModel { Id = 6, Name = "Aman", ModuleId = 5, ModuleName = "aman" };

            var workflowDTO = new WorkflowDTO { Id = 6, Name = "Aman", ModuleId = 5, ModuleName = "aman" };

            _workflowService = new WorkflowService(workflowRepository.Object);

            workflowRepository.Setup(x => x.Update(workflowModel)).Returns(0);

            var controller = new WorkFlowController(_workflowService, _mapper, _moduleService);
            var createResult = (RedirectToActionResult)controller.Edit(6, workflowDTO);
            var expectedResult = "Index";

            createResult.ActionName.Should().BeEquivalentTo(expectedResult);




        }
        [Test]
        public void Create_post_Test()
        {
            WorkflowModel workflowModel = new WorkflowModel { Id = 6, Name = "Aman", ModuleId = 5, ModuleName = "aman" };

            var workflowDTO = new WorkflowDTO { Id = 6, Name = "Aman", ModuleId = 5, ModuleName = "aman" };



            _workflowService = new WorkflowService(workflowRepository.Object);

            workflowRepository.Setup(x => x.Create(workflowModel)).Returns(0);

            var controller = new WorkFlowController(_workflowService, _mapper, _moduleService);

            var createResult = (RedirectToActionResult)controller.Create(workflowDTO);
            var expectedResult = "Index";

            createResult.ActionName.Should().BeEquivalentTo(expectedResult);







        }
        [Test]
        public void Delete_get_Test()
        {

            WorkflowModel workflowModel = new WorkflowModel { Id = 6, Name = "Aman", ModuleId = 5, ModuleName = "aman" };

            _workflowService = new WorkflowService(workflowRepository.Object);

            workflowRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(workflowModel);

            var controller = new WorkFlowController(_workflowService, _mapper, _moduleService);

            var createResult = (ViewResult)controller.Delete(6);
            var expectedResult = new WorkflowDTO() { Id = 6, Name = "Aman", ModuleId = 5, ModuleName = "aman" };

            createResult.Model.Should().BeEquivalentTo(expectedResult);



        }
        [Test]
        public void DeleteConfirmed_Test()
        {
            workflowRepository.Setup(x => x.Delete(It.IsAny<int>())).Returns(true);


            _workflowService = new WorkflowService(workflowRepository.Object);
            var controller = new WorkFlowController(_workflowService, _mapper, _moduleService);


            var createResult = (RedirectToActionResult)controller.DeleteConfirmed(5);
            var expectedResult = "Index";

            createResult.ActionName.Should().BeEquivalentTo(expectedResult);



        }
    }
}

