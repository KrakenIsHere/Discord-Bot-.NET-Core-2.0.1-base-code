using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DiscordBot.NETCore2._0
{
    class Program : ModuleBase
    {
        public static DiscordSocketClient client;
        private CommandService commands;

        string token = "Mzc0NDU5NDI0MzgwNjgyMjUx.D0XKjA.b0EueOD5Vl-HH3zNjTyiYyTu5XA"; //Your token here!

        public IServiceProvider ConfigServ()
        {
            var services = new ServiceCollection()
                .AddSingleton(client)
                .AddSingleton(commands)
                .BuildServiceProvider();

            return services;
        }

        public static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            client = new DiscordSocketClient();
            commands = new CommandService();

            await InstallCommands();

            client.Log += Log;

            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            await Task.Delay(-1);
        }

        public async Task InstallCommands()
        {
            client.MessageReceived += HandleCommand;
            await commands.AddModulesAsync(Assembly.GetEntryAssembly(), ConfigServ());
        }

        private async Task HandleCommand(SocketMessage arg)
        {
            var msg = arg as SocketUserMessage;
            if (msg == null) return;
            var context = new CommandContext(client, msg);
            int pos = 0;

            //Set Custom Prefix here
            if (msg.HasCharPrefix('!', ref pos)) //This char is your prefix (The symbol before a command)
            {
                var result = await commands.ExecuteAsync(context, pos, ConfigServ());

                if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {
                    Console.WriteLine(result.ErrorReason);
                }
            }
        }

        private Task Log(LogMessage logmessage)
        {
            Console.WriteLine(logmessage.ToString());
            return Task.CompletedTask;
        }
    }
}
