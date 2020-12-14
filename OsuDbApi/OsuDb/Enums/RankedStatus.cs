using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuDbApi.OsuDb.Enums
{
    public enum RankedStatus : byte
    {
        Unknown,
        Unsubmitted,
        PendingWipGraveyard, 
        Unused,
        Ranked, 
        Approved,
        Qualified,
        Loved
    }
}
