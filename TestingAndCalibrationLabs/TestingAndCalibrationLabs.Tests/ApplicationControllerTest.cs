using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Mysqlx.Session;
using MySqlX.XDevAPI.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.common;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Services;
using TestingAndCalibrationLabs.Web.UI.Controllers;
using TestingAndCalibrationLabs.Web.UI.Mappers;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Tests
{
    [TestFixture]
    public class ApplicationControllerTest
    {
        IMapper _mapper;
        IApplicationService _applicationService;
        IUiPageNavigationService _uiNavigationCategoryService;
        Mock<IGenericRepository<ApplicationModel>> genericRepository = new Mock<IGenericRepository<ApplicationModel>>();


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
           List<ApplicationModel> applicationModel = new List<ApplicationModel>();
            applicationModel.Add(new ApplicationModel { Id = 6, Name = "Aman", Description = "Kumar" });
            applicationModel.Add(new ApplicationModel { Id = 46, Name = "Amane", Description = "Kiumar" });


            _applicationService = new ApplicationService(genericRepository.Object);

                genericRepository.Setup(x => x.Get()).Returns(applicationModel);
  
            var controller = new ApplicationController(_applicationService, _mapper, _uiNavigationCategoryService);

            var result = (ViewResult)controller.Index();
            //Expected Result
             List<ApplicationDTO> applicationDTO = new List<ApplicationDTO>();
            applicationDTO.Add(new ApplicationDTO { Id = 6, Name = "Aman", Description = "Kumar" });
            applicationDTO.Add(new ApplicationDTO { Id = 46, Name = "Amane", Description = "Kiumar" });


            var ExpectedResult = applicationDTO;

            result.Model.Should().BeEquivalentTo(ExpectedResult);

        }
        [Test]
        public void Edit_Get_Test()
        {
            //List<ApplicationModel> applicationModel = new List<ApplicationModel>();
            //applicationModel.Add(new ApplicationModel { Id = 6, Name = "Aman", Description = "Kumar" });
            //applicationModel.Add(new ApplicationModel { Name = "Amane", Description = "Kiumar" });

            _applicationService = new ApplicationService(genericRepository.Object);


            genericRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new ApplicationModel { Id = 6, Name = "Aman", Description = "Kumar" });

            var controller = new ApplicationController(_applicationService, _mapper, _uiNavigationCategoryService);

            var result = (ViewResult)controller.Edit(8);
            //Expected Result
            //   List<ApplicationDTO> applicationDTO = new List<ApplicationDTO>();
            // applicationDTO.Add(new ApplicationDTO { Id = 1, Name = "Aman", Description = "Kumar" });


            var ExpectedResult = new ApplicationDTO() { Id = 6, Name = "Aman", Description = "Kumar" };

            result.Model.Should().BeEquivalentTo(ExpectedResult);
        }

        [Test]
        public void Edit_post_Test()
        {

            //List<ApplicationModel> applicationModel = new List<ApplicationModel>();
            //applicationModel.Add(new ApplicationModel { Id = 1, Name = "Aman", Description = "Kumar" });
            //applicationModel.Add(new ApplicationModel { Id = 3, Name = "Amang", Description = "Kumarg" });

            //   List<LookupModel> lookupModel = new List<LookupModel>();
            ApplicationModel lookupModel = new ApplicationModel { Id = 1, Name = "Aman", Description = "Kumar" };


            // genericRepository.Setup(x => x.Update(It.IsAny<int>())).Returns(new ApplicationModel { Id = 1, Name = "Aman", Description = "Kumar" });

            // genericRepository.Setup(x => x.Update()).Returns(applicationModel);
            genericRepository.Setup(x => x.Update(lookupModel)).Throws(new NullReferenceException());


            var applicationDTO = new ApplicationDTO { Id = 1, Name = "Aman", Description = "Kumar" };

            _applicationService = new ApplicationService(genericRepository.Object);
            var controller = new ApplicationController(_applicationService, _mapper, _uiNavigationCategoryService);

            var createResult = (RedirectToActionResult)controller.Edit(applicationDTO);
            // var value = (ApplicationDTO)createResult.Value;
            //  var expectField = new List<ApplicationDTO>();

            //List<ApplicationDTO> applicationDT = new List<ApplicationDTO>();
            //applicationDT.Add(new ApplicationDTO { Id = 1, Name = "Aman", Description = "Kumar" });
            // ApplicationDTO lookupModela = new ApplicationDTO { Id = 1, Name = "Aman", Description = "Kumar" };

           // Assert.AreEqual("Index", createResult.ActionName);
            //Assert.AreEqual("Errors", createResult.ControllerName);
             var expectedResult = "Index";

             createResult.ActionName.Should().BeEquivalentTo(expectedResult);

        }
        [Test]
        public void Create_post_Test()
        {
           // List<ApplicationModel> applicationModel = new List<ApplicationModel>();
           // applicationModel.Add(new ApplicationModel { Id = 6, Name = "Aman", Description = "Kumar" });
           //// applicationModel.Add(new ApplicationModel { Name = "Amane", Description = "Kiumar" });

            ApplicationModel lookupModel = new ApplicationModel { Id = 1, Name = "Aman", Description = "Kumar" };

            // GenericRepository lookupModel = new GenericRepository();
            // var lookupModel =
            //string value = string.Empty;
           // _applicationService = new ApplicationService(genericRepository.Object);

          //genericRepository.Setup(x => x.Insert(It.IsAny<int>())).Returns(applicationModel);
             genericRepository.Setup(x => x.Insert(lookupModel)).Returns(0);


            var applicationDTO = new ApplicationDTO { Id = 1, Name = "Aman", Description = "Kumar" };


            _applicationService = new ApplicationService(genericRepository.Object);
            var controller = new ApplicationController(_applicationService, _mapper, _uiNavigationCategoryService);

            var createResult = (RedirectToActionResult)controller.Create(applicationDTO);
            var expectedResult = "Index";

            createResult.ActionName.Should().BeEquivalentTo(expectedResult);

        }
        [Test]
        public void Delete_get_Test()
        {
          //List<ApplicationModel> applicationModel = new List<ApplicationModel>();
          // applicationModel.Add(new ApplicationModel { Id = 6, Name = "Aman", Description = "Kumar" });
          //  applicationModel.Add(new ApplicationModel { Name = "Amane", Description = "Kiumar" });


            genericRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new ApplicationModel { Id = 6, Name = "Aman", Description = "Kumar" });

            _applicationService = new ApplicationService(genericRepository.Object);
            var controller = new ApplicationController(_applicationService, _mapper, _uiNavigationCategoryService);

           var result = (ViewResult)controller.Delete(6);

            //List<ApplicationDTO> applicationDTO = new List<ApplicationDTO>();
            //applicationDTO.Add(new ApplicationDTO { Id = 6, Name = "Aman", Description = "Kumar" });
            //applicationDTO.Add(new ApplicationDTO { Name = "Amane", Description = "Kiumar" });


            var ExpectedResult = new ApplicationDTO() { Id = 6, Name = "Aman", Description = "Kumar" };
            result.Should().BeEquivalentTo(ExpectedResult);


        }
        //[Test]
        //public void DeleteConfirmed_Test()
        //{
        //    genericRepository.Setup(x => x.Delete(It.IsAny<int>())).Returns(true);

        //    _applicationService = new ApplicationService(genericRepository.Object);
        //    var controller = new ApplicationController(_applicationService, _mapper, _uiNavigationCategoryService);

        //    var result = (NotFoundResult)controller.Delete(12);

        //    var expectedResult = "index";
        //    result.Should().BeEquivalentTo(expectedResult);


        //}
    }
}

