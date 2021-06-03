﻿using System;
using System.Data;
namespace SqlSugar
{
    public static partial class IDataRecordExtensions
    {

        #region Common Extensions
        public static Guid GetStringGuid(this IDataRecord dr, int i)
        {
            var result = Guid.Parse(dr.GetValue(i).ToString());
            return result;
        }

        public static Guid? GetConvertStringGuid(this IDataRecord dr, int i)
        {
            if (dr.IsDBNull(i))
            {
                return Guid.Empty;
            }
            var result = Guid.Parse(dr.GetValue(i).ToString());
            return result;
        }

        public static bool? GetConvertBoolean(this IDataRecord dr, int i)
        {
            var result = dr.GetBoolean(i);
            return result;
        }

        public static byte? GetConvertByte(this IDataRecord dr, int i)
        {
            if (dr.IsDBNull(i))
            {
                return null;
            }
            var result = dr.GetByte(i);
            return result;
        }

        public static char? GetConvertChar(this IDataRecord dr, int i)
        {
            if (dr.IsDBNull(i))
            {
                return null;
            }
            var result = dr.GetChar(i);
            return result;
        }

        public static DateTime? GetConvertDateTime(this IDataRecord dr, int i)
        {
            var result = dr.GetDateTime(i);
            if (result == DateTime.MinValue)
            {
                return null; ;
            }
            return result;
        }
        public static DateTime? GetConvertTime(this IDataRecord dr, int i)
        {
            var result = dr.GetValue(i);
            if (result == DBNull.Value)
            {
                return null; ;
            }
            return Convert.ToDateTime(result.ToString());
        }
        public static DateTime GetTime(this IDataRecord dr, int i)
        {
            return Convert.ToDateTime(dr.GetValue(i).ToString());
        }

        public static decimal? GetConvertDecimal(this IDataRecord dr, int i)
        {
            if (dr.IsDBNull(i))
            {
                return null;
            }
            var result = dr.GetDecimal(i);
            return result;
        }


        public static double? GetConvertDouble(this IDataRecord dr, int i)
        {
            if (dr.IsDBNull(i))
            {
                return null;
            }
            var result = dr.GetDouble(i);
            return result;
        }


        public static float? GetConvertDoubleToFloat(this IDataRecord dr, int i)
        {
            if (dr.IsDBNull(i))
            {
                return null;
            }
            var result = dr.GetDouble(i);
            return Convert.ToSingle(result);
        }


        public static Guid? GetConvertGuid(this IDataRecord dr, int i)
        {
            if (dr.IsDBNull(i))
            {
                return null;
            }
            var result = dr.GetGuid(i);
            return result;
        }

        public static short? GetConvertInt16(this IDataRecord dr, int i)
        {
            if (dr.IsDBNull(i))
            {
                return null;
            }
            var result = dr.GetInt16(i);
            return result;
        }

        public static Int32? GetConvertInt32(this IDataRecord dr, int i)
        {
            if (dr.IsDBNull(i))
            {
                return null;
            }
            var result = dr.GetInt32(i);
            return result;
        }
        //public static T GetConvertValue<T>(this IDataRecord dr, int i)
        //{
        //    try
        //    {
        //        if (dr.IsDBNull(i))
        //        {
        //            return default(T);
        //        }
        //        var result = dr.GetValue(i);
        //        return UtilMethods.To<T>(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return OtherException<T>(dr, i, ex);
        //    }
        //}

        public static long? GetConvetInt64(this IDataRecord dr, int i)
        {
            if (dr.IsDBNull(i))
            {
                return null;
            }
            var result = dr.GetInt64(i);
            return result;
        }

        public static float? GetConvertFloat(this IDataRecord dr, int i)
        {
            if (dr.IsDBNull(i))
            {
                return null;
            }
            var result = dr.GetFloat(i);
            return result;
        }

        public static DateTime GetdatetimeoffsetDate(this IDataRecord dr, int i)
        {
            if (dr.IsDBNull(i))
            {
                return DateTime.MinValue;
            }
            var offsetValue = (DateTimeOffset)dr.GetValue(i);
            var result = offsetValue.DateTime;
            return result;
        }

        public static DateTime? GetConvertdatetimeoffsetDate(this IDataRecord dr, int i)
        {
            if (dr.IsDBNull(i))
            {
                return DateTime.MinValue;
            }
            var offsetValue = (DateTimeOffset)dr.GetValue(i);
            var result = offsetValue.DateTime;
            return result;
        }

        public static DateTimeOffset Getdatetimeoffset(this IDataRecord dr, int i)
        {
            if (dr.IsDBNull(i))
            {
                return default(DateTimeOffset);
            }
            var date = dr.GetValue(i);
            if (date is DateTime)
            {
               return UtilMethods.GetDateTimeOffsetByDateTime((DateTime)(date));
            }
            else
            {
                var result = (DateTimeOffset)date;
                return result;
            }
        }

        public static DateTimeOffset? GetConvertdatetimeoffset(this IDataRecord dr, int i)
        {
            if (dr.IsDBNull(i))
            {
                return default(DateTimeOffset);
            }
            var date = dr.GetValue(i);
            if (date is DateTime)
            {
                return UtilMethods.GetDateTimeOffsetByDateTime((DateTime)(date));
            }
            else
            {
                var result = (DateTimeOffset)date;
                return result;
            }
        }


        public static string GetConvertString(this IDataRecord dr, int i)
        {
            if (dr.IsDBNull(i))
            {
                return null;
            }
            var result = Convert.ToString(dr.GetValue(i));
            return result;
        }

        public static Nullable<T> GetOtherNull<T>(this IDataReader dr, int i) where T : struct
        {
            if (dr.IsDBNull(i))
            {
                return null;
            }
            return GetOther<T>(dr,i);

        }

        public static T GetOther<T>(this IDataReader dr, int i)
        {
            try
            {
                if (dr.IsDBNull(i))
                {
                    return default(T);
                }
                var result = dr.GetValue(i);
                return UtilMethods.To<T>(result);
            }
            catch (Exception ex)
            {
                return OtherException<T>(dr, i, ex);
            }
        }

        public static T GetJson<T>(this IDataReader dr, int i)
        {
            var obj = dr.GetValue(i);
            if (obj == null)
                return default(T);
            var value = obj.ObjToString();
            return new SerializeService().DeserializeObject<T>(value);
        }
        public static T GetArray<T>(this IDataReader dr, int i)
        {
            //pgsql
            var obj = dr.GetValue(i);
            if (obj == null)
                return default(T);
            return  (T)obj;
        }

        public static Nullable<T> GetConvertEnum_Null<T>(this IDataReader dr, int i) where T : struct
        {
            if (dr.IsDBNull(i))
            {
                return null;
            }
            object value = dr.GetValue(i);
            T t = (T)Enum.ToObject(typeof(T), value);
            return t;
        }

        public static T GetEnum<T>(this IDataReader dr, int i) where T : struct
        {
            object value = dr.GetValue(i);
            if (value != null)
            {
                if (value.GetType() == UtilConstants.DecType)
                {
                    value = Convert.ToUInt32(value);
                }
                else if (value.GetType() == UtilConstants.StringType)
                {
                    return (T)Enum.Parse(typeof(T), value.ObjToString());
                }
            }
            T t = (T)Enum.ToObject(typeof(T), value);
            return t;
        }

        public static object GetEntity(this IDataReader dr, SqlSugarProvider context)
        {
            return null;
        }


        private static T OtherException<T>(IDataRecord dr, int i, Exception ex)
        {
            if (dr.GetFieldType(i) == UtilConstants.DateType)
            {
                return UtilMethods.To<T>(dr.GetConvertDouble(i));
            }
            if (dr.GetFieldType(i) == UtilConstants.GuidType)
            {
                var data = dr.GetString(i);
                if (data.ToString() == "")
                {
                    return UtilMethods.To<T>(default(T));
                }
                else
                {
                    return UtilMethods.To<T>(Guid.Parse(data.ToString()));
                }
            }
            throw new Exception(ex.Message);
        }

        #endregion
    }
}
