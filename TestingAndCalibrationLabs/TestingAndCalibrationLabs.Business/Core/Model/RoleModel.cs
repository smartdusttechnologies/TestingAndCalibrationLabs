using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    [DbTable("Role")]
    /// <summary>
    /// Role Model.
    /// </summary>
    public class RoleModel
    {
        [DbColumn]

        /// <summary>
        /// It Contains The Id of The Role.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// It Contains The Name of The Role
        /// </summary>///

        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }

        /// <summary>
        /// It Contains The Level of The Role
        /// </summary>

        [DbColumn]

        [Required(ErrorMessage = "Please Enter your Level")]
        public string Level { get; set; }
    }
}
