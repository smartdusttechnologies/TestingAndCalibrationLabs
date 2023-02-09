using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Services;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service interface for Module
    /// </summary>
    public interface IApplicationService
    {
        /// <summary>
        /// Get All Record From Module
        ///// </summary>
        //List<ApplicationModel> Get();
        //ApplicationModel GetById(int id);
        //RequestResult<int> Update(ApplicationModel ApplicationModel);
        //RequestResult<int> Create(ApplicationModel ApplicationModel);
        //bool Delete(int id);
        List<ApplicationModel> Get();

    }
}