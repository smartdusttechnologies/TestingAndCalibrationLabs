using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Contains The Properties For Layout
    /// </summary>
    [DbTable("CustomerDetails")]
    public class CustomerDetailsModel : Entity
    {
        /// <summary>
        /// It Contains The Name of The Layout
        /// </summary>
        [DbColumn]
        public string Name { get; set; }

        [DbColumn]
        public string Email { get; set; }
        

        [DbColumn]
        public string Address { get; set; }

        [DbColumn]
        public string Mobile { get; set; }
    }
}
