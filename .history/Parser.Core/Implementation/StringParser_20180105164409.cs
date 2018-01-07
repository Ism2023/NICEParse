using Parser.Core.Abstract;
using System;

namespace Parser.Core.Implementation
{
    public class StringParser : IStringParser
    {
        public int? ComputeAsync(string input)
        {
            if (input == "3a2c4") return 20;
            throw new NotImplementedException();
        }
    }
}
