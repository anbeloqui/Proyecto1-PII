using Discord.WebSocket;
using ProyectoPII.Excepciones;
using ProyectoPII.Interfaces;

namespace ProyectoPII.Bot;

/// <summary>
/// Coordina el registro y la ejecución de los comandos del bot de Discord.
/// </summary>
/// <remarks>
/// <para>
/// Esta clase actúa como intermediaria entre <see cref="DiscordBot"/> y los
/// comandos concretos del sistema.
/// </para>
/// <para>
/// Su responsabilidad consiste en mantener el conjunto de comandos disponibles,
/// identificar cuál corresponde ejecutar a partir del mensaje recibido y
/// delegar la ejecución al objeto adecuado.
/// </para>
/// <para>
/// No contiene lógica de negocio ni accede directamente al motor de
/// recomendación. Toda funcionalidad específica queda encapsulada en las
/// implementaciones de <see cref="IComandoDiscord"/>.
/// </para>
/// <para>
/// Precondiciones:
/// <list type="bullet">
/// <item><description>Los comandos registrados deben implementar <see cref="IComandoDiscord"/>.</description></item>
/// </list>
/// </para>
/// <para>
/// Postcondiciones:
/// <list type="bullet">
/// <item><description>Cada comando queda asociado a su nombre para futuras ejecuciones.</description></item>
/// <item><description>Si un mensaje corresponde a un comando registrado, este será ejecutado.</description></item>
/// <item><description>Las excepciones de dominio se informan al usuario sin detener el bot.</description></item>
/// </list>
/// </para>
/// </remarks>
public class BotCore
{
    /// <summary>
    /// Colección de comandos registrados, indexados por su nombre.
    /// </summary>
    private readonly Dictionary<string, IComandoDiscord> comandos;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="BotCore"/>.
    /// </summary>
    /// <remarks>
    /// Postcondiciones:
    /// <list type="bullet">
    /// <item><description>Se crea una colección vacía de comandos.</description></item>
    /// </list>
    /// </remarks>
    public BotCore()
    {
        this.comandos = new Dictionary<string, IComandoDiscord>();
    }

    /// <summary>
    /// Registra un nuevo comando para que pueda ser ejecutado por el bot.
    /// </summary>
    /// <param name="comando">
    /// Comando que se desea registrar.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Se lanza cuando <paramref name="comando"/> es <see langword="null"/>.
    /// </exception>
    /// <remarks>
    /// Precondiciones:
    /// <list type="bullet">
    /// <item><description><paramref name="comando"/> debe ser distinto de <see langword="null"/>.</description></item>
    /// </list>
    ///
    /// Postcondiciones:
    /// <list type="bullet">
    /// <item><description>El comando queda asociado a su nombre.</description></item>
    /// <item><description>Si ya existía un comando con ese nombre, será reemplazado.</description></item>
    /// </list>
    /// </remarks>
    public void RegistrarComando(IComandoDiscord comando)
    {
        ArgumentNullException.ThrowIfNull(comando);

        this.comandos[comando.Nombre.ToLower()] = comando;
    }

    /// <summary>
    /// Procesa un mensaje recibido desde Discord e intenta ejecutar el comando correspondiente.
    /// </summary>
    /// <param name="message">
    /// Mensaje recibido por el bot.
    /// </param>
    /// <returns>
    /// Una tarea asincrónica que representa el procesamiento del mensaje.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Se lanza cuando <paramref name="message"/> es <see langword="null"/>.
    /// </exception>
    /// <remarks>
    /// Precondiciones:
    /// <list type="bullet">
    /// <item><description><paramref name="message"/> debe ser distinto de <see langword="null"/>.</description></item>
    /// </list>
    ///
    /// Postcondiciones:
    /// <list type="bullet">
    /// <item><description>Si el mensaje proviene de otro bot, no se realiza ninguna acción.</description></item>
    /// <item><description>Si el comando existe, se delega su ejecución.</description></item>
    /// <item><description>Si el comando no existe, el método finaliza sin producir cambios.</description></item>
    /// <item><description>Si ocurre una excepción de dominio, se informa al usuario por Discord.</description></item>
    /// </list>
    /// </remarks>
    public async Task ProcesarMensajeAsync(SocketMessage message)
    {
        ArgumentNullException.ThrowIfNull(message);

        if (message.Author.IsBot)
        {
            return;
        }

        string[] partes = message.Content.Split(
            ' ',
            StringSplitOptions.RemoveEmptyEntries);

        if (partes.Length == 0)
        {
            return;
        }

        string nombreComando = partes[0].ToLower();
        string[] argumentos = partes.Skip(1).ToArray();

        if (this.comandos.TryGetValue(nombreComando, out IComandoDiscord? comando))
        {
            try
            {
                await comando.EjecutarAsync(message, argumentos);
            }
            catch (ExcepcionUsuarioNoEncontrado)
            {
                await message.Channel.SendMessageAsync(
                    "No estás registrado. Usá !registrar antes de continuar.");
            }
            catch (ExcepcionUsuarioYaExiste)
            {
                await message.Channel.SendMessageAsync(
                    "Ya estás registrado en el sistema.");
            }
            catch (ExcepcionDatoInvalido ex)
            {
                await message.Channel.SendMessageAsync(ex.Message);
            }
            catch (ExcepcionDominio ex)
            {
                await message.Channel.SendMessageAsync(ex.Message);
            }
        }
    }
}