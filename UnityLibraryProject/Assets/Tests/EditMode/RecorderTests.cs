using NUnit.Framework;
using Tests.Builders;
using DataRecording;
using System.Linq;
using static Utilities.NumericEqualities;

namespace Tests.EditMode
{
    /// <summary>
    /// Tests for the DataRecoder Class
    /// </summary>
    public class RecorderTests
    {
        /// <summary>
        /// Tests to see if the value return by Average is the value expected
        /// </summary>
        /// <param name="length">Number of double to record</param>
        /// <param name="values">The doubles to recod, length can be bigger than length for some tests</param>
        /// <param name="target">The value of the average</param>
        [Test]
        [TestCase(1, new double[] { 1 }, 1)]
        [TestCase(2, new double[] { 1, 1 }, 1)]
        [TestCase(5, new double[] { 1 }, 1)]
        [TestCase(1, new double[] { 1, 1 }, 1)]
        [TestCase(3, new double[] { 1, 2, 3 }, 2)]
        public void TestAverage(int length, double[] values, double target)
        {
            DataRecorder<double> recoder = A.Recorder<double>().WithTimeBetweenRecord(0).WithLength(length);

            foreach (double value in values)
                recoder.TryRecordData(value, 1);

            double[] data = recoder.Data.ToArray();

            double sum = 0;

            foreach (double value in data)
                sum += value;

            Assert.IsTrue(AreCloseEnough(sum / data.Length, target));
        }

        /// <summary>
        /// Test if the recorder let's you record data depending on the "variation of time"
        /// </summary>
        /// <param name="values">The values to pass at each possible time</param>
        /// <param name="target">The value we should expect at the end of the test</param>
        /// <param name="delatsTime">All the "variation of time"</param>
        /// <param name="timeBetweenRecord">The minimum "variation of time" between valuyes being recorded</param>
        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, 1, new float[] { .5f }, .4f)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, 2, new float[] { .5f, .5f }, .4f)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, 3, new float[] { .5f, .5f, .5f }, .4f)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, 2, new float[] { .5f, .1f, .35f }, .4f)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, 3, new float[] { .5f, 10f, .56f, .45f }, .5f)]
        public void TestTimmingBetweenRecord(int[] values, int target, float[] delatsTime, float timeBetweenRecord)
        {
            DataRecorder<int> recoder = A.Recorder<int>().WithTimeBetweenRecord(timeBetweenRecord).WithLength(1);

            int indexOfLastValue = 0;
            foreach (float deltaTime in delatsTime)
            {
                if (recoder.TryRecordData(values[indexOfLastValue], deltaTime) && indexOfLastValue < values.Length - 1)
                    ++indexOfLastValue;
            }

            Assert.AreEqual(target, recoder.Data.First());
        }
    }
}