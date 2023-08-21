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
        List<Layout2Model> Get();
        /// <summary>
        /// Get All Records From layout based on id
        /// </summary>
        /// <returns></returns>
        Layout2Model GetById(int id);
        /// <summary>
        /// Insert Record In layout
        /// </summary>
        /// <param name="layout2DTO"></param>
        /// <returns></returns>
        RequestResult<int> Create(Layout2Model layout2DTO);
        /// <summary>
        /// Update Record From layout
        /// </summary>
        /// <param name="layout2DTO"></param>
        /// <returns></returns>
        RequestResult<int> Update(Layout2Model layout2DTO);
        /// <summary>
        /// Delete Record From layout
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

    }
}
