using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class SurveyModel:Entity
    {   
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string HtmlMsg { get; set; }
        public string EmailTemplate { get; set; }
        public string LogoImage { get; set; }
        public string EmailContact { get; set; }
        public string BodyImage { get; set; }
        public string Mobile { get; set; }
        public List<string> Email { get; set; }
        public string TestingType { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public string Comments { get; set; }
    }
}