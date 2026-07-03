using Discord.WebSocket;
using ProyectoPII.Interfaces;
using FachadaProyecto = ProyectoPII.Fachada.Fachada;
using ProyectoPII.Modelos;

namespace ProyectoPII.Bot.Comandos;

/// <summary>
/// Implementa el comando <c>!recomendar</c>, encargado de obtener
/// recomendaciones de canciones o películas para el usuario que ejecutó el comando.
/// </summary>
/// <remarks>
/// <para>
/// Este comando obtiene automáticamente el usuario desde Discord y solicita
/// las recomendaciones a la Fachada.
/// </para>
/// <para>
/// El usuario debe indicar si desea recomendaciones de canciones o de películas.
/// </para>
/// <para>
/// No contiene lógica de recomendación ni interactúa directamente con el
/// motor del sistema.
/// </para>
/// </remarks>
public class ComandoRecomendar : IComandoDiscord
{
    /// <summary>
    /// Fachada utilizada para acceder a la lógica del sistema.
    /// </summary>
    private readonly FachadaProyecto fachada;

    /// <summary>
    /// Obtiene el nombre utilizado para invocar este comando.
    /// </summary>
    public string Nombre => "!recomendar";

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="ComandoRecomendar"/>.
    /// </summary>
    /// <param name="fachada">
    /// Fachada utilizada para generar recomendaciones.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Se lanza cuando <paramref name="fachada"/> es <see langword="null"/>.
    /// </exception>
    public ComandoRecomendar(FachadaProyecto fachada)
    {
        ArgumentNullException.ThrowIfNull(fachada);

        this.fachada = fachada;
    }

    /// <summary>
    /// Obtiene recomendaciones de canciones o películas para el usuario que ejecutó el comando.
    /// </summary>
    /// <param name="message">
    /// Mensaje recibido desde Discord.
    /// </param>
    /// <param name="argumentos">
    /// Argumentos enviados junto al comando. Debe indicarse <c>canciones</c> o <c>peliculas</c>.
    /// </param>
    /// <returns>
    /// Una tarea asincrónica que representa la ejecución del comando.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Se lanza cuando <paramref name="message"/> o
    /// <paramref name="argumentos"/> son <see langword="null"/>.
    /// </exception>
    public async Task EjecutarAsync(SocketMessage message, string[] argumentos)
    {
        ArgumentNullException.ThrowIfNull(message);
        ArgumentNullException.ThrowIfNull(argumentos);

        if (argumentos.Length == 0)
        {
            await message.Channel.SendMessageAsync(
                "Debés indicar qué querés recomendar: `!recomendar canciones` o `!recomendar peliculas`.");

            return;
        }

        string filtro = string.Join(" ", argumentos)
            .ToLowerInvariant()
            .Replace("á", "a")
            .Replace("é", "e")
            .Replace("í", "i")
            .Replace("ó", "o")
            .Replace("ú", "u");

        if (!EsFiltroValido(filtro))
        {
            await message.Channel.SendMessageAsync(
                "Tipo de recomendación no válido. Usá `!recomendar canciones` o `!recomendar peliculas`.");

            return;
        }

        string nombreUsuario = message.Author.Username;

        List<IRecomendable> recomendaciones = this.fachada.Recomendar(nombreUsuario);

        List<IRecomendable> recomendacionesFiltradas =
            FiltrarRecomendaciones(recomendaciones, filtro);

        if (recomendacionesFiltradas.Count == 0)
        {
            await message.Channel.SendMessageAsync(
                $"No se encontraron recomendaciones de {ObtenerNombreTipo(filtro)} para tus preferencias.");

            return;
        }

        string respuesta =
            ObtenerTitulo(filtro) +
            Environment.NewLine +
            Environment.NewLine +
            string.Join(
                Environment.NewLine,
                recomendacionesFiltradas.Select(FormatearRecomendacion));

        await message.Channel.SendMessageAsync(respuesta);
    }

    /// <summary>
    /// Genera el texto visible de una recomendación para Discord.
    /// </summary>
    /// <param name="item">Elemento recomendable que se desea mostrar.</param>
    /// <returns>Texto formateado con tipo, identificador y nombre del elemento.</returns>
    private static string FormatearRecomendacion(IRecomendable item)
    {
        return item switch
        {
            Cancion => $"🎵 [{item.Id}] {item.Nombre}",
            Pelicula => $"🎬 [{item.Id}] {item.Nombre}",
            _ => $"• [{item.Id}] {item.Nombre}"
        };
    }

    /// <summary>
    /// Valida si el filtro ingresado corresponde a un tipo de recomendación permitido.
    /// </summary>
    /// <param name="filtro">Filtro ingresado por el usuario.</param>
    /// <returns><see langword="true"/> si el filtro es válido; de lo contrario, <see langword="false"/>.</returns>
    private static bool EsFiltroValido(string filtro)
    {
        return filtro is "cancion" or "canciones" or "pelicula" or "peliculas";
    }

    /// <summary>
    /// Filtra las recomendaciones según el tipo solicitado por el usuario.
    /// </summary>
    /// <param name="recomendaciones">Recomendaciones obtenidas desde la Fachada.</param>
    /// <param name="filtro">Tipo solicitado: canciones o peliculas.</param>
    /// <returns>Lista de recomendaciones filtradas y limitada para mostrar.</returns>
    private static List<IRecomendable> FiltrarRecomendaciones(
        List<IRecomendable> recomendaciones,
        string filtro)
    {
        return filtro switch
        {
            "canciones" or "cancion" => recomendaciones
                .Where(item => item is Cancion)
                .Take(10)
                .ToList(),

            "peliculas" or "pelicula" => recomendaciones
                .Where(item => item is Pelicula)
                .Take(10)
                .ToList(),

            _ => new List<IRecomendable>()
        };
    }

    /// <summary>
    /// Obtiene el título que se mostrará en Discord según el tipo solicitado.
    /// </summary>
    /// <param name="filtro">Filtro ingresado por el usuario.</param>
    /// <returns>Título del mensaje de recomendaciones.</returns>
    private static string ObtenerTitulo(string filtro)
    {
        return filtro is "canciones" or "cancion"
            ? "**🎵 Recomendaciones de canciones:**"
            : "**🎬 Recomendaciones de películas:**";
    }

    /// <summary>
    /// Obtiene el nombre del tipo de recomendación para mensajes al usuario.
    /// </summary>
    /// <param name="filtro">Filtro ingresado por el usuario.</param>
    /// <returns>Nombre del tipo solicitado.</returns>
    private static string ObtenerNombreTipo(string filtro)
    {
        return filtro is "canciones" or "cancion"
            ? "canciones"
            : "películas";
    }
}