using System.Collections.Generic;
using System;
using UnityEngine;
using Utilities;

namespace DataRecording
{
    /// <summary>
    /// Class that records a certain number of doubles over time and give the current average
    /// </summary>
    [Serializable]
    public class DataRecorder<T> : ISerializationCallbackReceiver
    {
        const int MIN_LENGTH = 1;
        const float MIN_TIME = 0;

        #region Fields

        /// <summary>
        /// The desired length of dataQueue
        /// </summary>
        [SerializeField] private int desiredLength;

        /// <summary>
        /// The desired length of dataQueue
        /// </summary>
        public int DesiredLength => desiredLength;

        /// <summary>
        /// A queue that keeps track of the elements
        /// </summary>
        private Queue<T> dataQueue;

        /// <summary>
        /// A copy of the data that's currently stored inside the recorder
        /// </summary>
        public IEnumerable<T> Data => dataQueue.CloneAsEnumerable();

        /// <summary>
        /// The desired time intervale between each double recorded 
        /// </summary>
        [SerializeField]private float timeBetweenRecord = 0;

        /// <summary>
        /// The desired time intervale between each double recorded 
        /// </summary>
        public float TimeBetweenRecord => timeBetweenRecord;

        /// <summary>
        /// The time since the last double record 
        /// </summary>
        private float timeSinceLastRecord;

        #endregion

        /// <summary>
        /// Constructor if the DataRecorder needs to be created at runTime
        /// </summary>
        /// <param name="desiredLength"></param>
        /// <param name="timeBetweenRecord"></param>
        public DataRecorder(int desiredLength, float timeBetweenRecord)
        {
            this.desiredLength = desiredLength;
            dataQueue = new Queue<T>();
            this.timeBetweenRecord = timeBetweenRecord;
            timeSinceLastRecord = float.MaxValue;

            OnBeforeSerialize();
        }

        #region RecordData

        /// <summary>
        /// Tries to add the value to the Queue
        /// </summary>
        /// <param name="value">The value we're trying to add</param>
        /// <param name="deltaTime">The time since the last record</param>
        /// <returns>True if the double was added, else False</returns>
        public bool TryRecordData(T value, float deltaTime)
        {
            timeSinceLastRecord += deltaTime;
            if (CanRecordData())
            {
                RecordData(value);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks whether or not the Data can be recorded
        /// </summary>
        /// <returns>True if it can be recorded, else False</returns>
        private bool CanRecordData() => timeSinceLastRecord >= TimeBetweenRecord;

        /// <summary>
        /// Records the data
        /// </summary>
        /// <param name="value">The data to record</param>
        private void RecordData(T value)
        {
            dataQueue.Enqueue(value);
            timeSinceLastRecord = 0;

            RestrictDataQueue();
        }

        /// <summary>
        /// Removes the overflow of data in the Queue
        /// </summary>
        private void RestrictDataQueue()
        {
            T overflow;
            while (dataQueue.Count > desiredLength)
                dataQueue.TryDequeue(out overflow);
        }

        #endregion

        #region ISerializationCallbackReceiver

        /// <summary>
        /// Function used just like the OnValidate of a Monobehaviour
        /// </summary>
        public void OnBeforeSerialize()
        {
            if (desiredLength < MIN_LENGTH)
                desiredLength = MIN_LENGTH;

            if (timeBetweenRecord <= MIN_TIME)
                timeBetweenRecord = 0.1f;
        }

        public void OnAfterDeserialize() //Idk what it's suppose to do but it comes from ISerializationCallbackReceiver
        {
        }

        #endregion
    }
}