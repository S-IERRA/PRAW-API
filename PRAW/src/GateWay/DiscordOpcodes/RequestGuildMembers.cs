namespace PRAW.OpCode
{
    internal class RequestGuildMembers
    {
        internal ulong guild_id { get; set; }
        internal string query { get; set; }
        internal int limit { get; set; }
        internal bool presences { get; set; }
        internal ulong[] user_ids { get; set; }
        internal ulong nonce { get; set; }
    }
}
