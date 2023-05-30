using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Services;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface IEmailService
    {
        /// <summary>
        /// Implimenting interface for Sendmail Method
        /// </summary>
        /// <param name="surveyModel"></param>
        /// <returns></returns>
        bool Sendemail(EmailModel emailModel);
        
    }
}