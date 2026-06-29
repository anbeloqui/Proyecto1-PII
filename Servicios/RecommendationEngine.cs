using ProyectoPII.Interfaces;
using ProyectoPII.Modelos;
using ProyectoPII.Estrategias;

namespace ProyectoPII.Servicios;

/// <summary>
/// Motor de recomendaciones que coordina la estrategia principal.
/// </summary>
public class RecommendationEngine
{
    private IEstrategiaRecomendacion estrategia;

    public RecommendationEngine(IEstrategiaRecomendacion estrategia)
    {
        this.estrategia = estrategia;
    }

    public List<IRecomendable> Recomendar(
        Usuario usuario,
        List<IRecomendable> items)
    {
        return estrategia.Recomendar(usuario, items);
    }
}