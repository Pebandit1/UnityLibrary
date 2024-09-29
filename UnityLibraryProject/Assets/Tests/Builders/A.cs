using Tests.Builders.Recorder;
using Tests.TestBuilders;

namespace Tests.Builders
{
    public static class A
    {
        public static RecorderBuilder<T> Recorder<T>() => new RecorderBuilder<T>();

        public static ComplexeClassBuilder<T> ComplexeClass<T>() => new ComplexeClassBuilder<T>();
    }
}
