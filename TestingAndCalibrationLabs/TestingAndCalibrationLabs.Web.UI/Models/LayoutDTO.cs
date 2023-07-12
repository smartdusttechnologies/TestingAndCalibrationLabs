using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class LayoutDTO
    {
        public UiPageMetadataDTO UiPageMetadata { get; set; }
        public List<UiPageDataDTO> UiPageData { get; set; }
        


    }
}
