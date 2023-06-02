
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{

    /// <summary>
    /// It Conatains The Properties for Record
    /// </summary>
    public class MultiselectDropdownModel : Entity
    {
        #region Public Properties
        //public int Id { get; set; }
        public int ParentId { get; set; }

        public string title { get; set; }
        public List<MultiselectDropdownModel> Children { get; set; }
        #endregion
    }



}

