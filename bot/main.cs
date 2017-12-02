using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _client = new DiscordSocketClient();

            string token= "Mzg1NTU5MDIwMjIxNzU5NDkw.DQM6nA.odxmUV2q08a5df0vhgJorCp3GIQ";

            await _client.LoginAsync(TokenType.Bot, token);
            
            await _client.StartAsync();

            _handler = new CommandHandler();

            await _handler.InitializeAsync(_client);

            await Task.Delay(-1);//ezután semmi nem fut le
        }


    }
       
}

