using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// This model is to send the e-mail.
    /// </summary>
    public class EmailModel 
    {
        internal object myString;

        /// <summary>
        /// It will be used as Email address, where the mail will be sent
        /// </summary>
        public List<string> Email { get; set; }
          
        /// <summary>
        /// Email Template is used to send a decorative mail message 
        /// </summary>
        public string EmailTemplate { get; set; }

        /// <summary>
        /// It is used for the Logo Image
        /// </summary>
        public string LogoImage { get; set; }
             
        /// <summary>
        /// This is used for the Organisation email address.
        /// </summary>
        public string EmailContact { get; set; }

        /// <summary>
        /// It is used for the creating the messages
        /// </summary>
        public string HtmlMsg { get; set; }
                
        /// <summary>
        /// It is used for the body image which is used in the mail
        /// </summary>
        public string BodyImage { get; set; }

        /// <summary>
        /// This is the Mobile number of the Organisation
        /// </summary>
        public string MobileNumber { get; set; }
                
        /// <summary>
        /// This is name of the person who is interacting with the UI
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Subject mentioned in the mail
        /// </summary>
        public string Subject { get; set; }
                
        /// <summary>
        ///Message / Description  
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// List of BCC mail address
        /// </summary>
        public List<string> Bcc { get; set; }

        /// <summary>
        /// Lists of CC mail-address
        /// </summary>
        public List<string> Cc { get; set; }
    }
}