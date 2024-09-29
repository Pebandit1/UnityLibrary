using UnityEngine;
using static System.Math;

namespace Utilities
{
    /// <summary>
    /// Static class containg fonctions to test equalities with Numerical types
    /// </summary>
    public static class NumericEqualities
    {
        /// <summary>
        /// Fonctions that determines if two float are close enough
        /// </summary>
        /// <param name="a">the first float</param>
        /// <param name="b">the second float</param>
        /// <returns>True if they are close enough, else False</returns>
        public static bool AreCloseEnough(float a, float b)
        {
            const float MINIMAL_DIFF = 0.00001f;

            return Abs(a - b) < MINIMAL_DIFF;
        }

        /// <summary>
        /// Fonctions that determines if two doubles are close enough
        /// </summary>
        /// <param name="a">the first doubles</param>
        /// <param name="b">the second doubles</param>
        /// <returns>True if they are close enough, else False</returns>
        public static bool AreCloseEnough(double a, double b)
        {
            const double MINIMAL_DIFF = 0.00000000001;

            return Abs(a - b) < MINIMAL_DIFF;
        }

        /// <summary>
        /// Fonctions that determines if two Vector2 are close enough
        /// </summary>
        /// <param name="a">the first Vector2</param>
        /// <param name="b">the second Vector2</param>
        /// <returns>True if they are close enough, else False</returns>
        public static bool AreCloseEnough(Vector2 a, Vector2 b)
            => AreCloseEnough(a.x, b.x) && AreCloseEnough(a.y, b.y);


        /// <summary>
        /// Fonctions that determines if two Vector3 are close enough
        /// </summary>
        /// <param name="a">the first Vector3</param>
        /// <param name="b">the second Vector3</param>
        /// <returns>True if they are close enough, else False</returns>
        public static bool AreCloseEnough(Vector3 a, Vector3 b)
            => AreCloseEnough(a.x, b.x) && AreCloseEnough(a.y, b.y) && AreCloseEnough(a.z, b.z);
    }
}