using System.Collections.Generic;
using UnityEngine;

namespace DetectionSystem
{
    /// <summary>
    /// Detection zone (Trigger or Collider) that store the collider and the IDetectable component of GameObjects
    /// </summary>
    /// <typeparam name="T">The type of IDetectable to detect</typeparam>
    /// <typeparam name="U">The type of IDetectableElement to keep track of the collisions</typeparam>
    public abstract class DetectionZone<T, U> : MonoBehaviour
        where T : IDetectable
        where U : IDetectableElement
    {
        /// <summary>
        /// Function that tries to get the IDetectable from the GameObject that was hit
        /// </summary>
        /// <param name="gameObject">The gameObject that was hit</param>
        /// <param name="iDetectable">The IDetectable connected to the GameObject</param>
        /// <returns>True if the gameObject has an IDetectable, else False</returns>
        /// <remarks>You can chec tags before trying to get the component</remarks>
        protected abstract bool TryGetIDetectable(GameObject gameObject, out T iDetectable);

        /// <summary>
        /// Creates the new IDetectableElement on the first Collision
        /// </summary>
        /// <param name="iDetectable">The IDetectable of the collider</param>
        /// <returns>The new IDetectableElement</returns>
        protected abstract U CreateIDetectableElement(T iDetectable);

        /// <summary>
        /// Function to execute on the first hit
        /// </summary>
        /// <param name="iDetectable">The IDetectable that was just hit</param>
        protected virtual void OnEnter(T iDetectable) { }

        /// <summary>
        /// Function to execute when leaving the DetectionZone
        /// </summary>
        /// <param name="iDetectable">The IDetectable that just left</param>
        protected virtual void OnLeave(T iDetectable) { }

        /// <summary>
        /// The list of Collisions in the DetectionZone
        /// </summary>
        protected List<U> currCollisions = new List<U>();


        //---------- Using both OnTrigger and OnCollision

        private void OnCollisionEnter(Collision collision)
            => OnTriggerEnter(collision.collider);

        /// <summary>
        /// Checks if the GameObject needs to be/can be detected
        /// </summary>
        /// <param name="other">The collider that just entred the DetectionZone</param>
        private void OnTriggerEnter(Collider other)
        {
            if (!TryGetIDetectable(other.gameObject, out T iDetectable) || TryFindInCurrCollisions(iDetectable, out int i))
                return;

            if (iDetectable is IDetectableDisable)
            {
                ((IDetectableDisable)iDetectable).OnDisabled -= RemoveToCurrCollisions;
                ((IDetectableDisable)iDetectable).OnDisabled += RemoveToCurrCollisions;
            }

            currCollisions.Add(CreateIDetectableElement(iDetectable));
            OnEnter(iDetectable);
        }

        private void OnCollisionExit(Collision collision)
        => OnTriggerExit(collision.collider);

        /// <summary>
        /// Removes the collider from the currColisions
        /// </summary>
        /// <param name="other">The collider that just exited the DetectionZone</param>
        private void OnTriggerExit(Collider other)
        {
            if (TryGetIDetectable(other.gameObject, out T iDetectable) && TryFindInCurrCollisions(iDetectable, out int indexOfFound))
                RemoveToCurrCollisions(indexOfFound, iDetectable);
        }

        /// <summary>
        /// Removes the IDetectable from the current list 
        /// </summary>
        /// <param name="iDetectable">The IDetectable to remove</param>
        void RemoveToCurrCollisions(IDetectable iDetectable)
        {
            if (TryFindInCurrCollisions(iDetectable, out int index))
                RemoveToCurrCollisions(index, (T)iDetectable);
        }

        /// <summary>
        /// Removes the IDetectable at a certain position in the currColisions
        /// </summary>
        /// <param name="index">The position of the IDetectable in the currColisions</param>
        /// <param name="curr">The IDetectable to remove</param>
        void RemoveToCurrCollisions(int index, T curr)
        {
            currCollisions.RemoveAt(index);

            if (curr is IDetectableDisable)
                ((IDetectableDisable)curr).OnDisabled -= RemoveToCurrCollisions;

            OnLeave(curr);
        }

        /// <summary>
        /// Finds the index of the IDetectable inside the list
        /// </summary>
        /// <param name="iDetectable">The IDetectable component of the GameObject</param>
        /// <param name="indexOfFound">The index of the IDetectable inside currColisions</param>
        /// <returns>True if other is in currColisions, else False</returns>
        bool TryFindInCurrCollisions(IDetectable iDetectable, out int indexOfFound)
        {
            for (int i = 0; i < currCollisions.Count; i++)
            {
                if (currCollisions[i].Detectable.Equals(iDetectable))
                {
                    indexOfFound = i;
                    return true;
                }
            }
            indexOfFound = -1;
            return false;
        }

        /// <summary>
        /// You need to write base.OnDisable when overiding
        /// </summary>
        protected virtual void OnDisable()
        {
            foreach (IDetectableElement element in currCollisions)
            {
                if (element.Detectable is IDetectableDisable)
                    ((IDetectableDisable)element.Detectable).OnDisabled -= RemoveToCurrCollisions;

                OnLeave((T)element.Detectable);
            }

            currCollisions.Clear();
        }
    }
}