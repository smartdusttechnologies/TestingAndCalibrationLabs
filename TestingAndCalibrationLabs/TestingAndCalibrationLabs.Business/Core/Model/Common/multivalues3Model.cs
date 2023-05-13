using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class multivalues3Model : Entity
    {
        // public Dictionary<string, double> Data { get; set; }
        //public Dictionary<MultiselectDropdownDTO, List<Models.multiselectvaluesDTO>> FieldValues { get; set; }
        //public int Id { get; set; }
        //public int ParentId { get; set; }

        //public string title { get; set; }
        // public List<MultiselectDropdownModel> subs { get; set; }
        //public List<MultiselectDropdownDTO> sub { get; set; }
        public multiselectvaluesModel Subs { get; set; }
        // public List<MultiselectDropdownDTO, List<Models.multiselectvaluesDTO>> sub { get; set; }
    }
}
