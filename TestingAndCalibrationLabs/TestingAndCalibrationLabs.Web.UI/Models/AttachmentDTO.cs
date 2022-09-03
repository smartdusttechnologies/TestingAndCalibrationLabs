using System.IO;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class AttachmentDTO
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public MemoryStream FileStream { get; set; }
    }
}
