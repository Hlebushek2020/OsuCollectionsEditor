using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuDbApi.OsuDb.Enums
{
    public enum UserPermissions : byte
    {
        None = 0, 
        Normal = 1, 
        Moderator = 2, 
        Supporter = 4, 
        Friend = 8, 
        peppy = 16, 
        WorldCupStaff = 32
    }
}
