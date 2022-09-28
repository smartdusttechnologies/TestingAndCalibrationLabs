using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class AttachmentModel
    {
        /// <summary>
        /// Id 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Fila name.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Content type of the File.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Memory stream which contains the file to be downloaded.
        /// </summary>
        public MemoryStream FileStream { get; set; }

        /// <summary>
        /// Client name
        /// </summary>
        public string Client { get; set; }

        /// <summary>
        /// Contains the value of the file path, it is the Response Body Id received from google drive.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Job id of the Test Reprot.
        /// </summary>
        public string JobId { get; set; }        

        /// <summary>
        /// Email templates for sending the decorated e-mail.
        /// </summary>
        public string EmailTemplate { get; set; }

        /// <summary>
        /// Current time/date
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// It the email Id of the user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// It the image link of the 
        /// </summary>
        public string LogoImage { get; set; }

        /// <summary>
        /// This is the email of the Organisation.
        /// </summary>
        public string EmailContact { get; set; }

        /// <summary>
        /// It is the email message being made by the different services.
        /// </summary>
        public string HtmlMsg { get; set; }

        /// <summary>
        /// It the image link whick is attached in the mail.
        /// </summary>
        public string BodyImage { get; set; }

        /// <summary>
        /// Mobile Number of the Organisatoin.
        /// </summary>
        public string MobileNumber { get; set; }

        /// <summary>
        /// Name of the person.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Subject of the mail.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Consist of the body of the message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Blind Carbon Copy(Bcc) maid id.
        /// </summary>
        public List<string> Bcc { get; set; }

        /// <summary>
        /// Carbon copy (Cc) mail Id
        /// </summary>
        public List<string> Cc { get; set; }

        /// <summary>
        /// Data/ file to be uploaded.
        /// </summary>
        public IFormFile DataUrl { get; set; }
        public bool IsSuccess { get; set; }
        public Stream ImageData { get; set; }
    }
}