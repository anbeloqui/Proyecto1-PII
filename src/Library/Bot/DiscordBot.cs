using Discord;
using Discord.WebSocket;
using FachadaProyecto = ProyectoPII.Fachada.Fachada;

namespace ProyectoPII.Bot;

/// <summary>
/// Bot de Discord encargado de recibir y responder comandos.
/// </summary>
public class DiscordBot
{
    private readonly DiscordSocketClient client;
    private readonly ProyectoPII.Fachada.Fachada fachada;

    /// <summary>
    /// Inicializa una nueva instancia del bot.s
    /// </summary>
    public DiscordBot()
    {
        fachada = new FachadaProyecto();

        client = new DiscordSocketClient(new DiscordSocketConfig
        {
            GatewayIntents =
                GatewayIntents.Guilds |
                GatewayIntents.GuildMessages |
                GatewayIntents.MessageContent
        });
    }

    /// <summary>
    /// Inicia sesión y conecta el bot a Discord.
    /// </summary>
    /// <param name="token">Token del bot.</param>
    public async Task IniciarAsync(string token)
    {
        client.Log += LogAsync;
        client.MessageReceived += MessageReceivedAsync;

        await client.LoginAsync(TokenType.Bot, token);
        await client.StartAsync();

        await Task.Delay(-1);
    }

    /// <summary>
    /// Maneja los mensajes recibidos.
    /// </summary>
    private async Task MessageReceivedAsync(SocketMessage message)
    {
        if (message.Author.IsBot)
        {
            return;
        }

        string[] partes = message.Content.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (partes.Length == 0)
        {
            return;
        }

        switch (partes[0].ToLower())
        {
            case "!ping":
                await message.Channel.SendMessageAsync("¡Pong!");
                break;

            case "!registrar":

                if (partes.Length < 2)
                {
                    await message.Channel.SendMessageAsync(
                        "Uso: !registrar <nombre>");
                    break;
                }

                int id = Math.Abs(partes[1].GetHashCode());

                fachada.RegistrarUsuario(id, partes[1]);

                await message.Channel.SendMessageAsync(
                    $"✅ Usuario **{partes[1]}** registrado.");

                break;
        }
    }

    /// <summary>
    /// Muestra los mensajes de log del cliente.
    /// </summary>
    private Task LogAsync(LogMessage log)
    {
        Console.WriteLine(log.ToString());
        return Task.CompletedTask;
    }
}