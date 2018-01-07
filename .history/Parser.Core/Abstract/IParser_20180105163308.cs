using System;
using System.Threading.Tasks;

namespace Parser.Core.Abstract
{
    public interface IParser
    {
        Task<int> ComputeAsync(string input);
    }
}
