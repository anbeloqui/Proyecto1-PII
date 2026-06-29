using ProyectoPII.Interfaces;

namespace ProyectoPII.Interfaces;

/// <summary>
/// Define el comportamiento común de los filtros de recomendación.
/// </summary>
public interface IFiltroRecomendacion
{
    /// <summary>
    /// Filtra una lista de elementos recomendables.
    /// </summary>
    List<IRecomendable> Filtrar(List<IRecomendable> items);
}