using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class AttachmentModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public MemoryStream FileStream { get; set; }
        public string Client { get; set; }
        public string FilePath { get; set; }
        public string JobId { get; set; }        
        public string EmailTemplate { get; set; }
        public DateTime DateTime { get; set; }
        public string Email { get; set; }
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
        public Stream ImageData { get; set; }
        public IFormFile DataUrl { get; set; }
    }
}