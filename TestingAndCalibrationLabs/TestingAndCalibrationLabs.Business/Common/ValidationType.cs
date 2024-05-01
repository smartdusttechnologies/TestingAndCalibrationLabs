using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Common
{
    public enum ValidationType
    {
        MinPasswordLength =1,
        Email,
        AdharLength,
        MobileNumberLength,
        Year,
        Name,
        IsRequired,
        Password,
        DataType,
        Int = 1,
        String = 2,
        bit =3 ,
        Decimal = 4,
        Date = 5,
        Boolean =6
    }
   
}
