using Discord.WebSocket;
using ProyectoPII.Interfaces;

namespace ProyectoPII.Bot.Comandos;

/// <summary>
/// Comando utilizado para verificar que el bot responde.
/// </summary>
public class ComandoPing : IComandoDiscord
{
    public string Nombre => "!ping";

    public async Task EjecutarAsync(SocketMessage message, string[] argumentos)
    {
        await message.Channel.SendMessageAsync("Pong.");
    }
}