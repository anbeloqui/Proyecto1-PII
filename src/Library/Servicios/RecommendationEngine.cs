using ProyectoPII.Interfaces;
using ProyectoPII.Modelos;
using ProyectoPII.Filtros;
using ProyectoPII.Ordenadores;

namespace ProyectoPII.Servicios;

/// <summary>
/// Motor de recomendaciones que coordina el pipeline:
/// estrategia, filtros y ranking.
/// 
/// Aplica el patrón Strategy mediante IEstrategiaRecomendacion
/// y depende de abstracciones para cumplir con el principio de inversión
/// de dependencias.
/// </summary>
public class RecommendationEngine
{
    private IEstrategiaRecomendacion estrategia;
    private IFiltroRecomendacion filtros;
    private IRanker ranker;

    /// <summary>
    /// Inicializa el motor de recomendaciones con una estrategia específica,
    /// usando una cadena de filtros y un ranker por preferencias por defecto.
    /// </summary>
    /// <param name="estrategia">Estrategia de recomendación a utilizar.</param>
    public RecommendationEngine(IEstrategiaRecomendacion estrategia)
    {
        this.estrategia = estrategia;
        filtros = new FilterChain();
        ranker = new PreferenceRanker();
    }

    /// <summary>
    /// Inicializa el motor de recomendaciones con una estrategia, filtros y ranker personalizados.
    /// </summary>
    /// <param name="estrategia">Estrategia de recomendación a utilizar.</param>
    /// <param name="filtros">Filtro o cadena de filtros aplicada a las recomendaciones.</param>
    /// <param name="ranker">Componente encargado de ordenar las recomendaciones.</param>
    public RecommendationEngine(
        IEstrategiaRecomendacion estrategia,
        IFiltroRecomendacion filtros,
        IRanker ranker)
    {
        this.estrategia = estrategia;
        this.filtros = filtros;
        this.ranker = ranker;
    }


    /// <summary>
    /// Genera una lista de recomendaciones para un usuario a partir del catálogo disponible.
    /// </summary>
    /// <param name="usuario">Usuario para el cual se generan las recomendaciones.</param>
    /// <param name="items">Elementos disponibles para recomendar.</param>
    /// <returns>Lista de elementos recomendados.</returns>
    public List<IRecomendable> Recomendar(
        Usuario usuario,
        List<IRecomendable> items)
    {
        List<IRecomendable> recomendados =
            estrategia.Recomendar(usuario, items);

        List<IRecomendable> filtrados =
            filtros.Filtrar(recomendados);

        return ranker.Ordenar(filtrados);
    }
}