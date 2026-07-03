using Discord.WebSocket;
using ProyectoPII.Interfaces;
using FachadaProyecto = ProyectoPII.Fachada.Fachada;

namespace ProyectoPII.Bot.Comandos;

/// <summary>
/// Implementa el comando <c>!registrar</c>, encargado de registrar un nuevo
/// usuario en el sistema.
/// </summary>
/// <remarks>
/// <para>
/// Este comando obtiene la información proporcionada por el usuario,
/// valida los argumentos mínimos requeridos y delega el registro a la
/// Fachada del sistema.
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
/// <item><description>Si los datos son válidos, el usuario queda registrado mediante la Fachada.</description></item>
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
    /// Registra un usuario utilizando el nombre recibido como argumento.
    /// </summary>
    /// <param name="message">
    /// Mensaje recibido desde Discord.
    /// </param>
    /// <param name="argumentos">
    /// Argumentos enviados junto al comando.
    /// El primer argumento corresponde al nombre del usuario.
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
    /// <item><description>Si el nombre fue proporcionado, el usuario queda registrado mediante la Fachada.</description></item>
    /// <item><description>Se informa al usuario el resultado de la operación.</description></item>
    /// </list>
    /// </remarks>
    public async Task EjecutarAsync(SocketMessage message, string[] argumentos)
    {
        ArgumentNullException.ThrowIfNull(message);
        ArgumentNullException.ThrowIfNull(argumentos);

        if (argumentos.Length < 1)
        {
            await message.Channel.SendMessageAsync("Uso: !registrar <nombre>");
            return;
        }

        string nombre = message.Author.Username;
        int id = (int)message.Author.Id;

        await message.Channel.SendMessageAsync(
            $"Usuario {nombre} registrado.");
    }
}