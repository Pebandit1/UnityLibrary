using System.Collections.Generic;

namespace Tests.TestBuilders
{
    public class ComplexeClassBuilder<T>
    {
        List<T> myList;
        private int iData;
        private float fData;
        Dictionary<T, string> myDic;
        public ComplexeClass<T> Build() => new(myList, iData, fData, myDic);

        public ComplexeClassBuilder<T> WithList(List<T> list)
        {
            myList = list;
            return this;
        }

        public ComplexeClassBuilder<T> WitIData(int IData)
        {
            iData = IData;
            return this;
        }

        public ComplexeClassBuilder<T> WithFData(float FData)
        {
            fData = FData;
            return this;
        }

        public ComplexeClassBuilder<T> WithDic(Dictionary<T, string> dic)
        {
            myDic = dic;
            return this;
        }

        public static implicit operator ComplexeClass<T>(ComplexeClassBuilder<T> builder) => builder.Build();
    }
}
