using System;
using System.Threading.Tasks;

namespace Parser.Core.Abstract
{
    public interface IStringParser
    {
        Task<int> ComputeAsync(string input);
    }
}
