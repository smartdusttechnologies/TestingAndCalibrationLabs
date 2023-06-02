using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{

    /// <summary>
    /// It Conatains The Properties for Record
    /// </summary>
    [DbTable("Record")]
    public class RecordModel : Entity
    {
        #region Public Properties
        //this is only used for validation only dont use any other place without any resone 
        public int UiPageTypeId { get; set; }
        public int ModuleId { get; set; }
        public int WorkflowStageId { get; set; }
        //public int LookupId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public List<UiPageMetadataModel> Fields { get; set; }
        public List<ListSorterModel> UiPage { get; set; }
        public List<UiPageDataModel> FieldValues { get; set; }
        public IEnumerable<Node<LayoutModel>> Layout { get; set; }
        #endregion
    }



}
