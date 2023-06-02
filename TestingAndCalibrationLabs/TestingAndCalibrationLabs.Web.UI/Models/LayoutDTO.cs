using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class LayoutDTO
    {
        public UiPageMetadataDTO UiPageMetadata { get; set; }
        public UiPageDataDTO UiPageData { get; set; }
        //public multivalues3DTO multivalue { get; set; }
        public ListSorterModel UiPageDatas { get; set; }


    }
}
