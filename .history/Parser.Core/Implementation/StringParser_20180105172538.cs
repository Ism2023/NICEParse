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
            var _response = dt.Compute(_fixedString);
            return _response;        
        }
    }
}
