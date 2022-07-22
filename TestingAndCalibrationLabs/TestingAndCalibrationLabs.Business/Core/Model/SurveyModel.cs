

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class SurveyModel:EmailModel
    {
        public string Mobile { get; set; }
        public string TestingType { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public string Comments { get; set; }
    }
}