using Parser.Core.Abstract;
using Parser.Core.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;

namespace Parser.Test
{
    [TestClass]
    public class ParserTests
    {
        private readonly IStringParser _testItem;

        public ParserTests()
        {
            var _services = new ServiceCollection();
            _services.AddTransient<IStringParser, StringParser>();
            var _serviceProvider = _services.BuildServiceProvider();
            _testItem = _serviceProvider.GetService<IStringParser>();
        }

        [DataTestMethod]
        [DataRow("3a2c4", 20)]
        [DataRow("32a2d2", 17)]
        [DataRow("500a10b66c32", 14208)]
        [DataRow("3ae4c66fb32", 235)]
        [DataRow("3c4d2aee2a4c41fc4f", 990)]
        [DataRow("1c4be3434d2faee23b1fc2f", 44)]
        public void ItShouldParse(string input, int expectation)
        {
            var _response = _testItem.Compute(input);
            Assert.AreEqual(_response, expectation);
        }
    }
}