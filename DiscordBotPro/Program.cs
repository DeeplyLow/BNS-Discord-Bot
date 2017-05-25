using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace DiscordBotPro
{

    public class Program : ModuleBase<SocketCommandContext>
    {

        static void Main(string[] args)
        => new Program().StartAsync().GetAwaiter().GetResult();

        

        private DiscordSocketClient _client;

        private CommandHandler.CommandHandler _handler;

        public async Task StartAsync()
        {
            _client = new DiscordSocketClient();

            new CommandHandler.CommandHandler();

            string api = File.ReadLines(@"config.txt").Skip(1).Take(1).First();

            await _client.LoginAsync(TokenType.Bot, api);

            await _client.StartAsync();

            _handler = new CommandHandler.CommandHandler();

            await _handler.InitializeAsync(_client);


            Console.WriteLine("DiscordBnsBot");
            Console.WriteLine(" ");
            Console.WriteLine("You are connecting to Discord using api: " + api);
            Console.WriteLine(" ");
            Console.WriteLine("You can change api settings inside config.txt");




            await Task.Delay(-1);



        }
    }
}
