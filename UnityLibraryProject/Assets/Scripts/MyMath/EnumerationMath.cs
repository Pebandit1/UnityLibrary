using System;

namespace MyMath
{
    /// <summary>
    /// Static class containing all of the Enumeration Math formulas
    /// </summary>
    public static class EnumerationMath
    {
        /// <summary>
        /// Calculates the factorial of a number
        /// </summary>
        /// <param name="x">The number to get the factorial</param>
        /// <returns>The factorial of the number</returns>
        /// <exception cref="NotFactoriableNumberException">Exception thrown when the number doesn't have a factorial</exception>
        public static int Factorial(this int x)
        {
            if (x < 0)
                throw new NotFactoriableNumberException();

            return InnerFactorial(x);
        }

        /// <summary>
        /// Calculates the factorial through recursion
        /// </summary>
        /// <param name="x">The number to get the factorial</param>
        /// <returns>The factorial of the number</returns>
        private static int InnerFactorial(int x)
        {
            if (x == 0) return 1;

            return x * InnerFactorial(x - 1);
        }

        /// <summary>
        /// Calculates the number of combinations of k different objects chosen from n objects
        /// </summary>
        /// <param name="k">The size of the combinations</param>
        /// <param name="n">The total number of elements</param>
        /// <returns>The total number of combinations</returns>
        public static int Combination(int k, int n)
            => Arrangement(k, n) / k.Factorial();

        /// <summary>
        /// Calculates the number of arrangement of k different objects from a total of n different objects
        /// </summary>
        /// <param name="k">The size of the arrangements</param>
        /// <param name="n">The total number of elements</param>
        /// <returns>The total number of arrangements</returns>
        /// <exception cref="NotValideForArrangementException">Error thrown when the inputs are invalide</exception>
        public static int Arrangement(int k, int n)
        {
            if (k > n || k < 0)
                throw new NotValideForArrangementException();

            return n.Factorial() / (n - k).Factorial();
        }

        /// <summary>
        /// Calculates the value of a given row of Pascal's triangle 
        /// </summary>
        /// <param name="row">The index of the desired row</param>
        /// <returns>An array containing all the values of the triangle's row at the given index</returns>
        /// <exception cref="NotInPascalTriangleException">Error thrown when trying to acces an invalide row</exception>
        public static int[] GetPascalTriangleRow(int row)
        {
            if (row < 0)
                throw new NotInPascalTriangleException();

            int[] pascalTriangle = new int[row + 1];

            for(int i = 0; i <= row; ++i)
                pascalTriangle[i] = Combination(i, row);

            return pascalTriangle;
        }
    }

    /// <summary>
    /// Error thrown when a number doesn't have a factorial
    /// </summary>
    public class NotFactoriableNumberException : Exception { }
    
    /// <summary>
    /// Error thrown when trying to reach an invalide index inside of Pascal's triangle
    /// </summary>
    public class NotInPascalTriangleException : Exception { }

    /// <summary>
    /// Error thrown when trying to do an invalide arrangement
    /// </summary>
    public class NotValideForArrangementException : Exception { }
}