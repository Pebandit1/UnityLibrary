using System;
using System.Collections.Generic;

namespace Tests.TestBuilders
{
    [Serializable]
    public class ComplexeClass<T>
    {
        List<T> myList;
        public List<T> MyList{get {return myList;}}
        int iData;
        public int IData => iData;
        float fData;
        public float FData => fData;


        Dictionary<T, string> myDic;
        public Dictionary<T,string> MyDic { get { return myDic; }}

        public ComplexeClass(List<T> myList, int iData, float fData, Dictionary<T, string> myDic)
        {
            this.myList = myList;
            this.iData = iData;
            this.fData = fData;
            this.myDic = myDic;
        }
    }
}