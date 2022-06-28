using System;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class TestDetailsModel
    {
        public string SampleType { get; set; }
        public string SampleDetails { get; set; }
        public DateTime DateOfTP { get; set; }
        public int JobCode { get; set; }
        public int SampleId { get; set; }
        public int NumberOfSampleQuantity { get; set; }
        public string TestName { get; set; }
        public string TestMethod { get; set; }
        public string PersonAuthorized { get; set; }
        public DateTime ReceivedOn { get; set; }
        public DateTime TargedOn { get; set; }
        public DateTime CompletedOn { get; set; }
        public string Remarks { get; set; }
    }
}
