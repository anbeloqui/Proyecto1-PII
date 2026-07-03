using Discord.WebSocket;
using ProyectoPII.Interfaces;
using FachadaProyecto = ProyectoPII.Fachada.Fachada;

namespace ProyectoPII.Bot.Comandos;

/// <summary>
/// Implementa el comando <c>!guardar</c>, encargado de guardar un elemento
/// recomendable para que el usuario pueda verlo después.
/// </summary>
/// <remarks>
/// <para>
/// Este comando obtiene automáticamente el usuario desde Discord y registra
/// la acción de guardado mediante la Fachada.
/// </para>
/// <para>
/// No accede directamente al historial, al dominio ni al motor de recomendación.
/// </para>
/// </remarks>
public class ComandoGuardar : IComandoDiscord
{
    /// <summary>
    /// Fachada utilizada para acceder a la lógica del sistema.
    /// </summary>
    private readonly FachadaProyecto fachada;

    /// <summary>
    /// Obtiene el nombre utilizado para invocar este comando.
    /// </summary>
    public string Nombre => "!guardar";

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="ComandoGuardar"/>.
    /// </summary>
    /// <param name="fachada">Fachada utilizada para guardar elementos para después.</param>
    /// <exception cref="ArgumentNullException">
    /// Se lanza cuando <paramref name="fachada"/> es <see langword="null"/>.
    /// </exception>
    public ComandoGuardar(FachadaProyecto fachada)
    {
        ArgumentNullException.ThrowIfNull(fachada);
        this.fachada = fachada;
    }

    /// <summary>
    /// Guarda un elemento recomendable para el usuario que ejecutó el comando.
    /// </summary>
    /// <param name="message">Mensaje recibido desde Discord.</param>
    /// <param name="argumentos">
    /// Argumentos del comando. El primer argumento corresponde al identificador del elemento.
    /// </param>
    /// <returns>Una tarea asincrónica que representa la ejecución del comando.</returns>
    /// <exception cref="ArgumentNullException">
    /// Se lanza cuando <paramref name="message"/> o <paramref name="argumentos"/> son <see langword="null"/>.
    /// </exception>
    public async Task EjecutarAsync(SocketMessage message, string[] argumentos)
    {
        ArgumentNullException.ThrowIfNull(message);
        ArgumentNullException.ThrowIfNull(argumentos);

        if (argumentos.Length < 1)
        {
            await message.Channel.SendMessageAsync("Uso: !guardar <idItem>");
            return;
        }

        if (!int.TryParse(argumentos[0], out int itemId))
        {
            await message.Channel.SendMessageAsync(
                "El identificador del elemento debe ser un número.");
            return;
        }

        string nombreUsuario = message.Author.Username;

        this.fachada.GuardarParaDespues(nombreUsuario, itemId);

        await message.Channel.SendMessageAsync(
            $"Se guardó el elemento {itemId} para verlo después.");
    }
}