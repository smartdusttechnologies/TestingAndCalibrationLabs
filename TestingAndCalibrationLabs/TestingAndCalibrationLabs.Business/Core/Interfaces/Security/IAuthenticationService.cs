using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface IAuthenticationService
    {
        RequestResult<LoginToken> Login(LoginRequest loginRequest);
        RequestResult<bool> Add(UserModel user, string password);
        // RequestResult<bool> UpdatePaasword(ChangePasswordModel userId, string oldpassword, string newpassword, string confirmpassword);

        public RequestResult<bool> UpdatePaasword(ChangePasswordModel password);


    }
}
