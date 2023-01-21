using Newtonsoft.Json;

namespace PRAW
{
    public class User
    {
        /// <summary>
        ///the users token (not even sure if this works btw im writing this like 2 months later)
        /// </summary>
        [JsonProperty("token")]
        public static string Token { get; set; }

        ///<summary>
        ///the user's username
        ///</summary>
        [JsonProperty("username")]
        public string Username { get; internal set; }

        ///<summary>
        ///the user's 4-digit discord-tag
        ///</summary>
        [JsonProperty("discriminator")]
        public string Discriminator { get; internal set; }

        ///<summary>
        ///the user's avatar hash
        ///</summary>
        [JsonProperty("avatar")]
        public string? Avatar { get; internal set; }

        ///<summary>
        ///whether the user belongs to an OAuth2 application
        ///</summary>
        [JsonProperty("bot")]
        public bool Bot { get; internal set; }

        ///<summary>
        ///whether the user is an Official Discord System user (part of the urgent message system)
        ///</summary>
        [JsonProperty("system")]
        public bool System { get; internal set; }

        ///<summary>
        ///whether the user has two factor enabled on their account
        ///</summary>
        [JsonProperty("mfa_enabled")]
        public bool IsMfaEnabled { get; internal set; }

        ///<summary>
        ///the user's chosen language option
        ///</summary>
        [JsonProperty("locale")]
        public string Locale { get; internal set; }

        ///<summary>
        ///whether the email on this account has been verified
        ///</summary>
        [JsonProperty("verified")]
        public bool IsVerified { get; internal set; }

        ///<summary>
        ///the user's email
        ///</summary>
        [JsonProperty("email")]
        public string? Email { get; internal set; }

        ///<summary>
        ///the flags on a user's account
        ///</summary>
        [JsonProperty("flags")]
        public int Flags { get; internal set; }

        ///<summary>
        ///the type of Nitro subscription on a user's account
        ///</summary>
        [JsonProperty("premium_type")]
        public int PremiumType { get; internal set; }

        ///<summary>
        ///the public flags on a user's account
        ///</summary>
        [JsonProperty("public_flags")]
        public int PublicFlags { get; internal set; }
    }
}
