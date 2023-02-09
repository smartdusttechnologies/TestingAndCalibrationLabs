using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Conatains The Properties for Lookup Category
    /// </summary>
    [DbTable("Application")]
    public class ApplicationModel : Entity
    {
       

        /// <summary>
        /// It Contains The Name Of The Lookup Category
        /// </summary>
        /// 
        //public int Id { get; set; }
        public string Name { get; set; }
        
        

    }
}
