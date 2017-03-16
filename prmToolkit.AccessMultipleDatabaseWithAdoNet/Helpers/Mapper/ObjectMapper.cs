using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Reflection;

namespace prmToolkit.AccessMultipleDatabaseWithAdoNet.Helpers.Mapper
{
    /// <summary>
    /// Hydrates objects with data from a datareader
    /// 
    /// NOTE: Does not work for properties which are complex objects (e.g. ArrayLists, HashTables, Custom Objects etc).
    /// IF complex objects need to be filled, more custom code will need to be written.
    /// </summary>
    public static class ObjectMapper
    {
        #region Fields

        private static readonly object _lock = new object();
        private static ICacheHelper _cacheHelper = null;

        #endregion

        #region Properties

        // TODO: If this is now threadsafe?
        public static ICacheHelper CacheHelper
        {
            get
            {
                lock (_lock)
                {
                    return _cacheHelper;
                }
            }
            set
            {
                lock (_lock)
                {
                    _cacheHelper = value;
                }
            }
        }

        #endregion

        #region Methods


        public static T FillObject<T>(object value)
        {
            if (value == null || value is DBNull) return default(T);
            if (value is T) return (T)value;
            var type = typeof(T);
            type = Nullable.GetUnderlyingType(type) ?? type;
            if (type.IsEnum)
            {
                if (value is float || value is double || value is decimal)
                {
                    value = Convert.ChangeType(value, Enum.GetUnderlyingType(type), CultureInfo.InvariantCulture);
                }
                return (T)Enum.ToObject(type, value);
            }
            return (T)Convert.ChangeType(value, type, CultureInfo.InvariantCulture);
        }

        public static T FillObject<T>(IDataReader datareader) where T : class, new()
        {
            return FillObject<T>(datareader, null, false);
        }
        public static T FillObject<T>(IDataReader datareader, Action<T> callback) where T : class, new()
        {
            var result = FillObject<T>(datareader);

            if (result != null)
                callback(result);

            return result;
        }
        public static T FillObject<T>(IDataReader datareader, T instance, bool overwriteExistingProperties) where T : class, new()
        {
            T fillObject;

            bool shouldContinue = false;

            if (datareader != null && datareader.Read())
            {
                shouldContinue = true;
            }

            if (shouldContinue)
            {
                fillObject = CreateObject<T>(datareader, instance, overwriteExistingProperties);
            }
            else
            {
                fillObject = default(T);
            }

            if (datareader != null)
            {
                datareader.Close();
            }

            return fillObject;
        }
        public static T FillObject<T>(IDataReader datareader, T instance, bool overwriteExistingProperties, Action<T> callback) where T : class, new()
        {
            var result = FillObject<T>(datareader, instance, overwriteExistingProperties);

            if (result != null)
                callback(result);

            return result;
        }

        public static T FillObject<T>(DataTable dataTable) where T : class, new()
        {
            return FillObject<T>(dataTable.CreateDataReader());
        }
        public static T FillObject<T>(DataTable dataTable, Action<T> callback) where T : class, new()
        {
            var result = FillObject<T>(dataTable.CreateDataReader());

            if (result != null)
                callback(result);

            return result;
        }
        public static T FillObject<T>(DataTable dataTable, T instance, bool overwriteExistingProperties) where T : class, new()
        {
            return FillObject<T>(dataTable.CreateDataReader(), instance, overwriteExistingProperties);
        }
        public static T FillObject<T>(DataTable dataTable, T instance, bool overwriteExistingProperties, Action<T> callback) where T : class, new()
        {
            var result = FillObject<T>(dataTable.CreateDataReader(), instance, overwriteExistingProperties);

            if (result != null)
                callback(result);

            return result;
        }

        public static List<T> FillCollection<T>(IDataReader datareader) where T : class, new()
        {
            List<T> listObjects = new List<T>();

            if (datareader != null)
            {
                while (datareader.Read())
                {
                    T fillObject = CreateObject<T>(datareader);

                    listObjects.Add(fillObject);
                }

                datareader.Close();
            }

            return listObjects;
        }
        public static List<T> FillCollection<T>(IDataReader datareader, Action<T> callback) where T : class, new()
        {
            List<T> listObjects = new List<T>();

            if (datareader != null)
            {
                while (datareader.Read())
                {
                    T fillObject = CreateObject<T>(datareader);

                    if (fillObject != null)
                    {
                        callback(fillObject);
                        listObjects.Add(fillObject);
                    }
                }

                datareader.Close();
            }

            return listObjects;
        }

        public static List<T> FillCollection<T>(DataTable dataTable) where T : class, new()
        {
            return FillCollection<T>(dataTable.CreateDataReader());
        }
        public static List<T> FillCollection<T>(DataTable dataTable, Action<T> callback) where T : class, new()
        {
            return FillCollection<T>(dataTable.CreateDataReader(), callback);
        }

        private static T CreateObject<T>(IDataReader datareader, T instance = null, bool overwriteProperties = false) where T : class, new()
        {
            T objectInstance = instance;
            if (objectInstance == null)
                objectInstance = new T();

            // 1. Get cached object property data.
            var cachedPropertyInfo = GetPropertyInfo(typeof(T));

            // 2. Loop through datareader columns.
            for (int i = 0; i < datareader.FieldCount; i++)
            {
                PropertyInfo propertyInfo = null;
                object columnValue = null;
                object columnType = null;

                // 3. Check if column exists in object property data.
                if (cachedPropertyInfo.TryGetValue(datareader.GetName(i).ToUpperInvariant(), out propertyInfo))
                {
                    // 4. If column exists and writable, set property with value.
                    if (propertyInfo.CanWrite)
                    {
                        // 5. Get the column value and type.
                        columnValue = datareader.GetValue(i);
                        columnType = columnValue.GetType();

                        // 6. Check for existing object.
                        if (instance != null && propertyInfo.CanRead)
                        {
                            // 6a. Check if the property is set.
                            var currentPropertyValue = propertyInfo.GetValue(instance);

                            // 6b. Get the default value
                            var defaultValue = GetDefault(propertyInfo.PropertyType);

                            // 6c.  Check if value is not default and if properties should not be overwritten.
                            //      If the property is 'default' it can be set.
                            if (!object.Equals(currentPropertyValue, defaultValue) && !overwriteProperties)
                                continue;
                        }

                        // 7. If column value is null, set property value to Null value.
                        if (columnValue == null || columnValue == DBNull.Value)
                        {
                            propertyInfo.SetValue(objectInstance, Null.SetNull(propertyInfo), null);
                        }
                        // 8. If property type is the same as the column value type, set.
                        else if (propertyInfo.PropertyType.Equals(columnType))
                        {
                            propertyInfo.SetValue(objectInstance, columnValue, null);
                        }
                        // 9. Otherwise data types do not match.
                        else
                        {
                            // 10. Check for Enum as this needs to be handled differently.
                            if (propertyInfo.PropertyType.BaseType.Equals(typeof(Enum)))
                            {
                                // 10a. Check if the value is numeric.
                                if (columnValue is int || columnValue is float || columnValue is double || columnValue is decimal)
                                {
                                    propertyInfo.SetValue(objectInstance, Enum.ToObject(propertyInfo.PropertyType, Convert.ToInt32(columnValue)), null);
                                }
                                // 10b. Check if value is string - this is bad for performance.
                                else if (columnValue is string)
                                {

                                }
                                // 10c. Is another type.
                                else
                                {
                                    propertyInfo.SetValue(objectInstance, Enum.ToObject(propertyInfo.PropertyType, columnValue), null);
                                }
                            }
                            // 11. Check for Guid type.
                            else if (columnValue is Guid)
                            {
                                propertyInfo.SetValue(objectInstance, Convert.ChangeType(new Guid(columnValue.ToString()), propertyInfo.PropertyType), null);
                            }
                            // 12. If value is convertible
                            else if (columnValue is IConvertible)
                            {
                                propertyInfo.SetValue(objectInstance, ChangeType(columnValue, propertyInfo.PropertyType), null);
                            }
                            // 13. Try to explicitly set.
                            else
                            {
                                propertyInfo.SetValue(objectInstance, columnValue, null);
                            }
                        }
                    }
                }
            }

            return objectInstance;
        }

        private static Dictionary<string, PropertyInfo> GetPropertyInfo(Type objectType)
        {
            Dictionary<string, PropertyInfo> objectProperties = CacheHelper.GetFromCache<Dictionary<string, PropertyInfo>>(objectType.FullName);

            if (objectProperties == null)
            {
                objectProperties = new Dictionary<string, PropertyInfo>();

                foreach (PropertyInfo objectProperty in objectType.GetProperties())
                {
                    objectProperties.Add(objectProperty.Name.ToUpperInvariant(), objectProperty);
                }

                CacheHelper.SaveToCache(objectType.FullName, objectProperties, DateTime.Now.AddMinutes(10));
            }

            return objectProperties;
        }

        // TODO: Cache this for the object type?
        private static int[] GetOrdinals(List<PropertyInfo> objProperties, IDataReader datareader)
        {
            int[] listOrdinals = new int[objProperties.Count + 1];

            if (datareader != null)
            {
                for (int i = 0; i < objProperties.Count; i++)
                {
                    listOrdinals[i] = -1;
                    try
                    {
                        listOrdinals[i] = datareader.GetOrdinal(((PropertyInfo)objProperties[i]).Name);
                    }
                    catch (Exception)
                    {
                        // property does not exist in datareader - this exception is super expensive as it's per object rather than caching.              
                    }
                }
            }

            return listOrdinals;
        }

        private static object ChangeType(object obj, Type type)
        {
            Type convertToType = Nullable.GetUnderlyingType(type) ?? type;

            if (obj == null)
                return GetDefault(convertToType);

            return Convert.ChangeType(obj, convertToType);
        }
        private static object GetDefault(Type type)
        {
            if (type.IsValueType)
                return Activator.CreateInstance(type);

            return null;
        }

        #endregion

        #region Constructor

        static ObjectMapper()
        {
            CacheHelper = new CacheHelper();
        }

        #endregion
    }
}
