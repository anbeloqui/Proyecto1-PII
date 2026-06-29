using ProyectoPII.Interfaces;

namespace ProyectoPII.Filtros;

/// <summary>
/// Aplica una cadena de filtros sobre una lista de recomendaciones.
/// </summary>
public class FilterChain : IFiltroRecomendacion
{
    private List<IFiltroRecomendacion> filtros;

    public FilterChain()
    {
        filtros = new List<IFiltroRecomendacion>();
    }

    public void AgregarFiltro(IFiltroRecomendacion filtro)
    {
        filtros.Add(filtro);
    }

    public List<IRecomendable> Filtrar(List<IRecomendable> items)
    {
        List<IRecomendable> resultado = items;

        foreach (IFiltroRecomendacion filtro in filtros)
        {
            resultado = filtro.Filtrar(resultado);
        }

        return resultado;
    }
}