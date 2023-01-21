using System;
using Newtonsoft.Json;

namespace PRAW
{
    public class DiscordActivity
    {
        ///<summary>
        ///the activity's name
        ///</summary>
        [JsonProperty("name")]
        public string Name { get; internal set; }

        ///<summary>
        ///activity type
        ///</summary>
        [JsonProperty("type")]
        public int Type { get; internal set; }

        ///<summary>
        ///stream url
        ///</summary>
        [JsonProperty("url")]
        public string? Url { get; internal set; }

        ///<summary>
        ///unix timestamp of when the activity was added to the user's session
        ///</summary>
        [JsonProperty("created_at")]
        public ulong CreatedAt { get; internal set; }

        ///<summary>
        ///unix timestamps for start and/or end of the game
        ///</summary>
        [JsonProperty("timestamps")]
        public ActivityTimestamp TimeStamps { get; internal set; }

        ///<summary>
        ///application id for the game
        ///</summary>
        [JsonProperty("application_id")]
        public ulong ApplicationID { get; internal set; }

        ///<summary>
        ///what the player is currently doing
        ///</summary>
        [JsonProperty("details")]
        public string? Details { get; internal set; }

        ///<summary>
        ///the user's current party status
        ///</summary>
        [JsonProperty("state")]
        public string? State { get; internal set; }

        ///<summary>
        ///the emoji used for a custom status
        ///</summary>
        [JsonProperty("emoji")]
        public ActivityEmoji Emoji { get; internal set; }

        ///<summary>
        ///information for the current party of the player
        ///</summary>
        [JsonProperty("party")]
        public ActivityParty Party { get; internal set; }

        ///<summary>
        ///images for the presence and their hover texts
        ///</summary>
        [JsonProperty("assets")]
        public ActivityAssets Assets { get; internal set; }

        ///<summary>
        ///secrets for Rich Presence joining and spectating
        ///</summary>
        [JsonProperty("secrets")]
        public ActivitySecrets Secrets { get; internal set; }

        ///<summary>
        ///whether or not the activity is an instanced game session
        ///</summary>
        [JsonProperty("instance")]
        public bool IsInstance { get; internal set; }

        ///<summary>
        ///activity flags ORd together
        ///</summary>
        [JsonProperty("flags")]
        public int Flags { get; internal set; }

        ///<summary>
        ///the custom buttons shown in the Rich Presence (max 2)
        ///</summary>
        /*[JsonProperty("buttons")]
        public array of buttons Buttons { get; internal set; }*/

        public class ActivityTimestamp
        {
            ///<summary>
            ///unix time (in milliseconds) of when the activity started
            ///</summary>
            [JsonProperty("start")]
            public ulong Start { get; internal set; }

            ///<summary>
            ///unix time (in milliseconds) of when the activity ends
            ///</summary>
            [JsonProperty("end")]
            public ulong End { get; internal set; }
        }

        public class ActivityEmoji
        {
            ///<summary>
            ///the name of the emoji
            ///</summary>
            [JsonProperty("name")]
            public string Name { get; internal set; }

            ///<summary>
            ///the id of the emoji
            ///</summary>
            [JsonProperty("id")]
            public ulong Id { get; internal set; }

            ///<summary>
            ///whether this emoji is animated
            ///</summary>
            [JsonProperty("animated")]
            public bool IsAnimated { get; internal set; }
        }

        public class ActivityParty
        {
            ///<summary>
            ///the id of the party
            ///</summary>
            [JsonProperty("id")]
            public string Id { get; internal set; }

            ///<summary>
            ///array of two integers (current_size, max_size)
            ///</summary>
            [JsonProperty("size")]
            public int[] Size { get; internal set; }
        }

        public class ActivityAssets
        {
            ///<summary>
            ///the id for a large asset of the activity
            ///</summary>
            [JsonProperty("large_image")]
            public string LargeImage { get; internal set; }

            ///<summary>
            ///text displayed when hovering over the large image of the activity
            ///</summary>
            [JsonProperty("large_text")]
            public string LargeText { get; internal set; }

            ///<summary>
            ///the id for a small asset of the activity
            ///</summary>
            [JsonProperty("small_image")]
            public string SmallImage { get; internal set; }

            ///<summary>
            ///text displayed when hovering over the small image of the activity
            ///</summary>
            [JsonProperty("small_text")]
            public string SmallText { get; internal set; }
        }

        public class ActivitySecrets
        {
            ///<summary>
            ///the secret for joining a party
            ///</summary>
            [JsonProperty("join")]
            public string Join { get; internal set; }

            ///<summary>
            ///the secret for spectating a game
            ///</summary>
            [JsonProperty("spectate")]
            public string Spectate { get; internal set; }

            ///<summary>
            ///the secret for a specific instanced match
            ///</summary>
            [JsonProperty("match")]
            public string Match { get; internal set; }
        }
    }
}
