using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class AttachmentModel : Entity
    {
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
        /// Current time/date
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// It the email Id of the user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Name of the person.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Data/ file to be uploaded.
        /// </summary>
        public IFormFile DataUrl { get; set; }
    }
}