using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service Interface For LayoutService
    /// </summary>
    /// <returns></returns>
    public interface ICustomerDetailsService
    {

        /// <summary>
        /// Get All Records From CustomerDetails
        /// </summary>
        /// <returns></returns>
        List<CustomerDetailsModel> Get();
        /// <summary>
        /// Get  Records From CustomerDetails based on id
        /// </summary>
        /// <returns></returns>
        CustomerDetailsModel GetById(int id);
        /// <summary>
        /// Insert Record In CustomerDetails
        /// </summary>
        /// <param name="layoutMModel"></param>
        /// <returns></returns>
        RequestResult<int> Create(CustomerDetailsModel customerDetailsModel);
        /// <summary>
        /// Update Record From CustomerDetails
        /// </summary>
        /// <param name="layout2DTO"></param>
        /// <returns></returns>
        RequestResult<int> Update(CustomerDetailsModel customerDetailsModel);
        /// <summary>
        /// Delete Record From CustomerDetails
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}
