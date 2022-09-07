using System.IO;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class AttachmentDTO
    {
        /// <summary>
        /// Property represent the File Name.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Property shows the file type.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Property contains the file stream.
        /// </summary>
        public MemoryStream FileStream { get; set; }
    }
}
