using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gouw.Common.Tests
{
    [TestClass()]
    public class StringHelperTest
    {
        [TestMethod()]
        public void Append()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void Capitalize()
        {
            Assert.AreEqual("herman gouw".Capitalize(), "Herman Gouw");
        }

        [TestMethod()]
        public void Decode()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void Decrypt()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void Encode()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void Encrypt()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void HashAndEncode()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void IsAlphabetic()
        {
            Assert.AreEqual("abcdefghijklmnopqstuvwxyz".IsAlphabetic(), true);
        }

        [TestMethod()]
        public void IsAlphanumeric()
        {
            Assert.AreEqual("abcdefghijklmnopqstuvwxyz0123456789".IsAlphanumeric(), true);
        }

        [TestMethod()]
        public void IsAlphanumericBlank()
        {
            Assert.AreEqual("abcdefghijklmnopqstuvwxyz 0123456789".IsAlphanumericBlank(), true);
        }

        [TestMethod()]
        public void IsCapitalized()
        {
            Assert.AreEqual("herman".IsCapitalized(), false);
        }

        [TestMethod()]
        public void IsNullOrEmpty()
        {
            Assert.AreEqual("0123456789".IsNullOrEmpty(), false);
        }

        [TestMethod()]
        public void IsNumeric()
        {
            Assert.AreEqual("0123456789".IsNumeric(), true);
            Assert.AreEqual("abc0123456789".IsNumeric(), false);
        }

        [TestMethod()]
        public void IsWhiteSpace()
        {
            Assert.AreEqual(" ".IsWhiteSpace(), true);
        }

        [TestMethod()]
        public void Reverse()
        {
            Assert.AreEqual("0123456789".Reverse(), "9876543210");
        }

        [TestMethod()]
        public void Right()
        {
            Assert.AreEqual("the quick brown fox jumps over the lazy dog".Right(12), "the lazy dog");
        }

        [TestMethod()]
        public void ToDouble()
        {
            Assert.AreEqual("123.456".ToDouble(), 123.456);
        }

        [TestMethod()]
        public void ToInt()
        {
            Assert.AreEqual("123456".ToInt(), 123456);
        }

        [TestMethod()]
        public void Trim()
        {
            Assert.AreEqual("the quick brown fox jumps over the lazy dog".Trim(" jumps ", Position.Before), "the quick brown fox");
            Assert.AreEqual("the quick brown fox jumps over the lazy dog".Trim(" jumps ", Position.After), "over the lazy dog");
        }
    }
}
