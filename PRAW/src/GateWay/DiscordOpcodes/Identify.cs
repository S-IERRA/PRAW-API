using Newtonsoft.Json;

namespace PRAW
{
    internal class Identify
    {
        public string token { get; set; }
        public Properties properties = new();
        //public bool compress { get; set; }
        //public int large_threshold { get; set; }
        //public int[] shard { get; set; }
        //public PresenceUpdate presence { get; set; }
        //public int intents { get; set; }

        public class Properties
        {
            public string os = "linux";
            public string browser = "disco";
            public string device = "disco";
        }

        internal static string IdentifyData(string token) =>
            JsonConvert.SerializeObject(new DiscordEvent()
            {
                OpCode = GatewayOpcodes.Identify,
                Data = new Identify()
				{
                    token = token
				}
            });
    }
}
