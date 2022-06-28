using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface ILogger
    {
        Task<int> LoginLog(LoginRequest loginRequest);

        Task<int> LoginTokenLog(LoginToken loginToken);
    }
}
