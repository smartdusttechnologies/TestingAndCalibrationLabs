using System.ComponentModel.DataAnnotations;
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
        [DbColumn("thisiSattributetext")]
        
        public string fdgfd { get; set; }
        [DbColumn("fdgdgdg")]
        
        public string dfgdgd { get; set; }
        [DbColumn("dfgdgd")]
        
        public string Name { get; set; }
        [DbColumn("")]
        
        public string emptyAttributeHaibhia { get; set; }
    }
}
