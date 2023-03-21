using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Conatains The Properties for Records
    /// </summary>
    public class RecordsModel : Entity
    {
        public int ModuleId { get; set; }
        public string WorkflowStageName { get; set; }
        public IEnumerable<UiPageMetadataModel> Fields { get; set; }
        public Dictionary<int, List<Core.Model.UiPageDataModel>> FieldValues { get; set; }
        public  List<Core.Model.UiPageDataModel> FieldValue { get; set; }
    }
}
