using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySerializer
{
    public interface IBinarySerializable
    {
        Task SerializeAsync(BinaryWriter writer);
        Task DeserializeAsync(BinaryReader reader);
    }
}
