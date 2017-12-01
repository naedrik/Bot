using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bot.modules
{
    public class Test:ModuleBase<SocketCommandContext>
    {
        [Command("test")]
        public async Task kecske()
        {
            await Context.Channel.SendMessageAsync("Test Successful!");
        }
    }
}
