using System;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IGenericRepository<Organization> _genericRepository;
        private readonly ILogger _logger;
        public OrganizationService(IOrganizationRepository organizationRepository, ILogger logger, IGenericRepository<Organization> genericRepository)
        {
            _organizationRepository = organizationRepository;
            _logger = logger;
            _genericRepository = genericRepository;
        }

        /// <summary>
        /// Method to Get Orgnization Details from DB
        /// </summary>
        //public List<Organization> Get()
        //{
        //    try
        //    {
        //        return _organizationRepository.Get();
        //    }
        //    catch (Exception ex)
        //    {
        //        //_logger.LogException(new ExceptionLog
        //        // {
        //        //    ExceptionDate = DateTime.Now,
        //        //    ExceptionMsg = ex.Message,
        //        //    ExceptionSource = ex.Source,
        //        //    ExceptionType = "UserService",
        //        //    FullException = ex.StackTrace
        //        //});
        //        return null;
        //    }
        //}
        //public List<Organization> Get(SessionContext sessionContext)
        //{
        //    try
        //    {
        //        return _organizationRepository.Get(sessionContext);
        //    }
        //    catch (Exception ex)
        //    {
        //        //_logger.LogException(new ExceptionLog
        //        // {
        //        //    ExceptionDate = DateTime.Now,
        //        //    ExceptionMsg = ex.Message,
        //        //    ExceptionSource = ex.Source,
        //        //    ExceptionType = "UserService",
        //        //    FullException = ex.StackTrace
        //        //});
        //        return null;
        //    }
        //}
        //public Organization Get(SessionContext sessionContext, int id)
        //{
        //    try
        //    {
        //        return _organizationRepository.Get(sessionContext, id);
        //    }
        //    catch (Exception ex)
        //    {
        //        //_logger.LogException(new ExceptionLog
        //        //{
        //        //    ExceptionDate = DateTime.Now,
        //        //    ExceptionMsg = ex.Message,
        //        //    ExceptionSource = ex.Source,
        //        //    ExceptionType = "UserService",
        //        //    FullException = ex.StackTrace
        //        //});
        //        return null;
        //    }
        //}

        public List<Organization> Get()
        {
            return _genericRepository.Get();
        }
        public RequestResult<int> Create(Organization organization)
        {
            _genericRepository.Insert(organization);
            return new RequestResult<int>(1);
        }


        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }


        public RequestResult<int> Update(Organization organization)
        {
            _genericRepository.Update(organization);
            return new RequestResult<int>(1);
        }


        public Organization GetById(int id)
        {
            return _genericRepository.Get(id);
        }
    }
}
