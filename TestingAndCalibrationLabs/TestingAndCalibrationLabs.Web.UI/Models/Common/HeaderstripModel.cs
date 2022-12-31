using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{

    /// <summary>
    /// This Model is Design For Home Page Header
    /// </summary> 
    public class HeaderstripModel
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
        /// It Contains The AwardImageURL1 of The Data Type
        /// </summary>
        public string AwardImageURL1 { get; set; }
        /// <summary>
        /// It Contains The AwardImageURL2 of The Data Type
        /// </summary>
        public string AwardImageURL2 { get; set; }
        /// <summary>
        /// It Contains The AwardImageURL3 of The Data Type
        /// </summary>
        public string AwardImageURL3 { get; set; }
        /// <summary>
        /// It Contains The FacebookIcon of The Data Type
        /// </summary>
        public string FacebookIcon { get; set; }
        /// <summary>
        /// It Contains The linkedlnIcon of The Data Type
        /// </summary>
        public string linkedlnIcon { get; set; }
    }
}
