using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Conatains The Properties for Ui Control Category Type 
    /// </summary>
    [DbTable("UiControlCategoryType")]
    public class UiControlCategoryTypeModel : Entity
    {
        /// <summary>
        /// It Contains The Name of The Ui Control Category Type
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// It Contains The Template of The Ui Control Category Type
        /// </summary>
        public string Template { get; set; }
        /// <summary>
        /// It Contains The UiControlTypeId from Ui Control Type
        /// </summary>
        public int UiControlTypeId { get; set; }
        /// <summary>
        /// It Contains The UiControlTypeName From Ui Control Type 
        /// </summary>
        public string UiControlTypeName { get; set; }
    }
}