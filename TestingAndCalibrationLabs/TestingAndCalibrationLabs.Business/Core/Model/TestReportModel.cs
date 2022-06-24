using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class TestReportModel : Entity
    {
        public string Client { get; set; }
        public string FilePath { get; set; }
        public IFormFile DataUrl { get; set; }
        public string JobId { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public string Email { get; set; }
    }
}