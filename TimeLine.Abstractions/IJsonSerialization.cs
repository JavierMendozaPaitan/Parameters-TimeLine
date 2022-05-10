using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLine.Abstractions
{
    public interface IJsonSerialization
    {
        string Serialize<T>(T toSerialize);
    }
}
