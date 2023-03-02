using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Infrastructure;

namespace TestingAndCalibrationLabs.Business.Data.Repository
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public ModuleRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
    }
}
