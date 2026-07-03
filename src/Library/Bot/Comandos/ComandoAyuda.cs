using Discord.WebSocket;
using ProyectoPII.Interfaces;

namespace ProyectoPII.Bot.Comandos;

/// <summary>
/// Comando que muestra la ayuda general del bot.
/// </summary>
public class ComandoAyuda : IComandoDiscord
{
    /// <summary>
    /// Nombre del comando.
    /// </summary>
    public string Nombre => "!ayuda";

    /// <summary>
    /// Ejecuta el comando de ayuda.
    /// </summary>
    /// <param name="message">Mensaje recibido desde Discord.</param>
    /// <param name="argumentos">Argumentos del comando.</param>
    public async Task EjecutarAsync(SocketMessage message, string[] argumentos)
    {
        ArgumentNullException.ThrowIfNull(message);
        ArgumentNullException.ThrowIfNull(argumentos);

        string ayuda = """
        👋 **Bienvenido al Sistema de Recomendaciones**

        Este bot te permite recibir recomendaciones de canciones y películas según tus preferencias.

        **Comandos disponibles:**

        `!registrar`
        Registra tu usuario de Discord en el sistema.

        `!preferencia <preferencia>`
        Agrega una preferencia a tu perfil.
        Ejemplo: `!preferencia rock`

        `!recomendar`
        Muestra recomendaciones según tus preferencias.

        `!historial`
        Muestra tu historial de interacciones.

        `!like <id>`
        Marca una recomendación como gustada.
        Ejemplo: `!like 1001`

        `!dislike <id>`
        Marca una recomendación como no gustada.
        Ejemplo: `!dislike 1001`

        `!guardar <id>`
        Guarda una recomendación para ver o escuchar después.
        Ejemplo: `!guardar 1001`

        **Preferencias que podés probar:**

        `rock`, `pop`, `latino`, `reggaeton`, `electronica`, `romantica`, `accion`, `ciencia ficcion`, `terror`, `comedia`, `drama`, `superheroes`, `fantasia`, `aventura`

        **Ejemplo rápido:**

        `!registrar`
        `!preferencia accion`
        `!recomendar`
        """;

        await message.Channel.SendMessageAsync(ayuda);
    }
}