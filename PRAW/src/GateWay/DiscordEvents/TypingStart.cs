using Newtonsoft.Json;

namespace PRAW
{
	public class TypingStart
	{
		///<summary>
		///id of the channel
		///</summary>
		[JsonProperty("channel_id")]
		public ulong ChannelID { get; internal set; }

		///<summary>
		///id of the guild
		///</summary>
		[JsonProperty("guild_id")]
		public ulong GuildID { get; internal set; }

		///<summary>
		///id of the user
		///</summary>
		[JsonProperty("user_id")]
		public ulong Userid { get; internal set; }

		///<summary>
		///unix time (in seconds) of when the user started typing
		///</summary>
		[JsonProperty("timestamp")]
		public object TimeStamp { get; internal set; }

		///<summary>
		///the member who started typing if this happened in a guild
		///</summary>
		[JsonProperty("member")]
		public GuildMember Member { get; internal set; }
	}
}
