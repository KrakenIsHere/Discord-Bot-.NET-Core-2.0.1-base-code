using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace DiscordBot.NETCore2._0
{
    public class Commands : ModuleBase
    {
        [Command("Hello")] //Command
        [Summary("Says Ello!!")] //Description
        [Alias("Hi")] //Other uses for this command
        public async Task Hello([Remainder] string remainder) //Remainder come after the command itself
        {
            if (remainder == "1")
            {
                await Context.Channel.SendMessageAsync("Ello!!");
            }
            else if (remainder == "2")
            {
                await Context.Channel.SendMessageAsync("Hello :grinning:");
            }
            else
            {
                await Context.Channel.SendMessageAsync("That's not a valid number :crying_cat_face:");
            }
        }

        [Command("Lol")] //Command
        [Summary("Replys with LOL")] //Description
        public async Task Hello()
        {
                await Context.Channel.SendMessageAsync("LOL");
        }
    }
}
