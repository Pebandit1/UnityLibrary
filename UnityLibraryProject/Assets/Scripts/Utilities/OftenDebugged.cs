using MyMath;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Utilities
{
    /// <summary>
    /// Static class containingg Debbug templates 
    /// </summary>
    public static class OftenDebbuged
    {
        /// <summary>
        /// To use when the gameobject is missing an important component for the script to work as desired
        /// </summary>
        /// <typeparam name="TCompontent">Missing component type</typeparam>
        /// <typeparam name="TSender">Script type of the sender</typeparam>
        /// <param name="gameObject">The gameObject that needs the component</param>
        public static void MissingImportantComponent<TCompontent, TSender>(GameObject gameObject)
            where TCompontent : Component
            where TSender : MonoBehaviour
            => Debug.LogWarning($"{gameObject} is missing a component of type {typeof(TCompontent)} for the Monobehaviour {typeof(TSender)} to work");

        /// <summary>
        /// To use when debuging a Matrix
        /// </summary>
        /// <typeparam name="T">The type of the matrix</typeparam>
        /// <param name="message">The message to put before the matrix</param>
        /// <param name="matrix">The matrix</param>
        public static void DebugMatrix<T>(string message, T[,] matrix)
        => Debug.Log(message + "\r\n" + GetMatrixBuilder(matrix).ToString());

        /// <summary>
        /// To use when debuging a Matrix
        /// </summary>
        /// <typeparam name="T">The type of the matrix</typeparam>
        /// <param name="matrix">The matrix</param>
        public static void DebugMatrix<T>(T[,] matrix)
            => Debug.Log(GetMatrixBuilder(matrix).ToString());

        const string VERTICAL_SEPARATION = " | ";

        /// <summary>
        /// Creates a StringBuilder for the matrix
        /// </summary>
        /// <typeparam name="T">The type of the matrix</typeparam>
        /// <param name="matrix">The matrix</param>
        /// <returns>The StringBuilder containing the matrix as text</returns>
        private static StringBuilder GetMatrixBuilder<T>(T[,] matrix)
        {
            StringBuilder matrixBuilder = new StringBuilder();

            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);
            int longest = FindLongestString(matrix);

            int dashLineLength = width * (longest + 2 * VERTICAL_SEPARATION.Length);

            for (int rowIndex = 0; rowIndex < height; ++rowIndex)
                WriteMatrixLine(matrix, matrixBuilder, width, longest, dashLineLength, rowIndex);

            WriteDashLine(matrixBuilder, dashLineLength);

            return matrixBuilder;
        }

        /// <summary>
        /// Writes one line of the matrix inside the StringBuilder
        /// </summary>
        /// <typeparam name="T">The type of the matrix</typeparam>
        /// <param name="matrix">The matrix to write</param>
        /// <param name="matrixBuilder">The StringBuilder to write in</param>
        /// <param name="width">The width of the matrix</param>
        /// <param name="longest">The longest character in the matrix</param>
        /// <param name="dashLineLength">The length of the dash line between each row of the matrix</param>
        /// <param name="rowIndex">The index of the row inside the matrix</param>
        private static void WriteMatrixLine<T>(T[,] matrix, StringBuilder matrixBuilder, int width, int longest, int dashLineLength, int rowIndex)
        {
            WriteDashLine(matrixBuilder, dashLineLength);
            matrixBuilder.Append(VERTICAL_SEPARATION);

            for (int columnIndex = 0; columnIndex < width; ++columnIndex)
                WriteValueCentered(matrix[rowIndex, columnIndex], matrixBuilder, longest);

            matrixBuilder.AppendLine();
        }

        /// <summary>
        /// Writes the value centered inside its own cell
        /// </summary>
        /// <typeparam name="T">The type of the value</typeparam>
        /// <param name="value">The value to write</param>
        /// <param name="stringBuilder">The StringBuilder to write in</param>
        /// <param name="longest">The longest character in the matrix</param>
        private static void WriteValueCentered<T>(T value, StringBuilder stringBuilder, int longest)
        {
            int length = value.ToString().Length;
            int spaces = longest - length;

            stringBuilder.Append(' ', spaces / 2);
            stringBuilder.Append(value);
            stringBuilder.Append(' ', (spaces + 1) / 2);
            stringBuilder.Append(VERTICAL_SEPARATION);
        }

        /// <summary>
        /// To use when debuging an array 
        /// </summary>
        /// <typeparam name="T">The type of the array</typeparam>
        /// <param name="message">The message to put before the array</param>
        /// <param name="array">The array to debug</param>
        public static void DebugArray<T>(string message, T[] array)
            => Debug.Log(message + "\r\n" + GetArrayBuilder(array).ToString());

        /// <summary>
        /// To use when debuging an array 
        /// </summary>
        /// <typeparam name="T">The type of the array</typeparam>
        /// <param name="array">The array to debug</param>
        public static void DebugArray<T>(T[] array)
        => Debug.Log(GetArrayBuilder(array));

        /// <summary>
        /// Creates a StringBuilder for the array
        /// </summary>
        /// <typeparam name="T">The type of the matrix</typeparam>
        ///<param name="array">The array to write in the StringBuilder</param>
        /// <returns>The StringBuilder containing the array as text</returns>
        private static StringBuilder GetArrayBuilder<T>(T[] array)
        {
            StringBuilder builder = new StringBuilder();
            int length = array.Length;
            int longest = FindLongestString(array);

            int dashlineLength = longest + VERTICAL_SEPARATION.Length * 2;

            WriteDashLine(builder, dashlineLength);

            foreach(T curr in array)
            {
                builder.Append(VERTICAL_SEPARATION);
                WriteValueCentered(curr, builder, longest);
                builder.AppendLine();
                WriteDashLine(builder, dashlineLength);
            }

            return builder;
        }

        /// <summary>
        /// Finds the longest value when converted to string
        /// </summary>
        /// <typeparam name="T">The type of the matrix</typeparam>
        /// <param name="matrix">The matrix to check in</param>
        /// <returns>The length of the longest value</returns>
        private static int FindLongestString<T>(T[,] matrix)
        {
            int longest = 0;

            LinearAlgebraMath.LoopOverMatrix(matrix, (i, j) =>
            {
                int newLength = matrix[i, j].ToString().Length;
                longest = newLength > longest ? newLength : longest;
            });

            return longest;
        }

        /// <summary>
        /// Finds the longest value when converted to string
        /// </summary>
        /// <typeparam name="T">The type of the IEnumerable</typeparam>
        /// <param name="list">The IEnumerable to check in</param>
        /// <returns>The length of the longest value</returns>
        private static int FindLongestString<T>(IEnumerable<T> list)
        {
            int longest = 0;
            foreach(T curr in list)
            {
                int currLenght = curr.ToString().Length;
                longest = currLenght > longest ? currLenght : longest;
            }

            return longest;
        }

        /// <summary>
        /// Writes a line of dashes inside the StringBuilder
        /// </summary>
        /// <param name="builder">the StringBuilder to write in</param>
        /// <param name="amount">the number of dashes to put</param>
        private static void WriteDashLine(StringBuilder builder, int amount)
        {
            const string HORIZONTAL_SEPARATION = "-";

            for (int i = 0; i < amount; i++)
                builder.Append(HORIZONTAL_SEPARATION);

            builder.AppendLine();
        }
    }
}