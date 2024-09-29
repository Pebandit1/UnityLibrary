#pragma warning disable CS0168
using NUnit.Framework;
using MyMath;
using static MyMath.EnumerationMath;

namespace Tests.EditMode.MyMath.EnumerationMathTests
{
    public class PascalTriangleTests
    {
        [Test]
        [TestCase(0, new int[] { 1 })]
        [TestCase(1, new int[] { 1, 1 })]
        [TestCase(2, new int[] { 1, 2, 1 })]
        [TestCase(3, new int[] { 1, 3, 3, 1 })]
        [TestCase(4, new int[] { 1, 4, 6, 4, 1 })]
        [TestCase(5, new int[] { 1, 5, 10, 10, 5, 1 })]
        [TestCase(6, new int[] { 1, 6, 15, 20, 15, 6, 1 })]
        public void TestPascalTriangleResult(int row, int[] results)
            => Assert.AreEqual(results, GetPascalTriangleRow(row));

        [Test]
        [TestCase(0, false)]
        [TestCase(1, false)]
        [TestCase(2, false)]
        [TestCase(3, false)]
        [TestCase(4, false)]
        [TestCase(5, false)]
        [TestCase(-0, false)]
        [TestCase(-1, true)]
        [TestCase(-2, true)]
        [TestCase(-3, true)]
        [TestCase(-4, true)]
        public void TestException(int row, bool shouldFail)
        {
            bool hasFailed = false;

            try
            {
                GetPascalTriangleRow(row);
            }
            catch (NotInPascalTriangleException)
            {
                hasFailed = true;
            }

            Assert.AreEqual(shouldFail, hasFailed);
        }
    }
}
