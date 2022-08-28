using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
      /// <summary>
      /// It Conatains The Properties for Ui Control Type 
      /// </summary>
    [DbTableAttribute("UiControlType")]
    public class UiControlTypeModel : Entity
    {
        /// <summary>
        /// It Contains The Name of The Ui Control Type
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// It Contains The DisplayName of The Ui Control Type
        /// </summary>
        public string DisplayName { get; set; }
    }
}
