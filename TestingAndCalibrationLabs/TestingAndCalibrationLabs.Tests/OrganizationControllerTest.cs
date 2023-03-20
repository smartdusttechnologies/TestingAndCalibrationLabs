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
    public class OrganizationControllerTest
    {
         IOrganizationService _organizationService;
         IMapper _mapper;
      //  ILogger _logger;
        Mock<IGenericRepository<Organization>> _genericRepository = new Mock<IGenericRepository<Organization>>();
        Mock<IOrganizationRepository> _organizationRepository = new Mock<IOrganizationRepository>();


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
           List<Organization> organization = new List<Organization>();
            organization.Add(new Organization { Id = 6, OrgCode = "Aman", OrgName = "Kumar" });
            organization.Add(new Organization { Id = 46, OrgCode = "Amane", OrgName = "Kiumar" });


            _organizationService = new OrganizationService(_organizationRepository.Object,_genericRepository.Object);

            _genericRepository.Setup(x => x.Get()).Returns(organization);
  
            var controller = new OrganizationController(_organizationService, _mapper);

            var result = (ViewResult)controller.Index();
            //Expected Result
             List<OrganizationDTO> organizationDTO = new List<OrganizationDTO>();
            organizationDTO.Add(new OrganizationDTO { Id = 6, OrgCode = "Aman", OrgName = "Kumar" });
            organizationDTO.Add(new OrganizationDTO { Id = 46, OrgCode = "Amane", OrgName = "Kiumar" });


            var ExpectedResult = organizationDTO;

            result.Model.Should().BeEquivalentTo(ExpectedResult);

        }
        [Test]
        public void Edit_Get_Test()
        {

            _organizationService = new OrganizationService(_organizationRepository.Object, _genericRepository.Object);


            _genericRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new Organization { Id = 6, OrgCode = "Aman", OrgName = "Kumar" });

            var controller = new OrganizationController(_organizationService, _mapper);

            var result = (ViewResult)controller.Edit(8);
          

            var ExpectedResult = new OrganizationDTO() { Id = 6, OrgCode = "Aman", OrgName = "Kumar" };

            result.Model.Should().BeEquivalentTo(ExpectedResult);
        }

        [Test]
        public void Edit_post_Test()
        {

            Organization organization = new Organization { Id = 6, OrgCode = "Aman", OrgName = "Kumar" };


            _genericRepository.Setup(x => x.Update(organization)).Throws(new NullReferenceException());


            var organizationDTO = new OrganizationDTO { Id = 6, OrgCode = "Aman", OrgName = "Kumar" };

            _organizationService = new OrganizationService(_organizationRepository.Object, _genericRepository.Object);
            var controller = new OrganizationController(_organizationService, _mapper);

            var createResult = (RedirectToActionResult)controller.Edit(organizationDTO);
                var expectedResult = "Index";

             createResult.ActionName.Should().BeEquivalentTo(expectedResult);

        }
        [Test]
        public void Create_post_Test()
        {
            Organization organization = new Organization { Id = 6, OrgCode = "Aman", OrgName = "Kumar" };

            _genericRepository.Setup(x => x.Insert(organization)).Returns(0);


            var organizationDTO = new OrganizationDTO { Id = 6, OrgCode = "Aman", OrgName = "Kumar" };

            _organizationService = new OrganizationService(_organizationRepository.Object, _genericRepository.Object);
            var controller = new OrganizationController(_organizationService, _mapper);

            var createResult = (RedirectToActionResult)controller.Create(organizationDTO);
            var expectedResult = "Index";

            createResult.ActionName.Should().BeEquivalentTo(expectedResult);

        }
        [Test]
        public void Delete_get_Test()
        {


            _genericRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new Organization { Id = 6, OrgCode = "Aman", OrgName = "Kumar" });

            _organizationService = new OrganizationService(_organizationRepository.Object, _genericRepository.Object);
            var controller = new OrganizationController(_organizationService, _mapper);

            var result = (ViewResult)controller.Delete(6);

            var ExpectedResult = new OrganizationDTO { Id = 6, OrgCode = "Aman", OrgName = "Kumar" };

            result.Model.Should().BeEquivalentTo(ExpectedResult);

        }
        [Test]
        public void DeleteConfirmed_Test()
        {
            _genericRepository.Setup(x => x.Delete(It.IsAny<int>())).Returns(true);

            _organizationService = new OrganizationService(_organizationRepository.Object, _genericRepository.Object);
            var controller = new OrganizationController(_organizationService, _mapper);

            var result = (RedirectToActionResult)controller.DeleteConfirmed(0);

            var expectedResult = "index";
       
            result.ActionName.Should().BeEquivalentTo(expectedResult);


        }
    }
}

