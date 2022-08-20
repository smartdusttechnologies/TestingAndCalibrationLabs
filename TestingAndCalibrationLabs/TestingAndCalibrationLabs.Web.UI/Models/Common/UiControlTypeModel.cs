﻿using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{    
    /// <summary>
    /// Declaring Public Properties
    /// </summary>
    public class UiControlTypeModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your displayname")]
        public string DisplayName { get; set; }
    }
}
