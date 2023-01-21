using PRAW;
using System;
using System.Threading;
using PRAW.Benchmark;
using System.Threading.Tasks;

namespace Project__REDACTED_
{
    class Program
    {
        static async Task Main()
        {
           SocketClient socketClient = new();

            await socketClient.LoginAsync("TOKEN");

            socketClient.OnReady += SocketClient_OnReady;
			socketClient.OnMessageRecieved += SocketClient_OnMessageRecieved;

            //dont uncomment cuz user is null and u get nullptr
            //Console.WriteLine(socketClient.User.Avatar);

            Thread.Sleep(-1);
            //Console.WriteLine(JSONHandler.PreSerialize(5, "test"));
            //Benchmark.RunTest<BenchmarkRunner>();
        }

		private static void SocketClient_OnMessageRecieved(DiscordMessage Args)
		{
            Console.WriteLine($"{Args.Author.Username} : {Args.Content} : {Args.TimeStamp}");
		}

		private static void SocketClient_OnReady(User Args)
        {
            Console.WriteLine($"Logged in as {Args.Username}");
        }
    }
}
