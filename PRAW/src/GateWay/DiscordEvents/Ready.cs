using Newtonsoft.Json;

namespace PRAW
{
    public struct Ready
    {
        [JsonProperty("v")]
        public char GatewayVersion { get; internal set; }

        [JsonProperty("user")]
        public User? User { get; internal set; }

        [JsonProperty("guilds")]
        public DiscordGuild[] Guilds { get; internal set; }

        [JsonProperty("session_id")]
        public static string? SessionID { get; internal set; }

        [JsonProperty("shard")]
        public static int[] Shard { get;internal set; }

        [JsonProperty("application")]
        public static DiscordApplication? UserID { get; internal set; }
    }
}
