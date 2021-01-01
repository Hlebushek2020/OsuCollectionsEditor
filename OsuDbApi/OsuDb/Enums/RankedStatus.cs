using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuDbApi.OsuDb.Enums
{
    [Flags]
    public enum RankedStatus
    {
        Unknown = 0,
        Unsubmitted = 1,
        PendingWipGraveyard = 2, 
        Unused = 3,
        Ranked = 4, 
        Approved = 5,
        Qualified = 6,
        Loved = 7
    }
}
