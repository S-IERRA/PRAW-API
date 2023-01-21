using Newtonsoft.Json;
using System;
using System.ComponentModel;


namespace PRAW
{
    public class DiscordEmbed
    {
        ///<summary>
        ///title of embed
        ///</summary>
        [JsonProperty("title")]
        public string Title { get; internal set; }

        ///<summary>
        ///type of embed (always "rich" for webhook embeds)
        ///</summary>
        [JsonProperty("type")]
        public string Type { get; internal set; }

        /// <summary>
        /// description of embed
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; internal set; }

        ///<summary>
        ///url of embed
        ///</summary>
        [JsonProperty("url")]
        public string Url { get; internal set; }

        ///<summary>
        ///timestamp of embed content
        ///</summary>
        [JsonProperty("timestamp")]
        public DateTime TimeStamp { get; internal set; }

        ///<summary>
        ///color code of the embed
        ///</summary>
        [JsonProperty("color")]
        public int Color { get; internal set; }

        ///<summary>
        ///footer information
        ///</summary>
        [JsonProperty("footer")]
        public EmbedFooter Footer { get; internal set; }

        ///<summary>
        ///image information
        ///</summary>
        [JsonProperty("image")]
        public EmbedImage Image { get; internal set; }

        ///<summary>
        ///thumbnail information
        ///</summary>
        [JsonProperty("thumbnail")]
        public EmbedThumbnail Thumbnail { get; internal set; }

        ///<summary>
        ///video information
        ///</summary>
        [JsonProperty("video")]
        public EmbedVideo Video { get; internal set; }

        ///<summary>
        ///provider information
        ///</summary>
        [JsonProperty("provider")]
        public EmbedProvider Provider { get; internal set; }

        ///<summary>
        ///author information
        ///</summary>
        [JsonProperty("author")]
        public EmbedAuthor Author { get; internal set; }

        ///<summary>
        ///fields information
        ///</summary>
        [JsonProperty("fields")]
        public EmbedField[] Fields { get; internal set; }

        public class EmbedThumbnail
        {
            ///<summary>
            ///source url of thumbnail (only supports http(s) and attachments)
            ///</summary>
            [JsonProperty("url")]
            public string Url { get; internal set; }

            ///<summary>
            ///a proxied url of the thumbnail
            ///</summary>
            [JsonProperty("proxy_url")]
            public string Proxyurl { get; internal set; }

            ///<summary>
            ///height of thumbnail
            ///</summary>
            [JsonProperty("height")]
            public int Height { get; internal set; }

            ///<summary>
            ///width of thumbnail
            ///</summary>
            [JsonProperty("width")]
            public int Width { get; internal set; }
        }

        public class EmbedVideo
        {
            ///<summary>
            ///source url of video
            ///</summary>
            [JsonProperty("url")]
            public string Url { get; internal set; }

            ///<summary>
            ///a proxied url of the video
            ///</summary>
            [JsonProperty("proxy_url")]
            public string ProxyUrl { get; internal set; }

            ///<summary>
            ///height of video
            ///</summary>
            [JsonProperty("height")]
            public int Height { get; internal set; }

            ///<summary>
            ///width of video
            ///</summary>
            [JsonProperty("width")]
            public int Width { get; internal set; }
        }

        public class EmbedImage
        {
            ///<summary>
            ///source url of image (only supports http(s) and attachments)
            ///</summary>
            [JsonProperty("url")]
            public string Url { get; internal set; }

            ///<summary>
            ///a proxied url of the image
            ///</summary>
            [JsonProperty("proxy_url")]
            public string Proxyurl { get; internal set; }

            ///<summary>
            ///height of image
            ///</summary>
            [JsonProperty("height")]
            public int Height { get; internal set; }

            ///<summary>
            ///width of image
            ///</summary>
            [JsonProperty("width")]
            public int Width { get; internal set; }

        }

        public class EmbedProvider
        {
            ///<summary>
            ///name of provider
            ///</summary>
            [JsonProperty("name")]
            public string Name { get; internal set; }

            ///<summary>
            ///url of provider
            ///</summary>
            [JsonProperty("url")]
            public string Url { get; internal set; }
        }

        public class EmbedAuthor
        {
            ///<summary>
            ///name of author
            ///</summary>
            [JsonProperty("name")]
            public string Name { get; internal set; }

            ///<summary>
            ///url of author
            ///</summary>
            [JsonProperty("url")]
            public string Url { get; internal set; }

            ///<summary>
            ///url of author icon (only supports http(s) and attachments)
            ///</summary>
            [JsonProperty("icon_url")]
            public string Iconurl { get; internal set; }

            ///<summary>
            ///a proxied url of author icon
            ///</summary>
            [JsonProperty("proxy_icon_url")]
            public string Proxyiconurl { get; internal set; }
        }

        public class EmbedFooter
        {
            ///<summary>
            ///footer text
            ///</summary>
            [JsonProperty("text")]
            public string Text { get; internal set; }

            ///<summary>
            ///url of footer icon (only supports http(s) and attachments)
            ///</summary>
            [JsonProperty("icon_url")]
            public string IconUrl { get; internal set; }

            ///<summary>
            ///a proxied url of footer icon
            ///</summary>
            [JsonProperty("proxy_icon_url")]
            public string ProxyiconUrl { get; internal set; }
        }

        public class EmbedField
        {
            ///<summary>
            ///name of the field
            ///</summary>
            [JsonProperty("name")]
            public string Name { get; internal set; }

            ///<summary>
            ///value of the field
            ///</summary>
            [JsonProperty("value")]
            public string Value { get; internal set; }

            ///<summary>
            ///whether or not this field should display inline
            ///</summary>
            [JsonProperty("inline")]
            public bool Inline { get; internal set; }
        }
    }
}
