using Newtonsoft.Json;
using System.ComponentModel;

namespace PRAW
{
    public class DiscordSticker
    {
        ///<summary>
        ///id of the sticker
        ///</summary>
        [JsonProperty("id")]
        public ulong ID { get; internal set; }

        ///<summary>
        ///id of the pack the sticker is from
        ///</summary>
        [JsonProperty("pack_id")]
        public ulong PackID { get; internal set; }

        ///<summary>
        ///name of the sticker
        ///</summary>
        [JsonProperty("name")]
        public string Name { get; internal set; }

        ///<summary>
        ///description of the sticker
        ///</summary>
        [JsonProperty("description")]
        public string Description { get; internal set; }

        ///<summary>
        ///a comma-separated list of tags for the sticker
        ///</summary>
        [JsonProperty("tags")]
        public string Tags { get; internal set; }

        ///<summary>
        ///sticker asset hash
        ///</summary>
        [JsonProperty("asset")]
        public string Asset { get; internal set; }

        ///<summary>
        ///type of sticker format
        ///</summary>
        [JsonProperty("format_type")]
        public int Formattype { get; internal set; }
    }
}
