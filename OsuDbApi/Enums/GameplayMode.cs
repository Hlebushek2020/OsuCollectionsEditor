using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuDbApi.Enums
{
    [Flags]
    public enum GameplayMode
    {
        Standart = 0,
        Taiko = 1,
        CTB = 2,
        Mania = 3
    }
}
