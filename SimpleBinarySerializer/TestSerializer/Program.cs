using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinarySerializer;

namespace TestSerializer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var item = new TestClass1();
            item.TestString = null;
            item.TestBool = true;
            item.TestChar = 'o';
            item.TestIgnored = 't';
            item.TestInt = 123456;
            item.TestEnum = TestEnum.a6;
            item.TestShortNullable = null;
            item.List.Add(new TestClass2() { Name = "Test1" });
            item.List.Add(new TestClass2() { Name = "Test2" });
            item.List.Add(new TestClass2() { Name = null });
            //var ser = new Serializer();
            //var data = ser.SerializeAsync(item).Result;
            var data = item.BinarySerializeAsync().Result;

            var itemREs = data.BinaryDeserializeAsync<TestClass1>().Result;


            //var list = new List<TestClass1>();
            //var ser = list.BinarySerializeAsync().Result;


            //var ser = new AgentMetadata() { Id = "aaaaaaaaaa" }.BinarySerializeAsync().Result;
            //var obj = ser.BinaryDeserializeAsync<AgentMetadata>().Result;
        }
    }
}
