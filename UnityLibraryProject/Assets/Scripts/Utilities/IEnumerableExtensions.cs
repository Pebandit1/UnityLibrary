using System;
using System.Collections.Generic;
using System.Linq;

namespace Utilities
{
    /// <summary>
    /// Static class containg fonctions frequently used with IEnumerables
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Creates a clone of the IEnumerable
        /// </summary>
        /// <typeparam name="T">The type of the IEnumerable</typeparam>
        /// <param name="list">The IEnumerable to clone</param>
        /// <returns>The clone</returns>
        public static IEnumerable<T> CloneAsEnumerable<T>(this IEnumerable<T> list)
        {
            List<T> clone = new List<T>(list.Count());

            foreach(var item in list)
                clone.Add(item);

            return clone;
        }

        /// <summary>
        /// Checks if the index is a whithin the count of the IEnumerable
        /// </summary>
        /// <typeparam name="T">The type of the IEnumerable</typeparam>
        /// <param name="list">The IEnumerable in which we are checking</param>
        /// <param name="index">The index were are checking</param>
        /// <returns>True if the index is valide, else False</returns>
        public static bool IsIndexValide<T>(this IEnumerable<T> list, int index) => index >= 0 && index < list.Count();

        /// <summary>
        /// Checks if the two IEnumerable have the same content
        /// </summary>
        /// <typeparam name="T">The type of the IEnumerables, must be IEquatable<T> </typeparam>
        /// <param name="a">The first IEnumerable</param>
        /// <param name="b">The second IEnumerable</param>
        /// <returns>True if they have the same content, else False</returns>
        public static bool HaveTheSameContent<T>(IEnumerable<T> a, IEnumerable<T> b) where T : IEquatable<T>
            => HaveTheSameContent(a, b, (x, y) => x.Equals(y));

        /// <summary>
        /// Checks if the two IEnumerable have the same content
        /// </summary>
        /// <typeparam name="T">The type of the IEnumerables</typeparam>
        /// <param name="a">The first IEnumerable</param>
        /// <param name="b">The second IEnumerable</param>
        /// <param name="equals">The equality test</param>
        /// <returns>True if they have the same content, else False</returns>
        public static bool HaveTheSameContent<T>(IEnumerable<T> a, IEnumerable<T> b, Func<T, T, bool> equals)
        {
            if (a.Count() != b.Count())
                return false;

            bool areTheSame = true;

            for (int i = 0; i < a.Count(); i++)
                areTheSame = areTheSame && equals(a.ElementAt(i), b.ElementAt(i));

            return areTheSame;
        }
    }
}