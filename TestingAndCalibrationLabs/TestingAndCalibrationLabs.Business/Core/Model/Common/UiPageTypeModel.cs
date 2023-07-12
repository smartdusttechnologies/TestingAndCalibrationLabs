using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{

    /// <summary>
    /// It Conatains The Properties for Ui Page Type
    /// </summary>
    [DbTable("UiPageType")]
    public class UiPageTypeModel : Entity
    {
        /// <summary>
        /// It Contains The Name For The Ui Page Type
        /// </summary>
        [DbColumn]
        
        public string Name { get; set; }
        
    }

}
