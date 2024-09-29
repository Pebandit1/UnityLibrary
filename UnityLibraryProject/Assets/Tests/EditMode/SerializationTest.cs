using NUnit.Framework;
using Serialization;
using System.Collections;
using System.Collections.Generic;
using Tests.Builders;
using Tests.TestBuilders;

namespace Tests.EditMode
{
    public class SerializationTest
    {
        private class SerializationOfComplexeClassTest : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return Test0();
                yield return Test1();
            }

            static ComplexeClass<int> Test0()
            {
                return A.ComplexeClass<int>().WithList(new List<int>()).WitIData(5).WithFData(.0934343434f).WithDic(new Dictionary<int, string>());
            }

            static ComplexeClass<int> Test1()
            {
                List<int> list = new List<int>();
                Dictionary<int, string> dic = new Dictionary<int, string>();

                for (int i = 0; i < 4; ++i)
                    list.Add(i);
                

                for (int i = 0; i < 8; ++i)
                    dic.Add(i, i.ToString());
                

                return A.ComplexeClass<int>().WithList(list).WitIData(-3).WithFData(.04f).WithDic(dic);
            }
        }

        [Test]
        [TestCaseSource(typeof(SerializationOfComplexeClassTest))]
        public void TestSerializationOfAComplexeClass(ComplexeClass<int> data)
        {
            BinarySerializer serializer = new BinarySerializer();
            string serialized = serializer.Serialize(data);
            object deserialized =  serializer.Deserialize(serialized, typeof(ComplexeClass<int>));

            ComplexeClass<int> dataDeserialized = deserialized as ComplexeClass<int>;
            Assert.AreEqual(data.IData, dataDeserialized.IData);
            Assert.AreEqual(data.FData, dataDeserialized.FData);
            
            int nbElementsData = data.MyList.Count;
            int nbElementsDataDeserialized = dataDeserialized.MyList.Count;

            Assert.AreEqual(nbElementsData, nbElementsDataDeserialized);


            for(int i = 0; i < nbElementsData; ++i)
                Assert.AreEqual(data.MyList[i], dataDeserialized.MyList[i]);

            int dicSizeData = data.MyDic.Count;
            int dicSizeDataDeserialized = dataDeserialized.MyDic.Count;

            Assert.AreEqual(dicSizeData, dicSizeDataDeserialized);

            for(int i = 0; i < dicSizeData; ++i)
                Assert.AreEqual(data.MyDic[i], dataDeserialized.MyDic[i]); 
        }
    }
}
