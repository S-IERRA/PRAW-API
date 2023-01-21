using Newtonsoft.Json;
using System.ComponentModel;

namespace PRAW
{
    public class DiscordEmoji
    {
        ///<summary>
        ///emoji name
        ///</summary>
        [JsonProperty("name")]
        public string? Name { get; internal set; }

        ///<summary>
        ///roles allowed to use this emoji
        ///</summary>
        [JsonProperty("roles")]
        public DiscordRole[] Roles { get; internal set; }

        ///<summary>
        ///user that created this emoji
        ///</summary>
        [JsonProperty("user")]
        public User User { get; internal set; }

        ///<summary>
        ///whether this emoji must be wrapped in colons
        ///</summary>
        [JsonProperty("require_colons")]
        public bool RequireColons { get; internal set; }

        ///<summary>
        ///whether this emoji is managed
        ///</summary>
        [JsonProperty("managed")]
        public bool Managed { get; internal set; }

        ///<summary>
        ///whether this emoji is animated
        ///</summary>
        [JsonProperty("animated")]
        public bool Animated { get; internal set; }

        ///<summary>
        ///whether this emoji can be used
        ///</summary>
        [JsonProperty("available")]
        public bool Available { get; internal set; }
    }
}
