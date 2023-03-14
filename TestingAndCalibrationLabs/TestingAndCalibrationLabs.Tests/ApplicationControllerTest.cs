using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MySqlX.XDevAPI.Common;
using NUnit.Framework;
using System.Collections.Generic;
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

        Mock<IGenericRepository<ApplicationModel>> igenericRepository = new Mock<IGenericRepository<ApplicationModel>>();


        [SetUp]
        public void SetUp()
        {
            var profile = new MappingProfile();
            var Configuration = new MapperConfiguration(x => x.AddProfile(profile));
            var mapper = new Mapper(Configuration);
            _mapper = mapper;


            //  var controller = new ApplicationController(_applicationService, _mapper);

        }
        [Test]
        public void Common_Index_Method_Test()
        {
            List<ApplicationModel> applicationModel = new List<ApplicationModel>();
            applicationModel.Add(new ApplicationModel { Id = 1, Name = "Aman", Description = "Kumar" });

            _applicationService = new ApplicationService(igenericRepository.Object);


            igenericRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new ApplicationModel { Id = 1, Name = "Aman", Description = "Kumar" });


            var controller = new ApplicationController(_applicationService, _mapper, _uiNavigationCategoryService);

            var result = (ViewResult)controller.Index();
            //Expected Result
            List<ApplicationDTO> applicationDTO = new List<ApplicationDTO>();
            applicationDTO.Add(new ApplicationDTO { Id = 1, Name = "Aman", Description = "Kumar" });


            var ExpectedResult = new ApplicationDTO() { Id = 1, Name = "Aman", Description = "Kumar" };

            result.Model.Should().BeEquivalentTo(ExpectedResult);

        }
        [Test]
        public void Edit_Get_Test()
        {
            List<ApplicationModel> applicationModel = new List<ApplicationModel>();
            applicationModel.Add(new ApplicationModel { Id = 1, Name = "Aman", Description = "Kumar", });

            _applicationService = new ApplicationService(igenericRepository.Object);

           
            igenericRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new ApplicationModel { Id = 1, Name = "Aman", Description = "Kumar" });

            var controller = new ApplicationController(_applicationService, _mapper, _uiNavigationCategoryService);

            var result = (ViewResult)controller.Index();
            //Expected Result
            List<ApplicationDTO> applicationDTO = new List<ApplicationDTO>();
            //applicationDTO.Add(new ApplicationDTO { Id = 1, Name = "Aman", Description = "Kumar" });
            //applicationDTO.Add(new ApplicationDTO { Name = "Ritesh", Description = "bvv"});


            var ExpectedResult = new ApplicationDTO() { Id = 1, Name = "Aman", Description = "Kumar" };

            result.Model.Should().BeEquivalentTo(ExpectedResult);
        }
    }
}

