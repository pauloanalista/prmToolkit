using System;
using System.Collections.Generic;
using System.Reflection;


namespace prmToolkit.AccessMultipleDatabaseWithAdoNet.Helpers.Mapper
{
    public static class Null
    {
        private static Dictionary<string, object> _nullLookup;

        public static Dictionary<string, object> NullLookup
        {
            get
            {
                return _nullLookup;
            }
            private set
            {
                _nullLookup = value;
            }
        }

        public static short NullShort
        {
            get
            {
                return -1;
            }
        }
        public static int NullInteger
        {
            get
            {
                return -1;
            }
        }
        public static byte NullByte
        {
            get
            {
                return 255;
            }
        }
        public static float NullSingle
        {
            get
            {
                return float.MinValue;
            }
        }
        public static double NullDouble
        {
            get
            {
                return double.MinValue;
            }
        }
        public static decimal NullDecimal
        {
            get
            {
                return decimal.MinValue;
            }
        }
        public static DateTime NullDate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public static string NullString
        {
            get
            {
                return string.Empty;
            }
        }
        public static bool NullBoolean
        {
            get
            {
                return false;
            }
        }
        public static Guid NullGuid
        {
            get
            {
                return Guid.Empty;
            }
        }

        public static object SetNull(PropertyInfo objPropertyInfo)
        {
            object returnValue = null;

            if (NullLookup.TryGetValue(objPropertyInfo.PropertyType.ToString(), out returnValue))
                return returnValue;

            //Enumerations default to the first entry
            Type propertyType = objPropertyInfo.PropertyType;
            if (objPropertyInfo.PropertyType.BaseType.Equals(typeof(Enum)))
            {
                Array objEnumValues = Enum.GetValues(propertyType);
                Array.Sort(objEnumValues);
                return Enum.ToObject(propertyType, objEnumValues.GetValue(0));
            }

            return returnValue;
        }
        public static object GetNull(object objField, object objDBNull)
        {
            object returnValue = objField;
            if (objField == null)
            {
                returnValue = objDBNull;
            }
            else if (objField is byte)
            {
                if (Convert.ToByte(objField) == NullByte)
                {
                    returnValue = objDBNull;
                }
            }
            else if (objField is short)
            {
                if (Convert.ToInt16(objField) == NullShort)
                {
                    returnValue = objDBNull;
                }
            }
            else if (objField is int)
            {
                if (Convert.ToInt32(objField) == NullInteger)
                {
                    returnValue = objDBNull;
                }
            }
            else if (objField is float)
            {
                if (Convert.ToSingle(objField) == NullSingle)
                {
                    returnValue = objDBNull;
                }
            }
            else if (objField is double)
            {
                if (Convert.ToDouble(objField) == NullDouble)
                {
                    returnValue = objDBNull;
                }
            }
            else if (objField is decimal)
            {
                if (Convert.ToDecimal(objField) == NullDecimal)
                {
                    returnValue = objDBNull;
                }
            }
            else if (objField is DateTime)
            {
                // compare the Date part of the DateTime with the DatePart of the NullDate ( this avoids subtle time differences )
                if (Convert.ToDateTime(objField).Date == NullDate.Date)
                {
                    returnValue = objDBNull;
                }
            }
            else if (objField is string)
            {
                if (objField == null)
                {
                    returnValue = objDBNull;
                }
                else
                {
                    if (objField.ToString() == NullString)
                    {
                        returnValue = objDBNull;
                    }
                }
            }
            else if (objField is bool)
            {
                if (Convert.ToBoolean(objField) == NullBoolean)
                {
                    returnValue = objDBNull;
                }
            }
            else if (objField is Guid)
            {
                if (((Guid)objField).Equals(NullGuid))
                {
                    returnValue = objDBNull;
                }
            }
            return returnValue;
        }

        static Null()
        {
            // Initialise Lookup Dictionary
            NullLookup = new Dictionary<string, object>();

            // Add items as this isn't going to change.
            NullLookup["System.Int16"] = NullShort;
            NullLookup["System.Int32"] = NullInteger;
            NullLookup["System.Int64"] = NullInteger;
            NullLookup["System.Byte"] = NullByte;
            NullLookup["System.Single"] = NullSingle;
            NullLookup["System.Double"] = NullDouble;
            NullLookup["System.Decimal"] = NullDecimal;
            NullLookup["System.DateTime"] = NullDate;
            NullLookup["System.String"] = NullString;
            NullLookup["System.Char"] = NullString;
            NullLookup["System.Boolean"] = NullBoolean;
            NullLookup["System.Guid"] = NullGuid;
        }
    }
}
