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
        Standart = 1,
        Taiko = 2,
        CTB = 4,
        Mania = 8
    }
}
