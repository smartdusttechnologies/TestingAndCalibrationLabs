using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class LayoutDTO
    {
        public UiPageMetadataDTO UiPageMetadata { get; set; }
        public  List<UiPageDataDTO> UiPageData { get; set; }
    }
}
