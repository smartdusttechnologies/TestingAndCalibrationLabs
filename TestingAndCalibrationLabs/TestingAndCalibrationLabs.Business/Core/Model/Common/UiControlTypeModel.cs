using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
      /// <summary>
      /// It Conatains The Properties for Ui Control Type 
      /// </summary>
    [DbTable("UiControlType")]
    public class UiControlTypeModel : Entity
    {
        /// <summary>
        /// It Contains The Name of The Ui Control Type
        /// </summary>
        [DbColumn]
        public string Name { get; set; }
        /// <summary>
        /// It Contains The DisplayName of The Ui Control Type
        /// </summary>
        [DbColumn]
        public string DisplayName { get; set; }
        /// <summary>
        /// It Contains The ControlCategoryId of The Ui Control Type
        /// </summary>
        public int ControlCategoryId { get; set; }
        /// <summary>
        /// It Contains The ControlCategoryName of The Ui Control Type
        /// </summary>
        public string ControlCategoryName { get; set;}

    }
}
