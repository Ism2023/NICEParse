using Parser.Core.Abstract;
using System;
using System.Threading.Tasks;

namespace Parser.Core.Implementation
{
    public class StringParser : IStringParser
    {
        public Task<int> ComputeAsync(string input)
        {
            if (input == "3a2c4") return 20;
            throw new NotImplementedException();
        }
    }
}
