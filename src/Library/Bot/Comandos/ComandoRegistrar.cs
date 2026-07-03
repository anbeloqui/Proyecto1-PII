using Discord.WebSocket;
using ProyectoPII.Interfaces;
using FachadaProyecto = ProyectoPII.Fachada.Fachada;

namespace ProyectoPII.Bot.Comandos;

/// <summary>
/// Implementa el comando <c>!registrar</c>, encargado de registrar en el sistema
/// al usuario que ejecutó el comando.
/// </summary>
/// <remarks>
/// <para>
/// Este comando obtiene automáticamente el usuario desde Discord y delega
/// el registro a la Fachada del sistema.
/// </para>
/// <para>
/// No accede directamente a modelos, estrategias, motores de recomendación
/// ni componentes internos de la aplicación.
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
/// <item><description>El usuario identificado por <see cref="SocketMessage.Author"/> queda registrado mediante la Fachada.</description></item>
/// <item><description>Se envía un mensaje informando el resultado de la operación.</description></item>
/// </list>
/// </para>
/// </remarks>
public class ComandoRegistrar : IComandoDiscord
{
    /// <summary>
    /// Fachada utilizada para acceder a la lógica del sistema.
    /// </summary>
    private readonly FachadaProyecto fachada;

    /// <summary>
    /// Obtiene el nombre utilizado para invocar este comando.
    /// </summary>
    /// <value>
    /// La cadena <c>!registrar</c>.
    /// </value>
    public string Nombre => "!registrar";

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="ComandoRegistrar"/>.
    /// </summary>
    /// <param name="fachada">
    /// Fachada utilizada para realizar el registro de usuarios.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Se lanza cuando <paramref name="fachada"/> es <see langword="null"/>.
    /// </exception>
    /// <remarks>
    /// Precondiciones:
    /// <list type="bullet">
    /// <item><description><paramref name="fachada"/> debe ser distinto de <see langword="null"/>.</description></item>
    /// </list>
    ///
    /// Postcondiciones:
    /// <list type="bullet">
    /// <item><description>La instancia queda preparada para registrar usuarios.</description></item>
    /// </list>
    /// </remarks>
    public ComandoRegistrar(FachadaProyecto fachada)
    {
        ArgumentNullException.ThrowIfNull(fachada);

        this.fachada = fachada;
    }

    /// <summary>
    /// Registra al usuario que ejecutó el comando.
    /// </summary>
    /// <param name="message">
    /// Mensaje recibido desde Discord.
    /// </param>
    /// <param name="argumentos">
    /// Argumentos enviados junto al comando. Este comando no requiere argumentos.
    /// </param>
    /// <returns>
    /// Una tarea asincrónica que representa la ejecución del comando.
    /// </returns>
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
    /// <item><description>El usuario identificado por <see cref="SocketMessage.Author"/> queda registrado mediante la Fachada.</description></item>
    /// <item><description>Se informa al usuario el resultado de la operación.</description></item>
    /// </list>
    /// </remarks>
    public async Task EjecutarAsync(SocketMessage message, string[] argumentos)
    {
        ArgumentNullException.ThrowIfNull(message);
        ArgumentNullException.ThrowIfNull(argumentos);

        string nombre = message.Author.Username;
        int id = Math.Abs(message.Author.Id.GetHashCode());

        this.fachada.RegistrarUsuario(id, nombre);

        await message.Channel.SendMessageAsync(
            $"Usuario {nombre} registrado.");
    }
}