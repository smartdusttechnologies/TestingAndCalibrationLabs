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
        public int UiPageTypeId { get; set; }
        public int ModuleId { get; set; }
        public List<UiPageMetadataModel> Fields { get; set; }

        public List<UiPageDataModel> FieldValues { get; set; }
        public IEnumerable<Node<LayoutModel>> Layout { get; set; }
        #endregion
    }



}
