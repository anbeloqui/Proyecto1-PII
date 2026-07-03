using Discord.WebSocket;
using ProyectoPII.Interfaces;
using FachadaProyecto = ProyectoPII.Fachada.Fachada;
using ProyectoPII.Modelos;

namespace ProyectoPII.Bot.Comandos;

/// <summary>
/// Implementa el comando <c>!historial</c>, encargado de mostrar el historial
/// del usuario que ejecutó el comando.
/// </summary>
/// <remarks>
/// <para>
/// Este comando obtiene automáticamente el usuario desde Discord y solicita
/// su historial a la Fachada.
/// </para>
/// <para>
/// No accede directamente al dominio, al motor de recomendación ni a las
/// estructuras internas del historial.
/// </para>
/// </remarks>
public class ComandoHistorial : IComandoDiscord
{
    /// <summary>
    /// Fachada utilizada para acceder a la lógica del sistema.
    /// </summary>
    private readonly FachadaProyecto fachada;

    /// <summary>
    /// Obtiene el nombre utilizado para invocar este comando.
    /// </summary>
    public string Nombre => "!historial";

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="ComandoHistorial"/>.
    /// </summary>
    /// <param name="fachada">Fachada utilizada para consultar el historial.</param>
    /// <exception cref="ArgumentNullException">
    /// Se lanza cuando <paramref name="fachada"/> es <see langword="null"/>.
    /// </exception>
    public ComandoHistorial(FachadaProyecto fachada)
    {
        ArgumentNullException.ThrowIfNull(fachada);
        this.fachada = fachada;
    }

    /// <summary>
    /// Muestra el historial del usuario que ejecutó el comando.
    /// </summary>
    /// <param name="message">Mensaje recibido desde Discord.</param>
    /// <param name="argumentos">
    /// Argumentos enviados junto al comando. Este comando no requiere argumentos.
    /// </param>
    /// <returns>Una tarea asincrónica que representa la ejecución del comando.</returns>
    /// <exception cref="ArgumentNullException">
    /// Se lanza cuando <paramref name="message"/> o <paramref name="argumentos"/> son <see langword="null"/>.
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
    /// <item><description>El historial se obtiene mediante la Fachada para el usuario identificado por <see cref="SocketMessage.Author"/>.</description></item>
    /// <item><description>La respuesta es enviada al canal desde el cual se ejecutó el comando.</description></item>
    /// </list>
    /// </remarks>
    public async Task EjecutarAsync(SocketMessage message, string[] argumentos)
    {
        ArgumentNullException.ThrowIfNull(message);
        ArgumentNullException.ThrowIfNull(argumentos);

        string nombreUsuario = message.Author.Username;

        var historial = this.fachada.VerHistorial(nombreUsuario);

        if (historial.Count == 0)
        {
            await message.Channel.SendMessageAsync("Tu historial está vacío.");
            return;
        }

        List<IRecomendable> items = this.fachada.ObtenerItems();

        string respuesta =
            "**Tu historial:**" +
            Environment.NewLine +
            string.Join(
                Environment.NewLine,
                historial.Select(interaccion =>
                    FormatearInteraccion(interaccion, items)));

        await message.Channel.SendMessageAsync(respuesta);
    }

    /// <summary>
    /// Genera el texto visible de una interacción del historial.
    /// </summary>
    /// <param name="interaccion">Interacción que se desea mostrar.</param>
    /// <param name="items">Elementos disponibles en el catálogo.</param>
    /// <returns>Texto formateado de la interacción.</returns>
    private static string FormatearInteraccion(
        Interaccion interaccion,
        List<IRecomendable> items)
    {
        IRecomendable? item = items.FirstOrDefault(i => i.Id == interaccion.ItemId);

        string elemento = item is null
            ? $"ítem {interaccion.ItemId}"
            : FormatearItem(item);

        return $"{ObtenerIconoInteraccion(interaccion.Tipo)} {interaccion.Tipo} - {elemento} - {interaccion.Fecha:g}";
    }

    /// <summary>
    /// Genera el texto visible de un elemento recomendable.
    /// </summary>
    /// <param name="item">Elemento recomendable que se desea mostrar.</param>
    /// <returns>Texto formateado con tipo, identificador y nombre.</returns>
    private static string FormatearItem(IRecomendable item)
    {
        return item switch
        {
            Cancion => $"🎵 [{item.Id}] {item.Nombre}",
            Pelicula => $"🎬 [{item.Id}] {item.Nombre}",
            _ => $"• [{item.Id}] {item.Nombre}"
        };
    }

    /// <summary>
    /// Obtiene el ícono asociado al tipo de interacción.
    /// </summary>
    /// <param name="tipo">Tipo de interacción registrada.</param>
    /// <returns>Ícono representativo del tipo de interacción.</returns>
    private static string ObtenerIconoInteraccion(TipoInteraccion tipo)
    {
        return tipo switch
        {
            TipoInteraccion.Like => "👍",
            TipoInteraccion.Dislike => "👎",
            TipoInteraccion.Guardado => "📌",
            TipoInteraccion.Consumido => "✅",
            _ => "•"
        };
    }
}