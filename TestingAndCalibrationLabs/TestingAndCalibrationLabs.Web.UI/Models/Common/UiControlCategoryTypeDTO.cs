namespace TestingAndCalibrationLabs.Web.UI.Models
{
    /// <summary>
    /// It Contains The Properties for Ui Control Category Type
    /// </summary>
    public class UiControlCategoryTypeDTO
    {
        /// <summary>
        /// It Contains The Id of The Ui Control Category Type
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// It Contains The Name of The Ui Control Category Type
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// It Contains The Template of The Ui Control Category Type
        /// </summary>
        public string Template { get; set; }
        /// <summary>
        /// It Contains The UiControlTypeId from Ui Control Type
        /// </summary>
        public int UiControlTypeId { get; set; }
        /// <summary>
        /// It Contains The UiControlTypeName From Ui Control Type 
        /// </summary>
        public string UiControlTypeName { get; set; }
    }
}