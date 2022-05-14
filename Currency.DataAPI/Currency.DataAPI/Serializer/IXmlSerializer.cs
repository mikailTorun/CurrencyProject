using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Currency.DataAPI.Serializer
{
    interface IXmlSerializer
    {
        public interface IXmlSerializer
        {
            T Deserializer<T>(string value);
            string Serializer(object value);
        }
    }
}
