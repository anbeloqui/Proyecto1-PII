using System.Text.Json;
using ProyectoPII.Bot;

/// <summary>
/// Punto de entrada principal de la aplicación.
/// </summary>
/// <remarks>
/// Inicializa el bot de Discord utilizando el token almacenado en el archivo
/// <c>secrets.json</c>, ubicado fuera del repositorio.
///
/// Ruta esperada:
/// <c>~/.microsoft/usersecrets/RecommenderBot/secrets.json</c>,
/// donde <c>~</c> representa el directorio personal del usuario.
///
/// Precondiciones:
/// - Debe existir el archivo <c>secrets.json</c>.
/// - El archivo debe contener la clave <c>DiscordToken</c>.
///
/// Postcondiciones:
/// - Si el token existe, el bot se inicia correctamente.
/// - Si el token no existe o el archivo es inválido, la aplicación informa el
///   problema y finaliza sin exponer credenciales.
/// </remarks>

string? token = ObtenerTokenDiscord();

if (string.IsNullOrWhiteSpace(token))
{
    Console.WriteLine("No se pudo obtener el token de Discord.");
    return;
}

DiscordBot bot = new DiscordBot();
await bot.IniciarAsync(token);

/// <summary>
/// Obtiene el token de Discord desde el archivo <c>secrets.json</c>.
/// </summary>
/// <returns>
/// El token almacenado o <see langword="null"/> si no pudo obtenerse.
/// </returns>
/// <remarks>
/// Precondiciones:
/// - El archivo debe existir en la ruta esperada.
/// - El contenido debe ser un JSON válido.
/// - Debe existir la clave <c>DiscordToken</c>.
///
/// Postcondiciones:
/// - Si el archivo y la clave existen, se devuelve el token.
/// - Si ocurre un error, se devuelve <see langword="null"/>.
/// </remarks>
static string? ObtenerTokenDiscord()
{
    try
    {
        string ruta = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            ".microsoft",
            "usersecrets",
            "RecommenderBot",
            "secrets.json");

        if (!File.Exists(ruta))
        {
            return null;
        }

        string contenido = File.ReadAllText(ruta);

        JsonDocument documento = JsonDocument.Parse(contenido);

        return documento.RootElement
            .GetProperty("DiscordToken")
            .GetString();
    }
    catch
    {
        return null;
    }
}