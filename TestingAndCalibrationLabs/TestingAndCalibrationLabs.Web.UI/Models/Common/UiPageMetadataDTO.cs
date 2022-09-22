using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    /// <summary>
    /// It Conatains The Properties for Ui Page Metadata
    /// </summary>
    public class UiPageMetadataDTO
    {
        /// <summary>
        /// It Contains The Id of The Ui Page Metadata
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// It Contains The Id of The Ui Page Type
        /// </summary>
        [Required(ErrorMessage = "Please Select  Page Type")]
        public int UiPageTypeId { get; set; }
        /// <summary>
        /// It Contains The Name of The Ui Page Type
        /// </summary>
        public string UiPageTypeName { get; set; }
        /// <summary>
        /// It Contains The Id of The Ui Control Type
        /// </summary>
        [Required(ErrorMessage = "Please Select Control Type")]
        public int UiControlTypeId { get; set; }
        /// <summary>
        /// It Contains The Name of The Ui Control Type
        /// </summary>
        public string UiControlTypeName { get; set; }
        /// <summary>
        /// It Contains The IsRequired of The Ui Page Metadata
        /// </summary>
        public bool IsRequired { get; set; }
        
        /// <summary>
        /// It Contains The UiControlDisplayName of The Ui Page Metadata
        /// </summary>
        [Required(ErrorMessage = "Please Enter Ui Control Display Name")]
        public string UiControlDisplayName { get; set; }
        /// <summary>
        /// It Contains The Id of The Data Type
        /// </summary>
        [Required(ErrorMessage = "Please Select Data Type")]
        public int DataTypeId { get; set; }
        /// <summary>
        /// It Contains The Name of The Data Type
        /// </summary>
        public string DataTypeName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? LookupCategoryId { get; set; }
        /// <summary>
        /// It Contains the Name Of The Lookup Category
        /// </summary>
        public string LookupCategoryName { get; set; }
        /// <summary>
        /// It Contains The SelectedLookupId From ComboTree
        /// </summary>
        public List<int> SelectedLookupId { get; set; }
        /// <summary>
        /// It Contains The List Of UiPageMetadataCharacteristics For Ui Page Metadata
        /// </summary>
        public List<UiPageMetadataCharacteristicsModel> uiPageMetadataCharacteristics { get; set; }
    }
}
