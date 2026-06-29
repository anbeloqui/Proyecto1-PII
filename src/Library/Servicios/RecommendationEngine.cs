using ProyectoPII.Interfaces;
using ProyectoPII.Modelos;
using ProyectoPII.Estrategias;
using ProyectoPII.Filtros;
using ProyectoPII.Ordenadores;

namespace ProyectoPII.Servicios;

/// <summary>
/// Motor de recomendaciones que coordina estrategia, filtros y ranking.
/// </summary>
public class RecommendationEngine
{
    private IEstrategiaRecomendacion estrategia;
    private IFiltroRecomendacion filtros;
    private IRanker ranker;

    public RecommendationEngine(IEstrategiaRecomendacion estrategia)
    {
        this.estrategia = estrategia;
        filtros = new FilterChain();
        ranker = new PreferenceRanker();
    }

    public RecommendationEngine(
        IEstrategiaRecomendacion estrategia,
        IFiltroRecomendacion filtros,
        IRanker ranker)
    {
        this.estrategia = estrategia;
        this.filtros = filtros;
        this.ranker = ranker;
    }

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