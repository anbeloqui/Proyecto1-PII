using Discord.WebSocket;
using ProyectoPII.Interfaces;
using FachadaProyecto = ProyectoPII.Fachada.Fachada;
using ProyectoPII.Modelos;

namespace ProyectoPII.Bot.Comandos;

/// <summary>
/// Implementa el comando <c>!recomendar</c>, encargado de obtener
/// recomendaciones para el usuario que ejecutó el comando.
/// </summary>
/// <remarks>
/// <para>
/// Este comando obtiene automáticamente el usuario desde Discord y solicita
/// las recomendaciones a la Fachada.
/// </para>
/// <para>
/// Opcionalmente puede recibir un filtro para recomendar únicamente
/// canciones o películas. Si no se especifica ningún filtro, se muestran
/// recomendaciones de todos los tipos disponibles.
/// </para>
/// <para>
/// No contiene lógica de recomendación ni interactúa directamente con el
/// motor del sistema; únicamente delega la operación a la Fachada y adapta
/// el resultado para su presentación en Discord.
/// </para>
/// </remarks>
public class ComandoRecomendar : IComandoDiscord
{
    /// <summary>
    /// Fachada utilizada para acceder a la lógica del sistema.
    /// </summary>
    private readonly FachadaProyecto fachada;

    /// <summary>
    /// Obtiene el nombre utilizado para invocar este comando.
    /// </summary>
    public string Nombre => "!recomendar";

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="ComandoRecomendar"/>.
    /// </summary>
    /// <param name="fachada">
    /// Fachada utilizada para generar recomendaciones.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Se lanza cuando <paramref name="fachada"/> es <see langword="null"/>.
    /// </exception>
    public ComandoRecomendar(FachadaProyecto fachada)
    {
        ArgumentNullException.ThrowIfNull(fachada);

        this.fachada = fachada;
    }

    /// <summary>
    /// Obtiene recomendaciones para el usuario que ejecutó el comando.
    /// </summary>
    /// <param name="message">
    /// Mensaje recibido desde Discord.
    /// </param>
    /// <param name="argumentos">
    /// Argumentos enviados junto al comando.
    /// Opcionalmente puede indicarse una estrategia de recomendación
    /// (<c>preferencias</c>, <c>historial</c>, <c>popularidad</c>,
    /// <c>similares</c> o <c>contenido</c>) y un tipo de contenido
    /// (<c>canciones</c> o <c>peliculas</c>).
    /// Si no se especifican argumentos, se utiliza la estrategia por preferencias
    /// y se muestran recomendaciones de todos los tipos disponibles.
    /// </param>
    /// <returns>
    /// Una tarea asincrónica que representa la ejecución del comando.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Se lanza cuando <paramref name="message"/> o
    /// <paramref name="argumentos"/> son <see langword="null"/>.
    /// </exception>
    public async Task EjecutarAsync(SocketMessage message, string[] argumentos)
    {
        ArgumentNullException.ThrowIfNull(message);
        ArgumentNullException.ThrowIfNull(argumentos);

        string nombreUsuario = message.Author.Username;

        OpcionesRecomendacion opciones = ObtenerOpciones(argumentos);

        if (!OpcionesValidas(opciones))
        {
            await message.Channel.SendMessageAsync(
                "Uso: !recomendar [estrategia] [tipo]\n" +
                "Estrategias: preferencias, historial, popularidad, similares, contenido.\n" +
                "Tipos: canciones, peliculas.");
            return;
        }

        List<IRecomendable> recomendaciones =
            this.fachada.Recomendar(nombreUsuario, opciones.Estrategia);

        List<IRecomendable> recomendacionesFiltradas =
            FiltrarRecomendaciones(recomendaciones, opciones.Tipo);

        if (recomendacionesFiltradas.Count == 0)
        {
            await message.Channel.SendMessageAsync(
                "No se encontraron recomendaciones para esa combinación.");
            return;
        }

        string respuesta =
            ObtenerTitulo(opciones.Estrategia) +
            Environment.NewLine +
            string.Join(
                Environment.NewLine,
                recomendacionesFiltradas.Select(FormatearRecomendacion));

        await message.Channel.SendMessageAsync(respuesta);
    }

    /// <summary>
    /// Genera el texto visible de una recomendación para Discord.
    /// </summary>
    /// <param name="item">Elemento recomendable que se desea mostrar.</param>
    /// <returns>Texto formateado con tipo, identificador y nombre del elemento.</returns>
    private static string FormatearRecomendacion(IRecomendable item)
    {
        return item switch
        {
            Cancion => $"🎵 [{item.Id}] {item.Nombre}",
            Pelicula => $"🎬 [{item.Id}] {item.Nombre}",
            _ => $"• [{item.Id}] {item.Nombre}"
        };
    }

    /// <summary>
    /// Filtra y limita las recomendaciones según el tipo de contenido solicitado.
    /// </summary>
    /// <param name="recomendaciones">Recomendaciones generadas por la Fachada.</param>
    /// <param name="tipo">Tipo de contenido solicitado, o <see langword="null"/> si se desean todos los tipos.</param>
    /// <returns>Lista filtrada y limitada de recomendaciones.</returns>
    private static List<IRecomendable> FiltrarRecomendaciones(
        List<IRecomendable> recomendaciones,
        string? tipo)
    {
        return tipo switch
        {
            "canciones" => recomendaciones
                .Where(item => item is Cancion)
                .Take(10)
                .ToList(),

            "peliculas" => recomendaciones
                .Where(item => item is Pelicula)
                .Take(10)
                .ToList(),

            _ => recomendaciones
                .Where(item => item is Cancion)
                .Take(10)
                .Concat(
                    recomendaciones
                        .Where(item => item is Pelicula)
                        .Take(10))
                .ToList()
        };
    }

    /// <summary>
    /// Interpreta los argumentos del comando y obtiene la estrategia y el tipo de contenido solicitado.
    /// </summary>
    /// <param name="argumentos">Argumentos recibidos por el comando.</param>
    /// <returns>Opciones de recomendación interpretadas desde los argumentos.</returns>
    private static OpcionesRecomendacion ObtenerOpciones(string[] argumentos)
    {
        OpcionesRecomendacion opciones = new();

        foreach (string argumento in argumentos)
        {
            string valor = argumento.Trim().ToLowerInvariant();

            switch (valor)
            {
                case "preferencias":
                    opciones.Estrategia = "preferencias";
                    break;

                case "historial":
                    opciones.Estrategia = "historial";
                    break;

                case "popularidad":
                case "populares":
                    opciones.Estrategia = "popularidad";
                    break;

                case "similares":
                    opciones.Estrategia = "similares";
                    break;

                case "contenido":
                    opciones.Estrategia = "contenido";
                    break;

                case "cancion":
                case "canciones":
                case "musica":
                case "música":
                    opciones.Tipo = "canciones";
                    break;

                case "pelicula":
                case "peliculas":
                case "cine":
                    opciones.Tipo = "peliculas";
                    break;

                default:
                    opciones.Estrategia = "invalida";
                    break;
            }
        }

        return opciones;
    }

    /// <summary>
    /// Indica si las opciones interpretadas son válidas para el comando.
    /// </summary>
    /// <param name="opciones">Opciones de recomendación a validar.</param>
    /// <returns><see langword="true"/> si las opciones son válidas; de lo contrario, <see langword="false"/>.</returns>
    private static bool OpcionesValidas(OpcionesRecomendacion opciones)
    {
        return opciones.Estrategia != "invalida";
    }

    /// <summary>
    /// Representa las opciones interpretadas desde los argumentos del comando.
    /// </summary>
    private class OpcionesRecomendacion
    {
        /// <summary>
        /// Estrategia de recomendación solicitada.
        /// </summary>
        public string Estrategia { get; set; } = "preferencias";

        /// <summary>
        /// Tipo de contenido solicitado. Puede ser <c>canciones</c>,
        /// <c>peliculas</c> o <see langword="null"/>.
        /// </summary>
        public string? Tipo { get; set; }
    }

    /// <summary>
    /// Obtiene el título que se mostrará en Discord según la estrategia utilizada.
    /// </summary>
    /// <param name="estrategia">Estrategia de recomendación aplicada.</param>
    /// <returns>Título del mensaje de recomendaciones.</returns>
    private static string ObtenerTitulo(string estrategia)
    {
        return estrategia switch
        {
            "preferencias" => "**Recomendaciones según tus preferencias:**",
            "historial" => "**Recomendaciones según tu historial:**",
            "popularidad" => "**Recomendaciones por popularidad:**",
            "similares" => "**Recomendaciones por usuarios similares:**",
            "contenido" => "**Recomendaciones por contenido relacionado:**",
            _ => "**Recomendaciones para ti:**"
        };
    }
}