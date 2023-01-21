using System;
using Newtonsoft.Json;

namespace PRAW
{
    public class Voice
    {
        ///<summary>
        ///the guild id this voice state is for
        ///</summary>
        [JsonProperty("guild_id")]
        public ulong Guildid { get; internal set; }

        ///<summary>
        ///the channel id this user is connected to
        ///</summary>
        [JsonProperty("channel_id")]
        public ulong? Channelid { get; internal set; }

        ///<summary>
        ///the user id this voice state is for
        ///</summary>
        [JsonProperty("user_id")]
        public ulong Userid { get; internal set; }

        ///<summary>
        ///the guild member this voice state is for
        ///</summary>
        [JsonProperty("member")]
        public GuildMember Member { get; internal set; }

        ///<summary>
        ///the session id for this voice state
        ///</summary>
        [JsonProperty("session_id")]
        public string Sessionid { get; internal set; }

        ///<summary>
        ///whether this user is deafened by the server
        ///</summary>
        [JsonProperty("deaf")]
        public bool IsDeaf { get; internal set; }

        ///<summary>
        ///whether this user is muted by the server
        ///</summary>
        [JsonProperty("mute")]
        public bool IsMute { get; internal set; }

        ///<summary>
        ///whether this user is locally deafened
        ///</summary>
        [JsonProperty("self_deaf")]
        public bool SelfDeaf { get; internal set; }

        ///<summary>
        ///whether this user is locally muted
        ///</summary>
        [JsonProperty("self_mute")]
        public bool SelfMute { get; internal set; }

        ///<summary>
        ///whether this user is streaming using "Go Live"
        ///</summary>
        [JsonProperty("self_stream")]
        public bool SelfStream { get; internal set; }

        ///<summary>
        ///whether this user's camera is enabled
        ///</summary>
        [JsonProperty("self_video")]
        public bool Selfvideo { get; internal set; }

        ///<summary>
        ///whether this user is muted by the current user
        ///</summary>
        [JsonProperty("suppress")]
        public bool Suppress { get; internal set; }

        ///<summary>
        ///the time at which the user requested to speak
        ///</summary>
        [JsonProperty("request_to_speak_timestamp")]
        public DateTime? Requesttospeaktimestamp { get; internal set; }
    }

    public class VoiceRegion
    {
        ///<summary>
        ///unique ID for the region
        ///</summary>
        [JsonProperty("id")]
        public string Id { get; internal set; }

        ///<summary>
        ///name of the region
        ///</summary>
        [JsonProperty("name")]
        public string Name { get; internal set; }

        ///<summary>
        ///true if this is a vip-only server
        ///</summary>
        [JsonProperty("vip")]
        public bool IsVip { get; internal set; }

        ///<summary>
        ///true for a single server that is closest to the current user's client
        ///</summary>
        [JsonProperty("optimal")]
        public bool IsOptimal { get; internal set; }

        ///<summary>
        ///whether this is a deprecated voice region (avoid switching to these)
        ///</summary>
        [JsonProperty("deprecated")]
        public bool IssDeprecated { get; internal set; }

        ///<summary>
        ///whether this is a custom voice region (used for events/etc)
        ///</summary>
        [JsonProperty("custom")]
        public bool IsCustom { get; internal set; }

    }
}