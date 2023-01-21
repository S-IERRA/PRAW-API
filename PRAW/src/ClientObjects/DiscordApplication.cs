using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PRAW
{
    public class DiscordApplication
    {
        ///<summary>
        ///the id of the app
        ///</summary>
        [JsonProperty("id")]
        public ulong Id { get; internal set; }

        ///<summary>
        ///the name of the app
        ///</summary>
        [JsonProperty("name")]
        public string Name { get; internal set; }

        ///<summary>
        ///the icon hash of the app
        ///</summary>
        [JsonProperty("icon")]
        public string? Icon { get; internal set; }

        ///<summary>
        ///the description of the app
        ///</summary>
        [JsonProperty("description")]
        public string Description { get; internal set; }

        ///<summary>
        ///an array of rpc origin urls
        ///</summary>
        [JsonProperty("rpc_origins")]
        public string[] Rpcorigins { get; internal set; }

        ///<summary>
        ///when false only app owner can join the app's bot to guilds
        ///</summary>
        [JsonProperty("bot_public")]
        public bool IsBotPublic { get; internal set; }

        ///<summary>
        ///when true the app's bot will only join upon completion of the full oauth2 code grant flow
        ///</summary>
        [JsonProperty("bot_require_code_grant")]
        public bool BotRequireCodegrant { get; internal set; }

        ///<summary>
        ///the url of the app's terms of service
        ///</summary>
        [JsonProperty("terms_of_service_url")]
        public string Termsofserviceurl { get; internal set; }

        ///<summary>
        ///the url of the app's privacy policy
        ///</summary>
        [JsonProperty("privacy_policy_url")]
        public string Privacypolicyurl { get; internal set; }

        ///<summary>
        ///partial user object containing info on the owner of the application
        ///</summary>
        [JsonProperty("owner")]
        public User[] Owner { get; internal set; }

        ///<summary>
        ///if this application is a game sold on Discord
        ///</summary>
        [JsonProperty("summary")]
        public string Summary { get; internal set; }

        ///<summary>
        ///the hex encoded key for verification in interactions and the GameSDK's GetTicket
        ///</summary>
        [JsonProperty("verify_key")]
        public string VerifyKey { get; internal set; }

        ///<summary>
        ///if the application belongs to a team
        ///</summary>
        [JsonProperty("team")]
        public DiscordTeam Team { get; internal set; }

        ///<summary>
        ///if this application is a game sold on Discord
        ///</summary>
        [JsonProperty("guild_id")]
        public ulong Guildid { get; internal set; }

        ///<summary>
        ///if this application is a game sold on Discord
        ///</summary>
        [JsonProperty("primary_sku_id")]
        public ulong Primaryskuid { get; internal set; }

        ///<summary>
        ///if this application is a game sold on Discord
        ///</summary>
        [JsonProperty("slug")]
        public string Slug { get; internal set; }

        ///<summary>
        ///the application's default rich presence invite cover image hash
        ///</summary>
        [JsonProperty("cover_image")]
        public string Coverimage { get; internal set; }

        ///<summary>
        ///the application's public flags
        ///</summary>
        [JsonProperty("flags")]
        public int Flags { get; internal set; }

        public class DiscordTeam
        {
            ///<summary>
            ///a hash of the image of the team's icon
            ///</summary>
            [JsonProperty("icon")]
            public string? Icon { get; internal set; }

            ///<summary>
            ///the unique id of the team
            ///</summary>
            [JsonProperty("id")]
            public ulong Id { get; internal set; }

            ///<summary>
            ///the members of the team
            ///</summary>
            [JsonProperty("members")]
            public TeamMember[] Members { get; internal set; }

            ///<summary>
            ///the name of the team
            ///</summary>
            [JsonProperty("name")]
            public string Name { get; internal set; }

            ///<summary>
            ///the user id of the current team owner
            ///</summary>
            [JsonProperty("owner_user_id")]
            public ulong OwnerUserID { get; internal set; }

            public class TeamMember
            {
                ///<summary>
                ///will always be ["*"]
                ///</summary>
                [JsonProperty("permissions")]
                public string[] Permissions { get; internal set; }

                ///<summary>
                ///the id of the parent team of which they are a member
                ///</summary>
                [JsonProperty("team_id")]
                public ulong TeamID { get; internal set; }

                ///<summary>
                ///the avatar
                ///</summary>
                [JsonProperty("user")]
                public object[] User { get; internal set; }
            }
        }
    }
}
