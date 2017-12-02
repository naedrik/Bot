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
            else if (msgnum>100)
            {
                msgnum = 100;
            }

            await Context.Channel.SendMessageAsync("Are you sure you want to purge "+msgnum+" message(s)? y/n");
            uint reply = 0;
            var r = await this.Context.Channel.GetMessagesAsync((int)reply + 1).Flatten();
            if (r.Equals("y"))
            {
                var bulk = await this.Context.Channel.GetMessagesAsync((int)msgnum + 1).Flatten();
                await this.Context.Channel.DeleteMessagesAsync(bulk);
                const int delay = 5000;
                var c = await this.ReplyAsync($"Purge completed. _This message will be deleted in {delay / 1000} seconds._");
                await Task.Delay(delay);
                await c.DeleteAsync();
            }
            else if (r.Equals("n"))
            {
                await Context.Channel.SendMessageAsync("Purging cancelled!");
            }
            else
            {
                await Context.Channel.SendMessageAsync("Purgin Terminated due to faulty reply!");
            }
            

            

        }
    }
}
