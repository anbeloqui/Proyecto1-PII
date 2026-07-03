using Discord.WebSocket;
using ProyectoPII.Interfaces;
using FachadaProyecto = ProyectoPII.Fachada.Fachada;
using ProyectoPII.Modelos;

namespace ProyectoPII.Bot.Comandos;

/// <summary>
/// Implementa el comando <c>!recomendar</c>, encargado de obtener
/// recomendaciones para el usuario que ejecutó el comando.
/// </summary>
/// <remarks>
/// <para>
/// Este comando obtiene automáticamente el usuario desde Discord y solicita
/// las recomendaciones a la Fachada.
/// </para>
/// <para>
/// Opcionalmente puede recibir un filtro para recomendar únicamente
/// canciones o películas. Si no se especifica ningún filtro, se muestran
/// recomendaciones de todos los tipos disponibles.
/// </para>
/// <para>
/// No contiene lógica de recomendación ni interactúa directamente con el
/// motor del sistema; únicamente delega la operación a la Fachada y adapta
/// el resultado para su presentación en Discord.
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

        string nombreUsuario = message.Author.Username;

        List<IRecomendable> recomendaciones =
            this.fachada.Recomendar(nombreUsuario);

        string? filtro = ObtenerFiltro(argumentos);

        if (!FiltroValido(filtro))
        {
            await message.Channel.SendMessageAsync(
                "Filtro no válido.\nUsá: !recomendar, !recomendar canciones o !recomendar peliculas.");
            return;
        }

        List<IRecomendable> recomendacionesFiltradas =
            FiltrarRecomendaciones(recomendaciones, filtro);

        if (recomendacionesFiltradas.Count == 0)
        {
            await message.Channel.SendMessageAsync(
                "No se encontraron recomendaciones para ese filtro.");
            return;
        }

        string respuesta =
            "**Recomendaciones para ti:**" +
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
    /// Filtra las recomendaciones según el tipo solicitado por el usuario.
    /// </summary>
    /// <param name="recomendaciones">Recomendaciones obtenidas desde la Fachada.</param>
    /// <param name="filtro">Tipo solicitado: canciones o peliculas.</param>
    /// <returns>Lista de recomendaciones filtradas y limitada para mostrar.</returns>
    private static List<IRecomendable> FiltrarRecomendaciones(
    List<IRecomendable> recomendaciones,
    string? filtro)
    {
        return filtro switch
        {
            "canciones" => recomendaciones
                .Where(item => item is Cancion)
                .Take(10)
                .ToList(),

            "peliculas" => recomendaciones
                .Where(item => item is Pelicula)
                .Take(10)
                .ToList(),

            _ => recomendaciones
                .Where(item => item is Cancion)
                .Take(10)
                .Concat(
                    recomendaciones
                        .Where(item => item is Pelicula)
                        .Take(10))
                .ToList()
        };
    }

    /// <summary>
    /// Obtiene el filtro solicitado por el usuario a partir de los argumentos.
    /// </summary>
    /// <param name="argumentos">Argumentos recibidos por el comando.</param>
    /// <returns>Filtro solicitado, o null si no se indicó filtro.</returns>
    private static string? ObtenerFiltro(string[] argumentos)
    {
        if (argumentos.Length == 0)
        {
            return null;
        }

        string filtro = string.Join(" ", argumentos)
            .Trim()
            .ToLowerInvariant();

        return filtro switch
        {
            "musica" or "música" or "cancion" or "canciones" => "canciones",
            "cine" or "pelicula" or "peliculas" => "peliculas",
            _ => filtro
        };
    }

    /// <summary>
    /// Indica si el filtro recibido es válido para el comando de recomendación.
    /// </summary>
    /// <param name="filtro">Filtro a validar.</param>
    /// <returns>True si el filtro es válido; false en caso contrario.</returns>
    private static bool FiltroValido(string? filtro)
    {
        return filtro is null
            or "canciones"
            or "peliculas";
    }
}