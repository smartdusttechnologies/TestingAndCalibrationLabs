using System;
using System.Collections.Generic;
using System.Data;

namespace TestingAndCalibrationLabs.Business.Infrastructure
{
    /// <summary>
    /// Implimenting interface for connection factory
    /// </summary>
    public interface IConnectionFactory
    {
        /// <summary>
        /// Implimenting IDb connection with GetConnection method
        /// </summary>
        IDbConnection GetConnection { get; }

        List<ApplicationId> Get();
    }
}