using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    /// <summary>
    /// It Contains Properties Of Layout
    /// </summary>
    public class LayoutDTO
    {
        /// <summary>
        /// It Contains UiPageMetadata record
        /// </summary>
        public UiPageMetadataDTO UiPageMetadata { get; set; }
        /// <summary>
        /// It Contains list of UiPageData record
        /// </summary>
        public List<UiPageDataDTO> UiPageData { get; set; }
        
    }
}
