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
using TestingAndCalibrationLabs.Business.Data.Repository;
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
        public void Index_Method_Wrong_Data_Test()
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
            applicationDTO.Add(new ApplicationDTO { Id = 16, Name = "Aman", Description = "Kumar" });
            applicationDTO.Add(new ApplicationDTO { Id = 76, Name = "Amane", Description = "Kiumar" });


            var ExpectedResult = applicationDTO;

            result.Model.Should().NotBeEquivalentTo(ExpectedResult);

        }

        [Test]
        public void Edit_Get_Test()
        {
          
            _applicationService = new ApplicationService(genericRepository.Object);


            genericRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new ApplicationModel { Id = 6, Name = "Aman", Description = "Kumar" });

            var controller = new ApplicationController(_applicationService, _mapper, _uiNavigationCategoryService);

            var result = (ViewResult)controller.Edit(6);
          

            var ExpectedResult = new ApplicationDTO() { Id = 6, Name = "Aman", Description = "Kumar" };

            result.Model.Should().BeEquivalentTo(ExpectedResult);
        }

        [Test]
        public void Edit_GetById_NullId_Test()
        {
            _applicationService = new ApplicationService(genericRepository.Object);
            genericRepository.Setup(x => x.Get(It.IsAny<int>()));

            var controller = new ApplicationController(_applicationService, _mapper, _uiNavigationCategoryService);

            var createResult = (NotFoundResult)controller.Edit(4);
          
            var expectedResult = 404;

            createResult.StatusCode.Should().Be(expectedResult);


        }
        [Test]
        public void Edit_Get_NullId_Test()
        {
            _applicationService = new ApplicationService(genericRepository.Object);
          //  genericRepository.Setup(x => x.Get(It.IsAny<int>()));

            var controller = new ApplicationController(_applicationService, _mapper, _uiNavigationCategoryService);

            var createResult = (NotFoundResult)controller.Edit(null);

            var expectedResult = 404;

            createResult.StatusCode.Should().Be(expectedResult);


        }
        [Test]
        public void Edit_post_Test()
        {

              ApplicationModel lookupModel = new ApplicationModel();


               genericRepository.Setup(x => x.Update(lookupModel)).Throws(new NullReferenceException());


            var applicationDTO = new ApplicationDTO ();

            _applicationService = new ApplicationService(genericRepository.Object);
            var controller = new ApplicationController(_applicationService, _mapper, _uiNavigationCategoryService);

            var createResult = (RedirectToActionResult)controller.Edit(1,applicationDTO);
                var expectedResult = "Index";

             createResult.ActionName.Should().BeEquivalentTo(expectedResult);

        }
        [Test]
        public void Create_post_Test()
        {
           
            ApplicationModel lookupModel = new ApplicationModel { Id = 1, Name = "Aman", Description = "Kumar" };

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
         

            genericRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new ApplicationModel { Id = 6, Name = "Aman", Description = "Kumar" });

            _applicationService = new ApplicationService(genericRepository.Object);
            var controller = new ApplicationController(_applicationService, _mapper, _uiNavigationCategoryService);

           var result = (ViewResult)controller.Delete(6);

            var ExpectedResult = new ApplicationDTO() { Id = 6, Name = "Aman", Description = "Kumar" };

            result.Model.Should().BeEquivalentTo(ExpectedResult);

        }
        [Test]
        public void Delete_get_null_Id()
        {

            _applicationService = new ApplicationService(genericRepository.Object);
            var controller = new ApplicationController(_applicationService, _mapper, _uiNavigationCategoryService);

            var createResult = (NotFoundResult)controller.Delete(null);


            var expectedResult = 404;

            createResult.StatusCode.Should().Be(expectedResult);



        }
        [Test]
        public void Delete_getbyId_null()
        {
            genericRepository.Setup(x => x.Get(It.IsAny<int>()));


            _applicationService = new ApplicationService(genericRepository.Object);
            var controller = new ApplicationController(_applicationService, _mapper, _uiNavigationCategoryService);

            var createResult = (NotFoundResult)controller.Delete(5);


            var expectedResult = 404;

            createResult.StatusCode.Should().Be(expectedResult);


        }
        [Test]
        public void DeleteConfirmed_Test()
        {
            genericRepository.Setup(x => x.Delete(It.IsAny<int>())).Returns(true);

            _applicationService = new ApplicationService(genericRepository.Object);
            var controller = new ApplicationController(_applicationService, _mapper, _uiNavigationCategoryService);

            var result = (RedirectToActionResult)controller.DeleteConfirmed(0);

            var expectedResult = "index";
       
            result.ActionName.Should().BeEquivalentTo(expectedResult);


        }
        [Test]
        public void Delete_Confirmed_IdNull()
        {

            _applicationService = new ApplicationService(genericRepository.Object);
            var controller = new ApplicationController(_applicationService, _mapper, _uiNavigationCategoryService);

            var createResult = (NotFoundResult)controller.DeleteConfirmed(null);
            genericRepository.Setup(x => x.Delete(It.IsAny<int>()));

            var expectedResult = 404;

            createResult.StatusCode.Should().Be(expectedResult);




        }
    }
}

