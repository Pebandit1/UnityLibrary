using DataRecording;

namespace Tests.Builders.Recorder
{
    public class RecorderBuilder<T>
    {
        private int desiredLength;
        private float timeBetweenRecord;
        public DataRecorder<T> Build() => new(desiredLength, timeBetweenRecord);

        public RecorderBuilder<T> WithLength(int length)
        {
            desiredLength = length;
            return this;
        }

        public RecorderBuilder<T> WithTimeBetweenRecord(float newTimeBetweenRecord)
        {
            timeBetweenRecord = newTimeBetweenRecord;
            return this;
        }

        public static implicit operator DataRecorder<T>(RecorderBuilder<T> builder) => builder.Build();

    }
}
