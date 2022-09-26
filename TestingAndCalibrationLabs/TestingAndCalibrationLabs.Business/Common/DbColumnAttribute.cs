using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Common
{

    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class DbColumnAttribute : System.Attribute
    {
        public string Name { get; set; }

        public DbColumnAttribute(string name)
        {
            Name = name;
        }
    }
}
