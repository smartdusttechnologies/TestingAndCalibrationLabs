using System.ComponentModel;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public abstract class Entity
    {
        [Description("ignore")]
        public virtual int Id { get; set; }
    }
}
