//using AutoMapper;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using Moq;
//using NUnit.Framework;
//using System.Collections.Generic;
//using System.Net;
//using TestingAndCalibrationLabs.Business.Core.Interfaces;
//using TestingAndCalibrationLabs.Business.Core.Model;
//using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
//using TestingAndCalibrationLabs.Business.Services;
//using TestingAndCalibrationLabs.Web.UI.Controllers;

//namespace TestingAndCalibrationLabs.Tests
//{

//    / <summary>
//    / Decaring Class
//    / </summary>
//    #region public
//    public class SampleTests
//    {
//        / <summary>
//        / creating services 
//        / </summary>
//        ICommonService _sampleService;
//        ISampleRepository _sampleRepository;
//        IMapper _mapper;
//        ILogger<SampleController> _logger;

//        Web.UI.Models.Sample.SampleModelDTO detailToadd = new Web.UI.Models.Sample.SampleModelDTO
//        {
//            Name = "India",
//            Description = "Abc"
//        };
//        List<SampleModel> details = new List<SampleModel>
//            {
//                new SampleModel
//                {
//                    Id = 1, Name = "India", Description = "abc"
//                }
//            };


//        / <summary>
//        / Setuping Mock
//        / </summary>
//        [SetUp]
//        public void Setup()
//        {
//            mock mapper.

//            Mock<IMapper> mapper = new Mock<IMapper>();
//            mapper.Setup(m => m.Map<List<SampleModel>, List<Web.UI.Models.Sample.SampleModelDTO>>(details)).Returns(MapDetails(details));
//            mapper.Setup(m => m.Map<SampleModel, Web.UI.Models.Sample.SampleModelDTO>(details[0])).Returns(MapDetails(details[0]));
//            mapper.Setup(m => m.Map<Web.UI.Models.Sample.SampleModelDTO, SampleModel>(detailToadd)).Returns(details[0]);


//            mock repository\DB calls.
//            Mock<ISampleRepository> sampleRepo = new Mock<ISampleRepository>();
//            sampleRepo.Setup(mock => mock.Get()).Returns(details);
//            sampleRepo.Setup(mock => mock.Get(1)).Returns(details[0]);
//            sampleRepo.Setup(mock => mock.Insert(details[0])).Returns(details[0].Id);
//            sampleRepo.Setup(mock => mock.Delete(1)).Returns(true);
//            sampleRepo.Setup(mock => mock.Update(details[0])).Returns(details[0].Id);


//            resolve dependencies.
//            _mapper = mapper.Object;
//            _sampleRepository = sampleRepo.Object;
//            _sampleService = new SampleService(_sampleRepository);
//        }


//        / <summary>
//        / testing For getting all Details from Database
//        / </summary>
//        [Test]
//        public void SampleTestGetAllDetails()
//        {
//            SampleController sampleController = new SampleController(_logger, _sampleService, _mapper);
//            IActionResult response = sampleController.Index();
//            var data = response as ViewResult;
//            Assert.AreEqual(1, (data.Model as List<Web.UI.Models.Sample.SampleModelDTO>).Count);
//        }


//        / <summary>
//        / testing for adding a details
//        / </summary>
//        [Test]
//        public void SampleTestAddDetails()
//        {
//            SampleController sampleController = new SampleController(_logger, _sampleService, _mapper);
//            IActionResult response = sampleController.Create(1);
//            var data = response as ViewResult;
//            Assert.IsNotNull(data);
//            Assert.IsNotNull(data.Model);
//            Assert.IsTrue(string.IsNullOrEmpty(data.ViewName) || data.ViewName == "Index");

//        }

//        / <summary>
//        /testing  for updating details
//        / </summary>
//        [Test]
//        public void SampleTestUpdateDetails()
//        {
//            SampleController sampleController = new SampleController(_logger, _sampleService, _mapper);
//            IActionResult response = sampleController.Edit(1);
//            var data = response as ViewResult;
//            Assert.IsNotNull(data);
//            Assert.IsNotNull(data.Model);
//            Assert.IsTrue(string.IsNullOrEmpty(data.ViewName) || data.ViewName == "Index");
//        }


//        / <summary>
//        / testing for Deleting Details
//        / </summary>
//        [Test]
//        public void SampleTestDeleteDetails()
//        {
//            SampleController sampleController = new SampleController(_logger, _sampleService, _mapper);
//            IActionResult response = sampleController.Delete(1);
//            ViewResult data = response as ViewResult;
//            Assert.IsNotNull(data);
//            Assert.IsNotNull(data.Model);
//            Assert.IsTrue(string.IsNullOrEmpty(data.ViewName) || data.ViewName == "Index");
//        }
//        #endregion

//        #region Private methods
//        private List<Web.UI.Models.Sample.SampleModelDTO> MapDetails(List<SampleModel> samples)
//        {
//            List<Web.UI.Models.Sample.SampleModelDTO> list = new List<Web.UI.Models.Sample.SampleModelDTO>();
//            foreach (var details in samples)
//            {
//                list.Add(new Web.UI.Models.Sample.SampleModelDTO { Description = details.Description, Name = details.Name });
//            }
//            return list;
//        }
//        private Web.UI.Models.Sample.SampleModelDTO MapDetails(SampleModel details)
//        {
//            return new Web.UI.Models.Sample.SampleModelDTO { Description = details.Description, Name = details.Name };
//        }
//        #endregion

//    }
//}