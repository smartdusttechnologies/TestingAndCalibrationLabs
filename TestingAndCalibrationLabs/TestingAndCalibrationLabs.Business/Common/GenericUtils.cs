using System;
using System.Collections.Generic;
using System.Linq;

namespace TestingAndCalibrationLabs.Business.Common
{
    /// <summary>
    /// These are common utility methods used across projects at class level. 
    /// </summary>
    public static class GenericUtils
    {
        #region Public Methods
        /// <summary>
        /// List is always instantiated even when it is passed as null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static List<T> ToNonNullList<T>(this IEnumerable<T> obj)
        {
            return obj == null ? new List<T>() : obj.ToList();
        }

        public static string GetDbTableName<T>()
        {
            var tableAttribute = typeof(T).GetCustomAttributes(
                typeof(DbTableAttribute), true
            ).FirstOrDefault() as DbTableAttribute;
            if (tableAttribute != null)
            {
                return tableAttribute.Name;
            }
            return null;
        }
        
        #endregion

    }
}

