using Parser.Core.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NICEParserTests
{
    [TestClass]
    public class ParserTests
    {
        private readonly StringParser _testItem;

        [TestMethod]
        public void ItShouldEqual20()
        {
            var _response = _testItem.Compute("3a2c4");
            Assert.Equals(_response, 20);
        }
        [TestMethod]
        public void ItShouldEqual17()
        {
            var _response = _testItem.Compute("32a2d2");
            Assert.Equals(_response, 20);
        }
        [TestMethod]
        public void ItShouldEqual14208()
        {
            var _response = _testItem.Compute("500a10b66c32");
            Assert.Equals(_response, 20);
        }
        [TestMethod]
        public void ItShouldEqual235()
        {
            var _response = _testItem.Compute("3ae4c66fb32");
            Assert.Equals(_response, 20);
        }
        [TestMethod]
        public void ItShouldEqual990()
        {
            var _response = _testItem.Compute("3c4d2aee2a4c41fc4f");
            Assert.Equals(_response, 20);
        }
    }
}