﻿using System.Linq.Expressions;

namespace SqlSugar 
{
    public class MapperExpression
    {
        public MapperExpressionType Type { get; set; }
        public Expression FillExpression { get; set; }
        public Expression MappingField1Expression { get; set; }
        public Expression MappingField2Expression { get; set; }
        public SqlSugarProvider Context { get; set; }
        public QueryBuilder QueryBuilder { get;  set; }
        public ISqlBuilder SqlBuilder { get;  set; }
    }

    public enum MapperExpressionType
    {
        oneToOne=1,
        oneToN=2
    }
}
