namespace ProyectoPII.Interfaces;

// ---------------------------------------------------------
// INTERFAZ IRECOMENDABLE
// ---------------------------------------------------------
// Define qué información mínima debe tener cualquier elemento
// que pueda ser recomendado por el sistema.
//
// Gracias a esta interfaz, el recomendador no depende
// directamente de una clase específica como Cancion.
// En el futuro también podría recomendar películas,
// podcasts u otros contenidos.
// ---------------------------------------------------------

/// <summary>
/// Define el contrato que debe cumplir cualquier elemento que pueda ser
/// recomendado por el sistema.
/// </summary>
public interface IRecomendable
{
    /// <summary>
    /// Obtiene el identificador único del elemento.
    /// </summary>
    int Id { get; }

    /// <summary>
    /// Obtiene el nombre del elemento recomendable.
    /// </summary>
    string Nombre { get; }

    /// <summary>
    /// Obtiene la lista de atributos utilizados por el motor de recomendaciones
    /// para comparar y clasificar elementos.
    /// </summary>
    List<string> Atributos { get; }
}