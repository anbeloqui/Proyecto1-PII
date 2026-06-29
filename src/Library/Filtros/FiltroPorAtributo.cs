using ProyectoPII.Interfaces;

namespace ProyectoPII.Filtros;

/// <summary>
/// Filtra recomendaciones según un atributo específico.
/// </summary>
public class FiltroPorAtributo : IFiltroRecomendacion
{
    private string atributo;

    public FiltroPorAtributo(string atributo)
    {
        this.atributo = atributo;
    }

    public List<IRecomendable> Filtrar(List<IRecomendable> items)
    {
        return items
            .Where(item => item.Atributos.Contains(atributo))
            .ToList();
    }
}