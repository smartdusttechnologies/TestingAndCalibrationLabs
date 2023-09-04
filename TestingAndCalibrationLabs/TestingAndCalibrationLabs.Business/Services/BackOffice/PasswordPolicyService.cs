using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Class for Password Policy Management
    /// </summary>
    public class PasswordPolicyService : IPasswordPolicyService
    {
        private readonly IGenericRepository<PasswordPolicyModel> _genericRepository;

        public PasswordPolicyService(IGenericRepository<PasswordPolicyModel> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        #region Public Methods
        /// <summary>
        /// Create a new Password Policy record
        /// </summary>
        /// <param name="passwordPolicyModel">The Password Policy model to create</param>
        /// <returns>The result of the create operation</returns>
        public RequestResult<int> Create(PasswordPolicyModel passwordPolicyModel)
        {
            _genericRepository.Insert(passwordPolicyModel);
            return new RequestResult<int>(1);
        }

        /// <summary>
        /// Delete a Password Policy record by its ID
        /// </summary>
        /// <param name="id">The ID of the record to delete</param>
        /// <returns>True if the delete operation was successful; otherwise, false</returns>
        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }

        /// <summary>
        /// Update an existing Password Policy record
        /// </summary>
        /// <param name="passwordPolicyModel">The Password Policy model to update</param>
        /// <returns>The result of the update operation</returns>
        public RequestResult<int> Update(PasswordPolicyModel passwordPolicyModel)
        {
            _genericRepository.Update(passwordPolicyModel);
            return new RequestResult<int>(1);
        }

        /// <summary>
        /// Get all Password Policy records
        /// </summary>
        /// <returns>A list of all Password Policy records</returns>
        public List<PasswordPolicyModel> Get()
        {
            return _genericRepository.Get();
        }

        /// <summary>
        /// Get a Password Policy record by its ID
        /// </summary>
        /// <param name="id">The ID of the record to retrieve</param>
        /// <returns>The Password Policy record with the specified ID</returns>
        public PasswordPolicyModel GetById(int id)
        {
            return _genericRepository.Get(id);
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
