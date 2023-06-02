using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using System;
using Microsoft.VisualBasic;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class multiselectvaluesDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int ParentId { get; set; }
        //public int Orders { get; set; }
       // public int Position { get; set; }
        //public string Category { get; set; }

    }
}
