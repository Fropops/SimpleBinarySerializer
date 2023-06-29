using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinarySerializer;

namespace TestSerializer
{
    internal enum TestEnum : byte
    {
        a1 = 0,a2, a3, a4, a5, a6
    }

    internal class TestClass1
    {
        [FieldOrder(1)]
        public string TestString { get; set; } = "";

        [FieldOrder(2)]
        public int TestInt { get; set; } = 0;

        [FieldOrder(3)]
        public char TestChar { get; set; } = '\0';

        public char TestIgnored { get; set; } = '\r';

        [FieldOrder(4)]
        public bool TestBool { get; set; } = false;

        [FieldOrder(5)]
        public List<TestClass2> List { get; set; } = new List<TestClass2>();

        [FieldOrder(6)]
        public short? TestShortNullable { get; set; } = null;

        [FieldOrder(7)]
        public TestEnum TestEnum { get; set; }
    }

    internal class TestClass2
    {
        [FieldOrder(1)]
        public string Name { get; set; } = "";
    }

    public class AgentMetadata
    {
        [FieldOrder(0)]
        public string Id { get; set; }
        //[FieldOrder(1)]
        public string Hostname { get; set; }
        //[FieldOrder(2)]
        public string UserName { get; set; }
        //[FieldOrder(3)]
        public string ProcessName { get; set; }
        //[FieldOrder(4)]
        public int ProcessId { get; set; }
        //[FieldOrder(5)]
        public string Integrity { get; set; }
        //[FieldOrder(6)]
        public string Architecture { get; set; }
        //[FieldOrder(7)]
        public string EndPoint { get; set; }
        //[FieldOrder(8)]
        public string Version { get; set; }

        public int SleepInterval { get; set; }
        public int SleepJitter { get; set; }
    }
}
