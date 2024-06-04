using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Core.Model.Common;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.BackOffice;

namespace TestingAndCalibrationLabs.Business.Services.BackOffice
{
    public class TemplateService: ITemplateService
    {
        private readonly ITemplateRepository _templateRepository;
        public TemplateService(ITemplateRepository templateRepository)
        {
            _templateRepository = templateRepository;
        }

        /// <summary>
        /// this method to get the Data
        /// </summary>
        /// <returns></returns>
         public List<TemplateModel> Get() {
           return _templateRepository.Get();
        }

        /// <summary>
        /// This method to get a data by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TemplateModel GetById(int id) {
          
            return _templateRepository.GetById(id);
        }
        
        /// <summary>
        /// This method to create a record
        /// </summary>
        /// <param name="templateModel"></param>
        /// <returns></returns>
        public int Create(TemplateModel templateModel) { 
            return _templateRepository.Create(templateModel);
        
        }

        /// <summary>
        /// This method to Update the Existing Data
        /// </summary>
        /// <param name="templateModel"></param>
        /// <returns></returns>
        public bool Update(TemplateModel templateModel) {
            return _templateRepository.Update(templateModel);

        
        }
        
        /// <summary>
        /// This method to delete the Record from db
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       public bool Delete(int id) {

            return _templateRepository.Delete(id);
        }
    }
}
