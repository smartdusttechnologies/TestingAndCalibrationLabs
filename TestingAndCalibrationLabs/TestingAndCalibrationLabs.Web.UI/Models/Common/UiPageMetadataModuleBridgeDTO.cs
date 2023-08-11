namespace TestingAndCalibrationLabs.Web.UI.Models
{

    public class UiPageMetadataModuleBridgeDTO
    {
        public int Id { get; set; } 
        public int UiPageMetadataId { get; set; }
       // public string UiControlDisplayName { get; set; }    
        public int UiPageTypeId { get; set; }
        public string UiPageTypeName { get; set; }
         public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public int ParentId { get; set; }
        public int Orders { get; set; }
        public string UiControlDisplayName { get; set; }

        public string MultiValueControl { get; set; }

    } 
}
