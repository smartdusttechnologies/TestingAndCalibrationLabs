using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Core.Model.MetirialTest
{
    public class TestingCategoryLookupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public int Position { get; set; }
        public string Icon { get; set; }    
        public string Descrpition { get; set; }
    }
}
