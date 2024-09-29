namespace MyMath
{
    /// <summary>
    /// Static class containg MathFonctions that can't be grouped with others
    /// </summary>
    public static class MathUtils
    {
        /// <summary>
        /// Finds the greatest common divisor of two whole numbers using Euclid's algorithm
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>The greatest common divisor of both numbers</returns>
        public static int FindGreatestCommonDivisor(int a, int b)
        {
            if (a < 0)
                return FindGreatestCommonDivisor(-a, b);

            if (b < 0)
                return FindGreatestCommonDivisor(a, - b);

            if (b > a)
                return FindGreatestCommonDivisor(b, a);

            if (b == 0)
                return a;

            return FindGreatestCommonDivisor(b, a % b);
        }
    }
}
