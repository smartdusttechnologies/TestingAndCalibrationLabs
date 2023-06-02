using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using System;
using Microsoft.VisualBasic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    /// <summary>
    /// Declaring Public Properties
    /// </summary>
    public class MultiselectDropdownDTO
    {
        // public string sub { get; set; }
        // public string Id { get; set; }
        //public string Birds { get; set; }

        // public string Cats { get; set; }
        // public string Bigs { get; set; }

        //public List<List<string>> Birds { get; set; }
        // public List<List<string>> Cats { get; set; }
        //public List<List<string>> Bigs { get; set; }
        //public int Id { get; set; }
        //public string title { get; set; }
        //public int Parentid { get; set; }
        //public IEnumerable<Node<LayoutModel>> Layout { get; set; }
        public int Id { get; set; }
        public int ParentId { get; set; }

        public string title { get; set; }
        public List<MultiselectDropdownDTO> Children { get; set; }


        

    }
}
