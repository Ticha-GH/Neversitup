using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Tests
{
    [TestClass()]
    public class ProgramTests
    {
        private Program _service;


        [TestMethod()]
        [DataRow("a", new string[] { "a" })]
        [DataRow("ab", new string[] { "ab", "ba" })]
        [DataRow("abc", new string[] { "abc", "acb", "bac", "bca", "cab", "cba" })]
        [DataRow("aabb", new string[] { "aabb", "abab", "abba", "baab", "baba", "bbaa" })]
        public void ShuffleTest(string word, string[] expected)
        {
            //prepare
            _service = new Program();

            //act
            var actual = _service.Shuffle(word);

            //asset
            Assert.IsNotNull(actual);
            CollectionAssert.AreEqual(expected, actual);
        }

        // $"{result.Number}, because ot occurs {result.Count} times (which is odd)
        [TestMethod()]
        [DataRow(new int[] { 7 }, "7, because ot occurs 1 times (which is odd)")]
        [DataRow(new int[] { 0 }, "0, because ot occurs 1 times (which is odd)")]
        [DataRow(new int[] { 1, 1, 2 }, "2, because ot occurs 1 times (which is odd)")]
        [DataRow(new int[] { 0, 1, 0, 1, 0 }, "0, because ot occurs 3 times (which is odd)")]
        [DataRow(new int[] { 1, 2, 2, 3, 3, 3, 4, 3, 3, 3, 2, 2, 1 }, "4, because ot occurs 1 times (which is odd)")]
        public void FindOddTest(int[] numbers, string expected)
        {
            //prepare
            _service = new Program();

            //act
            var actual = _service.FindOdd(numbers);

            //asset
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(new string[] { "" }, 0)]
        [DataRow(new string[] { "0" }, 0)]
        [DataRow(new string[] { }, 0)]
        [DataRow(new string[] { ":)", ";(", ";}", ":-D" }, 2)]
        [DataRow(new string[] { ";D", ":-(", ":-)", ";~)" }, 3)]
        [DataRow(new string[] { ";]", ":[", ":$", ";-D" }, 1)]
        public void SmileyFacesTest(string[] faces, int expected)
        {
            //prepare
            _service = new Program();

            //act
            var actual = _service.SmileyFaces(faces);

            //asset
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
        }

    }
}