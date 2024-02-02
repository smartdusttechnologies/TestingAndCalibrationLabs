using System.ComponentModel.DataAnnotations;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    [DbTable("Group")]
    /// <summary>
    /// Group Model.
    /// </summary>
    public class GroupModel
    {
        [DbColumn]

        /// <summary>
        /// It Contains The Id of The Group
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// It Contains The Name of The Group
        /// </summary>///

        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }

    }
}

