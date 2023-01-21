using System;
using Newtonsoft.Json;

namespace PRAW
{
    public class GuildMember
    {
        ///<summary>
        ///the user this guild member represents
        ///</summary>
        [JsonProperty("user")]
        public User User { get; internal set; }

        ///<summary>
        ///this users guild nickname
        ///</summary>
        [JsonProperty("nick")]
        public string? Nick { get; internal set; }

        ///<summary>
        ///array of role object ids
        ///</summary>
        [JsonProperty("roles")]
        public ulong[] Roles { get; internal set; }

        ///<summary>
        ///when the user joined the guild
        ///</summary>
        [JsonProperty("joined_at")]
        public DateTime JoinedDate { get; internal set; }

        ///<summary>
        ///when the user started boosting the guild
        ///</summary>
        [JsonProperty("premium_since")]
        public DateTime? Premiumsince { get; internal set; }

        ///<summary>
        ///whether the user is deafened in voice channels
        ///</summary>
        [JsonProperty("deaf")]
        public bool IsDeaf { get; internal set; }

        ///<summary>
        ///whether the user is muted in voice channels
        ///</summary>
        [JsonProperty("mute")]
        public bool IsMute { get; internal set; }

        ///<summary>
        ///whether the user has not yet passed the guild's Membership Screening requirements
        ///</summary>
        [JsonProperty("pending")]
        public bool IsPending { get; internal set; }

        ///<summary>
        ///total permissions of the member in the channel
        ///</summary>
        [JsonProperty("permissions")]
        public string Permissions { get; internal set; }
    }

    public class DiscordGuild
    {
        ///<summary>
        ///guild id
        ///</summary>
        [JsonProperty("id")]
        public ulong Id { get; internal set; }

        ///<summary>
        ///guild name (2-100 characters)
        ///</summary>
        [JsonProperty("name")]
        public string Name { get; internal set; }

        ///<summary>
        ///icon hash
        ///</summary>
        [JsonProperty("icon")]
        public string? Icon { get; internal set; }

        ///<summary>
        ///icon hash
        ///</summary>
        [JsonProperty("icon_hash")]
        public string? IconHash { get; internal set; }

        ///<summary>
        ///splash hash
        ///</summary>
        [JsonProperty("splash")]
        public string? Splash { get; internal set; }

        ///<summary>
        ///discovery splash hash; only present for guilds with the "DISCOVERABLE" feature
        ///</summary>
        [JsonProperty("discovery_splash")]
        public string? DiscoverySplash { get; internal set; }

        ///<summary>
        ///true if the user is the owner of the guild
        ///</summary>
        [JsonProperty("owner")]
        public bool Owner { get; internal set; }

        ///<summary>
        ///id of owner
        ///</summary>
        [JsonProperty("owner_id")]
        public ulong OwnerID { get; internal set; }

        ///<summary>
        ///total permissions for the user in the guild (excludes overwrites)
        ///</summary>
        [JsonProperty("permissions")]
        public string Permissions { get; internal set; }

        ///<summary>
        ///voice region id for the guild
        ///</summary>
        [JsonProperty("region")]
        public string Region { get; internal set; }

        ///<summary>
        ///id of afk channel
        ///</summary>
        [JsonProperty("afk_channel_id")]
        public ulong? AfkChannelID { get; internal set; }

        ///<summary>
        ///afk timeout in seconds
        ///</summary>
        [JsonProperty("afk_timeout")]
        public int AfkTimeout { get; internal set; }

        ///<summary>
        ///true if the server widget is enabled
        ///</summary>
        [JsonProperty("widget_enabled")]
        public bool WidgetEnabled { get; internal set; }

        ///<summary>
        ///the channel id that the widget will generate an invite to
        ///</summary>
        [JsonProperty("widget_channel_id")]
        public ulong? WidgetChannelID { get; internal set; }

        ///<summary>
        ///verification level required for the guild
        ///</summary>
        [JsonProperty("verification_level")]
        public int VerificationLevel { get; internal set; }

        ///<summary>
        ///default message notifications level
        ///</summary>
        [JsonProperty("default_message_notifications")]
        public int DefaultMessageNotifications { get; internal set; }

        ///<summary>
        ///explicit content filter level
        ///</summary>
        [JsonProperty("explicit_content_filter")]
        public int ExplicitContentFilter { get; internal set; }

        ///<summary>
        ///roles in the guild
        ///</summary>
        [JsonProperty("roles")]
        public DiscordRole[] Roles { get; internal set; }

        ///<summary>
        ///custom guild emojis
        ///</summary>
        [JsonProperty("emojis")]
        public DiscordEmoji[] Emojis { get; internal set; }

        ///<summary>
        ///enabled guild features
        ///</summary>
        [JsonProperty("features")]
        public string[] Features { get; internal set; }

        ///<summary>
        ///required MFA level for the guild
        ///</summary>
        [JsonProperty("mfa_level")]
        public int MfaLevel { get; internal set; }

        ///<summary>
        ///application id of the guild creator if it is bot-created
        ///</summary>
        [JsonProperty("application_id")]
        public ulong? ApplicationID { get; internal set; }

        ///<summary>
        ///the id of the channel where guild notices such as welcome messages and boost events are posted
        ///</summary>
        [JsonProperty("system_channel_id")]
        public ulong? SystemChannelID { get; internal set; }

        ///<summary>
        ///system channel flags
        ///</summary>
        [JsonProperty("system_channel_flags")]
        public int SystemChannelFlags { get; internal set; }

        ///<summary>
        ///the id of the channel where Community guilds can display rules and/or guidelines
        ///</summary>
        [JsonProperty("rules_channel_id")]
        public ulong? RulesChannelID { get; internal set; }

        ///<summary>
        ///when this guild was joined at
        ///</summary>
        [JsonProperty("joined_at")]
        public DateTimeOffset JoinedDate { get; internal set; }

        ///<summary>
        ///true if this is considered a large guild
        ///</summary>
        [JsonProperty("large")]
        public bool Large { get; internal set; }

        ///<summary>
        ///true if this guild is unavailable due to an outage
        ///</summary>
        [JsonProperty("unavailable")]
        public bool Unavailable { get; internal set; }

        ///<summary>
        ///total number of members in this guild
        ///</summary>
        [JsonProperty("member_count")]
        public int MemberCount { get; internal set; }

        ///<summary>
        ///states of members currently in voice channels; lacks the guild_id key
        ///</summary>
        /*[JsonProperty("voice_states")]
        public array of partial voice state objects Voicestates { get; internal set; }*/

        ///<summary>
        ///users in the guild
        ///</summary>
        [JsonProperty("members")]
        public GuildMember[] Members { get; internal set; }

        ///<summary>
        ///channels in the guild
        ///</summary>
        [JsonProperty("channels")]
        public DiscordChannel[] Channels { get; internal set; }

        ///<summary>
        ///all active threads in the guild that current user has permission to view
        ///</summary>
        [JsonProperty("threads")]
        public DiscordChannel[] Threads { get; internal set; }

        ///<summary>
        ///presences of the members in the guild
        ///</summary>
        [JsonProperty("presences")]
        public PresenceUpdate[] Presences { get; internal set; }

        ///<summary>
        ///the maximum number of presences for the guild (the default value
        ///</summary>
        [JsonProperty("max_presences")]
        public int? MaxPresences { get; internal set; }

        ///<summary>
        ///the maximum number of members for the guild
        ///</summary>
        [JsonProperty("max_members")]
        public int MaxMembers { get; internal set; }

        ///<summary>
        ///the vanity url code for the guild
        ///</summary>
        [JsonProperty("vanity_url_code")]
        public string? VanityUrlCode { get; internal set; }

        ///<summary>
        ///the description of a Community guild
        ///</summary>
        [JsonProperty("description")]
        public string? Description { get; internal set; }

        ///<summary>
        ///banner hash
        ///</summary>
        [JsonProperty("banner")]
        public string? Banner { get; internal set; }

        ///<summary>
        ///premium tier (Server Boost level)
        ///</summary>
        [JsonProperty("premium_tier")]
        public int PremiumTier { get; internal set; }

        ///<summary>
        ///the number of boosts this guild currently has
        ///</summary>
        [JsonProperty("premium_subscription_count")]
        public int PremiumSubscriptionCount { get; internal set; }

        ///<summary>
        ///the preferred locale of a Community guild; used in server discovery and notices from Discord; defaults to "en-US"
        ///</summary>
        [JsonProperty("preferred_locale")]
        public string PreferredLocale { get; internal set; }

        ///<summary>
        ///the id of the channel where admins and moderators of Community guilds receive notices from Discord
        ///</summary>
        [JsonProperty("public_updates_channel_id")]
        public ulong? PublicUpdatesChannelid { get; internal set; }

        ///<summary>
        ///the maximum amount of users in a video channel
        ///</summary>
        [JsonProperty("max_video_channel_users")]
        public int MaxvideoChannelUsers { get; internal set; }

        ///<summary>
        ///approximate number of members in this guild
        ///</summary>
        [JsonProperty("approximate_member_count")]
        public int ApproximateMembercount { get; internal set; }

        ///<summary>
        ///approximate number of non-offline members in this guild
        ///</summary>
        [JsonProperty("approximate_presence_count")]
        public int ApproximatePresencecount { get; internal set; }

        ///<summary>
        ///the welcome screen of a Community guild
        ///</summary>
        [JsonProperty("welcome_screen")]
        public WelcomeScreen Welcomescreen { get; internal set; }

        ///<summary>
        ///guild NSFW level
        ///</summary>
        [JsonProperty("nsfw_level")]
        public int NsfwLevel { get; internal set; }

        ///<summary>
        ///Stage instances in the guild
        ///</summary>
        [JsonProperty("stage_instances")]
        public StageInstance[] StageInstances { get; internal set; }

        public class StageInstance
        {
            ///<summary>
            ///The id of this Stage instance
            ///</summary>
            [JsonProperty("id")]
            public ulong Id { get; internal set; }

            ///<summary>
            ///The guild id of the associated Stage channel
            ///</summary>
            [JsonProperty("guild_id")]
            public ulong GuildID { get; internal set; }

            ///<summary>
            ///The id of the associated Stage channel
            ///</summary>
            [JsonProperty("channel_id")]
            public ulong ChannelID { get; internal set; }

            ///<summary>
            ///The topic of the Stage instance (1-120 characters)
            ///</summary>
            [JsonProperty("topic")]
            public string Topic { get; internal set; }

            ///<summary>
            ///The privacy level of the Stage instance
            ///</summary>
            [JsonProperty("privacy_level")]
            public int PrivacyLevel { get; internal set; }

            ///<summary>
            ///Whether or not Stage discovery is disabled
            ///</summary>
            [JsonProperty("discoverable_disabled")]
            public bool DiscoverableDisabled { get; internal set; }
        }

        public class WelcomeScreen
        {
            ///<summary>
            ///the server description shown in the welcome screen
            ///</summary>
            [JsonProperty("description")]
            public string? Description { get; internal set; }

            ///<summary>
            ///the channels shown in the welcome screen
            ///</summary>
            [JsonProperty("welcome_channels")]
            public welcomeChannels[] WelcomeChannels { get; internal set; }

            public class welcomeChannels
            {
                ///<summary>
                ///the channel's id
                ///</summary>
                [JsonProperty("channel_id")]
                public ulong ChannelID { get; internal set; }

                ///<summary>
                ///the description shown for the channel
                ///</summary>
                [JsonProperty("description")]
                public string Description { get; internal set; }

                ///<summary>
                ///the emoji id
                ///</summary>
                [JsonProperty("emoji_id")]
                public ulong? Emojiid { get; internal set; }

                ///<summary>
                ///the emoji name if custom
                ///</summary>
                [JsonProperty("emoji_name")]
                public string? Emojiname { get; internal set; }
            }
        }
    }
}