using Discord.WebSocket;
using ProyectoPII.Interfaces;
using ProyectoPII.Modelos;
using FachadaProyecto = ProyectoPII.Fachada.Fachada;

namespace ProyectoPII.Bot.Comandos;

/// <summary>
/// Implementa el comando <c>!dislike</c>, encargado de registrar un "No me gusta"
/// sobre un elemento recomendable.
/// </summary>
/// <remarks>
/// Este comando obtiene el usuario desde Discord y registra la interacción
/// mediante la Fachada.
/// </remarks>
public class ComandoDislike : IComandoDiscord
{
    /// <summary>
    /// Fachada utilizada para acceder a la lógica del sistema.
    /// </summary>
    private readonly FachadaProyecto fachada;

    /// <summary>
    /// Obtiene el nombre utilizado para invocar este comando.
    /// </summary>
    public string Nombre => "!dislike";

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="ComandoDislike"/>.
    /// </summary>
    /// <param name="fachada">
    /// Fachada utilizada para registrar la interacción.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Se lanza cuando <paramref name="fachada"/> es <see langword="null"/>.
    /// </exception>
    public ComandoDislike(FachadaProyecto fachada)
    {
        ArgumentNullException.ThrowIfNull(fachada);
        this.fachada = fachada;
    }

    /// <summary>
    /// Registra un "No me gusta" para un elemento recomendable.
    /// </summary>
    /// <param name="message">
    /// Mensaje recibido desde Discord.
    /// </param>
    /// <param name="argumentos">
    /// El primer argumento corresponde al identificador del elemento.
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

        if (argumentos.Length < 1)
        {
            await message.Channel.SendMessageAsync(
                "Uso: !dislike <idItem>");
            return;
        }

        if (!int.TryParse(argumentos[0], out int itemId))
        {
            await message.Channel.SendMessageAsync(
                "El identificador del elemento debe ser un número.");
            return;
        }

        string nombreUsuario = message.Author.Username;

        this.fachada.AgregarInteraccion(
            nombreUsuario,
            itemId,
            TipoInteraccion.Dislike);

        await message.Channel.SendMessageAsync(
            $"Se registró un DISLIKE para el elemento {itemId}.");
    }
}