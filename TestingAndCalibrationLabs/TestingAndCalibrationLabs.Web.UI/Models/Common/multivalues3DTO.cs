using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using System;
using Microsoft.VisualBasic;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class multivalues3DTO
    {
        // public Dictionary<string, double> Data { get; set; }
        //public Dictionary<MultiselectDropdownDTO, List<Models.multiselectvaluesDTO>> FieldValues { get; set; }
        //public int Id { get; set; }

        //public string title { get; set; }
        //public int ParentId { get; set; }

        public multiselectvaluesDTO Subs { get; set; }
        //public List<MultiselectDropdownDTO> sub { get; set; }

        // public List<MultiselectDropdownDTO, List<Models.multiselectvaluesDTO>> sub { get; set; }
    }
}
