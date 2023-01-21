using Newtonsoft.Json;

using System.Net.WebSockets;
using System.Text;

namespace PRAW.Handlers
{
	internal class WebSocketClient
    {
        private static byte[] Buffer { get; } = new byte[2048];
        private const ushort MaxRetryThreshold = 5;
        private ushort RetryInt = 1;

        private static Uri URI { get; } = new("wss://gateway.discord.gg/?v=9&encoding");
        private ClientWebSocket WS { get; } = new();

        internal static CancellationTokenSource CTS { get; } = new();
        private CancellationToken CancellationToken { get; } = CTS.Token;

        public delegate Task HandleReceived(GatewayOpcodes opcode, string? message, string? eventType);

        public event HandleReceived OnReceived;
        public event EventHandler<EventArguments> OnOpened;

        internal async Task<bool> OpenAsync()
        {
            do
            {
                await WS.ConnectAsync(URI, CancellationToken);

                OnOpened?.Invoke(this, new(WS.State));

                await Task.Factory.StartNew(
                    () => RecieveLoop(), CancellationToken, TaskCreationOptions.LongRunning, TaskScheduler.Default);

                if (WS.State == WebSocketState.Open)
                    return true;
            }
            while (WS.State != WebSocketState.Connecting && RetryInt++ != MaxRetryThreshold);

            return false;
        }

        internal async Task CloseAsync()
        {
            if (WS.State == WebSocketState.Open)
            {
                await WS.CloseOutputAsync(WebSocketCloseStatus.Empty, null, CancellationToken);
                await WS.CloseAsync(WebSocketCloseStatus.Empty, null, CancellationToken);
                CTS.Cancel();
            }

            WS.Dispose();
            CTS.Dispose();
        }

        internal async Task SendAsync(string Data)
        {
            ArraySegment<byte> Array = new(Encoding.UTF8.GetBytes(Data));

            await Task.Factory.StartNew(() =>
                WS.SendAsync(Array, WebSocketMessageType.Text, true, CancellationToken));
        }

        private async Task RecieveLoop()
        {
            StringBuilder sb = new();
            WebSocketReceiveResult result;

            while (!CTS.IsCancellationRequested && WS.State == WebSocketState.Open)
            {
                do
                {
                    result = await WS.ReceiveAsync(Buffer, CancellationToken);
                    sb.Append(Encoding.UTF8.GetString(Buffer, 0, result.Count));
                }
                while (!result.EndOfMessage);

                DiscordEvent? d = JsonConvert.DeserializeObject<DiscordEvent>(sb.ToString());

                OnReceived?.Invoke(d!.OpCode, d.Data?.ToString(), d.EventType);
                SocketClient.Sequence = d!.Sequence;

                sb.Clear();
            }
        }

        internal class EventArguments
        {
            private protected object Data { get; set; }

            internal EventArguments(object data)
            {
                Data = data;
            }
        }
    }
}   