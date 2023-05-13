using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class multiselectvaluesModel : Entity
    {
        public int ParentId { get; set; }

        public string Name { get; set; }
        public int Orders { get; set; }
    }
}
