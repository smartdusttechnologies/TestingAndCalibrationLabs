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
        public UiPageDataModel UiPageData { get; set; }
        public ListSorterModel UiPageDatas { get; set; }

        // public multiselectvaluesModel multivalue { get; set; }
    }
}
