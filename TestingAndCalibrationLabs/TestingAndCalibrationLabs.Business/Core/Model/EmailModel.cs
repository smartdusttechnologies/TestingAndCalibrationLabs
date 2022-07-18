using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class EmailModel
    {
        public List<string> Email { get; set; }

        public string EmailTemplate { get; set; }

        public string LogoImage { get; set; }

        public string EmailContact { get; set; }

        public string HtmlMsg { get; set; }

        public string BodyImage { get; set; }

        public string MobileNumber { get; set; }

        public string Name { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public List<string> Bcc { get; set; }

        public List<string> Cc { get; set; }
    }
}
