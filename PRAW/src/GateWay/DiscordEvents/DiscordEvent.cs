using Newtonsoft.Json;

namespace PRAW
{
    internal class DiscordEvent
    {
        [JsonProperty("op")]
        public GatewayOpcodes OpCode { get; set; }

        [JsonProperty("d")]
        public object? Data { get; set; }

        [JsonProperty("s")]
        public uint? Sequence { get; set; }

        [JsonProperty("t")]
        public string? EventType { get; set; }
    }
}
