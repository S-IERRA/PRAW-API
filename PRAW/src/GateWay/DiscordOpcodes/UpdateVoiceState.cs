using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAW.OpCode
{
    internal class UpdateVoiceState
    {
        internal ulong guild_id { get; set; }
        internal ulong? channel_id { get; set; }
        internal bool self_mute { get; set; }
        internal bool self_deaf { get; set;}
    }
}
