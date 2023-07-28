using System;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{

    public class WhatsappModel : Entity
    {
        public long from { get; set; }
        public string phoneNumberId { get; set; }
        public string entry { get; set; }
        public string messagingproduct { get; set; }
        public string to { get; set; }
        public string body { get; set; }
        
        public string text { get; set; }
        public string Image { get; set; }

    }
}
