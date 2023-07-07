using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Contains Properties Of Layout
    /// </summary>
    public class LayoutModel
    {
        /// <summary>
        /// It Contains List Of UiPageMetadata
        /// </summary>
        public UiPageMetadataModel UiPageMetadata { get; set; }
        /// <summary>
        /// It Contains List Of UiPageData
        /// </summary>
        public List<UiPageDataModel> UiPageData { get; set; }

    }
}
