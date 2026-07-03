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

        Este bot permite recibir recomendaciones de canciones y películas según tus preferencias.

        ⚠️ **Importante**
        Las preferencias deben escribirse exactamente como aparecen en esta ayuda.
        Si una palabra está mal escrita, el sistema puede no encontrar recomendaciones.

        **Comandos disponibles**

        `!registrar`
        Registra tu usuario de Discord en el sistema.

        `!preferencia <preferencia>`
        Agrega una preferencia a tu perfil.

        Ejemplos:
        `!preferencia rock`
        `!preferencia accion`
        `!preferencia ciencia ficcion`

        `!recomendar canciones`
        Muestra recomendaciones de canciones según tus preferencias.

        `!recomendar peliculas`
        Muestra recomendaciones de películas según tus preferencias.

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

        **Ejemplo rápido para canciones**

        `!registrar`
        `!preferencia rock`
        `!recomendar canciones`

        **Ejemplo rápido para películas**

        `!registrar`
        `!preferencia accion`
        `!recomendar peliculas`

        **Preferencias disponibles para canciones**

        `rock`
        `pop`
        `latino`
        `reggaeton`
        `electronica`
        `romantica`
        `clasico`
        `baile`
        `fiesta`
        `motivacional`
        `guitarra`
        `vocal`
        `piano`
        `soul`
        `funk`
        `disco`
        `rnb`
        `rap`
        `hiphop`
        `metal`
        `grunge`
        `folk`
        `alternativo`
        `emocional`
        `triste`
        `tranquila`
        `punk`
        `alegre`
        `country`
        `salsa`
        `bachata`
        `ska`
        `kpop`
        `moderno`
        `progresivo`

        **Preferencias disponibles para películas**

        `accion`
        `aventura`
        `ciencia ficcion`
        `drama`
        `comedia`
        `fantasia`
        `epica`
        `crimen`
        `terror`
        `suspenso`
        `misterio`
        `historia`
        `guerra`
        `romantica`
        `animacion`
        `familia`
        `musical`
        `superheroes`
        `western`
        `biografica`
        `tecnologia`
        `venganza`
        `cine`
        `espionaje`
        `autos`
        `deporte`
        `emocional`
        `dialogo`
        `navidad`
        `juventud`
        `amistad`
        `supervivencia`
        `sobrenatural`
        `clasico`

        **Recordatorio**
        Para canciones usá:
        `!recomendar canciones`

        Para películas usá:
        `!recomendar peliculas`
        """;

        await message.Channel.SendMessageAsync(ayuda);
    }
}