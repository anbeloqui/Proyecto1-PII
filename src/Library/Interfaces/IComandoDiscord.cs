using Discord.WebSocket;

namespace ProyectoPII.Interfaces;
/// <summary>
/// Define el contrato común que deben cumplir todos los comandos ejecutados por el bot de Discord.
/// </summary>
/// <remarks>
/// <para>
/// Esta interfaz pertenece a la capa de comunicación externa del sistema.
/// Su objetivo es permitir que el bot delegue la ejecución de comandos concretos sin conocer
/// sus detalles internos.
/// </para>
/// <para>
/// Cada comando debe implementar esta interfaz y utilizar la Fachada como único punto de acceso
/// a la lógica del sistema.
/// </para>
/// <para>
/// Precondiciones:
/// <list type="bullet">
/// <item><description>El mensaje recibido no debe ser <see langword="null"/>.</description></item>
/// <item><description>El arreglo de argumentos no debe ser <see langword="null"/>.</description></item>
/// </list>
/// </para>
/// <para>
/// Postcondiciones:
/// <list type="bullet">
/// <item><description>El comando ejecuta su acción o informa al usuario si la operación no puede completarse.</description></item>
/// <item><description>La ejecución no debe modificar directamente el motor de recomendación ni acceder a clases internas del dominio.</description></item>
/// </list>
/// </para>
/// </remarks>
public interface IComandoDiscord
{
    /// <summary>
    /// Obtiene el nombre textual que identifica al comando.
    /// </summary>
    /// <remarks>
    /// Este valor es utilizado por <c>BotCore</c> para buscar el comando correspondiente
    /// a partir del mensaje recibido en Discord.
    /// </remarks>
    /// <value>
    /// Nombre del comando sin el prefijo utilizado en Discord.
    /// </value>
    string Nombre { get; }

    /// <summary>
    /// Ejecuta la acción asociada al comando.
    /// </summary>
    /// <param name="message">
    /// Mensaje de Discord que originó la ejecución del comando.
    /// </param>
    /// <param name="argumentos">
    /// Argumentos recibidos junto con el comando, separados previamente por la capa que procesa el mensaje.
    /// </param>
    /// <returns>
    /// Una tarea asincrónica que representa la ejecución del comando.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Se lanza si <paramref name="message"/> o <paramref name="argumentos"/> son <see langword="null"/>.
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
    /// <item><description>El comando responde al usuario cuando corresponde.</description></item>
    /// <item><description>La lógica del sistema se invoca únicamente mediante la Fachada.</description></item>
    /// </list>
    /// </remarks>
    Task EjecutarAsync(SocketMessage message, string[] argumentos);
}