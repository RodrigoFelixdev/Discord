using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

class Program
{
    private DiscordSocketClient _client;

     public static async Task Main(string[] args)
    {
        var program = new Program();
        await program.MainAsync();
    }

    private Task LogAsync(LogMessage log)
    {
        Console.WriteLine(log.ToString());
        return Task.CompletedTask;
    }

    private async Task MessageReceivedAsync(SocketMessage message)
    {
        if (message.Author.IsBot) return;

        if (message.Content == "!ping")
        {
            await message.Channel.SendMessageAsync("!pingo");
        }
    }

    public async Task MainAsync()
    {
        _client = new DiscordSocketClient();
        _client.Log += LogAsync;
        _client.MessageReceived += MessageReceivedAsync;
        string token = "MTM3NTIxODQxMzY0NzE2NzY1MQ.G28TUK.EGSXQ0YbrJmsY9KTMbVaUw38Bcecavdcn-65X8";
        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();

        while (true)
        {
            await Task.Delay(10000);
        }
    }
}