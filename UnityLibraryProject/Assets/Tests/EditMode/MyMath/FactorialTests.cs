#pragma warning disable CS0168
using NUnit.Framework;
using MyMath;

namespace Tests.EditMode.MyMath.EnumerationMathTests
{
    public class FactorialTests
    {
        [Test]
        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 6)]
        [TestCase(4, 24)]
        [TestCase(5, 120)]
        [TestCase(6, 720)]
        [TestCase(7, 5040)]
        [TestCase(8, 40320)]
        [TestCase(9, 362880)]
        public void TestResultFactorials(int n, int result)
            => Assert.AreEqual(result, n.Factorial());

        [Test]
        [TestCase(0, false)]
        [TestCase(1, false)]
        [TestCase(-1, true)]
        [TestCase(-3, true)]
        [TestCase(4, false)]
        [TestCase(-5, true)]
        [TestCase(6, false)]
        [TestCase(-7, true)]
        [TestCase(-0, false)]
        public void TestException(int n, bool shouldFail)
        {
            bool hasFailed = false; 
            try
            {
                n.Factorial();
            }
            catch (NotFactoriableNumberException)
            {
                hasFailed = true;
            }

            Assert.AreEqual(shouldFail, hasFailed);

        }

    }
}


