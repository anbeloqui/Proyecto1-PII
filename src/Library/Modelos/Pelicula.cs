using ProyectoPII.Interfaces;

namespace ProyectoPII.Modelos;

// ---------------------------------------------------------
// CLASE PELICULA
// ---------------------------------------------------------
// Representa una película dentro del sistema.
//
// Implementa IRecomendable porque una película puede ser
// recomendada por el sistema.
//
// Sus atributos, como "accion", "drama" o "ciencia ficcion",
// se usan para compararlos con las preferencias del usuario.
// ---------------------------------------------------------

/// <summary>
/// Representa una película dentro del catálogo de elementos recomendables.
/// </summary>
public class Pelicula : IRecomendable
{
    /// <summary>
    /// Identificador único de la película.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nombre de la película.
    /// </summary>
    public string Nombre { get; set; } = "";

    /// <summary>
    /// Nombre del director de la película.
    /// </summary>
    public string Director { get; set; } = "";

    /// <summary>
    /// Lista de atributos utilizados por el sistema de recomendaciones.
    /// </summary>
    public List<string> Atributos { get; set; } = new();
}