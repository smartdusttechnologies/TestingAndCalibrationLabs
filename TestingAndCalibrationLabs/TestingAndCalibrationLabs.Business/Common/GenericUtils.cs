using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Common
{
    /// <summary>
    /// These are common utility methods used across projects at class level. 
    /// </summary>
    public static class GenericUtils
    {
        private static readonly IWebHostEnvironment _webHostEnvironment;
        
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
        public static IEnumerable<Node<T>> Hierarchize<T, TKey, TOrderKey>(this IEnumerable<T> elements, TKey topMostKey, Func<T, TKey> keySelector, Func<T, TKey> parentKeySelector, Func<T, TOrderKey> orderingKeySelector)
        {
            var families = elements.ToLookup(parentKeySelector);
            var childrenFetcher = default(Func<TKey, IEnumerable<Node<T>>>);
            childrenFetcher = parentId => families[parentId]
                .OrderBy(orderingKeySelector)
                .Select(x => new Node<T>(x, childrenFetcher(keySelector(x))));

            return childrenFetcher(topMostKey);
        }
        public static string JsonToSql(string json)
        {
            var str = File.ReadAllText("SqlQuery.json");
            dynamic ob = JObject.Parse(str);
            if (ob != null)
            {
                string typ = ob.head.type.ToString();
                StringBuilder query = new StringBuilder(typ);
                if (ob.head.column != null)
                {
                    foreach (var col in ob.head.column)
                    {
                        query.Append($" {col.tableName}.{col.columnName} AS {col.As} ,");
                    }
                    query.Remove(query.Length - 1, 1);
                }
                query.Append($" FROM {ob.head.tableName.ToString()} ");
                if (ob.forign != null)
                {
                    foreach (var forign in ob.forign)
                    {
                        query.Append($"{forign.type} {forign.tableName} ON {forign.tableName}.{forign.on.pKey} {forign.on.optor} {forign.forignTableName}.{forign.on.fKey} ");
                    }
                }
                if (ob.condition != null)
                {
                    query.Append($"WHERE");
                    foreach (var condition in ob.condition)
                    {
                        query.Append($"{condition.tableName}.{condition.where} {condition.optor} {condition.value} AND ");
                    }
                    query.Remove(query.Length - 4, 4);
                }
                return query.ToString();
            }
            return null;
        }
        #endregion

    }
}

