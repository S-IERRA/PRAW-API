using System.Reflection;

using PRAW.Handlers;
using PRAW.ErrorCodes;
using PRAW.OpCode;

using Newtonsoft.Json;

namespace PRAW
{   
    public class SocketClient
    {
        private protected const uint maxResumeThreshold = (uint)1.8E4;

        private protected static WebSocketClient WebSocket { get; } = new();

        private static ClientState clientState = ClientState.None;

        
        //this part is a mess cuz it was WIP and i never finished it 
        //in general this class is a mess because it was WIP and i never actually finished it
        //it works enough to be considered an api wrapper

        /// <summary>
        /// touch this and the whole thing will break (TEMP SOLUTION)
        /// </summary>
        public static uint? Sequence { get; internal set; }
        public static uint currentTime() => (uint)DateTime.UtcNow.Subtract(DateTime.UnixEpoch).TotalSeconds;

        #region ClientObjects

        //these are also broken lol never fixed them so dont touch them
        private static Ready readyEvent { get; set; }
        private static Hello helloEvent { get; set; }

        public User User = readyEvent.User;
        public DiscordGuild[] Guilds = readyEvent.Guilds;
        /*public async Task<IEnumerable<DiscordGuild>> RequestGuildMembers()
		{
            await WebSocket.SendAsync(JsonConvert.SerializeObject(new DiscordEvent()
            {
                OpCode = GatewayOpcodes.RequestGuildMembers,
                Sequence = Sequence
            }));


		}*/


		#endregion

		#region Events
		public delegate void EventHandler<T>(T Args);
            
		public event EventHandler<User> OnReady;

        public event EventHandler<TypingStart> OnTyping;
        public event EventHandler<DiscordMessage> OnMessageRecieved;
        public event EventHandler<DiscordMessageDelete> OnMessageDeleted;
        public event EventHandler<DiscordMessageDeleteBulk> OnMessageBulkDeleted;

        public event EventHandler<MessageReactionAdd> OnReactionAdded;
        public event EventHandler<MessageReactionRemove> OnReactionRemoved;
        /// <summary>
        /// Sent when a user explicitly removes all reactions from a message.
        /// </summary>
        public event EventHandler<MessageReactionRemoveAll> OnReactionRemoveAll;
        /// <summary>
        /// Sent when a bot removes all instances of a given emoji from the reactions of a message.
        /// </summary>
        public event EventHandler<MessageReactionRemoveEmoji> OnBotRemoveEmoji;

        public event EventHandler<DiscordGuild> OnGuildCreate;

        #endregion


        public async Task LoginAsync(string Token)
        {
            WebSocket.OnReceived += Ws_OnReceived;

            WebSocket.OnOpened += (obj1, obj2) =>
                Console.WriteLine("Connected!");

            await Task.Run(
                () => WebSocket.OpenAsync());

            await Task.Run(
                () => WebSocket.SendAsync(Identify.IdentifyData(Token)));
        }

        //THIS ISNT FINISHED AND IT DOESNT WORK
        private void GenericInvoke<T>(string method, object[] param)
		{
            MethodInfo methodInfo = typeof(SocketClient).GetMethod(method, BindingFlags.Public);

            Console.WriteLine(methodInfo);

            MethodInfo generic = methodInfo.MakeGenericMethod(typeof(EventHandler<T>));

            generic?.Invoke(this, param);
		}


        private async Task Ws_OnReceived(GatewayOpcodes opcode, string? message, string? eventType)
        {
            switch (opcode)
            {
                case GatewayOpcodes.Reconnect:
                    await WebSocket.CloseAsync();

                    clientState = ClientState.Reconnecting;

                    if (await WebSocket.OpenAsync())
                        clientState = ClientState.Connected;
                    else
                        throw new ConnectionException(PRAWErrors.MaxReconnectThresholdReached, "The websocket has reached the max amount of retries to reconnect to the socket server, connection lost.");
                    
                    break;

                case GatewayOpcodes.InvalidSession:
                    bool canResume = Boolean.Parse(message!);

                    if (canResume)
                        await Resume.DoResumeOrIdentify(Sequence);
                    else
                        await Task.Run(() => WebSocket.SendAsync(
                            Identify.IdentifyData(User.Token)));
                    break;

                case GatewayOpcodes.Heartbeat:

                    await WebSocket.SendAsync(JsonConvert.SerializeObject(new DiscordEvent()
                    {
                        OpCode = GatewayOpcodes.Heartbeat,
                        Sequence = Sequence
                    }));
                    break;

                case GatewayOpcodes.HeartbeatACK:
                    HeartBeatACK.HeartBeatAck = true;
                    HeartBeatACK.LastHeartbeatAck = currentTime();
                    HeartBeatACK.ExpeditedHeartbeatTimeout = null;
                    break;

                case GatewayOpcodes.Hello:
                    Hello hello = JsonConvert.DeserializeObject<Hello>(message!)!;

                    new Thread(async () =>
                    {
                        while (clientState is ClientState.Ready or ClientState.None)
                        {
                            //Console.WriteLine(sequence);
                            Thread.Sleep(hello.HeartbeatInterval);

                            await Task.Run(() => WebSocket.SendAsync(
                                JsonConvert.SerializeObject(new DiscordEvent()
                                {
                                    OpCode = GatewayOpcodes.Heartbeat,
                                    Sequence = Sequence
                                })));
                        }
                    }).Start();

                    break;

                case GatewayOpcodes.Dispatch:
                    switch (eventType)
                    {
                        case "READY":
                            readyEvent = JsonConvert.DeserializeObject<Ready>(message!)!;
                            //GenericInvoke<Ready>("OnReady", new object[] {readyEvent.User}); //DONT UNCOMMENT THIS
                            OnReady?.Invoke(readyEvent.User);

                            clientState = ClientState.Ready;
                            break;

                        case "RESUMED":
                            break;

                        case "PRESENCE_UPDATE" when OnReactionAdded != null:
                            break;

                        case "USER_UPDATE" when OnReactionAdded != null:
                            break;

                        //Message
                        case "MESSAGE_CREATE" when OnMessageRecieved != null:
                            //Console.WriteLine(message);
                            var discordMessage = JsonConvert.DeserializeObject<DiscordMessage>(message);

                            OnMessageRecieved?.Invoke(discordMessage);
                            break;

                        case "MESSAGE_DELETE" when OnMessageDeleted != null:
                            var discordMessageDelete = JsonConvert.DeserializeObject<DiscordMessageDelete>(message);

                            OnMessageDeleted?.Invoke(discordMessageDelete);
                            break;

                        case "MESSAGE_DELETE_BULK" when OnMessageBulkDeleted != null:
                            var discordMessageDeleteBulk = JsonConvert.DeserializeObject<DiscordMessageDeleteBulk>(message);

                            OnMessageBulkDeleted?.Invoke(discordMessageDeleteBulk);
                            break;

                        case "MESSAGE_REACTION_ADD" when OnReactionAdded != null:
                            var messageReactionAdd = JsonConvert.DeserializeObject<MessageReactionAdd>(message);

                            OnReactionAdded?.Invoke(messageReactionAdd);
                            break;

                        case "MESSAGE_REACTION_REMOVE" when OnReactionRemoved != null:
                            var messsageReactionRemove = JsonConvert.DeserializeObject<MessageReactionRemove>(message);

                            OnReactionRemoved?.Invoke(messsageReactionRemove);
                            break;

                        case "MESSAGE_REACTION_REMOVE_ALL" when OnReactionRemoveAll != null:
                            var messageReactionRemoveAll = JsonConvert.DeserializeObject<MessageReactionRemoveAll>(message);

                            OnReactionRemoveAll?.Invoke(messageReactionRemoveAll);
                            break;

                        case "MESSAGE_REACTION_REMOVE_EMOJI" when OnBotRemoveEmoji != null:
                            var messageBotRemoveEmoji = JsonConvert.DeserializeObject<MessageReactionRemoveEmoji>(message);

                            OnBotRemoveEmoji?.Invoke(messageBotRemoveEmoji);
                            break;

                        //Typing
                        case "TYPING_START" when OnTyping != null:
                            var typingStart = JsonConvert.DeserializeObject<TypingStart>(message);

                            OnTyping?.Invoke(typingStart);
                            break;

                        //Guild
                        case "GUILD_CREATE" when OnReactionAdded != null:
                            var guildCreate = JsonConvert.DeserializeObject<DiscordGuild>(message);
                            
                            OnGuildCreate?.Invoke(guildCreate);
                            break;

                        case "GUILD_UPDATE" when OnReactionAdded != null:
                            break;

                        case "GUILD_DELETE" when OnReactionAdded != null:
                            break;

                        case "GUILD_BAN_ADD" when OnReactionAdded != null:
                            break;

                        case "GUILD_BAN_REMOVE" when OnReactionAdded != null:
                            break;

                        case "GUILD_EMOJIS_UPDATE" when OnReactionAdded != null:
                            break;

                        case "GUILD_INTEGRATIONS_UPDATE" when OnReactionAdded != null:
                            break;

                        case "GUILD_MEMBER_ADD" when OnReactionAdded != null:
                            break;

                        case "GUILD_MEMBER_REMOVE" when OnReactionAdded != null:
                            break;

                        case "GUILD_MEMBER_UPDATE" when OnReactionAdded != null:
                            break;

                        case "GUILD_MEMBERS_CHUNK" when OnReactionAdded != null:
                            break;

                        case "GUILD_ROLE_CREATE" when OnReactionAdded != null:
                            break;

                        case "GUILD_ROLE_UPDATE" when OnReactionAdded != null:
                            break;

                        case "GUILD_ROLE_DELETE" when OnReactionAdded != null:
                            break;

                        //Channel
                        case "CHANNEL_CREATE" when OnReactionAdded != null:
                            break;

                        case "CHANNEL_UPDATE" when OnReactionAdded != null:
                            break;

                        case "CHANNEL_DELETE" when OnReactionAdded != null:
                            break;

                        case "CHANNEL_PINS_UPDATE" when OnReactionAdded != null:
                            break;

                        //Integration
                        case "INTEGRATION_CREATE" when OnReactionAdded != null:
                            break;

                        case "INTEGRATION_UPDATE" when OnReactionAdded != null:
                            break;

                        case "INTEGRATION_DELETE" when OnReactionAdded != null:
                            break;

                        //Thread
                        case "THREAD_CREATE" when OnReactionAdded != null:
                            break;

                        case "THREAD_UPDATE" when OnReactionAdded != null:
                            break;

                        case "THREAD_DELETE" when OnReactionAdded != null:
                            break;

                        case "THREAD_LIST_SYNC" when OnReactionAdded != null:
                            break;

                        case "THREAD_MEMBER_UPDATE" when OnReactionAdded != null:
                            break;

                        case "THREAD_MEMBERS_UPDATE" when OnReactionAdded != null:
                            break;

                        //Interaction
                        case "INTERACTION_CREATE" when OnReactionAdded != null:
                            break;

                        //Invite
                        case "INVITE_CREATE" when OnReactionAdded != null:
                            break;

                        case "INVITE_DELETE" when OnReactionAdded != null:
                            break;

                        //Stage
                        case "STAGE_INSTANCE_CREATE" when OnReactionAdded != null:
                            break;

                        case "STAGE_INSTANCE_DELETE" when OnReactionAdded != null:
                            break;

                        case "STAGE_INSTANCE_UPDATE" when OnReactionAdded != null:
                            break;

                        //Voice
                        case "VOICE_STATE_UPDATE" when OnReactionAdded != null:
                            break;

                        case "VOICE_SERVER_UPDATE" when OnReactionAdded != null:
                            break;

                        //Webhook
                        case "WEBHOOKS_UPDATE" when OnReactionAdded != null:
                            break;

                        //Application
                        case "APPLICATION_COMMAND_CREATE" when OnReactionAdded != null:
                            break;

                        case "APPLICATION_COMMAND_UPDATE" when OnReactionAdded != null:
                            break;

                        case "APPLICATION_COMMAND_DELETE" when OnReactionAdded != null:
                            break;
                    }
                    break;

                case (_):
                    Console.Error.WriteLine($"[ERROR] Unhandled OP {opcode}");
                    break;
            }
        }
    }
}
