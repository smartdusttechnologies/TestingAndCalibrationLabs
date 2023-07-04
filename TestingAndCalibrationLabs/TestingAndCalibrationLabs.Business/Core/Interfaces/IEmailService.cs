using System.Threading.Tasks;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface IEmailService
    {
        Task FindByEmailAsync(string email);

        /// <summary>
        /// Implimenting interface for Sendmail Method
        /// </summary>
        /// <param name="surveyModel"></param>
        /// <returns></returns>
        bool Sendemail(EmailModel emailModel);

        //object Sendemail(ForgotPasswordModel mailreq);
    }
}