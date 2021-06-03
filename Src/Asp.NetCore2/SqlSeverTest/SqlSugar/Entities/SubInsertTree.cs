﻿using System.Collections.Generic;
using System.Linq.Expressions;

namespace SqlSugar
{
    public class SubInsertTree
    {
        public object Expression { get; set; }
        public List<SubInsertTree> ChildExpression { get; set; }
    }

    internal class SubInsertTreeExpression
    {
        public Expression Expression { get; set; }
        public List<SubInsertTreeExpression> Childs { get; set; }
    }
}
