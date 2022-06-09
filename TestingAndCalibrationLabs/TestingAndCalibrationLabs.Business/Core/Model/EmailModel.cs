using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class EmailModel
    {
        /// <summary>
        /// Declaring EmailTo property
        /// </summary>
        public List<string> EmailTo { get; set; }

        /// <summary>
        /// Choose a Mail Templet to Send Mail
        /// </summary>
        public string EmailTemplate { get; set; }

        /// <summary>
        /// To Choose a Logo Included in Email Template to send Decorated eMails
        /// </summary>
        public string LogoImage { get; set; }

        /// <summary>
        /// This represent the Organisation Contact emailId
        /// </summary>
        public string EmailContact { get; set; }

        /// <summary>
        /// This is used to frame the message 
        /// </summary>
        public string HtmlMsg { get; set; }

        /// <summary>
        /// BodyImage
        /// </summary>
        public string BodyImage { get; set; }

        /// <summary>
        /// This represent the Organisation Contact Mobile NO.
        /// </summary>
        public string MobileNumber { get; set; }

        /// <summary>
        /// Declaring Name property of user
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Declaring Subject property
        /// </summary>
        
        public string Subject { get; set; }
        /// <summary>
        /// Declaring Body property
        /// </summary>
        //TODO:ADD THE CORRESPONDING DB CHANGES
        
        public string Message { get; set; }

        public List<string> Bcc { get; set; }
        public List<string> Cc { get; set; }
    }
}
