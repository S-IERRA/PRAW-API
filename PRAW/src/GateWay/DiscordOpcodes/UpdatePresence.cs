using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAW.OpCode
{
    internal class UpdatePresence
    {
        internal int since { get; set; }
        internal DiscordActivity[] activities { get; set; }
        internal StatusType status { get; set; }
        internal bool afk { get; set; }

        internal enum StatusType
        {
            online,
            dnd,
            idle,
            invisible,
            offline
        }
    }
}
