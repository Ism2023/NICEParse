using Parser.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Data;

namespace Parser.Core.Implementation
{
    public class StringParser : IStringParser
    {
        public int Compute(string input)
        {
            var fixedString = input
                .Replace("a", "+")
                .Replace("b", "-")
                .Replace("c", "*")
                .Replace("d", "/")
                .Replace("e", "(")
                .Replace("f", ")");

            //simplify any parenthesis
            var simplifiedString = Simplifier.Simplify(fixedString);

            Processor _p = new Processor();
            return _p.Process(simplifiedString);
        }
    }
}
