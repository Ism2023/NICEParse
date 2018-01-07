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

            if (_fixedString.Contains("(")) _fixedString = Simplifier.Simplify(_fixedString);

            Processor _p = new Processor();
            return _p.Process(_fixedString);
        }
    }
}
