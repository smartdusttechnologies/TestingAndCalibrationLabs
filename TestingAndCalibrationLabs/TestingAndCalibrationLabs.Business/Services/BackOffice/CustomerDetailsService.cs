using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    public class CustomerDetailsService : ICustomerDetailsService
    {
        private readonly IGenericRepository<CustomerDetailsModel> _genericRepository;
        public CustomerDetailsService(IGenericRepository<CustomerDetailsModel> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        #region Public methods
        /// <summary>
        /// Insert Record In CustomerDetails
        /// </summary>
        /// <param name="customerDetailsModel"></param>
        /// <returns></returns>
        public RequestResult<int> Create(CustomerDetailsModel customerDetailsModel)
        {
            _genericRepository.Insert(customerDetailsModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Delete Record From CustomerDetails
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }
        /// <summary>
        /// Edit Record From CustomerDetails
        /// </summary>
        /// <param name="layoutMModel"></param>
        /// <returns></returns>
        public RequestResult<int> Update(CustomerDetailsModel customerDetailsModel)
        {
            _genericRepository.Update(customerDetailsModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Get All Records From CustomerDetails
        /// </summary>
        /// <returns></returns>
        public List<CustomerDetailsModel> Get()
        {
            return _genericRepository.Get();
        }
        /// <summary>
        /// Get Record by Id For CustomerDetails
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CustomerDetailsModel GetById(int id)
        {
            return _genericRepository.Get(id);
        }
        #endregion
    }
}
