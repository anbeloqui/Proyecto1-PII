using Discord.WebSocket;
using ProyectoPII.Interfaces;
using FachadaProyecto = ProyectoPII.Fachada.Fachada;

namespace ProyectoPII.Bot.Comandos;

/// <summary>
/// Implementa el comando <c>!preferencia</c>, encargado de agregar una
/// preferencia a un usuario registrado.
/// </summary>
/// <remarks>
/// <para>
/// Este comando obtiene el nombre del usuario y la preferencia indicada en
/// el mensaje de Discord y delega la operación a la Fachada.
/// </para>
/// <para>
/// No contiene lógica del dominio ni interactúa directamente con el motor
/// de recomendación.
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
/// <item><description>La preferencia queda registrada para el usuario si la operación es válida.</description></item>
/// <item><description>Se informa el resultado mediante un mensaje en Discord.</description></item>
/// </list>
/// </para>
/// </remarks>
public class ComandoPreferencia : IComandoDiscord
{
    /// <summary>
    /// Fachada utilizada para acceder a la lógica del sistema.
    /// </summary>
    private readonly FachadaProyecto fachada;

    /// <summary>
    /// Obtiene el nombre utilizado para invocar este comando.
    /// </summary>
    public string Nombre => "!preferencia";

    /// <summary>
    /// Inicializa una nueva instancia de <see cref="ComandoPreferencia"/>.
    /// </summary>
    /// <param name="fachada">
    /// Fachada utilizada para registrar preferencias.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Se lanza cuando <paramref name="fachada"/> es <see langword="null"/>.
    /// </exception>
    public ComandoPreferencia(FachadaProyecto fachada)
    {
        ArgumentNullException.ThrowIfNull(fachada);

        this.fachada = fachada;
    }

    /// <summary>
    /// Agrega una preferencia al usuario que ejecutó el comando.
    /// </summary>
    /// <param name="message">
    /// Mensaje recibido desde Discord.
    /// </param>
    /// <param name="argumentos">
    /// Argumentos del comando.
    /// El primer argumento corresponde a la preferencia que se desea agregar.
    /// El usuario se obtiene automáticamente desde <see cref="SocketMessage.Author"/>.
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
    /// <item><description>Si los argumentos son válidos, la preferencia se agrega al usuario identificado por <see cref="SocketMessage.Author"/> mediante la Fachada.</description></item>
    /// <item><description>Se informa al usuario el resultado de la operación.</description></item>
    /// </list>
    /// </remarks>
    public async Task EjecutarAsync(SocketMessage message, string[] argumentos)
    {
        ArgumentNullException.ThrowIfNull(message);
        ArgumentNullException.ThrowIfNull(argumentos);

        if (argumentos.Length < 1)
        {
            await message.Channel.SendMessageAsync("Uso: !preferencia <preferencia>");
            return;
        }

        string nombreUsuario = message.Author.Username;
        string preferencia = argumentos[0];

        this.fachada.AgregarPreferencia(nombreUsuario, preferencia);

        await message.Channel.SendMessageAsync(
            $"Se agregó la preferencia \"{preferencia}\" al usuario {nombreUsuario}.");
    }
}