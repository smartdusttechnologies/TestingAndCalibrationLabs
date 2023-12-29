using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using TestingAndCalibrationLabs.Business.Core.Model;

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
        public static List<T> ExcludeNoneId<T>(this IEnumerable<T> obj, bool allowNoneId)
        {
            if (allowNoneId)
            {
                var ti = obj.Where(x => (x as Entity).Id != 0).ToList();
            }
            return obj.ToList();

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
        public static IEnumerable<Node<T>> Hierarchize<T, TKey, TOrderKey>(this IEnumerable<T> elements, TKey topMostKey, Func<T, TKey> keySelector, Func<T, TKey> parentKeySelector, Func<T, TOrderKey> orderingKeySelector)
        {
            var families = elements.ToLookup(parentKeySelector);
            var childrenFetcher = default(Func<TKey, IEnumerable<Node<T>>>);
            childrenFetcher = parentId => families[parentId]
                .OrderBy(orderingKeySelector)
                .Select(x => new Node<T>(x, childrenFetcher(keySelector(x))));

            return childrenFetcher(topMostKey);
        }
        public static IEnumerable<Node<T>> Hierarchize1<T, TKey, TOrderKey>(this IEnumerable<T> elements, TKey topMostKey, Func<T, TKey> keySelector, Func<T, TKey> parentKeySelector, Func<T, TOrderKey> orderingKeySelector)
        {
            var families = elements.ToLookup(parentKeySelector);
            var childrenFetcher = default(Func<TKey, IEnumerable<Node<T>>>);
            childrenFetcher = parentId => families[parentId]
                .OrderBy(orderingKeySelector)
                .Select(x => new Node<T>(x, childrenFetcher(keySelector(x))));

            return childrenFetcher(topMostKey);
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
        public static DataTable GetDataTable<T>(IEnumerable<T> list)
        {
            var table = new DataTable();
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                table.Columns.Add(property.Name, System.Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }
            foreach (var item in list)
            {
                var row = table.NewRow();
                foreach (var property in properties)
                {
                    row[property.Name] = property.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }
            return table;
        }
        #endregion
    }
}
