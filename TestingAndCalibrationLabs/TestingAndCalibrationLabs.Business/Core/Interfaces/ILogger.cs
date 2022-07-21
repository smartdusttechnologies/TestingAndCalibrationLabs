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
