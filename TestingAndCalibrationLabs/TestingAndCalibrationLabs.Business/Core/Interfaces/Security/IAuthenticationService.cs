using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface IAuthenticationService
    {
        RequestResult<LoginToken> Login(LoginRequest loginRequest);
        RequestResult<bool> Add(UserModel user, string password,string Email,string Mobile,string ReEnterPassword, string UserName, string FirstName, string LastName, string Country, string Organizations);

    }
}
