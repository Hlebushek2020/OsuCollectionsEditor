using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuDbApi.Interface
{
    interface IDbReader<T>
    {
        bool Next();
        T GetValue();
    }
}
