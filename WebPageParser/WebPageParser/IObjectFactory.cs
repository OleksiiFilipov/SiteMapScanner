using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPageParser
{
    public interface IObjectFactory
    {
        T CreateObject<T>();
    }
}
