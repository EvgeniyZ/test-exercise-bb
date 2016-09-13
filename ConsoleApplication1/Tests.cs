using System;
using NUnit.Framework;

namespace ConsoleApplication1
{
    class Tests
    {
        [Test]
        public void TestStupidBinarySum()
        {
            var first = 5;
            var second = 4;
            var result = Program.Sum(Convert.ToString(first, 2), Convert.ToString(second, 2));
            Assert.AreEqual(Convert.ToInt32(result, 2), 1);
            first = 7;
            second = 9;
            result = Program.Sum(Convert.ToString(first, 2), Convert.ToString(second, 2));
            Assert.AreEqual(Convert.ToInt32(result, 2), 14);
            first = 50;
            second = 10;
            result = Program.Sum(Convert.ToString(first, 2), Convert.ToString(second, 2));
            Assert.AreEqual(Convert.ToInt32(result, 2), 56);
        }
    }
}
