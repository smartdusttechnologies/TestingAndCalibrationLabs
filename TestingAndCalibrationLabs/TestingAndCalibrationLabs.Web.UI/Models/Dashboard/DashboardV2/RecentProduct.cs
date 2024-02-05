using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Web.UI.Models.Dashboard.DashboardV2
{
    public class RecentProduct
    {
        /// <summary>
        /// To store the Product Price
        /// </summary>
        public List<string> Price { get; set; }
        /// <summary>
        /// To store the Name
        /// </summary>
        public List<string> Name { get; set; }
        /// <summary>
        /// To store the details of the Products
        /// </summary>
        public List<string> ProductDetails { get; set; }
        /// <summary>
        /// To store the Images of Product
        /// </summary>
        public List<string> ProductImg { get; set; }

    }
}
