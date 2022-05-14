using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Currency.BusinessAPI.Serializer
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
