using UnityEngine;

namespace Utilities
{
    /// <summary>
    /// Static class containing fonctions for GameObjects
    /// </summary>
    public static class GameObjectUtilities
    {
        /// <summary>
        /// Creates a GameObject and sets its parent automatically
        /// </summary>
        /// <param name="parent">The parent</param>
        /// <returns>The new GameObject</returns>
        public static GameObject CreateObjectAndSetParent(Transform parent)
            => CreateObjectAndSetParent(parent, "newGameObject", Vector3.zero);

        /// <summary>
        /// Creates a GameObject and sets its parent automatically
        /// </summary>
        /// <param name="parent">The parent</param>
        /// <param name="name">The name of the GameObject</param>
        /// <returns>The new GameObject</returns>
        public static GameObject CreateObjectAndSetParent(Transform parent, string name)
        => CreateObjectAndSetParent(parent, name, Vector3.zero);

        /// <summary>
        /// Creates a GameObject and sets its parent automatically
        /// </summary>
        /// <param name="parent">The parent</param>
        /// <param name="localPos">The localPosition of the GameObject</param>
        /// <returns>The new GameObject</returns>
        public static GameObject CreateObjectAndSetParent(Transform parent, Vector3 localPos)
            => CreateObjectAndSetParent(parent, "newGameObject", localPos);

        /// <summary>
        /// Creates a GameObject and sets its parent automatically
        /// </summary>
        /// <param name="parent">The parent</param>
        /// <param name="name">The name of the GameObject</param>
        /// <param name="localPos">The localPosition of the GameObject</param>
        /// <returns>The new GameObject</returns>
        public static GameObject CreateObjectAndSetParent(Transform parent, string name, Vector3 localPos)
        {
            GameObject obj = new GameObject(name);
            obj.transform.parent = parent;
            obj.transform.localPosition = localPos;

            return obj;
        }
    }
}