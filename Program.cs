using ProyectoPII.Bot;

/// <summary>
/// Punto de entrada principal de la aplicación.
/// Inicia el bot de Discord usando el token configurado
/// en la variable de entorno DISCORD_TOKEN.
/// </summary>
string? token = Environment.GetEnvironmentVariable("DISCORD_TOKEN");

if (string.IsNullOrWhiteSpace(token))
{
    Console.WriteLine("No se encontró la variable de entorno DISCORD_TOKEN.");
    return;
}

DiscordBot bot = new DiscordBot();
await bot.IniciarAsync(token);