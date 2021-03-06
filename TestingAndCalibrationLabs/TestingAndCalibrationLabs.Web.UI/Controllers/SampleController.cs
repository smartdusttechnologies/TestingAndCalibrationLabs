using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;
using TestingAndCalibrationLabs.Business.Core;
namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    /// <summary>
    /// a base class for view
    /// </summary>
    public class SampleController : Controller
    {
        private readonly ILogger<SampleController> _logger;
        private readonly ISampleService _sampleService;
        private readonly IMapper _mapper;
        /// <summary>
        /// passing parameter via varibales for establing connection
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="sampleService"></param>
        /// <param name="hostingEnvironment"></param>
        public SampleController(ILogger<SampleController> logger, ISampleService sampleService,IMapper mapper)
        {
            _logger = logger;
            _sampleService = sampleService;
            _mapper = mapper;   
        }
       /// <summary>
       /// Mapping the Bussiness and ui model for getting List of data
       /// </summary>
       /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            List<Business.Core.Model.SampleModel> samplelists = _sampleService.Get();
            var samples = _mapper.Map<List<Business.Core.Model.SampleModel>, List<Models.Sample.SampleModelDTO>>(samplelists);
           return View(samples);
        }
 
        /// <summary>
        /// Shows Details for Sample
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sample = _sampleService.Get((int)id);
            if (sample == null)
            {
                return NotFound();
            }
            var sampleUIModel = new Models.Sample.SampleModelDTO
            {
                Id = sample.Id,
                Name = sample.Name,
                Description = sample.Description,
            };
            return View(sampleUIModel);
        }

        /// <summary>
        /// Inseting details for Sample
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(int id)
        {
            return base.View(new Models.Sample.SampleModelDTO { Id = id });
        }
        /// <summary>
        /// for creating data
        /// </summary>
        /// <param name="sample"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] Models.Sample.SampleModelDTO sample)
        {
            if (ModelState.IsValid)
            {
                var samples = _mapper.Map<UI.Models.Sample.SampleModelDTO, Business.Core.Model.SampleModel>(sample);
                _sampleService.Add(samples);
                return RedirectToAction("Index");
            }
            return View(sample);
        }

        /// <summary>
        /// Edit deatils of Sample
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sample = _sampleService.Get((int)id);
            if (sample == null)
            {
                return NotFound();
            }
            var sampleUIModel = new Models.Sample.SampleModelDTO
            {
                Id = sample.Id,
                Name = sample.Name,
                Description = sample.Description,
            };
            return View(sampleUIModel);
        }
       /// <summary>
       /// Edit and binding with business project
       /// </summary>
       /// <param name="id"></param>
       /// <param name="sample"></param>
       /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind] Models.Sample.SampleModelDTO sample)
        {
            if (id != sample.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var samples = _mapper.Map<UI.Models.Sample.SampleModelDTO, Business.Core.Model.SampleModel>(sample);
                _sampleService.Update(id, samples);
                return RedirectToAction("Index");
            }
            return View(sample);
        }

        /// <summary>
        ///  Delete sample details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sample = _sampleService.Get((int)id);
            if (sample == null)
            {
                return NotFound();
            }
            var sampleUIModel = new Models.Sample.SampleModelDTO
            {
                Id = sample.Id,
                Name = sample.Name,
                Description = sample.Description,
            };
            return View(sampleUIModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _sampleService.Delete((int)id);
            return RedirectToAction("Index");
        }
    }
}
