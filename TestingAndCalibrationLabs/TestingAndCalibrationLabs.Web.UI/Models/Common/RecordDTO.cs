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
    public class RecordDTO
    {
        #region Public Properties
        public int Id { get; set; }
        public int UiPageTypeId { get; set; }
        public int ModuleId { get; set; }
        public int WorkflowStageId { get; set; }
        public int RecordId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public List<UiPageMetadataDTO> Fields { get; set; }
        public List<UiPageDataDTO> FieldValues { get; set; }
        public string ModuleName { get; set; }
        public IEnumerable<Node<LayoutDTO>> Layout { get; set; }
        public IList<ValidationMessage> ErrorMessage { get; set; }
        #endregion
    }
}