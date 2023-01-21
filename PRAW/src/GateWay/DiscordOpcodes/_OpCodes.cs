using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAW
{
    //my n uts hurt 
    internal enum GatewayOpcodes
    {
        Dispatch = 0,            // RECIEVE (EVENT)
        Heartbeat = 1,           // SEND/RECIEVE
        Identify = 2,            // SEND
        PresenceUpdate = 3,      // SEND
        VoiceStateUpdate = 4,    // SEND
        Resume = 6,              // SEND
        Reconnect = 7,           // RECIEVE
        RequestGuildMembers = 8, // SEND
        InvalidSession = 9,      // RECIEVE
        Hello = 10,              // RECIEVE
        HeartbeatACK = 11,       // RECIEVE
        GuildSync = 12,          // SEND
        GuildSubscription = 14,  // SEND
        LobbyConnection = 15,
        LobbyDisconnect = 16,
        LobbyVoiceStatesUpdate = 17,
        StreamCreate = 18,
        StreamDelete = 19,
        StreamWatch = 20,
        StreamPing = 21,
        StreamSetPaused = 22,
    }
}
