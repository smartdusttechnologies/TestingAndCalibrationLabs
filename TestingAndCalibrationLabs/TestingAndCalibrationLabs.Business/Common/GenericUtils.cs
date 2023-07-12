using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
        /// <summary>
        /// To Get Table Name Of Model With The Help Of DbTableAttributes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
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
        /// <summary>
        /// To Get All ColumnNames Of A Given Model With DbColumnAttribute
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<string> GetDbColumnName<T>()
        {
            var _listOfColumns = new List<string>();
            var propertieList = GetApplicableProperties(typeof(T).GetProperties().AsEnumerable());
            foreach (PropertyInfo prop in propertieList)
            {
                object[] attributeList = prop.GetCustomAttributes(true);
                foreach (var attribute in attributeList)
                {
                    string columnName;
                    if (!(attribute is DbColumnAttribute dbColumnAttribute))
                        continue;
                    else if (string.IsNullOrEmpty(dbColumnAttribute.Name))
                        columnName = prop.Name;
                    else
                        columnName = dbColumnAttribute.Name;

                    _listOfColumns.Add(columnName);
                }
            }
            return _listOfColumns;
        }
        #endregion

        #region private methods
        private static List<PropertyInfo> GetApplicableProperties(IEnumerable<PropertyInfo> listOfProperties)
        {
            return (from prop in listOfProperties
                    let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    where attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "ignore"
                    select prop).ToList();
        }
        #endregion
    }
}

