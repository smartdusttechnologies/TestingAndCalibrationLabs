using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Infrastructure;
using TestingAndCalibrationLabs.Business.Data.Repository.common;

namespace TestingAndCalibrationLabs.Business.Data.Repository
{
    /// <summary>
    /// This repository contains the database access logic specific to Sample feature in case common crud repository is not enough. 
    /// </summary>
    public class SampleRepository : CommonRepository, ISampleRepository
    {

        public SampleRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        #region Public Methods

        #endregion
        #region Private Methods

        #endregion
    }
}
