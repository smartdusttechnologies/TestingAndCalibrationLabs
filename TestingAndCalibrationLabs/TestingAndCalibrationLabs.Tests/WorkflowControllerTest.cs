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
    public class WorkFlowControllerTest
    {
        IWorkflowService _workflowService;
        IMapper _mapper;
        IModuleService _moduleService;

        Mock<IModuleRepository> genericRepository = new Mock<IModuleRepository>();
        Mock<IWorkflowRepository> workflowRepository = new Mock<IWorkflowRepository>();
        Mock<IGenericRepository<WorkflowModel>> _genericRepository = new Mock<IGenericRepository<WorkflowModel>>();

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
            workflowModel.Add(new WorkflowModel { Id = 6, Name = "Aman", ModuleId = 5, Module = "aman" });
            workflowModel.Add(new WorkflowModel { Id = 26, Name = "eAman", ModuleId = 25, Module = "eaman" });

            _workflowService = new WorkflowService(workflowRepository.Object,_genericRepository.Object);

            workflowRepository.Setup(x => x.Get()).Returns(workflowModel);


            var controller = new WorkFlowController(_workflowService, _mapper, _moduleService);

            var result = (ViewResult)controller.Index();
            List<WorkflowDTO> workflowDTO = new List<WorkflowDTO>();
            workflowDTO.Add(new WorkflowDTO { Id = 6, Name = "Aman", ModuleId = 5, Module = "aman" });
            workflowDTO.Add(new WorkflowDTO { Id = 26, Name = "eAman", ModuleId = 25, Module = "eaman" });

            var ExpectedResult = workflowDTO;

            result.Model.Should().BeEquivalentTo(ExpectedResult);

        }
        [Test]
        public void Edit_Get_Test()
        {
            _workflowService = new WorkflowService(workflowRepository.Object, _genericRepository.Object);


            workflowRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(new WorkflowModel { Id = 6, Name = "Aman", ModuleId = 5, Module = "aman" });
            var controller = new WorkFlowController(_workflowService, _mapper, _moduleService);

            var result = (ViewResult)controller.Edit(6);
            var ExpectedResult = new WorkflowDTO() { Id = 6, Name = "Aman", ModuleId = 5, Module = "aman" };

            result.Model.Should().BeEquivalentTo(ExpectedResult);



        }
        [Test]
        public void Edit_get_null_Id()
        {

            _workflowService = new WorkflowService(workflowRepository.Object, _genericRepository.Object);


            var controller = new WorkFlowController(_workflowService, _mapper, _moduleService);

            var createResult = (NotFoundResult)controller.Edit(null);

            var expectedResult = 404;

            createResult.StatusCode.Should().Be(expectedResult);



        }
        [Test]
        public void Create_Get_Test()
        {
            _workflowService = new WorkflowService(workflowRepository.Object, _genericRepository.Object);


            var controller = new WorkFlowController(_workflowService, _mapper, _moduleService);

            var result = (ViewResult)controller.Create(6);
            var ExpectedResult = new WorkflowDTO() { Id = 6 };

            result.Model.Should().BeEquivalentTo(ExpectedResult);



        }
        [Test]
        public void Edit_post_Test()
        {
            WorkflowModel workflowModel = new WorkflowModel { Id = 6, Name = "Aman", ModuleId = 5, Module = "aman" };

            var workflowDTO = new WorkflowDTO { Id = 6, Name = "Aman", ModuleId = 5, Module = "aman" };

            _workflowService = new WorkflowService(workflowRepository.Object, _genericRepository.Object);

            workflowRepository.Setup(x => x.Update(workflowModel)).Returns(0);

            var controller = new WorkFlowController(_workflowService, _mapper, _moduleService);
            var createResult = (RedirectToActionResult)controller.Edit(6, workflowDTO);
            var expectedResult = "Index";

            createResult.ActionName.Should().BeEquivalentTo(expectedResult);




        }
        [Test]
        public void Edit_Null_Id_Post_Test()
        {
            var workflowDTO = new WorkflowDTO { Id = 6, Name = "Aman", ModuleId = 5, Module = "aman" };


            _workflowService = new WorkflowService(workflowRepository.Object, _genericRepository.Object);
            var controller = new WorkFlowController(_workflowService, _mapper, _moduleService);

            var createResult = (NotFoundResult)controller.Edit(1, workflowDTO);
            var expectedResult = 404;

            createResult.StatusCode.Should().Be(expectedResult);


        }
        [Test]
        public void Create_post_Test()
        {
            WorkflowModel workflowModel = new WorkflowModel { Id = 6, Name = "Aman", ModuleId = 5, Module = "aman" };

            var workflowDTO = new WorkflowDTO { Id = 6, Name = "Aman", ModuleId = 5, Module = "aman" };



            _workflowService = new WorkflowService(workflowRepository.Object, _genericRepository.Object);

            workflowRepository.Setup(x => x.Create(workflowModel)).Returns(0);

            var controller = new WorkFlowController(_workflowService, _mapper, _moduleService);

            var createResult = (RedirectToActionResult)controller.Create(workflowDTO);
            var expectedResult = "Index";

            createResult.ActionName.Should().BeEquivalentTo(expectedResult);







        }
        [Test]
        public void Delete_get_Test()
        {

            WorkflowModel workflowModel = new WorkflowModel { Id = 6, Name = "Aman", ModuleId = 5, Module = "aman" };

            _workflowService = new WorkflowService(workflowRepository.Object, _genericRepository.Object);

            workflowRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(workflowModel);

            var controller = new WorkFlowController(_workflowService, _mapper, _moduleService);

            var createResult = (ViewResult)controller.Delete(6);
            var expectedResult = new WorkflowDTO() { Id = 6, Name = "Aman", ModuleId = 5, Module = "aman" };

            createResult.Model.Should().BeEquivalentTo(expectedResult);



        }
        [Test]
        public void Delete_get_null_Id()
        {

            _workflowService = new WorkflowService(workflowRepository.Object, _genericRepository.Object);
            var controller = new WorkFlowController(_workflowService, _mapper, _moduleService);

            var createResult = (NotFoundResult)controller.Delete(null);

            var expectedResult = 404;

            createResult.StatusCode.Should().Be(expectedResult);



        }
        
        public void Delete_Confirmed_IdNull()
        {

            _workflowService = new WorkflowService(workflowRepository.Object, _genericRepository.Object);
            var controller = new WorkFlowController(_workflowService, _mapper, _moduleService);

            var createResult = (NotFoundResult)controller.DeleteConfirmed(null);

            var expectedResult = 404;

            createResult.StatusCode.Should().Be(expectedResult);




        }
    }
}
