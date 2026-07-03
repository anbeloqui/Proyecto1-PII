using ProyectoPII.Bot;

/// <summary>
/// Punto de entrada principal de la aplicación.
/// </summary>
/// <remarks>
/// Este archivo inicializa el bot de Discord usando el token configurado
/// en la variable de entorno <c>DISCORD_TOKEN</c>.
///
/// Precondiciones:
/// - Debe existir una variable de entorno llamada <c>DISCORD_TOKEN</c>.
/// - El valor de dicha variable debe corresponder a un token válido.
///
/// Postcondiciones:
/// - Si el token existe, se crea e inicia el bot.
/// - Si el token no existe, se informa el problema por consola y la
///   aplicación finaliza sin exponer credenciales en el código fuente.
///
/// Esta decisión evita guardar secretos dentro del repositorio y mantiene
/// separada la configuración de la lógica del programa.
/// </remarks>

string? token = Environment.GetEnvironmentVariable("DISCORD_TOKEN");

if (string.IsNullOrWhiteSpace(token))
{
    Console.WriteLine("No se encontró la variable de entorno DISCORD_TOKEN.");
    return;
}

DiscordBot bot = new DiscordBot();
await bot.IniciarAsync(token);