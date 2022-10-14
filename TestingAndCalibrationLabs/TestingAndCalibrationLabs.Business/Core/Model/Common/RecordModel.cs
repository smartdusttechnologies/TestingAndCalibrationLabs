using System;
using System.Collections.Generic;
using System.Text;
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
        public int UiPageId { get; set; }

        public List<UiPageMetadataModel> Fields { get; set; }

        public List<UiPageDataModel> FieldValues { get; set; }
        public Node<UiPageMetadataModel> Layout { get; set; }
        #endregion
    }



}
