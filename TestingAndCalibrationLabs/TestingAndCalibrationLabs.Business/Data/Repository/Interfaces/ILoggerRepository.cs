using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    public interface ILoggerRepository
    {
       int LoginLog(LoginRequest loginRequest);
       int LoginTokenLog(LoginToken loginToken);
    }
}
