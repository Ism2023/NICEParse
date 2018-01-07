using Parser.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Data;

namespace Parser.Core.Implementation
{
    public class StringParser : IStringParser
    {
        /// <summary>
        /// Process incoming string based on prescribed parse logic
        /// </summary>
        /// <param name="input">string to process</param>
        /// <returns>Double representing completed calculation</returns>
        public double Compute(string input)
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
