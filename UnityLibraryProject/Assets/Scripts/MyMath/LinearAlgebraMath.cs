using System;
using System.Linq;

namespace MyMath
{
    /// <summary>
    /// Static class containing functions to resolve and create linear algebra system
    /// <para>For this class, an array is a nth dimension vector and a matrix is a nxm matrix </para>
    /// <para> All public matrix manipulation return clones without changing the original</para>
    /// </summary>
    /// <remarks>Made in a way that I could add public functions that affect two matrices at the same time. Might need to add a clone function 
    /// as input of some functions if we want to use them with class</remarks>
    public static class LinearAlgebraMath
    {
        #region General Functionalities

        /// <summary>
        /// Converts a matrix from a type to another, mainly used to transform int[,] into float[,] or double[,]
        /// </summary>
        /// <typeparam name="T">Type of the initial matrix</typeparam>
        /// <typeparam name="U">Type of the final matrix</typeparam>
        /// <param name="matrix">The matrix to convert</param>
        /// <param name="convert">A function that takes in a T and converts it to a U</param>
        /// <returns>The matrix converted into the a type U matrix</returns>
        public static U[,] ConvertMatrixType<T, U>(T[,] matrix, Func<T, U> convert)
        {
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);

            U[,] converted = new U[height, width];

            LoopOverMatrix(height, width, (i, j) => converted[i, j] = convert(matrix[i, j]));

            return converted;
        }

        /// <summary>
        /// Determines if a matrix is squared
        /// </summary>
        /// <typeparam name="T">The type of the matrix</typeparam>
        /// <param name="matrix">The matrix evaluated</param>
        /// <returns>True is the matrix is square, false if it's not</returns>
        public static bool IsSquare<T>(T[,] matrix)
            => IsSquare(matrix.GetLength(0), matrix.GetLength(1));

        /// <summary>
        /// Determines if a matrix is squared
        /// </summary>
        /// <param name="height">The height of the matrix</param>
        /// <param name="width">The width of the matrix</param>
        /// <returns>True is the matrix is square, false if it's not</returns>
        private static bool IsSquare(int height, int width)
           => height == width;

        /// <summary>
        /// Loops over every cell of the matrix and applies a function
        /// </summary>
        /// <typeparam name="T">The type of the matrix</typeparam>
        /// <param name="matrix">The matrix we are looping over</param>
        /// <param name="function">The function applied at every cell</param>
        public static void LoopOverMatrix<T>(T[,] matrix, Action<int, int> function)
            => LoopOverMatrix(matrix.GetLength(0), matrix.GetLength(1), function);

        /// <summary>
        /// Loops over every cell of the matrix and applies a function
        /// </summary>
        /// <param name="function">The function applied at every cell</param>
        /// <param name="height">The height of the matrix</param>
        /// <param name="width">�The width of the matrix</param>
        /// <remarks>Because this is the private function, there's no verification done on the inputs</remarks>
        private static void LoopOverMatrix(int height, int width, Action<int, int> function)
        {
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                    function(i, j);
            }
        }

        /// <summary>
        /// Determines if both matrices are the same
        /// </summary>
        /// <typeparam name="T">The type of the matrices, must be IEquatable<T></typeparam>
        /// <param name="m1">The first matrix</param>
        /// <param name="m2">The second matrix</param>
        /// <returns>True if they are the same, else false</returns>
        public static bool AreTheSame<T>(T[,] m1, T[,] m2) where T : IEquatable<T>
         => AreTheSame(m1, m2, (x, y) => x.Equals(y));

        /// <summary>
        /// Determines if both matrices are the same
        /// </summary>
        /// <typeparam name="T">The type of the matrices</typeparam>
        /// <param name="m1">The first matrix</param>
        /// <param name="m2">The second matrix</param>
        /// <param name="equals">A predicate that determine if two Ts are the same</param>
        /// <returns>True if they are the same, else false</returns>
        public static bool AreTheSame<T>(T[,] m1, T[,] m2, Func<T, T, bool> equals)
        {
            if (!AreTheSameSize(m1, m2))
                return false;

            bool areTheSame = true;

            LoopOverMatrix(m1, (i, j) => areTheSame = areTheSame && equals(m1[i, j], m2[i, j]));

            return areTheSame;
        }

        /// <summary>
        /// Determines if both matrices are the same size
        /// </summary>
        /// <typeparam name="T">The type of the first matrix</typeparam>
        /// <typeparam name="U">The type of the second matrix</typeparam>
        /// <param name="m1">The first matrix</param>
        /// <param name="m2">The second matrix</param>
        /// <returns>True if both matrices are the same size, false else</returns>
        public static bool AreTheSameSize<T, U>(T[,] m1, U[,] m2) => m1.GetLength(0) == m2.GetLength(0) && m1.GetLength(1) == m2.GetLength(1);

        /// <summary>
        /// Determines if a cell is part of the matrix or not
        /// </summary>
        /// <typeparam name="T">Type of the matrix</typeparam>
        /// <param name="matrix">The matrix</param>
        /// <param name="row">The row of the cell</param>
        /// <param name="column">The column of the cell</param>
        /// <returns>True if the cell is in the matrix, else false</returns>
        public static bool IsInTheMatrix<T>(T[,] matrix, int row, int column)
            => IsInTheMatrix(matrix.GetLength(0), matrix.GetLength(1), row, column);

        /// <summary>
        /// Determines if a cell is part of the matrix or not
        /// </summary>
        /// <param name="height">The height of the matrix</param>
        /// <param name="width">The width of the matrix</param>
        /// <param name="row">The row of the cell</param>
        /// <param name="column">The column of the cell</param>
        /// <returns>True if the cell is in the matrix, else false</returns>
        /// <remarks>Because this is the private function, there's no verification done on the inputs</remarks>
        private static bool IsInTheMatrix(int height, int width, int row, int column)
            => row < height && row >= 0 && column < width && column >= 0;

        #endregion

        #region Matrix Operations

        /// <summary>
        /// Multiplies two matrices together
        /// </summary>
        /// <typeparam name="T">The type of the first matrix</typeparam>
        /// <typeparam name="U">The type of the second matrix</typeparam>
        /// <typeparam name="V">The type of the resulting matrix</typeparam>
        /// <param name="m1">The first matrix</param>
        /// <param name="m2">The second matrix</param>
        /// <param name="zero">The value zero of the type V</param>
        /// <param name="add">A function that takes in two Vs and return their sum as a V</param>
        /// <param name="multiply">A function that takes in a T and a U and that return their multiple as a V</param>
        /// <returns>The multiple of the two matrices as a matrix of Vs</returns>
        /// <exception cref="IncompatibleMatricesSizeException">Exception returned if the first matrice's width isn't the same as the second matrice's height</exception>
        public static V[,] MultiplyMatrixByMatrix<T, U, V>(T[,] m1, U[,] m2, V zero, Func<V, V, V> add, Func<T, U, V> multiply)
        {
            if (m1.GetLength(1) != m2.GetLength(0))
                throw new IncompatibleMatricesSizeException();

            int height = m1.GetLength(0);
            int width = m2.GetLength(1);
            int nbOfAdditions = m1.GetLength(1);

            V[,] result = new V[height, width];

            LoopOverMatrix(height, width, (i, j) =>
            {
                V curr = zero;

                for (int k = 0; k < nbOfAdditions; ++k)
                    curr = add(curr, multiply(m1[i, k], m2[k, j]));

                result[i, j] = curr;
            });

            return result;
        }

        /// <summary>
        /// Multiplies a matrix by a vector
        /// </summary>
        /// <typeparam name="T">The type of the matrix</typeparam>
        /// <typeparam name="U">The type of the input vector</typeparam>
        /// <typeparam name="V">The type of the resulting vector</typeparam>
        /// <param name="matrix">The matrix</param>
        /// <param name="vector">The vector</param>
        /// <param name="zero">The value zero of the type V</param>
        /// <param name="add">A function that takes in two Vs and returns their sum as a V</param>
        /// <param name="multiply">A function that takes in a T and a U and returns their multiple as a V</param>
        /// <returns>The multiple of the matrix and the vector as a vector of Vs</returns>
        /// <exception cref="IncompatibleMatrixVectorSizeException">Exception thrown when the vector's length and the matrix width aren't equal</exception>
        public static V[] MultiplyMatrixByVector<T, U, V>(T[,] matrix, U[] vector, V zero, Func<V, V, V> add, Func<T, U, V> multiply)
        {
            int length = vector.Length;

            if (length != matrix.GetLength(1))
                throw new IncompatibleMatrixVectorSizeException();

            int height = matrix.GetLength(0);
            V[] result = Enumerable.Repeat(zero, height).ToArray();

            LoopOverMatrix(height, length, (i, j) => result[i] = add(result[i], multiply(matrix[i, j], vector[j])));

            return result;
        }

        /// <summary>
        /// Adds two matrices together
        /// </summary>
        /// <typeparam name="T">Type of the first matrix</typeparam>
        /// <typeparam name="U">Type of the second matrix</typeparam>
        /// <typeparam name="V">Type of the resulting matrix</typeparam>
        /// <param name="m1">The first matrix</param>
        /// <param name="m2">The second matrix</param>
        /// <param name="add">A function that takes in a T and a U and return their sum as a V</param>
        /// <returns>A matrix of Vs that represent the sum of the two other matrices</returns>
        /// <exception cref="IncompatibleMatricesSizeException">Exception thrown when the two matrices aren't the same size</exception>
        public static V[,] MatrixAddition<T, U, V>(T[,] m1, U[,] m2, Func<T, U, V> add)
        {
            if (!AreTheSameSize(m1, m2))
                throw new IncompatibleMatricesSizeException();

            int height = m1.GetLength(0);
            int width = m1.GetLength(1);
            V[,] result = new V[height, width];

            LoopOverMatrix(height, width, (i, j) => result[i, j] = add(m1[i, j], m2[i, j]));

            return result;
        }

        /// <summary>
        /// Gets a column of the matrix
        /// </summary>
        /// <typeparam name="T">The type of the matrix</typeparam>
        /// <param name="matrix">The matrix</param>
        /// <param name="column">The index of the column</param>
        /// <returns>The column of the matrix has a vector</returns>
        /// <exception cref="NotAPartOfTheMatrixException">Exception thrown when the column is greater than the width of the matrix</exception>
        public static T[] GetVectorFromMatrix<T>(T[,] matrix, int column)
        {
            if (column >= matrix.GetLength(1) || column < 0)
                throw new NotAPartOfTheMatrixException();

            int height = matrix.GetLength(0);
            T[] vector = new T[height];

            for (int i = 0; i < height; ++i)
                vector[i] = matrix[i, column];

            return vector;
        }

        /// <summary>
        /// Multiplies the matrix by a scalar
        /// </summary>
        /// <typeparam name="T">The type of the matrix</typeparam>
        /// <typeparam name="U">The type of the scalar</typeparam>
        /// <typeparam name="V">The type of the resulting matrix</typeparam>
        /// <param name="matrix">The matrix</param>
        /// <param name="scalar">The scalar</param>
        /// <param name="multiply">A function that takes in a T and a U and returns their multiple as a V</param>
        /// <returns>Their multiple as a matrix of Vs</returns>
        public static V[,] MultiplyMatrixByScalar<T, U, V>(T[,] matrix, U scalar, Func<T, U, V> multiply)
            => MultiplyMatrixByScalar(matrix, scalar, multiply, matrix.GetLength(0), matrix.GetLength(1));

        /// <summary>
        /// Multiplies the matrix by a scalar
        /// </summary>
        /// <typeparam name="T">The type of the matrix</typeparam>
        /// <typeparam name="U">The type of the scalar</typeparam>
        /// <typeparam name="V">The type of the resulting matrix</typeparam>
        /// <param name="matrix">The matrix</param>
        /// <param name="scalar">The scalar</param>
        /// <param name="height">The height of the matrix</param>
        /// <param name="width">The width of the matrix</param>
        /// <param name="multiply">A function that takes in a T and a U and returns their multiple as a V</param>
        /// <returns>Their multiple as a matrix of Vs</returns>
        /// <remarks>Because this is the private function, there's no verification done on the inputs</remarks>
        private static V[,] MultiplyMatrixByScalar<T, U, V>(T[,] matrix, U scalar, Func<T, U, V> multiply, int height, int width)
        {
            V[,] result = new V[height, width];

            LoopOverMatrix(height, width, (i, j) => result[i, j] = multiply(matrix[i, j], scalar));
            return result;
        }

        /// <summary>
        /// Multiplies a vector by a scalar
        /// </summary>
        /// <typeparam name="T">The type of the initial vector</typeparam>
        /// <typeparam name="U">The type of the scalar</typeparam>
        /// <typeparam name="V">The type of the resulting vector</typeparam>
        /// <param name="vector">The initial vector</param>
        /// <param name="multiplier">The scalar</param>
        /// <param name="multiply">A function that takes in a T and a U and returns their multiple as a V</param>
        /// <returns>A vector of Vs that represents the result of the multiplication</returns>
        public static V[] MultiplyVectorByScalar<T, U, V>(T[] vector, U multiplier, Func<T, U, V> multiply)
            => MultiplyVectorByScalar(vector, multiplier, multiply, vector.Length);

        /// <summary>
        /// Multiplies a vector by a scalar
        /// </summary>
        /// <typeparam name="T">The type of the initial vector</typeparam>
        /// <typeparam name="U">The type of the scalar</typeparam>
        /// <typeparam name="V">The type of the resulting vector</typeparam>
        /// <param name="vector">The initial vector</param>
        /// <param name="multiplier">The scalar</param>
        /// <param name="multiply">A function that takes in a T and a U and returns their multiple as a V</param>
        /// <param name="length">The length of the vector</param>
        /// <returns>A vector of Vs that represents the result of the multiplication</returns>
        /// <remarks>Because this is the private function, there's no verification done on the inputs</remarks>
        private static V[] MultiplyVectorByScalar<T, U, V>(T[] vector, U multiplier, Func<T, U, V> multiply, int length)
        {
            V[] result = new V[length];

            for (int i = 0; i < length; ++i)
                result[i] = multiply(vector[i], multiplier);

            return result;
        }

        /// <summary>
        /// Adds two vectors together
        /// </summary>
        /// <typeparam name="T">The type of the first vector</typeparam>
        /// <typeparam name="U">The type of the second vector</typeparam>
        /// <typeparam name="V">The type of the resulting vector</typeparam>
        /// <param name="v1">The first vector</param>
        /// <param name="v2">The second vector</param>
        /// <param name="add">A function that takes in a T and a U and returns their sums as a V</param>
        /// <returns>A vector of Vs that represents the result of their addition</returns>
        /// <exception cref="IncompatibleVectorsSizeException">Error thrown when the two vectors don't have the same length</exception>
        public static V[] VectorAddition<T, U, V>(T[] v1, U[] v2, Func<T, U, V> add)
        {
            int length = v1.Length;

            if (length != v2.Length)
                throw new IncompatibleVectorsSizeException();

            V[] result = new V[length];

            for (int i = 0; i < length; ++i)
                result[i] = add(v1[i], v2[i]);

            return result;
        }

        /// <summary>
        /// Multiplies the two vectors and returns a scalar value
        /// </summary>
        /// <typeparam name="T">The type of the first vector</typeparam>
        /// <typeparam name="U">The type of the second vector</typeparam>
        /// <typeparam name="V">The type of the resulting scalar</typeparam>
        /// <param name="v1">The first vector</param>
        /// <param name="v2">The second vector</param>
        /// <param name="zero">The value value of the type V</param>
        /// <param name="multiply">A function that takes in a T and a U and returns their multiple as a V</param>
        /// <param name="add">A function that takes in two Vs and returns their sums as a V</param>
        /// <returns>A scalar value </returns>
        /// <exception cref="IncompatibleVectorsSizeException">Exception thrown when the two vectors doesn't share the same length</exception>
        public static V VectorDotProduct<T, U, V>(T[] v1, U[] v2, V zero, Func<T, U, V> multiply, Func<V, V, V> add)
        {
            int length = v1.Length;

            if (length != v2.Length)
                throw new IncompatibleVectorsSizeException();

            V result = zero;

            for (int i = 0; i < length; ++i)
                result = add(result, multiply(v1[i], v2[i]));

            return result;
        }

        /// <summary>
        /// Multiplies the two 3D vectors and return their normal vector
        /// <para>THIS ONLY WORKS ON 3D VECTORS</para>
        /// </summary>
        /// <typeparam name="T">The type of the first vector</typeparam>
        /// <typeparam name="U">The type of the second vector</typeparam>
        /// <typeparam name="V">The type of the normal vector</typeparam>
        /// <param name="v1">The first vector</param>
        /// <param name="v2">The second vector</param>
        /// <param name="multiply">A function that takes in a T and a U and returns their multiple as a V</param>
        /// <param name="subtract">A function that takes in two Vs and returns their difference as a V</param>
        /// <returns>A vector that's normal to the plain defined by v1 and v2</returns>
        /// <exception cref="Not3DVectorException">Exception thrown when the vectors aren't 3D</exception>
        /// <remarks>There exists an equivalent in 7 dimensions, but I don't see any reason to code it for now</remarks>
        public static V[] VectorCrossProduct3D<T, U, V>(T[] v1, U[] v2, Func<T, U, V> multiply, Func<V, V, V> subtract)
        {
            const int LENGTH = 3;

            if (v1.Length != LENGTH || v2.Length != LENGTH)
                throw new Not3DVectorException();

            V[] result = new V[LENGTH];

            result[0] = subtract(multiply(v1[1], v2[2]), multiply(v1[2], v2[1]));
            result[1] = subtract(multiply(v1[2], v2[0]), multiply(v1[0], v2[2]));
            result[2] = subtract(multiply(v1[0], v2[1]), multiply(v1[1], v2[0]));

            return result;
        }

        #endregion

        #region MatrixManipulation

        /// <summary>
        /// Returns the determinant of the matrix (ie how does the unit square area gets multiplied)
        /// </summary>
        /// <typeparam name="T">The type of the matrix</typeparam>
        /// <typeparam name="U">The type of the determinant</typeparam>
        /// <param name="matrix">The matrix</param>
        /// <param name="zero">The value zero of the type U</param>
        /// <param name="one">The value one of the type U</param>
        /// <param name="convert">A function that takes in a T and returns it's equivalence as a U</param>
        /// <param name="add">A function that takes in two Us and returns their sum as a U</param>
        /// <param name="multiply">A function that takes in two Us and returns their multiple as a U</param>
        /// <param name="getMultiplicativeInverse">A function that takes in a U and returns their multiplicative inverse (ie 1/x) as a U</param>
        /// <param name="inverseSign">A function that takes in a U and returns their sign inverse (ie -x) as a U</param>
        /// <returns>The determinant of the matrix as a U</returns>
        /// <remarks>It's almost certain that this function will need to convert an integer into a floating point value</remarks>
        public static U GetMatrixDeterminant<T, U>(T[,] matrix, U zero, U one, Func<T, U> convert, Func<U, U, U> add, Func<U, U, U> multiply,
                                                  Func<U, U> getMultiplicativeInverse, Func<U, U> inverseSign) where U : IEquatable<U>
           => GetMatrixDeterminant(matrix, zero, one, convert, add, multiply, getMultiplicativeInverse, inverseSign, (x, y) => x.Equals(y));

        /// <summary>
        /// Returns the determinant of the matrix (ie how does the unit square area gets multiplied)
        /// </summary>
        /// <typeparam name="T">The type of the matrix</typeparam>
        /// <typeparam name="U">The type of the determinant</typeparam>
        /// <param name="matrix">The matrix</param>
        /// <param name="zero">The value zero of the type U</param>
        /// <param name="one">The value one of the type U</param>
        /// <param name="convert">A function that takes in a T and returns it's equivalence as a U</param>
        /// <param name="add">A function that takes in two Us and returns their sum as a U</param>
        /// <param name="multiply">A function that takes in two Us and returns their multiple as a U</param>
        /// <param name="getMultiplicativeInverse">A function that takes in a U and returns their multiplicative inverse (ie 1/x) as a U</param>
        /// <param name="inverseSign">A function that takes in a U and returns their sign inverse (ie -x) as a U</param>
        /// <param name="equals">A function that takes in two Us and return true if they are the same</param>
        /// <returns>The determinant of the matrix as a U</returns>
        /// <remarks>It's almost certain that this function will need to convert an integer into a floating point value</remarks>
        public static U GetMatrixDeterminant<T, U>(T[,] matrix, U zero, U one, Func<T, U> convert, Func<U, U, U> add, Func<U, U, U> multiply,
                                                   Func<U, U> getMultiplicativeInverse, Func<U, U> inverseSign, Func<U, U, bool> equals)
        {
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);

            if (!IsSquare(height, width))
                throw new NotSquareMatrixException();

            return GetMatrixDeterminant(ConvertMatrixType(matrix, convert), null, height, width, zero, one, add, multiply, getMultiplicativeInverse, inverseSign, equals);
        }

        //Makes the Matrix into an upper triangular matrix that shares the same Determinant
        //It's faster than the ususal cofactor method (cofactor method is O(n!) and this is O(n^3))
        //This is based on the following facts : 
        //The determinant change sign when you swap two rows
        //The determinant doesn't change when you remove a scalar multiple of a row to another
        //The determinant of a triangular matrix is the multiplication of the values of it's diagonal

        /// <summary>
        /// Returns the determinant of the matrix (ie how does the unit square area gets multiplied)
        /// </summary>
        /// <typeparam name="T">The type of the matrix</typeparam>
        /// <param name="primaryMatrix">The matrix that we want to get the determinant</param>
        /// <param name="otherMatrix">A matrix that gets modified along the way (mainly for GetInverseMatrix)</param>
        /// <param name="height">The height of the matrix</param>
        /// <param name="width">The width of the matrix</param>
        /// <param name="zero">The value zero of the type T</param>
        /// <param name="one">The value one of the type T</param>
        /// <param name="add">A function that takes in two Ts and returns their sum as a T</param>
        /// <param name="multiply">A function that takes in two Ts and returns their multiple as a T</param>
        /// <param name="getMultiplicativeInverse">A function that takes in a T and returns their multiplicative inverse (1/x) as a T</param>
        /// <param name="inverseSign">A function that takes in a T and returns their sign inverse (-x) as a T</param>
        /// <param name="equals">A function that takes in two Ts and returns true if they are the same</param>
        /// <returns>The determinant of the matrix as a T</returns>
        /// <exception cref="NotSquareMatrixException">Exception throw when the matrix given in parameter isn't square</exception>
        /// <remarks>Because this is the private function, there's no verification done on the inputs</remarks>
        private static T GetMatrixDeterminant<T>(T[,] primaryMatrix, T[,] otherMatrix, int height, int width, T zero, T one, Func<T, T, T> add, Func<T, T, T> multiply,
                                                   Func<T, T> getMultiplicativeInverse, Func<T, T> inverseSign, Func<T, T, bool> equals)
        {
            bool needToChangeSign = false;

            for (int j = 0; j < width; ++j)
            {
                TryMoveValueLower(primaryMatrix, otherMatrix, height, width, j, j, zero, equals, out bool hasChange);

                if (equals(primaryMatrix[j, j], zero))
                    return zero;

                needToChangeSign = hasChange ? !needToChangeSign : needToChangeSign;

                for (int i = j + 1; i < height; ++i)
                {
                    T scalar = inverseSign(multiply(primaryMatrix[i, j], getMultiplicativeInverse(primaryMatrix[j, j])));
                    AddScalledRowsToAnother(primaryMatrix, otherMatrix, width, i, add, multiply, (j, scalar));
                }
            }

            T determinant = one;

            for (int i = 0; i < width; ++i)
                determinant = multiply(determinant, primaryMatrix[i, i]);

            return needToChangeSign ? inverseSign(determinant) : determinant;
        }

        /// <summary>
        /// Tries to switch the row with a lower one if the cell is equal to the value
        /// </summary>
        /// <typeparam name="T">The type of the matrix, must be IEquatable</typeparam>
        /// <param name="matrix">The matrix</param>
        /// <param name="row">The row of the cell</param>
        /// <param name="column">The column of the cell</param>
        /// <param name="value">The value that we want to move</param>
        /// <returns>A copy of the matrix with the modifications </returns>
        public static T[,] TryMoveValueLower<T>(T[,] matrix, int row, int column, T value) where T : IEquatable<T>
            => TryMoveValueLower(matrix, row, column, value, (x, y) => x.Equals(y));

        /// <summary>
        /// Tries to switch the row with a lower one if the cell is equal to the value
        /// </summary>
        /// <typeparam name="T">The type of the matrix</typeparam>
        /// <param name="matrix">The matrix</param>
        /// <param name="row">The row of the cell</param>
        /// <param name="column">The column of the cell</param>
        /// <param name="value">The value that we want to move</param>
        /// <param name="equals">A function that takes in two Ts and return true if they are the same</param>
        /// <returns>A copy of the matrix with the modifications </returns>
        /// <exception cref="NotAPartOfTheMatrixException">An exception thrown when the cell isn't a part of the matrix</exception>
        public static T[,] TryMoveValueLower<T>(T[,] matrix, int row, int column, T value, Func<T, T, bool> equals)
        {
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);

            if (!IsInTheMatrix(height, width, row, column))
                throw new NotAPartOfTheMatrixException();

            T[,] cloned = (T[,])matrix.Clone();

            TryMoveValueLower(cloned, null, height, width, row, column, value, equals, out bool changed);

            return cloned;
        }

        /// <summary>
        /// If the given cell is value, the function tries to switch the row with one lower
        /// </summary>
        /// <typeparam name="T">The type of the matrix</typeparam>
        /// <param name="matrix">The matrix</param>
        /// <param name="height">The height of the matrix</param>
        /// <param name="width">The width of the matrix</param>
        /// <param name="row">The row of the cell</param>
        /// <param name="column">The column of the cell</param>
        /// <param name="value">The value that we want to move</param>
        /// <param name="equals">A function that takes in two Ts and return true if they are the same</param>
        /// <param name="changed">A bool that's true if rows where swapped</param>
        /// <returns>A copy of the matrix if there were modifications, else the matrix </returns>
        ///<remarks>Because this is the private function, there's no verification done on the inputs</remarks>
        private static void TryMoveValueLower<T>(T[,] matrix, T[,] otherMatrix, int height, int width, int row, int column, T value, Func<T, T, bool> equals, out bool changed)
            => TryMoveValue(matrix, otherMatrix, width, row, column, value, equals, out changed, height - 1, -1, (i) => i > row);

        /// <summary>
        /// If the given cell is value, the function tries to switch the row with one higher
        /// </summary>
        /// <typeparam name="T">The type of the matrix, must be IEquatable</typeparam>
        /// <param name="matrix">The matrix</param>
        /// <param name="row">The row of the cell</param>
        /// <param name="column">The column of the cell</param>
        /// <param name="value">The value 0</param>
        /// <param name="equals">A function that takes in two Ts and return true if they are the same</param>
        /// <returns>A copy of the matrix if there were modifications, else the matrix </returns>
        public static T[,] TryMoveValueHigher<T>(T[,] matrix, int row, int column, T value) where T : IEquatable<T>
            => TryMoveValueHigher(matrix, row, column, value, (x, y) => x.Equals(y));

        /// <summary>
        /// If the given cell is value, the function tries to switch the row with one higher
        /// </summary>
        /// <typeparam name="T">The type of the matrix</typeparam>
        /// <param name="matrix">The matrix</param>
        /// <param name="row">The row of the cell</param>
        /// <param name="column">The column of the cell</param>
        /// <param name="value">The value 0</param>
        /// <param name="equals">A function that takes in two Ts and return true if they are the same</param>
        /// <returns>A copy of the matrix if there were modifications, else the matrix </returns>
        /// <exception cref="NotAPartOfTheMatrixException">An exception thrown when the cell isn't a part of the matrix</exception>
        public static T[,] TryMoveValueHigher<T>(T[,] matrix, int row, int column, T value, Func<T, T, bool> equals)
        {
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);

            if (!IsInTheMatrix(height, width, row, column))
                throw new NotAPartOfTheMatrixException();

            T[,] cloned = (T[,])matrix.Clone();

            TryMoveValueHigher(cloned, null, width, row, column, value, equals, out bool changed);

            return cloned;
        }

        /// <summary>
        /// If the given cell is value, the function tries to switch the row with one higher
        /// </summary>
        /// <typeparam name="T">The type of the matrix</typeparam>
        /// <param name="matrix">The matrix</param>
        /// <param name="height">The height of the matrix</param>
        /// <param name="width">The width of the matrix</param>
        /// <param name="row">The row of the cell</param>
        /// <param name="column">The column of the cell</param>
        /// <param name="value">The value 0</param>
        /// <param name="equals">A function that takes in two Ts and return true if they are the same</param>
        /// <param name="changed">A bool that's true if rows where swapped</param>
        /// <returns>A copy of the matrix if there were modifications, else the matrix </returns>
        private static void TryMoveValueHigher<T>(T[,] matrix, T[,] otherMatrix, int width, int row, int column, T value, Func<T, T, bool> equals, out bool changed)
            => TryMoveValue(matrix, otherMatrix, width, row, column, value, equals, out changed, 0, 1, (i) => i < row);

        /// <summary>
        /// Tries to swap the row of the cell with another one, if the cell is value and the other one isn't
        /// </summary>
        /// <typeparam name="T">The type of the matrix</typeparam>
        /// <param name="matrix">The matrix</param>
        /// <param name="width">The width of the matrix</param>
        /// <param name="row">The row of the cell</param>
        /// <param name="column">The column of the cell</param>
        /// <param name="value">The value 0</param>
        /// <param name="equals">A function that takes in two T's and return true if they are equal</param>
        /// <param name="changed">A bool that's true if there was a change else it's false</param>
        /// <param name="startIndex">The index of the row the function start looking at</param>
        /// <param name="increment">The increment between the rows the function check</param>
        /// <param name="condition">A function that takes in the current row and return true if the function need to check it</param>
        /// <remarks>The other matrix is a matrix that will receive the same modification, you are responsable to be sure it's the same size</remarks>
        private static void TryMoveValue<T>(T[,] primaryMatrix, T[,] otherMatrix, int width, int row, int column, T value, Func<T, T, bool> equals, out bool changed, int startIndex, int increment, Func<int, bool> condition)
        {
            changed = false;

            if (!equals(primaryMatrix[row, column], value))
                return;

            for (int i = startIndex; condition(i); i += increment)
            {
                if (!equals(primaryMatrix[i, column], value))
                {
                    changed = true;
                    if (otherMatrix != null)
                        SwapRows(otherMatrix, row, i, width);
                    SwapRows(primaryMatrix, row, i, width);
                    return;
                }
            }
        }

        /// <summary>
        /// Multiplies a row of the matrix by a scalar 
        /// </summary>
        /// <typeparam name="T">Type of the matrix</typeparam>
        /// <param name="matrix">The matrix</param>
        /// <param name="row">The row</param>
        /// <param name="scalar">The scalar</param>
        /// <param name="multiply">A function that takes in two Ts and that return their multiple</param>
        /// <returns>A copy of the matrix where the row is multiplies by the scalar</returns>
        /// <exception cref="NotAPartOfTheMatrixException">Exception thrown when the row isn't a part of the matrix</exception>
        public static T[,] MultiplyRowByScalar<T>(T[,] matrix, int row, T scalar, Func<T, T, T> multiply)
        {
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);

            if (row < 0 || row >= height)
                throw new NotAPartOfTheMatrixException();

            T[,] cloned = (T[,])matrix;

            MultiplyRowByScalar(cloned, null, width, row, scalar, multiply);

            return cloned;
        }

        /// <summary>
        /// Multiplies a row of the matrix by a scalar 
        /// </summary>
        /// <typeparam name="T">Type of the matrix</typeparam>
        /// <param name="matrix">The matrix</param>
        /// <param name="width">The width of the matrix</param>
        /// <param name="row">The row</param>
        /// <param name="scalar">The scalar</param>
        /// <param name="multiply">A function that takes in two Ts and that return their multiple</param>
        /// <remarks>Because this is the private version, send a CLONE if you want a copy  and be sure that the parameters are ok</remarks>
        private static void MultiplyRowByScalar<T>(T[,] matrix, T[,] otherMatrix, int width, int row, T scalar, Func<T, T, T> multiply)
        {
            for (int j = 0; j < width; ++j)
                matrix[row, j] = multiply(scalar, matrix[row, j]);

            if (otherMatrix != null)
                for (int j = 0; j < width; ++j)
                    matrix[row, j] = multiply(scalar, matrix[row, j]);
        }

        /// <summary>
        /// Adds to a specific row, the scalled values of the rows past in parameter
        /// </summary>
        /// <typeparam name="T">The type of the matrix</typeparam>
        /// <param name="matrix">The matrix</param>
        /// <param name="affectedRow">The row that gets the modifications</param>
        /// <param name="add">A function that takes in tow Ts and return their sum as a T</param>
        /// <param name="multiply">A function that takes in tow Ts and return their multiple as a T</param>
        /// <param name="operations">An array of rows and scalars that each needs to be added to the affected row</param>
        /// <returns>A copy of the matrix where the affected row was added with all the operationw</returns>
        /// <exception cref="NotAPartOfTheMatrixException">Excption thrown when the row isn't a part of the matrix</exception>
        public static T[,] AddScalledRowsToAnother<T>(T[,] matrix, int affectedRow, Func<T, T, T> add, Func<T, T, T> multiply, params (int affectingRow, T scalar)[] operations)
        {
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);

            bool invalide = affectedRow >= height || affectedRow < 0;

            foreach ((int row, T sca) in operations)
            {
                invalide = invalide || row >= height || row < 0;
                if (invalide)
                    throw new NotAPartOfTheMatrixException();
            }

            T[,] cloned = (T[,])matrix.Clone();

            AddScalledRowsToAnother(cloned, null, width, affectedRow, add, multiply, operations);

            return cloned;
        }

        /// <summary>
        /// Adds to a specific row, the scalled values of the rows given in parameter
        /// </summary>
        /// <typeparam name="T">The type of the matrix</typeparam>
        /// <param name="matrix">The matrix</param>
        /// <param name="width">The width of the matrix</param>
        /// <param name="affectedRow">The row that gets the modifications</param>
        /// <param name="add">A function that takes in tow Ts and return their sum as a T</param>
        /// <param name="multiply">A function that takes in tow Ts and return their multiple as a T</param>
        /// <param name="operations">An array of rows and scalars that each needs to be added to the affected row</param>
        /// <remarks>Because this is the private version, you must send a CLONE if you want a copy and be sure that all the parameters are ok</remarks>
        private static void AddScalledRowsToAnother<T>(T[,] primaryMatrix, T[,] otherMatrix, int width, int affectedRow, Func<T, T, T> add, Func<T, T, T> multiply, params (int affectingRow, T scalar)[] operations)
        {
            foreach ((int currRow, T currScalar) in operations)
            {
                for (int j = 0; j < width; ++j)
                    primaryMatrix[affectedRow, j] = add(primaryMatrix[affectedRow, j], multiply(currScalar, primaryMatrix[currRow, j]));
            }

            if (otherMatrix != null)
            {
                foreach ((int currRow, T currScalar) in operations)
                {
                    for (int j = 0; j < width; ++j)
                        otherMatrix[affectedRow, j] = add(otherMatrix[affectedRow, j], multiply(currScalar, otherMatrix[currRow, j]));
                }
            }
        }

        /// <summary>
        /// Swaps two rows of the matrix arround 
        /// </summary>
        /// <typeparam name="T">The type of the matrix</typeparam>
        /// <param name="matrix">The matrix</param>
        /// <param name="row1">The first row to switch</param>
        /// <param name="row2">The second row to switch</param>
        /// <returns>A copy of the matrix where the two rows are switched</returns>
        /// <exception cref="NotAPartOfTheMatrixException">Excpetion thrown when one of the row isn't part of the matrix</exception>
        public static T[,] SwapRows<T>(T[,] matrix, int row1, int row2)
        {
            int height = matrix.GetLength(0);

            //Technically doesn't check if it's in the matrix, but if both rows are valid
            if (!IsInTheMatrix(height, height, row1, row2))
                throw new NotAPartOfTheMatrixException();

            T[,] cloned = (T[,])matrix.Clone();

            SwapRows(cloned, row1, row2, height);

            return cloned;
        }

        /// <summary>
        /// Swaps two rows of the matrix arround 
        /// </summary>
        /// <typeparam name="T">The type of the matrix</typeparam>
        /// <param name="matrix">The matrix</param>
        /// <param name="row1">The first row to switch</param>
        /// <param name="row2">The second row to switch</param>
        /// <param name="width">The width of the matrix</param>
        /// <returns>The matrix where the two rows are switched</returns>
        /// <remarks>Because this is the private version, you must CLONE the matrix before if you want a clone and no value should throw an error</remarks>
        private static void SwapRows<T>(T[,] matrix, int row1, int row2, int width)
        {
            for (int i = 0; i < width; ++i)
                (matrix[row1, i], matrix[row2, i]) = (matrix[row2, i], matrix[row1, i]);
        }

        /// <summary>
        /// Creates a matrix with all the values that aren't in the row or in the column given
        /// </summary>
        /// <typeparam name="T">The type of the matrix</typeparam>
        /// <param name="matrix">The matrix</param>
        /// <param name="rowToRemove">The row that won't be copied</param>
        /// <param name="columnToRemove">The column that won't be copied</param>
        /// <returns>A copy of the matrix with the row and the column removed</returns>
        /// <exception cref="NotAPartOfTheMatrixException">Exception thrown when the row or the column isn't in the matrix</exception>
        public static T[,] GetMinor<T>(T[,] matrix, int rowToRemove, int columnToRemove)
        {
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);

            if (!IsInTheMatrix(height, width, rowToRemove, columnToRemove))
                throw new NotAPartOfTheMatrixException();

            return GetMinor(matrix, height, width, rowToRemove, columnToRemove);
        }

        /// <summary>
        /// Creates a matrix with all the values that aren't in the row or in the column given
        /// </summary>
        /// <typeparam name="T">The type of the matrix</typeparam>
        /// <param name="matrix">The matrix</param>
        /// <param name="height">The height of the matrix</param>
        /// <param name="width">The width of the matrix</param>
        /// <param name="rowToRemove">The row that won't be copied</param>
        /// <param name="columnToRemove">The column that won't be copied</param>
        /// <returns>A copy of the matrix with the row and the column removed</returns>
        private static T[,] GetMinor<T>(T[,] matrix, int height, int width, int rowToRemove, int columnToRemove)
        {
            T[,] cofactor = new T[height - 1, width - 1];

            for (int i = 0; i < height; ++i)
            {
                if (i == rowToRemove)
                    continue;

                int removeToHeight = i > rowToRemove ? 1 : 0;

                for (int j = 0; j < width; ++j)
                {
                    if (j == columnToRemove)
                        continue;

                    int removeToWidth = j > columnToRemove ? 1 : 0;

                    cofactor[i - removeToHeight, j - removeToWidth] = matrix[i, j];
                }
            }
            return cofactor;
        }

        /// <summary>
        /// Return the matrix of cofactors
        /// </summary>
        /// <typeparam name="T">The type of the initial matrix</typeparam>
        /// <typeparam name="U">The type of the resulting matrix</typeparam>
        /// <param name="matrix">The matrix</param>
        /// <param name="zero">The value 0 of the type U</param>
        /// <param name="one">The value 1 of the type U</param>
        /// <param name="convert">A function that takes a type T and convert it to a type U</param>
        /// <param name="add">A function that takes in two Us and returns their sum as a U</param>
        /// <param name="multiply">A function that takes in two Us and returns their multiple as a U</param>
        /// <param name="getMultiplicativeInverse">A function that takes in a U and returns it's multiplicative inverse as a U</param>
        /// <param name="inverseSign">A function that takes in a U and return it's sign inverse as a U</param>
        /// <param name="equals">A function that takes in two Us and return a bool if they are the same</param>
        /// <returns>The cofactor of the matrix</returns>
        public static U[,] GetCofactorMatrix<T, U>(T[,] matrix, U zero, U one, Func<T, U> convert, Func<U, U, U> add, Func<U, U, U> multiply, Func<U, U> getMultiplicativeInverse, Func<U, U> inverseSign, Func<U, U, bool> equals)
        {
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);

            if (!IsSquare(height, width))
                throw new NotSquareMatrixException();

            return GetCofactorMatrix(ConvertMatrixType(matrix, convert), height, width, zero, one, add, multiply, getMultiplicativeInverse, inverseSign, equals);
        }

        /// <summary>
        /// Return the matrix of cofactors
        /// </summary>
        /// <typeparam name="T">The type of the matrix</typeparam>
        /// <param name="matrix">The matrix</param>
        /// <param name="height">The height of the matrix</param>
        /// <param name="width">The width of the matrix</param>
        /// <param name="zero">The value 0 of the type U</param>
        /// <param name="one">The value 1 of the type U</param>
        /// <param name="convert">A function that takes a type T and convert it to a type U</param>
        /// <param name="add">A function that takes in two Us and returns their sum as a U</param>
        /// <param name="multiply">A function that takes in two Us and returns their multiple as a U</param>
        /// <param name="getMultiplicativeInverse">A function that takes in a U and returns it's multiplicative inverse as a U</param>
        /// <param name="inverseSign">A function that takes in a U and return it's sign inverse as a U</param>
        /// <param name="equals">A function that takes in two Us and return a bool if they are the same</param>
        /// <returns>The cofactor of the matrix</returns>
        private static T[,] GetCofactorMatrix<T>(T[,] matrix, int height, int width, T zero, T one, Func<T, T, T> add, Func<T, T, T> multiply, Func<T, T> getMultiplicativeInverse, Func<T, T> inverseSign, Func<T, T, bool> equals)
        {
            T[,] cofactors = new T[height, width];

            LoopOverMatrix(height, width, (i, j) =>
            {
                cofactors[i, j] = GetMatrixDeterminant(GetMinor(matrix, height, width, i, j), null, height - 1, width - 1, zero, one, add, multiply, getMultiplicativeInverse, inverseSign, equals);

                if ((i + j) % 2 == 1)
                    cofactors[i, j] = inverseSign(cofactors[i, j]);
            });

            return cofactors;
        }

        /// <summary>
        /// Transpose the matrix ("flips" it to the left arround the [0;0])
        /// </summary>
        /// <typeparam name="T">The type of the matrix</typeparam>
        /// <param name="matrix">The matrix</param>
        /// <returns>A copy of the matrix transposed</returns>
        public static T[,] TransposeMatrix<T>(T[,] matrix)
            => TransposeMatrix(matrix, matrix.GetLength(0), matrix.GetLength(1));

        /// <summary>
        /// Transpose the matrix ("flips" it to the left arround the [0;0])
        /// </summary>
        /// <typeparam name="T">The type of the matrix</typeparam>
        /// <param name="matrix">The matrix</param>
        /// <param name="height">The height of the matrix</param>
        /// <param name="width">The width of the matrix</param>
        /// <returns>A copy of the matrix transposed</returns>
        private static T[,] TransposeMatrix<T>(T[,] matrix, int height, int width)
        {
            T[,] transpose = new T[width, height];

            LoopOverMatrix(height, width, (i, j) => transpose[j, i] = matrix[i, j]);

            return transpose;
        }

        /// <summary>
        /// Get the inverse of the matrix to solve linear system
        /// </summary>
        /// <typeparam name="T">Type of the initial matrix</typeparam>
        /// <typeparam name="U">Type of the resulting matrix</typeparam>
        /// <param name="matrix">The matrix that we need to inverse</param>
        /// <param name="zero">The value 0 of the type U</param>
        /// <param name="one">The value 1 of the type U</param>
        /// <param name="convert">A function that takes in a T and returns it's equivalent in U</param>
        /// <param name="add">A function that takes in two Us and returns their sum as a U</param>
        /// <param name="multiply">A function that takes in two Us and returns their multiple as a U</param>
        /// <param name="inverseSign">A function that takes in a U and returns it's sign inverse (ie -x) as a U</param>
        /// <param name="getMultiplicativeInverse">A function that takes in a U and returns its multiplicative inverse (ie 1/x) as a U</param>
        /// <param name="equals">A function that takes in two Us and returns true if they are the same</param>
        /// <returns>The inverse matrix</returns>
        /// <remarks>Convert will most likely need to change int/long into float/double </remarks>
        public static U[,] GetInverseMatrix<T, U>(T[,] matrix, U zero, U one, Func<T, U> convert, Func<U, U, U> add, Func<U, U, U> multiply, Func<U, U> inverseSign, Func<U, U> getMultiplicativeInverse, Func<U, U, bool> equals)
            => GetInverseMatrix(ConvertMatrixType(matrix, convert), zero, one, add, multiply, inverseSign, getMultiplicativeInverse, equals);

        //Optimised this function, went from a time complexity of O(n^4) to O(n^3)
        /// <summary>
        /// Get the inverse of the matrix to solve linear system
        /// </summary>
        /// <typeparam name="T">Type of the  matrix</typeparam>
        /// <param name="matrix">The matrix that we need to inverse</param>
        /// <param name="zero">The value 0 of the type T</param>
        /// <param name="one">The value 1 of the type T</param>
        /// <param name="add">A function that takes in two Ts and returns their sum as a T</param>
        /// <param name="multiply">A function that takes in two Ts and returns their multiple as a T</param>
        /// <param name="inverseSign">A function that takes in a T and returns it's sign inverse (ie -x) as a T</param>
        /// <param name="getMultiplicativeInverse">A function that takes in a T and returns its multiplicative inverse (ie 1/x) as a T</param>
        /// <param name="equals">A function that takes in two Ts and returns true if they are the same</param>
        /// <returns>The inverse matrix</returns>
        /// <exception cref="ZeroDeterminantException">Exception thrown when the determinant of the matrix is 0</exception>
        /// <remarks>Based on Gausian elimination</remarks>
        private static T[,] GetInverseMatrix<T>(T[,] matrix, T zero, T one, Func<T, T, T> add, Func<T, T, T> multiply, Func<T, T> inverseSign, Func<T, T> getMultiplicativeInverse, Func<T, T, bool> equals)
        {
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);

            T[,] inverse = CreateIdentityMatrix(zero, one, width);
            T determinant = GetMatrixDeterminant(matrix, inverse, height, width, zero, one, add, multiply, getMultiplicativeInverse, inverseSign, equals);

            if (equals(determinant, zero))
                throw new ZeroDeterminantException();

            //puts everything except diagonal at 0
            for (int j = 1; j < width; j++)
            {
                for (int i = j - 1; i >= 0; --i)
                {
                    T scalar = inverseSign(multiply(matrix[i, j], getMultiplicativeInverse(matrix[j, j])));
                    AddScalledRowsToAnother(matrix, inverse, height, i, add, multiply, (j, scalar));
                }
            }

            //divides every row by the diagonal cell to get identity back
            for (int i = 0; i < width; i++)
                MultiplyRowByScalar(inverse, null, width, i, getMultiplicativeInverse(matrix[i, i]), multiply);

            return inverse;
        }

        /// <summary>
        /// Creates the identity matrix of the type T
        /// </summary>
        /// <typeparam name="T">The type of the matrix</typeparam>
        /// <param name="zero">The value value of the type T</param>
        /// <param name="one">The value one of the type T</param>
        /// <param name="size">The size desired for the identity matrix</param>
        /// <returns>A square matrix with 1s in the diagonal and 0 everywhere</returns>
        public static T[,] CreateIdentityMatrix<T>(T zero, T one, int size)
        {
            T[,] result = new T[size, size];

            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    if (i == j)
                        result[i, j] = one;
                    else
                        result[i, j] = zero;
                }
            }

            return result;
        }

        #endregion
    }

    /// <summary>
    /// Exception thrown when the dimensions of two matrices aren't compatible for an operation
    /// </summary>
    public class IncompatibleMatricesSizeException : Exception { }

    /// <summary>
    /// Exception thrown when the diemensions of a vector and a matrix aren't compatible for an operation
    /// </summary>
    public class IncompatibleMatrixVectorSizeException : Exception { }

    /// <summary>
    /// Exception thrown when you're trying to reach a column or row that's not inside the matrix
    /// </summary>
    public class NotAPartOfTheMatrixException : Exception { }

    /// <summary>
    /// Exception thrown when the lenght of two vectors aren't compativle for an operation
    /// </summary>
    public class IncompatibleVectorsSizeException : Exception { }

    /// <summary>
    /// Exception thrown when a vector isn't in three dimension when it should be 
    /// </summary>
    public class Not3DVectorException : Exception { }

    /// <summary>
    /// Exception thrown when the matrix isn't square when it should be
    /// </summary>
    public class NotSquareMatrixException : Exception { }

    /// <summary>
    /// Exception thrown when the determinant of the matrix is value when it shouldn't be
    /// </summary>
    public class ZeroDeterminantException : Exception { }
}