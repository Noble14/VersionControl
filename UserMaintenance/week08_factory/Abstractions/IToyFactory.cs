using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week08_factory.Abstractions
{
    interface IToyFactory
    {
        Toy CreateNew();
    }
}
