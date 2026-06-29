using ProyectoPII.Interfaces;

namespace ProyectoPII.Ordenadores;

/// <summary>
/// Ordena las recomendaciones alfabéticamente por nombre.
/// </summary>
public class OrdenadorPorNombre : IOrdenadorRecomendacion
{
    public List<IRecomendable> Ordenar(List<IRecomendable> items)
    {
        return items
            .OrderBy(item => item.Nombre)
            .ToList();
    }
}