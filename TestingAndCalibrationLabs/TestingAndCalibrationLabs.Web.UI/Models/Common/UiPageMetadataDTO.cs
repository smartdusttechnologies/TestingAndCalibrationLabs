namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class UiPageMetadataDTO
    {
        /// <summary>
        /// Declaring properties 
        /// </summary>
        public int Id { get; set; }
        public int UiPageTypeId { get; set; }
        public string UiPageName { get; set; }
        public int UiControlTypeId { get; set; }
        public string UiControlType { get; set; }
        public bool IsRequired { get; set; }
        public string UiControlDisplayName { get; set; }
    
        
    }
}
