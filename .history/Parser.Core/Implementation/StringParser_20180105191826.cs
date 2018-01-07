using Parser.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data;

namespace Parser.Core.Implementation
{
    public class StringParser : IStringParser
    {
        public int? Compute(string input)
        {
            var _fixedString = input
                .Replace("a", "+")
                .Replace("b", "-")
                .Replace("c", "*")
                .Replace("d", "/")
                .Replace("e", "(")
                .Replace("f", ")");
            return _Evaluate(_fixedString);
        }

        int? _Evaluate(string exp)
        {
            if (exp.Contains("+"))
            {
                var _parts = exp.Split('+');
                var _sum = Expression.Add(
                        Expression.Constant(int.Parse(_parts[0])),
                        Expression.Constant(int.Parse(_parts[1])));
                var _l = Expression.Lambda<Func<int?>>(_sum);
                return _l.Compile();
            }
            int _ret = 0;
            int.TryParse(exp, out _ret);
            return _ret;
        }
    }
}
