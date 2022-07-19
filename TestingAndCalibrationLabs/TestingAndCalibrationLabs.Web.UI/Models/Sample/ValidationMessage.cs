﻿namespace TestingAndCalibrationLabs.Web.UI.Models
{

    public class ValidationMessage
    {
        /// <summary>
        /// Decaring Public properties for validation
        /// </summary>
        #region Public Properties
        public string Reason { get; set; }

        public virtual ValidationSeverity Severity { get; set; }
        public string MessageKey { get; set; }
        public int Fid { get; set; }       //sourceId
        public string Description { get; set; }
        #endregion
    }

    public enum ValidationSeverity
    {
        None,
        Information,
        Warning,
        Error,
        Critical,
    }
}