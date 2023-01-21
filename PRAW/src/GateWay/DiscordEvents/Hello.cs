using Newtonsoft.Json;

namespace PRAW
{
    internal struct Hello
    {
        [JsonProperty("heartbeat_interval")]
        internal int HeartbeatInterval { get; set; }
    }
}
