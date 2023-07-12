namespace TestingAndCalibrationLabs.Business.Common
{
    /// <summary>
    /// To Get Table Name From Model Using DbTableAttribute 
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Class)]
    
    public class DbTableAttribute : System.Attribute
    {
        public string Name { get; set; }
        public DbTableAttribute(string name)
        {
            Name = name;
        }
    }
}
