using Newtonsoft.Json;
namespace PRAW
{
    public class PresenceUpdate
    {
        ///<summary>
        ///the user presence is being updated for
        ///</summary>
        [JsonProperty("user")]
        public User User { get; internal set; }

        ///<summary>
        ///id of the guild
        ///</summary>
        [JsonProperty("guild_id")]
        public ulong GuildID { get; internal set; }

        ///<summary>
        ///either "idle"
        ///</summary>
        [JsonProperty("status")]
        public string Status { get; internal set; }

        ///<summary>
        ///user's current activities
        ///</summary>
        [JsonProperty("activities")]
        public DiscordActivity[] Activities { get; internal set; }

        ///<summary>
        ///user's platform-dependent status
        ///</summary>
        [JsonProperty("client_status")]
        public ClientStatus Clientstatus { get; internal set; }

        public class ClientStatus
        {
            ///<summary>
            ///the user's status set for an active desktop (Windows
            ///</summary>
            [JsonProperty("desktop")]
            public string Desktop { get; internal set; }

            ///<summary>
            ///the user's status set for an active mobile (iOS
            ///</summary>
            [JsonProperty("mobile")]
            public string Mobile { get; internal set; }

            ///<summary>
            ///the user's status set for an active web (browser
            ///</summary>
            [JsonProperty("web")]
            public string Web { get; internal set; }
        }
    }
}
