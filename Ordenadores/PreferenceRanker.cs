using ProyectoPII.Interfaces;

namespace ProyectoPII.Ordenadores;

/// <summary>
/// Ordena los elementos recomendables según la cantidad de
/// atributos que poseen.
/// </summary>
public class PreferenceRanker : IRanker
{
    /// <summary>
    /// Ordena una lista de elementos de mayor a menor cantidad
    /// de atributos.
    /// </summary>
    /// <param name="items">Elementos a ordenar.</param>
    /// <returns>Lista ordenada de elementos.</returns>
    public List<IRecomendable> Ordenar(List<IRecomendable> items)
    {
        return items
            .OrderByDescending(item => item.Atributos.Count)
            .ToList();
    }
}