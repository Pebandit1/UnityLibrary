
using Tests.Builders.Recorder;

namespace Tests.Builders
{
    public static class A
    {
        public static RecorderBuilder<T> Recorder<T>() => new RecorderBuilder<T>();
    }
}
