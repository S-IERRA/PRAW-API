using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAW
{
    internal enum ClientState
    {
        Discovering,
        Connecting,
        Reconnecting,
        Resuming,
        Connected,
        Ready,
        None,
        Disconnecting,
        Disconnected,
        ConnectionDead
    }
}
