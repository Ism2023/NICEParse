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
            //Inject
            var _services = new ServiceCollection();
            _services.AddTransient<IStringParser, StringParser>();

            //Retrieve from Service Provider
            var _serviceProvider = _services.BuildServiceProvider();
            _testItem = _serviceProvider.GetService<IStringParser>();
        }

        [DataTestMethod]
        [DataRow("3a2c4", 20)]
        [DataRow("32a2d2", 17)]
        [DataRow("500a10b66c32", 14208)]
        [DataRow("3ae4c66fb32", 235)]
        [DataRow("3c4d2aee2a4c41fc4f", 990)]
        [DataRow("1c4be3434d2faee23b1fc2f", -1669)]
        [DataRow("e25de4d2fc5fc4ae24a1922f", 2196)]
        public void ItShouldParse(string input, int expectation)
        {
            var _response = _testItem.Compute(input);
            Assert.AreEqual(_response, expectation);
        }

        [TestMethod]
        public void ItShouldFailBadParenthesis(string input, int expectation)
        {
            var _response = _testItem.Compute("f25de4d2fc5fc4ae24a1922f");
            Assert.AreEqual(_response, expectation);
        }
    }
}