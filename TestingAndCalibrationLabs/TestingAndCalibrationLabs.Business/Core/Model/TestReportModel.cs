using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class TestReportModel 
    {
        /// <summary>
        /// Unique Id for the Table
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Client Name
        /// </summary>
        public string Client { get; set; }

        
        /// <summary>
        /// It is the location where the uploded file can be accessed.
        /// </summary>
        public string FilePath { get; set; } 

        /// <summary>
        /// Interface that represents transmitted file, used here to upload the file
        /// </summary>
        public IFormFile DataUrl { get; set; }

        /// <summary>
        /// It is the JobId 
        /// </summary>
        public string JobId { get; set; }
       
        /// <summary>
        /// Current time when the UI is accessed by the user.
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Email address of the user to whom the mail will be sent
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// It is the template for decorative email to be send
        /// </summary>
        public string EmailTemplate { get; set; }

        /// <summary>
        /// It represnt the Logo Image Location which is attached with the mail
        /// </summary>
        public string LogoImage { get; set; }

        /// <summary>
        /// It is the Organisation email Id
        /// </summary>
        public string EmailContact { get; set; }

        /// <summary>
        /// It used to create the Body of the email
        /// </summary>
        public string HtmlMsg { get; set; }

        /// <summary>
        /// It represnt the Body Image Location which is attached with the mail
        /// </summary>
        public string BodyImage { get; set; }

        /// <summary>
        /// It represent the Organisation contact Number.
        /// </summary>
        public string MobileNumber { get; set; }

        /// <summary>
        /// It is the name of the peson using the UI
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Subject which is send in the mail
        /// </summary>
        public string Subject { get; set; }


        public string Message { get; set; }

        /// <summary>
        /// BCC email address
        /// </summary>
        public List<string> Bcc { get; set; }

        /// <summary>
        /// CC email address
        /// </summary>
        public List<string> Cc { get; set; }
    }
}