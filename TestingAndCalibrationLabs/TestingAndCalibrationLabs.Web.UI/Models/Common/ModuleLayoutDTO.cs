using System.ComponentModel.DataAnnotations;

namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class ModuleLayoutDTO
    {
        public int Id {  get; set; } 
        public string Name { get; set; }
        public int ModuleId { get; set; }   
        public string ModuleName { get; set; }
        public int LayoutId { get; set; }   
        public string LayoutName { get; set; }      

    }
}
