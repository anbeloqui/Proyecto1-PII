using Discord;
using Discord.WebSocket;
using ProyectoPII.Bot.Comandos;
using FachadaProyecto = ProyectoPII.Fachada.Fachada;
using ProyectoPII.DatosIniciales;

namespace ProyectoPII.Bot;

/// <summary>
/// Bot de Discord encargado de conectar con Discord y delegar los mensajes recibidos
/// al núcleo de comandos del sistema.
/// </summary>
/// <remarks>
/// <para>
/// Esta clase pertenece a la capa externa de comunicación.
/// Su responsabilidad es configurar el cliente de Discord, iniciar la conexión
/// y enviar los mensajes recibidos a <see cref="BotCore"/>.
/// </para>
/// <para>
/// No interpreta comandos directamente, no contiene lógica de negocio y no accede
/// al motor de recomendación, estrategias, filtros, rankers ni modelos internos.
/// </para>
/// <para>
/// Precondiciones:
/// <list type="bullet">
/// <item><description>El bot debe iniciarse con un token válido.</description></item>
/// <item><description>La Fachada debe poder inicializarse correctamente.</description></item>
/// </list>
/// </para>
/// <para>
/// Postcondiciones:
/// <list type="bullet">
/// <item><description>El bot queda conectado a Discord.</description></item>
/// <item><description>Los mensajes recibidos son delegados a <see cref="BotCore"/>.</description></item>
/// </list>
/// </para>
/// </remarks>
public class DiscordBot
{
    /// <summary>
    /// Cliente utilizado para conectarse con Discord.
    /// </summary>
    private readonly DiscordSocketClient client;

    /// <summary>
    /// Fachada utilizada por los comandos para acceder a la lógica del sistema.
    /// </summary>
    private readonly FachadaProyecto fachada;

    /// <summary>
    /// Núcleo encargado de registrar y ejecutar comandos.
    /// </summary>
    private readonly BotCore botCore;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="DiscordBot"/>.
    /// </summary>
    /// <remarks>
    /// Precondiciones:
    /// <list type="bullet">
    /// <item><description>No requiere parámetros externos.</description></item>
    /// </list>
    ///
    /// Postcondiciones:
    /// <list type="bullet">
    /// /// <item><description>Se crea una instancia de la Fachada.</description></item>
    /// <item><description>Se cargan las canciones iniciales del catálogo.</description></item>
    /// <item><description>Se configura el cliente de Discord.</description></item>
    /// <item><description>Se inicializa el núcleo de comandos.</description></item>
    /// <item><description>Se registran los comandos disponibles.</description></item>
    /// </list>
    /// </remarks>
    public DiscordBot()
    {
        this.fachada = new FachadaProyecto();

        CancionesIniciales.Cargar(this.fachada);
        PeliculasIniciales.Cargar(this.fachada);

        this.client = new DiscordSocketClient(new DiscordSocketConfig
        {
            GatewayIntents =
                GatewayIntents.Guilds |
                GatewayIntents.GuildMessages |
                GatewayIntents.MessageContent
        });

        this.botCore = new BotCore();
        this.RegistrarComandos();
    }
    /// <summary>
    /// Inicia sesión en Discord y conecta el bot.
    /// </summary>
    /// <param name="token">
    /// Token de autenticación del bot.
    /// </param>
    /// <returns>
    /// Una tarea asincrónica que representa la ejecución permanente del bot.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Se lanza cuando <paramref name="token"/> es <see langword="null"/>,
    /// vacío o contiene únicamente espacios.
    /// </exception>
    /// <remarks>
    /// Precondiciones:
    /// <list type="bullet">
    /// <item><description><paramref name="token"/> debe contener un token válido de Discord.</description></item>
    /// </list>
    ///
    /// Postcondiciones:
    /// <list type="bullet">
    /// <item><description>El bot inicia sesión en Discord.</description></item>
    /// <item><description>El bot queda escuchando mensajes entrantes.</description></item>
    /// </list>
    /// </remarks>
    public async Task IniciarAsync(string token)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(token);

        this.client.Log += this.LogAsync;
        this.client.MessageReceived += this.MessageReceivedAsync;

        await this.client.LoginAsync(TokenType.Bot, token);
        await this.client.StartAsync();

        await Task.Delay(-1);
    }

    /// <summary>
    /// Registra los comandos disponibles en el núcleo del bot.
    /// </summary>
    /// <remarks>
    /// Precondiciones:
    /// <list type="bullet">
    /// <item><description><see cref="botCore"/> debe estar inicializado.</description></item>
    /// <item><description><see cref="fachada"/> debe estar inicializada.</description></item>
    /// </list>
    ///
    /// Postcondiciones:
    /// <list type="bullet">
    /// <item><description>Los comandos quedan disponibles para ser ejecutados desde Discord.</description></item>
    /// </list>
    /// </remarks>
    private void RegistrarComandos()
    {
        this.botCore.RegistrarComando(new ComandoPing());
        this.botCore.RegistrarComando(new ComandoRegistrar(this.fachada));
        this.botCore.RegistrarComando(new ComandoPreferencia(this.fachada));
        this.botCore.RegistrarComando(new ComandoRecomendar(this.fachada));
        this.botCore.RegistrarComando(new ComandoHistorial(this.fachada));
        this.botCore.RegistrarComando(new ComandoLike(this.fachada));
        this.botCore.RegistrarComando(new ComandoDislike(this.fachada));
        this.botCore.RegistrarComando(new ComandoGuardar(this.fachada));
    }

    /// <summary>
    /// Recibe un mensaje desde Discord y lo delega al núcleo de comandos.
    /// </summary>
    /// <param name="message">
    /// Mensaje recibido desde Discord.
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
    /// <item><description>El mensaje es delegado a <see cref="BotCore"/>.</description></item>
    /// <item><description>Esta clase no interpreta el comando directamente.</description></item>
    /// </list>
    /// </remarks>
    private async Task MessageReceivedAsync(SocketMessage message)
    {
        ArgumentNullException.ThrowIfNull(message);

        await this.botCore.ProcesarMensajeAsync(message);
    }

    /// <summary>
    /// Registra en consola los mensajes de log generados por Discord.Net.
    /// </summary>
    /// <param name="log">
    /// Mensaje de log recibido desde Discord.Net.
    /// </param>
    /// <returns>
    /// Una tarea completada.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Se lanza cuando <paramref name="log"/> es <see langword="null"/>.
    /// </exception>
    /// <remarks>
    /// Precondiciones:
    /// <list type="bullet">
    /// <item><description><paramref name="log"/> debe ser distinto de <see langword="null"/>.</description></item>
    /// </list>
    ///
    /// Postcondiciones:
    /// <list type="bullet">
    /// <item><description>El contenido del log se muestra en consola.</description></item>
    /// </list>
    /// </remarks>
    private Task LogAsync(LogMessage log)
    {
        Console.WriteLine(log.ToString());
        return Task.CompletedTask;
    }
}