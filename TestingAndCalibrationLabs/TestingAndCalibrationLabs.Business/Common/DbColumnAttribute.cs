namespace TestingAndCalibrationLabs.Business.Common
{
    /// <summary>
    /// DbColumnAttribute Is Used To Get Attribute Value From Model Properties
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class DbColumnAttribute : System.Attribute
    {
        public string Name { get; set; }
        public DbColumnAttribute(string name)
        {
            Name = name;
        }
        public DbColumnAttribute()
        {
            Name = null;
        }
    }
}
