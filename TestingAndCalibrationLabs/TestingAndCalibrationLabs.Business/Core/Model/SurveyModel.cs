namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// Survey inherits the property of the Email Model.
    /// </summary>
    public class SurveyModel:EmailModel
    {
        /// <summary>
        /// User 10 digit mobile number
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// Testing type from the UI
        /// </summary>
        public string TestingType { get; set; }

        /// <summary>
        /// User address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// user city name
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// user State
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// user 6 digit pin code
        /// </summary>
        public string PinCode { get; set; }

        /// <summary>
        /// user put comment in the UI
        /// </summary>
        public string Comments { get; set; }
    }
}