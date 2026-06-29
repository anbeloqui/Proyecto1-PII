using ProyectoPII.Interfaces;

namespace ProyectoPII.Interfaces;

/// <summary>
/// Define el comportamiento común de los componentes encargados
/// de ordenar una lista de recomendaciones.
/// </summary>
public interface IRanker
{
    /// <summary>
    /// Ordena una lista de elementos recomendables según un criterio.
    /// </summary>
    /// <param name="items">Elementos a ordenar.</param>
    /// <returns>Lista de elementos ordenados.</returns>
    List<IRecomendable> Ordenar(List<IRecomendable> items);
}