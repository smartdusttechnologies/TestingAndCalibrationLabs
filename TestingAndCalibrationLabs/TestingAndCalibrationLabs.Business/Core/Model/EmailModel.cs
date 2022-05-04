using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class EmailModel:Entity
    {
        public string Name { get; set; }
        public int MobileNumber { get; set; }
        public List<string> EmailId { get; set; }
        public string TestingType { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PinCode { get; set; }
        public string Comments { get; set; }
    }
}
