using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Common
{
    public class GTRLWebsiteModel
    {
        /// <summary>
        /// It Contains The Id of The Data Type
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// It Contains The Email of The Data Type
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// It Contains The Contact of The Data Type
        /// </summary>
        public string Contact { get; set; }
        /// <summary>
        /// It Contains The CompanyImageURl of The Data Type
        /// </summary>
        public string CompanyImageURl { get; set; }
        /// <summary>
        /// It Contains The FacebookURL of The Data Type
        /// </summary>
        public string FacebookURL { get; set; }
        /// <summary>
        /// It Contains The linkedlnURL of The Data Type
        /// </summary>
        public string linkedlnURL { get; set; }

        public string XUrl { get; set; }
        public string Image { get; set; }
        public string Header { get; set; }
        public string Paragraph { get; set; }
    }
}
