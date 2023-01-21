using System;

namespace PRAW
{
    internal struct HeartBeatACK
    {
        internal static uint LastHeartbeatAck { get; set; }
        internal static bool HeartBeatAck { get; set; }
        internal static int? ExpeditedHeartbeatTimeout { get; set; } = null;
    }
}
