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
            Console.WriteLine(_fixedString);
            var _ret = _Evaluate(_fixedString);
            Console.WriteLine(_ret);
            return _ret;
        }

        int _Evaluate(string expression)
        {
            DataTable _table = new DataTable();
            _table.Columns.Add("expression", typeof(string), expression);
            DataRow _row = _table.NewRow();
            _table.Rows.Add(_row);
            return int.Parse((string)_row["expression"]);
        }
    }
}
