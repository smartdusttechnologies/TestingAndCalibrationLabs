using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Core.Model.Common;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice
{
    public interface ITemplateService
    {
        /// <summary>
        /// Get Complete Record From the Template
        /// </summary>
        /// <returns></returns>
        List<TemplateModel> Get();
        /// <summary>
        /// Get Record By Id From Template
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TemplateModel GetById(int id);
        /// <summary>
        /// Insert Record In Template
        /// </summary>
        /// <param name="TemplateModel"></param>
        /// <returns></returns>
        int Create(TemplateModel templateModel);
        /// <summary>
        /// Edit Record From Template
        /// </summary>
        /// <param name="uiPageTypeModel"></param>
        /// <returns></returns>
        bool Update(TemplateModel templateModel);
        /// <summary>
        /// Delete Record From Template
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}
