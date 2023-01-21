using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace PRAW
{
    public class DiscordChannel
    {
        /// <summary>
        /// the id of this channel
        /// </summary>
        [JsonProperty("id")]
        public ulong Id { get; internal set; }

        /// <summary>
        /// the type of channel
        /// </summary>
        [JsonProperty("type")]
        public ChannelType Type { get; internal set; }

        ///<summary>
        ///the id of the guild (may be missing for some channel objects received over gateway guild dispatches)
        ///</summary>
        [JsonProperty("guild_id")]
        public ulong GuildID { get; internal set; }

        ///<summary>
        ///sorting position of the channel
        ///</summary>
        [JsonProperty("position")]
        public int Position { get; internal set; }

        ///<summary>
        ///explicit permission overwrites for members and roles
        ///</summary>
        [JsonProperty("permission_overwrites")]
        public OverWrite[] Permissionoverwrites { get; internal set; }

        ///<summary>
        ///the name of the channel (2-100 characters)
        ///</summary>
        [JsonProperty("name")]
        public string Name { get; internal set; }

        ///<summary>
        ///the channel topic (0-1024 characters)
        ///</summary>
        [JsonProperty("topic")]
        public string? Topic { get; internal set; }

        ///<summary>
        ///whether the channel is nsfw
        ///</summary>
        [JsonProperty("nsfw")]
        public bool IsNsfw { get; internal set; }

        ///<summary>
        ///the id of the last message sent in this channel (may not point to an existing or valid message)
        ///</summary>
        [JsonProperty("last_message_id")]
        public ulong? LastMessageID { get; internal set; }

        ///<summary>
        ///the bitrate (in bits) of the voice channel
        ///</summary>
        [JsonProperty("bitrate")]
        public int BitRate { get; internal set; }

        ///<summary>
        ///the user limit of the voice channel
        ///</summary>
        [JsonProperty("user_limit")]
        public int UserLimit { get; internal set; }

        ///<summary>
        ///amount of seconds a user has to wait before sending another message (0-21600); bots
        ///</summary>
        [JsonProperty("rate_limit_per_user")]
        public int RateLimitPerUser { get; internal set; }

        ///<summary>
        ///the recipients of the DM
        ///</summary>
        [JsonProperty("recipients")]
        public User[] Recipients { get; internal set; }

        ///<summary>
        ///icon hash
        ///</summary>
        [JsonProperty("icon")]
        public string? Icon { get; internal set; }

        ///<summary>
        ///id of the creator of the group DM or thread
        ///</summary>
        [JsonProperty("owner_id")]
        public ulong OwnerID { get; internal set; }

        ///<summary>
        ///application id of the group DM creator if it is bot-created
        ///</summary>
        [JsonProperty("application_id")]
        public ulong ApplicationID { get; internal set; }

        ///<summary>
        ///for guild channels: id of the parent category for a channel (each parent category can contain up to 50 channels)
        ///</summary>
        [JsonProperty("parent_id")]
        public ulong? ParentID { get; internal set; }

        ///<summary>
        ///when the last pinned message was pinned. This may be null in events such as GUILD_CREATE when a message is not pinned.
        ///</summary>
        [JsonProperty("last_pin_timestamp")]
        public DateTime? LastPinTimeStamp { get; internal set; }

        ///<summary>
        ///voice region id for the voice channel
        ///</summary>
        [JsonProperty("rtc_region")]
        public string? RtcRegion { get; internal set; }

        ///<summary>
        ///the camera video quality mode of the voice channel
        ///</summary>
        [JsonProperty("video_quality_mode")]
        public VideoQuality VideoQualityMode { get; internal set; }

        ///<summary>
        ///an approximate count of messages in a thread
        ///</summary>
        [JsonProperty("message_count")]
        public int MessageCount { get; internal set; }

        ///<summary>
        ///an approximate count of users in a thread
        ///</summary>
        [JsonProperty("member_count")]
        public int MemberCount { get; internal set; }

        ///<summary>
        ///thread-specific fields not needed by other channels
        ///</summary>
        [JsonProperty("thread_metadata")]
        public ThreadMetaData ThreadMetaData { get; internal set; }

        ///<summary>
        ///thread member object for the current user
        ///</summary>
        [JsonProperty("member")]
        public ThreadMember Member { get; internal set; }

        public enum ChannelType
        {
            GUILD_TEXT = 0,
            DM = 1,
            GUILD_VOICE = 2,
            GROUP_DM = 3,
            GUILD_CATEGORY = 4,
            GUILD_NEWS = 5,
            GUILD_STORE = 6,
            GUILD_NEWS_THREAD = 10,
            GUILD_PUBLIC_THREAD = 11,
            GUILD_PRIVATE_THREAD = 12,
            GUILD_STAGE_VOICE = 13,
        }

        public enum VideoQuality
        {
            Auto = 1,
            Full = 2
        }
    }

    public class OverWrite
    {
        ///<summary>
        ///role or user id
        ///</summary>
        [JsonProperty("id")]
        public ulong Id { get; internal set; }

        ///<summary>
        ///either 0 (role) or 1 (member)
        ///</summary>
        [JsonProperty("type")]
        public int Type { get; internal set; }

        ///<summary>
        ///permission bit set
        ///</summary>
        [JsonProperty("allow")]
        public string Allow { get; internal set; }

        ///<summary>
        ///permission bit set
        ///</summary>
        [JsonProperty("deny")]
        public string Deny { get; internal set; }
    }

    public class ThreadMetaData
    {
        ///<summary>
        ///whether the thread is archived
        ///</summary>
        [JsonProperty("archived")]
        public bool Archived { get; internal set; }

        ///<summary>
        ///id of the user that last archived or unarchived the thread
        ///</summary>
        [JsonProperty("archiver_id")]
        public ulong ArchiverID { get; internal set; }

        ///<summary>
        ///duration in minutes to automatically archive the thread after recent activity
        ///</summary>
        [JsonProperty("auto_archive_duration")]
        public int AutoarchiveDuration { get; internal set; }

        ///<summary>
        ///timestamp when the thread's archive status was last changed
        ///</summary>
        [JsonProperty("archive_timestamp")]
        public DateTimeOffset ArchiveTimeStamp { get; internal set; }

        ///<summary>
        ///when a thread is locked
        ///</summary>
        [JsonProperty("locked")]
        public bool Locked { get; internal set; }
    }

    public class ThreadMember
    {
        ///<summary>
        ///the id of the thread
        ///</summary>
        [JsonProperty("id")]
        public ulong Id { get; internal set; }

        ///<summary>
        ///the id of the user
        ///</summary>
        [JsonProperty("user_id")]
        public ulong UserID { get; internal set; }

        ///<summary>
        ///the time the current user last joined the thread
        ///</summary>
        [JsonProperty("join_timestamp")]
        public DateTimeOffset JoinTimeStamp { get; internal set; }

        ///<summary>
        ///any user-thread settings
        ///</summary>
        [JsonProperty("flags")]
        public int Flags { get; internal set; }
    }

    public class ChannelMention
    {
        ///<summary>
        ///id of the channel
        ///</summary>
        [JsonProperty("id")]
        public ulong ID { get; internal set; }

        ///<summary>
        ///id of the guild containing the channel
        ///</summary>
        [JsonProperty("guild_id")]
        public ulong GuildID { get; internal set; }

        ///<summary>
        ///the type of channel
        ///</summary>
        [JsonProperty("type")]
        public int Type { get; internal set; }

        ///<summary>
        ///the name of the channel
        ///</summary>
        [JsonProperty("name")]
        public string Name { get; internal set; }
    }
}
