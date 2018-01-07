using Parser.Core.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NICEParserTests
{
    [TestClass]
    public class ParserTests
    {
        private readonly StringParser _testItem;

        public ParserTests()
        {
            _testItem = new StringParser();
        }

        [DataTestMethod]
        [DataRow("3a2c4", 20)]
        public void ItShouldParse(string input, int expectation)
        {
            var _response = _testItem.Compute("3a2c4");
            Assert.AreEqual(_response, 20);
        }
    }
}