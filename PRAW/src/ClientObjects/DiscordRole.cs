using Newtonsoft.Json;

namespace PRAW
{
    public class DiscordRole
    {
        ///<summary>
        ///role id
        ///</summary>
        [JsonProperty("id")]
        public object ID { get; internal set; }

        ///<summary>
        ///role name
        ///</summary>
        [JsonProperty("name")]
        public string Name { get; internal set; }

        ///<summary>
        ///integer representation of hexadecimal color code
        ///</summary>
        [JsonProperty("color")]
        public int Color { get; internal set; }

        ///<summary>
        ///if this role is pinned in the user listing
        ///</summary>
        [JsonProperty("hoist")]
        public bool Hoist { get; internal set; }

        ///<summary>
        ///position of this role
        ///</summary>
        [JsonProperty("position")]
        public int Position { get; internal set; }

        ///<summary>
        ///permission bit set
        ///</summary>
        [JsonProperty("permissions")]
        public string Permissions { get; internal set; }

        ///<summary>
        ///whether this role is managed by an integration
        ///</summary>
        [JsonProperty("managed")]
        public bool Managed { get; internal set; }

        ///<summary>
        ///whether this role is mentionable
        ///</summary>
        [JsonProperty("mentionable")]
        public bool Mentionable { get; internal set; }

        ///<summary>
        ///the tags this role has
        ///</summary>
        [JsonProperty("tags")]
        public Tag Tags { get; internal set; }

        public class Tag
        {
            ///<summary>
            ///the id of the bot this role belongs to
            ///</summary>
            [JsonProperty("bot_id")]
            public ulong BotID { get; internal set; }

            ///<summary>
            ///the id of the integration this role belongs to
            ///</summary>
            [JsonProperty("integration_id")]
            public ulong IntegrationID { get; internal set; }
        }
    }
}
