using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace DiscordBot.NETCore2._0
{
    public class Other_Commands : ModuleBase
    {
        [Command("Help")] //Command
        public async Task Help()
        {
            var eb = new EmbedBuilder();

            eb.WithTitle("Help Menu:")
              .WithDescription("Help menu here")
              .WithColor(Color.LightOrange)
              .AddField("Field 1", "Field 1 Description")
              .AddField("Field 2", "Field 2 Description")
              .AddField("Field 3", "Field 3 Description")
              .AddField("Field 4", "Field 4 Description");


            await Context.Channel.SendMessageAsync("", false, embed: eb.Build());
        }
    }
}
