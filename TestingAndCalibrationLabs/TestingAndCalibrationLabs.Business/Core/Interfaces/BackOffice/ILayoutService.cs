using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface ILayoutService
    {

        /// <summary>
        /// Get All Records From layout
        /// </summary>
        /// <returns></returns>
        List<LayoutMModel> Get();
        /// <summary>
        /// Get All Records From layout based on id
        /// </summary>
        /// <returns></returns>
        LayoutMModel GetById(int id);
        /// <summary>
        /// Insert Record In layout
        /// </summary>
        /// <param name="layoutMModel"></param>
        /// <returns></returns>
        RequestResult<int> Create(LayoutMModel layoutMModel);
        /// <summary>
        /// Update Record From layout
        /// </summary>
        /// <param name="layout2DTO"></param>
        /// <returns></returns>
        RequestResult<int> Update(LayoutMModel layoutMModel);
        /// <summary>
        /// Delete Record From layout
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

    }
}
