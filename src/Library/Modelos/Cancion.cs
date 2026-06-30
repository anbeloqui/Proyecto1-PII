using ProyectoPII.Interfaces;

namespace ProyectoPII.Modelos;

// ---------------------------------------------------------
// CLASE CANCION
// ---------------------------------------------------------
// Representa una canción dentro del sistema.
//
// Implementa IRecomendable porque una canción puede ser
// recomendada por el sistema.
//
// Sus atributos, como "rock", "pop" o "clasica",
// se usan para compararlos con las preferencias del usuario.
// ---------------------------------------------------------

/// <summary>
/// Representa una canción dentro del catálogo de elementos recomendables.
/// </summary>
public class Cancion : IRecomendable
{
    /// <summary>
    /// Identificador único de la canción.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nombre de la canción.
    /// </summary>
    public string Nombre { get; set; } = "";

    /// <summary>
    /// Nombre del artista que interpreta la canción.
    /// </summary>
    public string Artista { get; set; } = "";

    /// <summary>
    /// Lista de atributos utilizados por el sistema de recomendaciones.
    /// </summary>
    public List<string> Atributos { get; set; } = new();
}