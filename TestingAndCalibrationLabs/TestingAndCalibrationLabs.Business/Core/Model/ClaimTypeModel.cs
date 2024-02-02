using System.ComponentModel.DataAnnotations;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    [DbTable("ClaimType")]
    /// <summary>
    /// Claim Type Model.
    /// </summary>
    public class ClaimTypeModel
    {
        [DbColumn]

        /// <summary>
        /// It Contains The Id of The Claim Type
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// It Contains The Name of The Claim Type
        /// </summary>///

        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }

        /// <summary>
        /// It Contains The value of The Claim Type
        /// </summary>

        [DbColumn]

        [Required(ErrorMessage = "Please Enter your Value")]
        public string Value { get; set; }
    }
}
