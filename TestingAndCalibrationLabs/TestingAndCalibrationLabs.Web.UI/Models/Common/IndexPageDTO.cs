namespace TestingAndCalibrationLabs.Web.UI.Models.Common
{
    public class IndexPageDTO
    {
        /// <summary>
        /// It Contains The PageTitle of the UI pages
        /// </summary>
        public string PageTitle { get; set; }
        /// <summary>
        /// It Contains the List of Columns and Values 
        /// </summary>
        public GridDTO GridData { get; set; }   
    }
}
