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

            var _dt = new DataTable();
            int? _response;
            if (int.TryParse(_dt.Compute(_fixedString, ""), out _response))
            {
                return _response;
            }
            else
            {
                throw new ApplicationException("Balls");
            }
        }
    }
}
