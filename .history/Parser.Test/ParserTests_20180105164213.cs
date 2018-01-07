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
            var _response = _testItem.ComputeAsync("3a2c4");
            Assert.Equals(_response, 20);
        }
        [TestMethod]
        public void ItShouldEqual17()
        {
            var _response = _testItem.ComputeAsync("32a2d2");
            Assert.Equals(_response, 20);
        }
        [TestMethod]
        public void ItShouldEqual14208()
        {
            var _response = _testItem.ComputeAsync("500a10b66c32");
            Assert.Equals(_response, 20);
        }
        [TestMethod]
        public void ItShouldEqual235()
        {
            var _response = _testItem.ComputeAsync("3ae4c66fb32");
            Assert.Equals(_response, 20);
        }
        [TestMethod]
        public void ItShouldEqual990()
        {
            var _response = _testItem.ComputeAsync("3c4d2aee2a4c41fc4f");
            Assert.Equals(_response, 20);
        }
    }
}