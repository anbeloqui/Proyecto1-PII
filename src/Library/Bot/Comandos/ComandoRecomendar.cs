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
/// No contiene lógica de recomendación ni interactúa directamente con el
/// motor del sistema.
/// </para>
/// <para>
/// Precondiciones:
/// <list type="bullet">
/// <item><description>La Fachada debe estar correctamente inicializada.</description></item>
/// </list>
/// </para>
/// <para>
/// Postcondiciones:
/// <list type="bullet">
/// <item><description>Se envía al usuario la lista de recomendaciones obtenidas.</description></item>
/// </list>
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
    /// Obtiene recomendaciones para el usuario que ejecutó el comando.
    /// </summary>
    /// <param name="message">
    /// Mensaje recibido desde Discord.
    /// </param>
    /// <param name="argumentos">
    /// Argumentos enviados junto al comando.
    /// Este comando no requiere argumentos.
    /// </param>
    /// <returns>
    /// Una tarea asincrónica que representa la ejecución del comando.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Se lanza cuando <paramref name="message"/> o
    /// <paramref name="argumentos"/> son <see langword="null"/>.
    /// </exception>
    /// <remarks>
    /// Precondiciones:
    /// <list type="bullet">
    /// <item><description><paramref name="message"/> debe ser distinto de <see langword="null"/>.</description></item>
    /// <item><description><paramref name="argumentos"/> debe ser distinto de <see langword="null"/>.</description></item>
    /// </list>
    ///
    /// Postcondiciones:
    /// <list type="bullet">
    /// <item><description>Las recomendaciones se obtienen mediante la Fachada para el usuario identificado por <see cref="SocketMessage.Author"/>.</description></item>
    /// <item><description>La respuesta es enviada al canal desde el cual se ejecutó el comando.</description></item>
    /// </list>
    /// </remarks>
    public async Task EjecutarAsync(SocketMessage message, string[] argumentos)
    {
        ArgumentNullException.ThrowIfNull(message);
        ArgumentNullException.ThrowIfNull(argumentos);

        string nombreUsuario = message.Author.Username;

        var recomendaciones = this.fachada.Recomendar(nombreUsuario);

        string? filtro = argumentos.Length > 0
            ? string.Join(" ", argumentos).ToLowerInvariant()
            : null;

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
    /// <param name="filtro">Tipo solicitado: canciones, peliculas o null.</param>
    /// <returns>Lista de recomendaciones filtradas y limitada para mostrar.</returns>
    private static List<IRecomendable> FiltrarRecomendaciones(
        List<IRecomendable> recomendaciones,
        string? filtro)
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

            _ => recomendaciones
                .GroupBy(item => item.GetType())
                .SelectMany(grupo => grupo.Take(10))
                .ToList()
        };
    }
}