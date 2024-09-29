using NUnit.Framework;
using static MyMath.EnumerationMath;

namespace Tests.EditMode.MyMath.EnumerationMathTests
{
    public class CombinaisonTests
    {

        [Test]
        [TestCase(0, 0, 1)]
        [TestCase(0, 1, 1)]
        [TestCase(1, 1, 1)]
        [TestCase(0, 2, 1)]
        [TestCase(1, 2, 2)]
        [TestCase(2, 2, 1)]
        [TestCase(0, 3, 1)]
        [TestCase(1, 3, 3)]
        [TestCase(2, 3, 3)]
        [TestCase(3, 3, 1)]
        [TestCase(0, 4, 1)]
        [TestCase(1, 4, 4)]
        [TestCase(2, 4, 6)]
        [TestCase(3, 4, 4)]
        [TestCase(4, 4, 1)]
        public void TestCombinaisonResult(int k, int n, int result)
            => Assert.AreEqual(result, Combination(k, n));
    }
}
