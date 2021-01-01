using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuDbApi.Enums
{
    public enum GameplayMode : byte
    {
        Standard = 0x00,
        Taiko = 0x01,
        CTB = 0x02,
        Mania = 0x03
    }
}
