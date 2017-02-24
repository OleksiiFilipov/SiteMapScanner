using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPageParser
{
    class ObjectFactory : IObjectFactory
    {
        public T CreateObject<T>() 
        {
            return StructureMapContainer.Container.TryGetInstance<T>();
        }
    }
}
