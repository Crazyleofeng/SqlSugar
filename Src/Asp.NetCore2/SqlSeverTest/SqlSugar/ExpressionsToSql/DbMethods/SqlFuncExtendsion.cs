﻿using System;
using System.Collections.Generic;

namespace SqlSugar 
{
    public static class SqlFuncExtendsion
    {
        internal static List<ConfigTableInfo> TableInfos = new List<ConfigTableInfo>();
        public static string GetConfigValue<Type>(this object field)
        {
            throw new NotSupportedException("Can only be used in expressions");
        }
        public static string GetConfigValue<Type>(this object field,string uniqueCode)
        {
            throw new NotSupportedException("Can only be used in expressions");
        }

        public static FieldType SelectAll<FieldType>(this FieldType field)
        {
            throw new NotSupportedException("Can only be used in expressions");
        }
    }
}