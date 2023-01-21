using Newtonsoft.Json;

namespace PRAW
{
    public class DiscordInteractions
    {
        public class Interaction
        {
            ///<summary>
            ///id of the interaction
            ///</summary>
            [JsonProperty("id")]
            public ulong Id { get; internal set; }

            ///<summary>
            ///id of the application this interaction is for
            ///</summary>
            [JsonProperty("application_id")]
            public ulong Applicationid { get; internal set; }

            ///<summary>
            ///the type of interaction
            ///</summary>
            [JsonProperty("type")]
            public InteractionType Type { get; internal set; }

            ///<summary>
            ///the command data payload
            ///</summary>
            [JsonProperty("data")]
            public ApplicationCommandInteractionData Data { get; internal set; }

            ///<summary>
            ///the guild it was sent from
            ///</summary>
            [JsonProperty("guild_id")]
            public ulong GuildID { get; internal set; }

            ///<summary>
            ///the channel it was sent from
            ///</summary>
            [JsonProperty("channel_id")]
            public ulong ChannelID { get; internal set; }

            ///<summary>
            ///guild member data for the invoking user
            ///</summary>
            [JsonProperty("member")]
            public GuildMember Member { get; internal set; }

            ///<summary>
            ///user object for the invoking user
            ///</summary>
            [JsonProperty("user")]
            public User User { get; internal set; }

            ///<summary>
            ///a continuation token for responding to the interaction
            ///</summary>
            [JsonProperty("token")]
            public string Token { get; internal set; }

            ///<summary>
            ///read-only property
            ///</summary>
            [JsonProperty("version")]
            public int Version { get; internal set; }

            ///<summary>
            ///for components
            ///</summary>
            [JsonProperty("message")]
            public DiscordMessage Message { get; internal set; }

            public class ApplicationCommandInteractionData
            {
                ///<summary>
                ///the ID of the invoked command
                ///</summary>
                [JsonProperty("id")]
                public ulong Id { get; internal set; }

                ///<summary>
                ///the name of the invoked command
                ///</summary>
                [JsonProperty("name")]
                public string Name { get; internal set; }

                ///<summary>
                ///converted users + roles + channels
                ///</summary>
                [JsonProperty("resolved")]
                public DataResolved Resolved { get; internal set; }

                ///<summary>
                ///the params + values from the user
                ///</summary>
                [JsonProperty("options")]
                public DataOption[] Options { get; internal set; }

                ///<summary>
                ///for components
                ///</summary>
                [JsonProperty("custom_id")]
                public string CustomID { get; internal set; }

                ///<summary>
                ///for components
                ///</summary>
                [JsonProperty("component_type")]
                public int ComponentType { get; internal set; }
            }

            public class DataResolved
            {
                ///<summary>
                ///the IDs and User objects
                ///</summary>
                [JsonProperty("users")]
                public User[] Users { get; internal set; }

                ///<summary>
                ///the IDs and partial Member objects
                ///</summary>
                [JsonProperty("members")]
                public GuildMember[] Members { get; internal set; }

                ///<summary>
                ///the IDs and Role objects
                ///</summary>
                [JsonProperty("roles")]
                public DiscordRole[] Roles { get; internal set; }

                ///<summary>
                ///the IDs and partial Channel objects
                ///</summary>
                [JsonProperty("channels")]
                public DiscordChannel[] Channels { get; internal set; }
            }

            public class DataOption
            {
                ///<summary>
                ///the name of the parameter
                ///</summary>
                [JsonProperty("name")]
                public string Name { get; internal set; }

                ///<summary>
                ///value of ApplicationCommandOptionType
                ///</summary>
                [JsonProperty("type")]
                public int Type { get; internal set; }

                ///<summary>
                ///the value of the pair
                ///</summary>
                [JsonProperty("value")]
                public OptionType Value { get; internal set; }

                ///<summary>
                ///present if this option is a group or subcommand
                ///</summary>
                [JsonProperty("options")]
                public DataOption[] Options { get; internal set; }

                public enum OptionType
                {
                    SUB_COMMAND = 1,
                    SUB_COMMAND_GROUP = 2,
                    STRING = 3,
                    INTEGER = 4,
                    BOOLEAN = 5,
                    USER = 6,
                    CHANNEL = 7,
                    ROLE = 8,
                    MENTIONABLE = 9
                }
            }

            public class MessageInteraction
            {
                ///<summary>
                ///id of the interaction
                ///</summary>
                [JsonProperty("id")]
                public ulong Id { get; internal set; }

                ///<summary>
                ///the type of interaction
                ///</summary>
                [JsonProperty("type")]
                public InteractionType Type { get; internal set; }

                ///<summary>
                ///the name of the ApplicationCommand
                ///</summary>
                [JsonProperty("name")]
                public string Name { get; internal set; }

                ///<summary>
                ///the user who invoked the interaction
                ///</summary>
                [JsonProperty("user")]
                public User User { get; internal set; }
            }

            public enum InteractionType
            {
                Ping = 1,
                ApplicationCommand = 2,
                MessageComponent = 3,
            }
        }
    }
}
