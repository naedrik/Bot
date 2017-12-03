using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Net.Providers.WS4Net;

namespace bot
{
    class main
    {
        static void Main(string[] args)
        => new main().Start_async().GetAwaiter().GetResult();

        private DiscordSocketClient _client;

        private CommandHandler _handler;


        public async Task Start_async()
        {

            _client = new DiscordSocketClient(new DiscordSocketConfig()
            {
                LogLevel = LogSeverity.Verbose,
                WebSocketProvider = WS4NetProvider.Instance
            });

            string token= "Mzg1NTU5MDIwMjIxNzU5NDkw.DQM6nA.odxmUV2q08a5df0vhgJorCp3GIQ";

            await _client.LoginAsync(TokenType.Bot, token);
            
            await _client.StartAsync();

            _client.Log += Log;
            _client.UserJoined += UserJoinedAsync;

            _handler = new CommandHandler();

            await _handler.InitializeAsync(_client);

            await Task.Delay(-1);//ezután semmi nem fut le
        }

        private async Task UserJoinedAsync(SocketGuildUser user)
        {
            var guild = user.Guild;
            var channel = guild.Channels.FirstOrDefault() as SocketTextChannel;
            //Console.WriteLine("kecske");
            await channel.SendMessageAsync($"My name is Black-Bot and I have been tasked to welcome you to our kingdom, {user.Mention}-dono!");
        }

        private Task Log(LogMessage message)
        {
            Console.WriteLine(message.ToString());
            return Task.CompletedTask;
        }

       

       
    }
       
}

