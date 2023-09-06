using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{

    public class ModuleLayoutModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public int LayoutId { get; set; }
        public string LayoutName { get; set; }
    }
}
