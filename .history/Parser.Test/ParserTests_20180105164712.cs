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

        [TestMethod]
        public void ItShouldEqual20()
        {
            var _response = _testItem.Compute("3a2c4");
            Assert.AreEqual(_response, 20);
        }
        [TestMethod]
        public void ItShouldEqual17()
        {
            var _response = _testItem.Compute("32a2d2");
            Assert.AreEqual(_response, 20);
        }
        [TestMethod]
        public void ItShouldEqual14208()
        {
            var _response = _testItem.Compute("500a10b66c32");
            Assert.AreEqual(_response, 20);
        }
        [TestMethod]
        public void ItShouldEqual235()
        {
            var _response = _testItem.Compute("3ae4c66fb32");
            Assert.AreEqual(_response, 20);
        }
        [TestMethod]
        public void ItShouldEqual990()
        {
            var _response = _testItem.Compute("3c4d2aee2a4c41fc4f");
            Assert.AreEqual(_response, 20);
        }
    }
}