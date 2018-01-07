using Parser.Core.Abstract;
using System;
using System.Collections.Generic;
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
            return _Eval(_fixedString);
        }

        private int _Eval(string expression)
        {
            var _dt = new DataTable();
            var _dc = new DataColumn("Eval", typeof(int), expression);
            _dt.Columns.Add(_dc);
            _dt.Rows.Add(0);
            var _output = _dt.Rows[0]["Eval"];
            Console.WriteLine($"Expression : {expression} Output : {_output}");
            return 0;
        }

        int Evaluate(string exp)
        {
            if (exp.Contains('+'))
            {
                var _parts = exp.Split('+');
                var _sum = Expression.Add(
                        Expression.Constant(int.parse(_parts[0])),
                        Expression.Constant(int.parse(_parts[1])));
                var _l = Expression.Lambda<Func<int>>(_sum);
                return _l.Compile();
            }
            int _ret = 0;
            int.TryParse(exp, out _ret);
            return _ret;
        }
    }
}
