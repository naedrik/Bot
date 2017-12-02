using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bot.modules
{
    public class Purge:ModuleBase<SocketCommandContext>
    {

        [Command("purge")]
        [RequireUserPermission(GuildPermission.Administrator)]
        [RequireBotPermission(ChannelPermission.ManageMessages)]

        public async Task Run(uint msgnum)
        {
            if (msgnum < 1)
            {
                msgnum = 1;
            }
            else if (msgnum > 100)
            {
                msgnum = 100;
            }

            var bulk = await this.Context.Channel.GetMessagesAsync((int)msgnum + 1).Flatten();
            await this.Context.Channel.DeleteMessagesAsync(bulk);
            const int delay = 4500;
            var c = await this.ReplyAsync($"Purge of " + msgnum + " message(s) completed. _This message will auto-destruct in " + delay+500 / 1000 + " seconds._");
            await Task.Delay(delay);
            var boom = await this.ReplyAsync($"_BOOM!!!_");
            await Task.Delay(500);
            await c.DeleteAsync();
            await boom.DeleteAsync();


        }
    }
}
