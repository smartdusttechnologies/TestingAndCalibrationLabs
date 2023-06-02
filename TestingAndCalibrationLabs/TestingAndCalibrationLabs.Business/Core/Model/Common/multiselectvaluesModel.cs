using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class multiselectvaluesModel : Entity
    {
        public int Id { get; set; }
        public int ParentId { get; set; }

        public string Name { get; set; }
        //public int Orders { get; set; }
        //public int Position { get; set; }
        public string Category { get; set; }

    }
}
