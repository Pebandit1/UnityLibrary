#pragma warning disable CS0168
using NUnit.Framework;
using static MyMath.EnumerationMath;
using MyMath;

namespace Tests.EditMode.MyMath.EnumerationMathTests
{
    public class ArrangementTests
    {
        [Test]
        [TestCase(0, 0, 1)]
        [TestCase(0, 1, 1)]
        [TestCase(1, 1, 1)]
        [TestCase(0, 2, 1)]
        [TestCase(1, 2, 2)]
        [TestCase(2, 2, 2)]
        [TestCase(0, 3, 1)]
        [TestCase(1, 3, 3)]
        [TestCase(2, 3, 6)]
        [TestCase(3, 3, 6)]
        public void TestArrangementResult(int k, int n, int result)
            => Assert.AreEqual(Arrangement(k, n), result);

        [Test]
        [TestCase(0, -1, true)]
        [TestCase(-1, 0, true)]
        [TestCase(0, 0, false)]
        [TestCase(1, 0, true)]
        [TestCase(0, 1, false)]
        [TestCase(1, 1, false)]
        [TestCase(0, 2, false)]
        [TestCase(1, 2, false)]
        [TestCase(2, 2, false)]
        [TestCase(3, 2, true)]
        public void TestException(int k, int n, bool shouldFail)
        {
            bool hasFailed = false;

            try
            {
                Arrangement(k, n);
            }
            catch (NotValideForArrangementException e)
            {
                hasFailed = true;
            }
            catch (NotFactoriableNumberException e)
            {
                hasFailed = true;
            }

            Assert.AreEqual(shouldFail, hasFailed);
        }
    }
}
