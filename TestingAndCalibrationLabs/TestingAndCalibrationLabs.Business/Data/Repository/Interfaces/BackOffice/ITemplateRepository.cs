using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model.Common;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.BackOffice
{
    public interface ITemplateRepository
    {
        public List<TemplateModel> Get();
        /// <summary>
        /// Get Record By Id From Template
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TemplateModel GetById(int id);
        /// <summary>
        /// Insert Record In Template
        /// </summary>
        /// <param name="TemplateModel"></param>
        /// <returns></returns>
        public int Create(TemplateModel templateModel);
        /// <summary>
        /// Update Record In Template
        /// </summary>
        /// <param name="TemplateModel"></param>
        /// <returns></returns>
        public bool Update(TemplateModel templateModel);
        /// <summary>
        /// Delete Record From Template By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id);
    }
}
