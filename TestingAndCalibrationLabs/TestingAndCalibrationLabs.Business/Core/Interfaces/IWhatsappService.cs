using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface IWhatsappService
    {

        Task SendMessageAsync(JObject message, string senderId);  

    }
}
