using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace PRAW.OpCode
{
    internal class Resume : SocketClient
    {
        public string token = User.Token;
        public string session_id = Ready.SessionID!;
        public uint? seq { get; set; }

        internal static async Task DoResumeOrIdentify(uint? sequence)
		{
            bool canResume = Ready.SessionID != null && currentTime() - HeartBeatACK.LastHeartbeatAck <= maxResumeThreshold;

            if (canResume)
                await Task.Run(() => WebSocket.SendAsync(
                     DoResume(sequence)));
            else
                await Task.Run(() => WebSocket.SendAsync(
                     Identify.IdentifyData(User.Token)));
        }

        internal static string DoResume(uint? sequence) =>
            JsonConvert.SerializeObject(new DiscordEvent()
            {
                OpCode = GatewayOpcodes.Resume,
                Data = new Resume()
				{
                    seq = sequence
				}
            });
    }
}
