using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Infrastructure
{
    public class Logger : ILogger
    {

        private readonly ILoggerRepository _loggerRepository;

        public Logger(ILoggerRepository loggerRepository)
        {
            _loggerRepository = loggerRepository;
        }
        public async Task<int> LoginTokenLog(LoginToken loginToken)
        {
            return await Task.Run(() => _loggerRepository.LoginTokenLog(loginToken));
        }

        public async Task<int> LoginLog(LoginRequest loginRequest)
        {
            return await Task.Run(() => _loggerRepository.LoginLog(loginRequest));
        }
    }
}
