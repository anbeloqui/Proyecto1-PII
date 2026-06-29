using ProyectoPII.Interfaces;
using ProyectoPII.Modelos;

namespace ProyectoPII.Filtros;

/// <summary>
/// Filtra los elementos que el usuario ya consumió.
/// </summary>
public class FiltroNoRepetirConsumidos : IFiltroRecomendacion
{
    private Usuario usuario;

    public FiltroNoRepetirConsumidos(Usuario usuario)
    {
        this.usuario = usuario;
    }

    public List<IRecomendable> Filtrar(List<IRecomendable> items)
    {
        List<int> consumidos = usuario.Historial.ObtenerItemsConsumidos();

        return items
            .Where(item => !consumidos.Contains(item.Id))
            .ToList();
    }
}