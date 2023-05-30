using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Services;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface IForgotPasswordService
    {
        /// <summary>
        /// This is used to send the mail of the survey to UI user and and dB user records by Role
        /// </summary>
        /// <param name="mailsend"></param>
        /// <returns></returns>
        RequestResult<int> Add(EmailModel forgotpasswordmodel);
    }
}