using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinarySerializer;
using MiscUtil.Conversion;
using MiscUtil.IO;

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

            var stream = new MemoryStream();
            var w = new EndianBinaryWriter(new BigEndianBitConverter(), stream);
            w.Write7BitEncodedInt(160);
            //w.Write7BitEncodedInt(32);

            var t = stream.ToArray();


            stream = new MemoryStream(t);
            var r = new EndianBinaryReader(new BigEndianBitConverter(), stream);
            var val = r.Read7BitEncodedInt();


            string b64 = "AQEBAAEKNGQ3MzA1NjJmZAEAAaAAAYV/x5TMiTsrrJuSigbtbPc8SWD5siJnn74AzDr/bsq/LbdijJjLIHiSfdvRSrtzMY8hGW1qSmqldwI8tVAMtp7f6BrkgyI7WolMchkw6RguTlq7OKw2MNLT+z5o3IgAxENtOdCQ6BQog+Nt+VpLrA2kmbQ2mnWJKdD7Y6ebdu7dY7AI16a9mEfMqJEsSys6h2lcEDrMzdsUFU+vBhSYdgk=";
            data = Convert.FromBase64String(b64);
            var obj = data.BinaryDeserializeAsync<List<Shared.NetFrame>>().Result;

        }
    }
}
