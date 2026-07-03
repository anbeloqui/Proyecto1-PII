using Discord.WebSocket;
using ProyectoPII.Interfaces;
using ProyectoPII.Modelos;
using FachadaProyecto = ProyectoPII.Fachada.Fachada;

namespace ProyectoPII.Bot.Comandos;

/// <summary>
/// Implementa el comando <c>!consumido</c>, encargado de registrar que
/// un usuario ya consumió un elemento recomendable.
/// </summary>
/// <remarks>
/// <para>
/// Este comando obtiene automáticamente el usuario desde Discord y registra
/// una interacción de tipo <see cref="TipoInteraccion.Consumido"/> mediante
/// la Fachada.
/// </para>
/// <para>
/// No contiene lógica de recomendación ni accede directamente al historial.
/// </para>
/// </remarks>
public class ComandoConsumido : IComandoDiscord
{
    /// <summary>
    /// Fachada utilizada para acceder a la lógica del sistema.
    /// </summary>
    private readonly FachadaProyecto fachada;

    /// <summary>
    /// Obtiene el nombre utilizado para invocar este comando.
    /// </summary>
    public string Nombre => "!consumido";

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="ComandoConsumido"/>.
    /// </summary>
    /// <param name="fachada">Fachada utilizada para registrar la interacción.</param>
    /// <exception cref="ArgumentNullException">
    /// Se lanza cuando <paramref name="fachada"/> es <see langword="null"/>.
    /// </exception>
    public ComandoConsumido(FachadaProyecto fachada)
    {
        ArgumentNullException.ThrowIfNull(fachada);
        this.fachada = fachada;
    }

    /// <summary>
    /// Registra como consumido el elemento indicado por su identificador.
    /// </summary>
    /// <param name="message">Mensaje recibido desde Discord.</param>
    /// <param name="argumentos">
    /// Argumentos del comando. Debe contener el identificador del elemento
    /// que se desea marcar como consumido.
    /// </param>
    /// <returns>Una tarea asincrónica que representa la ejecución del comando.</returns>
    /// <exception cref="ArgumentNullException">
    /// Se lanza cuando <paramref name="message"/> o <paramref name="argumentos"/>
    /// son <see langword="null"/>.
    /// </exception>
    /// <remarks>
    /// Precondición: el usuario debe estar registrado en el sistema.
    /// Precondición: debe proporcionarse un identificador numérico válido.
    /// Postcondición: se registra una interacción de tipo Consumido para el usuario.
    /// </remarks>
    public async Task EjecutarAsync(SocketMessage message, string[] argumentos)
    {
        ArgumentNullException.ThrowIfNull(message);
        ArgumentNullException.ThrowIfNull(argumentos);

        if (argumentos.Length < 1 || !int.TryParse(argumentos[0], out int itemId))
        {
            await message.Channel.SendMessageAsync(
                "Uso: !consumido <id>. Utilizá el ID mostrado por !recomendar.");
            return;
        }

        string nombreUsuario = message.Author.Username;

        this.fachada.AgregarInteraccion(
            nombreUsuario,
            itemId,
            TipoInteraccion.Consumido);

        await message.Channel.SendMessageAsync(
            $"Se marcó como consumido el elemento {itemId}.");
    }
}