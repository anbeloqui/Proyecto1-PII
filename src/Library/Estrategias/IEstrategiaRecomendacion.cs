using ProyectoPII.Interfaces;
using ProyectoPII.Modelos;

namespace ProyectoPII.Estrategias;

/// <summary>
/// Define el comportamiento común de las estrategias de recomendación.
/// </summary>
public interface IEstrategiaRecomendacion
{
    /// <summary>
    /// Genera recomendaciones para un usuario a partir de una lista de elementos.
    /// </summary>
    /// <param name="usuario">Usuario para el que se generan recomendaciones.</param>
    /// <param name="items">Elementos disponibles para recomendar.</param>
    /// <returns>Lista de elementos recomendados.</returns>
    List<IRecomendable> Recomendar(
        Usuario usuario,
        List<IRecomendable> catalogo);
}