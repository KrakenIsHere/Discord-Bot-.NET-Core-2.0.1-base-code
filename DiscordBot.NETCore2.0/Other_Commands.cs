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
            var eb = new EmbedBuilder(); //builds an embedded message

            eb.WithTitle("Help Menu:") //Title of the embedded message
              .WithDescription("Help menu here") //Description of the embedded message
              .WithColor(Color.LightOrange) //Color of the embedded message side line
              .AddField("Field 1", "Field 1 Description") //A field with description for the embedded message
              .AddField("Field 2", "Field 2 Description")
              .AddField("Field 3", "Field 3 Description")
              .AddField("Field 4", "Field 4 Description");


            await Context.Channel.SendMessageAsync("", false, embed: eb.Build()); //Sends an embedded message
        }

        [Command("Test")] //Command
        public async Task Test([Remainder] IUser user) //IUser gets the input as a UserName
        {
            string[] output = new string[]
            {
                $"Name: {user.Username}",
                $"Activity: {user.Activity}",
                $"Status: {user.Status}"
            };


            await Context.Channel.SendMessageAsync(output.ToString()); //Sends a message
        }
    }
}
