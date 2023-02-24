﻿using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    /// <summary>
    /// It Conatains The Properties for  Data Type
    /// </summary>
    public class ApplicationDTO
    {
        /// <summary>
        /// It Contains The Id of The Data Type
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// It Contains The Name of The Data Type
        /// </summary>
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Please Enter Description")]
        public string Description { get; set; }
    }
}
